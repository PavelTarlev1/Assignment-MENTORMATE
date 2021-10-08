using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment_2.Model
{
    public class FreeScheduleModel
    {
        [JsonPropertyName("from")]
        public DateTime From { get; set; }
        [JsonPropertyName("to")]
        public DateTime To { get; set; }
    }
}
