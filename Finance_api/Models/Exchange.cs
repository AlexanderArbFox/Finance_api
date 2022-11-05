using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_api.Models
{
    internal class Exchange
    {
        public int Id { get; set; }
        public string Name_original { get; set; }
        public string Name_second { get; set; }
        public string Name_full { get; set; }
        public int Country_id { get; set; }
    }
}
