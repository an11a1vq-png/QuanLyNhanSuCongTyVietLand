using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VietLandHR.DAL;
using VietLandHR.DTOs;
using VietLandHR.Utils;
using VietLandHR.GUI.Helpers;

namespace VietLandHR.BLL
{
    public class RegistrationRequestBLL
    {
        private readonly RegistrationRequestDAL _dal = new RegistrationRequestDAL();

        public Task<List<RegistrationRequestDTO>> GetPendingAsync() => _dal.GetPendingAsync();

        public async Task<(bool Success, string Message)> SubmitRegistrationAsync(
            string email, string fullName, string? phone, DateTime? birthDate)
        {
            try
            {
                var req = new RegistrationRequestDTO
                {
                    FullName = fullName,
                    Email = email,
                    Phone = phone,
                    BirthDate = birthDate,
                    Status = "Pending",
                    CreatedAt = DateTime.UtcNow
                };
                await _dal.CreateAsync(req);
                return (true, "Yêu cầu đăng ký đã được gửi! Vui lòng chờ Admin phê duyệt.");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi gửi yêu cầu: " + ex.Message);
            }
        }

        public async Task<(bool Success, string Message)> ApproveAsync(
            RegistrationRequestDTO request, int departmentId, int positionId)
        {
            if (!SessionManager.IsAdmin)
                return (false, "Chỉ Admin mới có quyền phê duyệt.");

            try
            {
                var client = SupabaseClientManager.Instance.GetClient();

                // Kiểm tra xem email đã tồn tại trong bảng employees chưa
                var existingEmpResponse = await client.From<EmployeeDTO>().Filter("email", Supabase.Postgrest.Constants.Operator.Equals, request.Email).Get();
                var activeEmps = existingEmpResponse.Models.Where(e => e.Status == "Active" || e.Status == "Đang làm việc").ToList();
                
                int targetEmpId = 0;
                // 1. Tạo hoặc cập nhật Employee
                var empBll = new EmployeeBLL();
                EmployeeDTO newEmp;

                if (activeEmps.Count > 0)
                {
                    // Nếu nhân viên đã tồn tại và đang hoạt động -> Tái sử dụng hồ sơ nhân viên này
                    newEmp = activeEmps[0];
                    targetEmpId = newEmp.EmployeeId;
                    if (departmentId > 0) newEmp.DepartmentId = departmentId;
                    if (positionId > 0) newEmp.PositionId = positionId;
                    await client.From<EmployeeDTO>().Update(newEmp);
                }
                else
                {
                    string newCode = await empBll.GetNextEmployeeCodeAsync();

                    var employee = new EmployeeDTO
                    {
                        FullName = request.FullName,
                        Email = request.Email,
                        Phone = request.Phone,
                        BirthDate = request.BirthDate,
                        Gender = request.Gender ?? "Nam",
                        CitizenId = request.CitizenId,
                        Address = request.Address,
                        HireDate = DateTime.Today,
                        DepartmentId = departmentId,
                        PositionId = positionId,
                        Status = "Active",
                        EmployeeCode = newCode
                    };
                    var empResponse = await client.From<EmployeeDTO>().Insert(employee);
                    newEmp = empResponse.Models[0];
                    targetEmpId = newEmp.EmployeeId;
                }

                try
                {
                    // 2. Tạo hoặc tái sử dụng tài khoản trên Supabase Auth
                    string defaultPassword = "123456";
                    var adminSession = client.Auth.CurrentSession;
                    string? authUserId = null;

                    try
                    {
                        var authSession = await client.Auth.SignUp(request.Email, defaultPassword);
                        authUserId = authSession?.User?.Id;
                    }
                    catch (Exception exAuth)
                    {
                        // Email đã tồn tại trong Supabase Auth -> Tái sử dụng Auth User cũ
                        try
                        {
                            var loginSession = await client.Auth.SignInWithPassword(request.Email, defaultPassword);
                            authUserId = loginSession?.User?.Id;
                        }
                        catch
                        {
                            authUserId = Guid.NewGuid().ToString();
                        }
                    }

                    // QUAN TRỌNG: Khôi phục lại session admin sau khi SignUp/SignIn
                    if (adminSession?.AccessToken != null)
                        await client.Auth.SetSession(adminSession.AccessToken, adminSession.RefreshToken ?? "");

                    if (string.IsNullOrEmpty(authUserId))
                        authUserId = Guid.NewGuid().ToString();

                    // Sinh mật khẩu băm để lưu làm minh chứng
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(defaultPassword);
                    
                    // Nếu gán chức vụ Trưởng phòng (positionId = 2) -> tự nâng RoleId = 2 (Manager)
                    bool isTruongPhong = positionId == 2;
                    int employeeRoleId = isTruongPhong ? 2 : 3;

                    var account = new AccountDTO
                    {
                        UserId = Guid.Parse(authUserId),
                        Username = request.Email,
                        PasswordHash = hashedPassword,
                        RoleId = employeeRoleId,
                        EmployeeId = newEmp.EmployeeId,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    };
                    await client.From<AccountDTO>().Insert(account);

                    // 2b. Tự động khởi tạo Hợp đồng Lao động đầu tiên cho nhân viên
                    try
                    {
                        var contractBll = new ContractBLL();
                        var posBll = new PositionBLL();
                        var posList = await posBll.GetAllAsync();
                        var pos = posList.FirstOrDefault(p => p.PositionId == positionId);
                        decimal initSalary = pos?.BaseSalary ?? 15000000;

                        var contract = new ContractDTO
                        {
                            ContractCode = $"HD-{newEmp.EmployeeCode}",
                            EmployeeId = newEmp.EmployeeId,
                            ContractType = isTruongPhong ? "Hữu hạn" : "Thử việc",
                            StartDate = DateTime.Today,
                            EndDate = isTruongPhong ? DateTime.Today.AddYears(1) : DateTime.Today.AddMonths(2),
                            Salary = initSalary,
                            Status = "Active"
                        };
                        await contractBll.CreateAsync(contract);
                    }
                    catch (Exception exContract)
                    {
                        Console.WriteLine("Lỗi tạo hợp đồng sau duyệt: " + exContract.Message);
                    }

                    // Đồng bộ phòng ban & Trưởng phòng cũ nếu bổ nhiệm Trưởng phòng mới
                    if (isTruongPhong && departmentId > 0)
                    {
                        try
                        {
                            // Hạ chức các Trưởng phòng cũ của phòng này về Nhân viên (chức vụ 3, role 3)
                            var allEmps = await empBll.GetVisibleEmployeesAsync();
                            var oldEmps = allEmps.Where(e => e.DepartmentId == departmentId && e.EmployeeId != newEmp.EmployeeId && e.PositionId == 2).ToList();
                            var accBll = new AccountBLL();
                            var accDal = new AccountDAL();
                            var allAccs = await accBll.GetAllAsync();

                            foreach (var oldE in oldEmps)
                            {
                                oldE.PositionId = 3;
                                await empBll.UpdateAsync(oldE);

                                var oldAcc = allAccs.FirstOrDefault(a => a.EmployeeId == oldE.EmployeeId);
                                if (oldAcc != null && oldAcc.RoleId == 2)
                                {
                                    oldAcc.RoleId = 3;
                                    await accDal.UpdateAsync(oldAcc);
                                }
                            }

                            // Cập nhật manager_id cho phòng ban
                            var deptBll = new DepartmentBLL();
                            var dept = await deptBll.GetByIdAsync(departmentId);
                            if (dept != null)
                            {
                                dept.ManagerId = newEmp.EmployeeId;
                                await deptBll.UpdateAsync(dept);
                            }
                        }
                        catch { }
                    }

                    // 3. Cập nhật trạng thái yêu cầu đăng ký
                    request.Status = "Approved";
                    request.ReviewedBy = SessionManager.CurrentAccount?.EmployeeId;
                    request.ReviewedAt = DateTime.UtcNow;
                    await _dal.UpdateAsync(request);

                    // 4. Gửi email thông báo
                    string subject = "Chúc mừng! Tài khoản VIETLAND HR của bạn đã được duyệt";
                    string body = $"Chào {request.FullName},\n\n" +
                                  $"Yêu cầu đăng ký tài khoản của bạn đã được phê duyệt.\n" +
                                  $"Tài khoản đăng nhập: {request.Email}\n" +
                                  $"Mật khẩu mặc định: {defaultPassword}\n\n" +
                                  $"Vui lòng đăng nhập và đổi mật khẩu sớm nhất có thể.\n\n" +
                                  $"Trân trọng,\nPhòng Nhân sự VIETLAND HR";
                    EmailHelper.SendEmailAsync(request.Email, subject, body, request.FullName);

                    return (true, $"Đã duyệt và tạo tài khoản cho {request.FullName}!\nMật khẩu mặc định: {defaultPassword}");
                }
                catch (Exception innerEx)
                {
                    // Rollback: Xoá Employee vừa tạo (session đã được khôi phục về admin)
                    try
                    {
                        var empDal = new EmployeeDAL();
                        await empDal.DeleteAsync(newEmp.EmployeeId);
                    }
                    catch { /* Bỏ qua lỗi rollback */ }
                    throw new Exception(innerEx.Message);
                }
            }
            catch (Exception ex)
            {
                return (false, "Lỗi phê duyệt: " + ex.Message);
            }
        }

        public async Task<(bool Success, string Message)> RejectAsync(RegistrationRequestDTO request)
        {
            if (!SessionManager.IsAdmin)
                return (false, "Chỉ Admin mới có quyền từ chối.");

            try
            {
                request.Status = "Rejected";
                request.ReviewedBy = SessionManager.CurrentAccount?.EmployeeId;
                request.ReviewedAt = DateTime.UtcNow;
                await _dal.UpdateAsync(request);

                // Gửi email từ chối
                string subject = "Kết quả yêu cầu đăng ký tài khoản VIETLAND HR";
                string body = $"Chào {request.FullName},\n\n" +
                              $"Rất tiếc, yêu cầu đăng ký tài khoản nhân viên của bạn đã bị từ chối.\n" +
                              $"Vui lòng liên hệ Phòng Nhân sự để biết thêm chi tiết.\n\n" +
                              $"Trân trọng,\nPhòng Nhân sự VIETLAND HR";
                EmailHelper.SendEmailAsync(request.Email, subject, body, request.FullName);

                return (true, "Đã từ chối yêu cầu đăng ký.");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi: " + ex.Message);
            }
        }

        // Tạo mật khẩu tạm thời – user sẽ cần dùng "Quên mật khẩu" để đặt lại
        private string GenerateTempPassword()
        {
            return "Hrm@" + Guid.NewGuid().ToString("N").Substring(0, 8);
        }
    }
}

