using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP_v1_2.Classes
{
    public class Course
    {
        [JsonProperty("ccy")]
        public string Currency { get; set; }

        [JsonProperty("base_ccy")]
        public string To { get; set; }

        [JsonProperty("buy")]
        public string BuyCourse { get; set; }

        [JsonProperty("sale")]
        public string SaleCourse { get; set; }
    }

}
