using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UHF_RFID_READER.DTO;

namespace UHF_RFID_READER.DAO
{
    internal class RecordDAO
    {
        private static RecordDAO instance;
        private DbConnection conn;

        public RecordDAO()
        {
            conn = new DbConnection();
        }

        public static RecordDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RecordDAO();
                }
                return RecordDAO.instance;
            }
            private set { instance = value; }
        }

        public int UpsertEpcByPROC(string id, string temperature, int ant, string epc, int firstAnt, DateTime firstTime, DateTime lastTime, string rssi, string method, string sn, DateTime uploadTime)
        {
            int result = 0;
            string query = $@"EXEC SP_UpsertEpcUHF @id , @temperature , @ant , @epc , @firstAnt , @firstTime , @lastTime , @rssi , @method , @sn , @uploadTime ;";
            result = conn.ExecuteNonQueryTranSaction(query, new object[] { id, temperature, ant, epc, firstAnt, firstTime, lastTime, rssi, method, sn, uploadTime });
            return result;
        }
        public int UpsertEpcByDML(string id, string temperature, int ant, string epc, int firstAnt, DateTime firstTime, DateTime lastTime, string rssi, string method, string sn, DateTime uploadTime)
        {
            int result = 0;
            string query = $@"
                        MERGE INTO DV_DATA_LAKE.dbo.UHF_RFID_TEST AS target
                        USING (VALUES ('{id}', {temperature}, '{ant}', '{epc}', '{firstAnt}', '{firstTime}', '{lastTime}', '{rssi}', '{method}', '{sn}', '{uploadTime}')) AS source (id, temperature, ant, epc, firstAnt, firstTime, lastTime, rssi, method, sn, uploadTime)
                        ON target.sn = source.sn AND target.ant = source.ant AND target.epc = source.epc
                        WHEN MATCHED THEN
                            UPDATE SET
                                target.firstTime = source.firstTime,
                                target.lastTime = source.lastTime,
                                target.uploadTime = source.uploadTime,
                                target.rssi = source.rssi
                        WHEN NOT MATCHED THEN
                            INSERT ( id, temperature, ant, epc, firstAnt, firstTime, lastTime, rssi, method, sn, uploadTime)
                            VALUES ( source.id, source.temperature, source.ant, source.epc, source.firstAnt, source.firstTime, source.lastTime, source.rssi, source.method, source.sn, source.uploadTime);
                    ";

            result = conn.ExecuteNonQueryTranSaction(query);
            return result;
        }

        public List<ResponseDTO> GetListData()
        {
            List<ResponseDTO> result = new List<ResponseDTO>();
            DataTable data = new DataTable();
            string query = $"SELECT * FROM UHF_RFID_TEST WHERE FORMAT(uploadTime, 'yyyyMMdd') = FORMAT(GETDATE(), 'yyyyMMdd') ORDER BY uploadTime DESC;";
            data = conn.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    result.Add(new ResponseDTO(row));
                }
            }
            return result;
        }

        public int MergeDataFromUHFTestToRecord()
        {
            int res = 0;
            string query = "EXEC MergeDataFromUHFTestToRecord";
            res = conn.ExecuteNonQuery(query);

            return res;
        }


        public List<DisplayObjectDTO> GetEpcCountOnStationNO()
        {
            List<DisplayObjectDTO> list = new List<DisplayObjectDTO>();
            DataTable data = new DataTable();
            string query = $"SELECT DISTINCT COALESCE((SELECT TOP 1 device_name FROM dv_rfidreader WHERE device_sn = urt.sn AND device_ant = urt.ant), CONCAT(urt.sn, '/', urt.ant)) AS stationNO,  COUNT(epc) as counts,  format(urt.uploadTime,'dd/MM/yyyy') as time from UHF_RFID_TEST urt WHERE format(urt.uploadTime,'dd/MM/yyyy') = format(GETDATE() ,'dd/MM/yyyy') group by urt.ant,  urt.sn, format(urt.uploadTime,'dd/MM/yyyy') order by stationNO DESC ";
            data = conn.ExecuteQuery(query);
            if(data.Rows.Count > 0)
            {
                foreach(DataRow row in data.Rows)
                {
                    list.Add(new DisplayObjectDTO(row));
                }
            }
            return list;
        }
    }
}
