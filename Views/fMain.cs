using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHF_RFID_READER.BUS;
using UHF_RFID_READER.DTO;
using UHF_RFID_READER.Resources;
using Timer = System.Windows.Forms.Timer;

namespace UHF_RFID_READER.Views
{
    public partial class fMain : Form
    {
        string httpIP = ConfigurationManager.AppSettings["HTTPServerAddress"];
        string databaseIP = ConfigurationManager.AppSettings["DatabaseIP"];
        bool isAutoMerge = Convert.ToBoolean(ConfigurationManager.AppSettings["AutoMergeFromUhfToRecord"]);
        private static CancellationTokenSource cancellationTokenSource;
        static List<ResponseDTO> responseDTOs;
        private Timer refreshTimer;
        private Timer onlineTimer;
        private Timer mergeTimer;
        private static string version_name = "UHF RFID READER 1.3.1";
        DateTime startTime;
        public fMain()
        {
            InitializeComponent();
            this.Text = version_name;
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            Task.Run(() => reloadDatagridview());
            responseDTOs = new List<ResponseDTO>();
            OpenHttpServer(httpIP);
            lblDatabaseUsage.Text = databaseIP;
            InitTimer();
        }

        void InitTimer()
        {
            InitOnlineTime();
            InitializeTimer();
            InitTimeAutoMerge();
        }
        private void InitTimeAutoMerge()
        {
            mergeTimer = new Timer();
            mergeTimer.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["MergeDelayTime"]) * 1000;
            mergeTimer.Tick += MergeTimer_Tick;
            mergeTimer.Start();
        }

        async void MergeTimer_Tick(object sender, EventArgs e)
        {
            if (isAutoMerge)
            {
                await Task.Run(async () => await RecordBUS.MergeData());
            }
        }

        private void InitializeTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["DelayTime"]) * 1000; // 1000 = 1s
            refreshTimer.Tick += RefreshTimer_Tick;

            // Bắt đầu hẹn giờ ngay từ khi form được khởi tạo hoặc có thể chọn một thời điểm phù hợp khác
            refreshTimer.Start();
        }

        private void InitOnlineTime()
        {
            startTime = DateTime.Now;
            onlineTimer = new Timer();
            onlineTimer.Interval = 1000;
            onlineTimer.Tick += OnlineTimer_Tick;
            onlineTimer.Start();
        }

        async void OnlineTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan onlTime = DateTime.Now - startTime;
            lblOnlineTime.Text = $"{onlTime.ToString(@"hh\:mm\:ss")}";
        }

        async void RefreshTimer_Tick(object sender, EventArgs e)
        {
            await Task.Run(() => reloadDatagridview());

        }
        private void OpenHttpServer(string ip)
        {
            try
            {

                string baseUrl = $"http://{ip}/api/receive-data/";

                HttpListener listener = new HttpListener();
                listener.Prefixes.Add(baseUrl);

                cancellationTokenSource = new CancellationTokenSource();
                Task.Run(() => StartListening(listener, cancellationTokenSource.Token));
            }
            catch (Exception ex)
            {
                Helper.WriteLogError($"Error: {ex.Message} at {DateTime.Now}", $"Log Exception OpenServer");
            }
        }
        async Task StartListening(HttpListener listener, CancellationToken cancellationToken)
        {
            try
            {
                // Bắt đầu lắng nghe yêu cầu từ client
                listener.Start();

                while (!cancellationToken.IsCancellationRequested)
                {
                    // Chấp nhận yêu cầu
                    HttpListenerContext context = await listener.GetContextAsync();

                    // Xử lý yêu cầu trong một luồng mới
                    HandleRequest(context);
                }
            }
            catch (HttpListenerException ex)
            {
                //Console.WriteLine($"Error: {ex.Message}");
                //throw new HttpListenerException();
                Helper.WriteLogError($"Error: {ex.Message} at {DateTime.Now}", $"Log Exception StartListening");
            }
            finally
            {
                // Dừng máy chủ khi hoàn thành
                listener.Stop();
            }
        }
        void HandleRequest(HttpListenerContext context)
        {
            try
            {
                if (context == null)
                {
                    Helper.WriteLogError("Error: HttpListenerContext is null.", "Log Handle Request NULL 1");
                    return; // Hoặc thực hiện xử lý khác tùy thuộc vào yêu cầu của bạn
                }
                else
                {


                    // Xử lý yêu cầu ở đây
                    HttpListenerRequest request = context.Request;
                    if (request == null)
                    {
                        Helper.WriteLogError("Error: HttpListenerRequest is null.", "Log Handle Request NULL 2");
                        return; // Hoặc thực hiện xử lý khác tùy thuộc vào yêu cầu của bạn
                    }

                    // Đọc dữ liệu từ yêu cầu (ví dụ: lấy dữ liệu từ máy đọc RFID)
                    string requestData;
                    using (System.IO.Stream body = request.InputStream)
                    {
                        if (body == null)
                        {
                            Helper.WriteLogError("Error: InputStream is null.", "Log Handle Request NULL 3");
                            return;
                        }

                        using (System.IO.StreamReader reader = new System.IO.StreamReader(body, request.ContentEncoding, true, 1024, true))
                        {
                            requestData = reader.ReadToEnd();
                        }
                    }



                    // Kiểm tra nếu chuỗi nhận được không rỗng
                    if (!string.IsNullOrEmpty(requestData))
                    {
                        try
                        {

                            DeviceReport deviceReport = JsonConvert.DeserializeObject<DeviceReport>(requestData);

                            List<Tag> tagsList = deviceReport.Data.TagList;
                            foreach (Tag tag in tagsList)
                            {
                                //AddtoResponseList(deviceReport, tag);
                                Task.Run(async () => await RecordBUS.UpsertEpcToDatabase(deviceReport, tag));
                            }
                            Helper.WriteLog($"DATA:{DateTime.Now} // {JsonConvert.SerializeObject(tagsList)}\n-------==-----===----", $"Received DATA");
                        }
                        catch (Exception ex)
                        {
                            Helper.WriteLogError($"Error: {ex.Message} at {DateTime.Now} // RECEIVE HEARTBEAT OF APP", $"Log Exception Serialize RequestData");
                        }
                    }

                    // Trả về phản hồi cho client
                    HttpListenerResponse response = context.Response;
                    byte[] buffer = Encoding.UTF8.GetBytes("Data received successfully!");
                    response.ContentLength64 = buffer.Length;
                    System.IO.Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    output.Close();
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLogError($"Error: {ex.Message} at {DateTime.Now} // {JsonConvert.SerializeObject(context)}", $"Log Exception Handle Request");
            }
        }


        void reloadDatagridview()
        {
            try
            {
                List<ResponseDTO> listRecord = new List<ResponseDTO>();
                List<DisplayObjectDTO> listCounts = new List<DisplayObjectDTO>();

                Task.Run(async () =>
                {
                    listCounts.Clear();
                    listCounts = await RecordBUS.LoadProductCountOnStationNO();
                    if (dtgvDisplayCounts.InvokeRequired)
                    {
                        // Nếu đang ở một luồng khác ngoài UI thread
                        dtgvDisplayCounts.Invoke(new MethodInvoker(() =>
                        {
                            dtgvDisplayCounts.DataSource = null;
                            dtgvDisplayCounts.DataSource = listCounts;

                        }));
                        return;

                    }
                    else
                    {
                        // Nếu đã ở UI thread
                        dtgvDisplayCounts.DataSource = null;
                        dtgvDisplayCounts.DataSource = listCounts;

                    }
                });

                Task.Run(async () =>
                {
                    listRecord.Clear();
                    listRecord = await RecordBUS.GetData();
                    if (dtgvDisplayRecordDetails.InvokeRequired)
                    {
                        // Nếu đang ở một luồng khác ngoài UI thread
                        dtgvDisplayRecordDetails.Invoke(new MethodInvoker(() =>
                        {
                            dtgvDisplayRecordDetails.DataSource = null;
                            dtgvDisplayRecordDetails.DataSource = listRecord;

                        }));
                        return;
                    }
                    else
                    {
                        // Nếu đã ở UI thread
                        dtgvDisplayRecordDetails.DataSource = null;
                        dtgvDisplayRecordDetails.DataSource = listRecord;

                    }
                });


            }
            catch (Exception ex)
            {
                Helper.WriteLogError($"Error: {ex.Message} at {DateTime.Now}", $"Log Exception ReloadDTGV");
            }
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                cancellationTokenSource.Cancel();
            }
            catch (Exception ex)
            {
                Helper.WriteLogError($"Error: {ex.Message} at {DateTime.Now}", $"Log Exception CloseForm");
            }
        }
    }
}
