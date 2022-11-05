using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_api.Models
{
    internal class Datum
    {
        public float open { get; set; }
        public float high { get; set; }
        public float low { get; set; }
        public float close { get; set; }
        public float volume { get; set; }
        public float? adj_high { get; set; }
        public float? adj_low { get; set; }
        public float adj_close { get; set; }
        public float? adj_open { get; set; }
        public float? adj_volume { get; set; }
        public float split_factor { get; set; }
        public float dividend { get; set; }
        public string symbol { get; set; }
        public string exchange { get; set; }
        public DateTime date { get; set; }
    }
}
