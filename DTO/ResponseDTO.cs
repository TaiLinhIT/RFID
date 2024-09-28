using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Data;
using System.ComponentModel;

namespace UHF_RFID_READER.DTO
{
    public class ResponseDTO
    {
        public ResponseDTO()
        {
        }

        public ResponseDTO(DataRow row)
        {
            this.id = row["id"].ToString();
            this.temperature = row["temperature"].ToString();
            this.method = row["method"].ToString();
            this.ant = Convert.ToInt32(row["ant"]);
            this.firstAnt = Convert.ToInt32(row["firstAnt"]);
            this.firstTime = Convert.ToDateTime(row["firstTime"]);
            this.lastTime = Convert.ToDateTime(row["lastTime"]);
            this.epc = row["epc"].ToString();
            this.uploadTime = Convert.ToDateTime(row["uploadTime"]);
            this.sn = row["sn"].ToString();
            this.rssi = row["rssi"].ToString();
            if (!row.IsNull("updated"))
            {
                this.updateTime = Convert.ToDateTime(row["updated"]);
            } 
        }
        public ResponseDTO(string id, string temperature, string method, int ant, int firstAnt, DateTime firstTime, DateTime lastTime, string epc, DateTime uploadTime, string sn, string rssi, DateTime updateTime)
        {
            this.id = id;
            this.temperature = temperature;
            this.method = method;
            this.ant = ant;
            this.firstAnt = firstAnt;
            this.firstTime = firstTime;
            this.lastTime = lastTime;
            this.epc = epc;
            this.uploadTime = uploadTime;
            this.sn = sn;
            this.rssi = rssi;
            this.updateTime = updateTime;
        }

        [DisplayName("ID")]
        public string id { get; set; }

        [Browsable(false)]
        [DisplayName("溫度")]
        public string temperature { get; set; }           

        [DisplayName("上傳方法")]
        public string method { get; set; }                

        [DisplayName("天線")]
        public int ant { get; set; }                     

        [DisplayName("第一根讀取天線")]
        public int firstAnt { get; set; }                

        [DisplayName("第一次讀取時間")]
        public DateTime firstTime { get; set; }          

        [DisplayName("最後讀取時間")]
        public DateTime lastTime { get; set; }        

        [DisplayName("上傳時間")]
        public DateTime uploadTime { get; set; }         

        [DisplayName("更新时间")]
        public DateTime? updateTime { get; set; }       
        
        [DisplayName("标签號碼")]
        public string epc { get; set; }                 

        [DisplayName("序列号")]
        public string sn { get; set; }                   

        [DisplayName("RSSI")]
        public string rssi { get; set; }                

    }
    public class Tag
    {
        public int Ant { get; set; }
        public string Direction { get; set; }
        public string Epc { get; set; }
        public int FirstAnt { get; set; }
        public long FirstTime { get; set; }
        public long LastTime { get; set; }
        public string Rssi { get; set; }
    }

    public class Data
    {
        public string Id { get; set; }
        public List<Tag> TagList { get; set; }
        public string Temperature { get; set; }
        public long Timestamp { get; set; }
    }

    public class DeviceReport
    {
        public Data Data { get; set; }
        public string Method { get; set; }
        public string Sn { get; set; }
        public DateTime DeviceTimestamp { get; set; }
    }
}
