using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHF_RFID_READER.DTO
{
    public class DisplayObjectDTO
    {
        public DisplayObjectDTO()
        {
        }

        public DisplayObjectDTO(DataRow row)
        {
            this.stationNO = row["stationNO"].ToString();
            this.counts = Convert.ToInt32(row["counts"]);
        }
        public DisplayObjectDTO(string stationNO, int counts)
        {
            this.stationNO = stationNO;
            this.counts = counts;
        }
        [DisplayName("站")]
        public string stationNO { get; set; }

        [DisplayName("合計")]
        public int counts { get; set; }

    }
}
