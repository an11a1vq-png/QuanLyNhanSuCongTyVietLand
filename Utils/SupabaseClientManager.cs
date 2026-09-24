using Supabase;
using Supabase.Interfaces;
using System;
using System.Threading.Tasks;

namespace VietLandHR.Utils
{
    /// <summary>
    /// Quản lý kết nối Supabase cho toàn ứng dụng
    /// Sử dụng Singleton Pattern để đảm bảo chỉ có 1 instance
    /// </summary>
    public class SupabaseClientManager
    {
        private static SupabaseClientManager? _instance;
        private static readonly object _lockObject = new object();
        private Client? _supabaseClient;
        private bool _isInitialized = false;

        // Cấu hình Supabase
        private const string SUPABASE_URL = "https://zbpuwwogrhclevjytjyv.supabase.co";     
        private const string SUPABASE_KEY = "sb_publishable_y39gg8zCQ69Rv0ymdXKvIQ_s3LC9Ppo";     

        public static SupabaseClientManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new SupabaseClientManager();
                        }
                    }
                }
                return _instance;
            }
        }

        private SupabaseClientManager()
        {
        }

        /// <summary>
        /// Khởi tạo kết nối Supabase
        /// Gọi method này lần đầu tiên khi ứng dụng khởi động
        /// </summary>
        public async Task InitializeAsync()
        {
            try
            {
                if (_isInitialized)
                    return;

                var options = new SupabaseOptions
                {
                    AutoConnectRealtime = true,
                    // Các cấu hình khác nếu cần
                };

                _supabaseClient = new Client(SUPABASE_URL, SUPABASE_KEY, options);
                await _supabaseClient.InitializeAsync();
                _isInitialized = true;

                Console.WriteLine("✓ Supabase client initialized successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error initializing Supabase: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Lấy instance của Supabase Client
        /// </summary>
        public Client GetClient()
        {
            if (!_isInitialized)
                throw new InvalidOperationException("Supabase client chưa được khởi tạo. Gọi InitializeAsync() trước!");

            return _supabaseClient;
        }

        /// <summary>
        /// Kiểm tra trạng thái kết nối
        /// </summary>
        public bool IsConnected => _isInitialized && _supabaseClient != null;

        /// <summary>
        /// Disconnect Supabase
        /// </summary>
        public void Disconnect()
        {
            try
            {
                _supabaseClient = null;
                _isInitialized = false;
                Console.WriteLine("✓ Supabase client disconnected!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Error disconnecting Supabase: {ex.Message}");
            }
        }
    }
}

