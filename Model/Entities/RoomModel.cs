using NPOI.SS.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment_2.Model
{
    public class RoomModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public TimeSpan AvailableFrom { get; set; }
        public TimeSpan AvailableTo { get; set; }
        //Navigation Properites
        [JsonPropertyName("schedule")]
        public List<Schedule> Schedule { get; set; }
    }

    public class Schedule
    {
        public int Id { get; set; }
        [JsonPropertyName("from")]
        public DateTime From { get; set; }
        [JsonPropertyName("to")]
        public DateTime To { get; set; }
        //Navigation Properties
        public int RoomModelId { get; set; }
        public RoomModel RoomModel { get; set; }
    }
}
