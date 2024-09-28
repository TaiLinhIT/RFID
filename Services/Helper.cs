using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UHF_RFID_READER.Resources
{
    public static class Helper
    {

        public static DateTime TimestampToDatetime(long timestamp)
        {
            const long minTimestamp = -62135596800000;
            const long maxTimestamp = 253402300799999;

            if (timestamp < minTimestamp || timestamp > maxTimestamp)
            {
                // Xử lý hoặc ném ngoại lệ nếu cần thiết
                //throw new ArgumentOutOfRangeException(nameof(timestamp), "Invalid timestamp value.");
                return DateTime.Now;
            }

            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(timestamp);
            return dateTimeOffset.DateTime;
        }

        public static void WriteLogError(string data, string nameOfFile)
        {
            string targetDirectoryName = "Errors";
            string logDate = DateTime.Now.ToString("yyyy-MM-dd");
            string fileName = $"{nameOfFile}_{logDate}.txt";

            string executablePath = Application.ExecutablePath;
            string executableDirectory = Path.GetDirectoryName(executablePath);
            string logDirectory = Path.Combine(executableDirectory, targetDirectoryName, logDate);
            string logFilePath = Path.Combine(logDirectory, fileName);

            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine(data);
                }
            }
            catch (IOException ex)
            {
                // Xử lý ngoại lệ I/O ở đây
            }
        }
        public static void WriteLog(string data, string nameOfFile)
        {
            string targetDirectoryName = "Data_Logs";
            string logDate = DateTime.Now.ToString("yyyy-MM-dd");
            string fileName = $"{nameOfFile}_{logDate}.txt";

            string executablePath = Application.ExecutablePath;
            string executableDirectory = Path.GetDirectoryName(executablePath);
            string logDirectory = Path.Combine(executableDirectory, targetDirectoryName, logDate);
            string logFilePath = Path.Combine(logDirectory, fileName);

            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine(data);
                }
            }
            catch (IOException ex)
            {
                // Xử lý ngoại lệ I/O ở đây
            }
        }

        public static string GetLocalIpAddress()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    // Sử dụng dịch vụ trực tuyến để lấy địa chỉ IP công cộng
                    string response = client.DownloadString("https://api64.ipify.org?format=json");

                    // Phân tích chuỗi JSON để lấy địa chỉ IP
                    dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(response);
                    string ipAddress = json.ip;

                    return ipAddress;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy địa chỉ IP: {ex.Message}");
                return "Không xác định";
            }
        }

        public static string GetRegionFromIpAddress(string ipAddress)
        {
            // Bạn có thể sử dụng một dịch vụ web hoặc thư viện API để lấy thông tin vùng từ địa chỉ IP
            // Dưới đây là một ví dụ giả sử

            // Gọi API hoặc thực hiện bất kỳ xử lý nào khác để lấy thông tin vùng dựa trên địa chỉ IP
            // Ví dụ: sử dụng một dịch vụ API cung cấp thông tin vùng

            // Chú ý: Đây chỉ là một ví dụ giả sử và bạn cần thay thế nó bằng cách thực tế phù hợp với ứng dụng của bạn
            // Ví dụ này sử dụng một dịch vụ miễn phí, hãy kiểm tra điều khoản sử dụng của dịch vụ trước khi triển khai trong môi trường sản xuất.
            string apiUrl = $"https://ipinfo.io/{ipAddress}/json";
            using (WebClient client = new WebClient())
            {
                try
                {
                    // Lấy dữ liệu từ API
                    string jsonResult = client.DownloadString(apiUrl);

                    // Xử lý JSON để lấy thông tin vùng (region)
                    // Điều này phụ thuộc vào cấu trúc của API bạn đang sử dụng
                    // Dưới đây là một ví dụ giả sử
                    // Bạn có thể sử dụng thư viện JSON (ví dụ: Newtonsoft.Json) để xử lý JSON một cách thuận tiện hơn
                    dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResult);
                    string region = result?.region ?? "Không xác định";

                    return region;
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi khi gọi API
                    return "Không xác định";
                }
            }
        }
 
    }
}
