using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UHF_RFID_READER.DAO;
using UHF_RFID_READER.DTO;
using UHF_RFID_READER.Resources;

namespace UHF_RFID_READER.BUS
{
    public static class RecordBUS
    {
        public async static Task<int> UpsertEpcToDatabase(DeviceReport device, Tag tag)
        {
            try
            {
                if (device != null || tag != null)
                {

                    int totalInsert = RecordDAO.Instance.UpsertEpcByPROC(device.Data.Id, device.Data.Temperature, tag.Ant, tag.Epc, tag.FirstAnt, Helper.TimestampToDatetime(tag.FirstTime).AddHours(7), Helper.TimestampToDatetime(tag.LastTime).AddHours(7),
                        tag.Rssi, device.Method, device.Sn, Helper.TimestampToDatetime(device.Data.Timestamp).AddHours(7));

                    return totalInsert;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Helper.WriteLogError($"Error: {ex.Message} at {DateTime.Now} ({JsonConvert.SerializeObject(device.Data)})", $"Log Exception UPSERT");
                return 0;
            }
        }

        public async static Task<List<ResponseDTO>> GetData()
        {
            List<ResponseDTO> list = new List<ResponseDTO>();
            list = RecordDAO.Instance.GetListData();
            return list;
        }
        public async static Task<int> MergeData()
        {
            try
            {
                return RecordDAO.Instance.MergeDataFromUHFTestToRecord();
            }
            catch (Exception ex)
            {
                Helper.WriteLogError($"Error: {ex.Message} at {DateTime.Now}", $"Log Exception MERGE DATA");
                return 0;
            }
        }
        public async static Task<List<DisplayObjectDTO>> LoadProductCountOnStationNO()
        {
            List<DisplayObjectDTO> list = new List<DisplayObjectDTO>();
            try
            {

                list = RecordDAO.Instance.GetEpcCountOnStationNO();
            }
            catch (Exception ex)
            {
                Helper.WriteLogError($"Error: {ex.Message} at {DateTime.Now}", $"Log Exception LOAD COUNT");
            }
            return list;
        }

    }
}
