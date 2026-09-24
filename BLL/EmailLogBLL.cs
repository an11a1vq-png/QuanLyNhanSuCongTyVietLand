using System;
using System.Threading.Tasks;

namespace VietLandHR.BLL
{
    public class EmailLogBLL
    {
        public Task InsertAsync(string a, string b, string c, string d) => Task.CompletedTask;
        public Task LogAndSendEmailAsync(string a, string b, string c, string d) => Task.CompletedTask;
        public Task LogLeaveEmailAsync(object a, object b, object c) => Task.CompletedTask;
    }
}

