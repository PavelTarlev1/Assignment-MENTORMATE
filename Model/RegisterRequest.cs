using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment_2.Model
{
    public class RegisterRequest
    {
        [Required]
        [JsonPropertyName("roomName")]
        public string Name { get; set; }
        [Required]
        [JsonPropertyName("capacity")]
        public int Capacity { get; set; }
        [Required]
        [JsonPropertyName("availableFrom")]
        [JsonConverter(typeof(JsonTimeSpanConverter))]
        public TimeSpan AvailableFrom { get; set; }
        [Required]
        [JsonPropertyName("availableTo")]
        [JsonConverter(typeof(JsonTimeSpanConverter))]
        public TimeSpan AvailableTo { get; set; }
        [JsonPropertyName("schedule")]
        public List<Schedule> Schedule { get; set; }
    }

    public class RegisterSchedule
    {
        [JsonPropertyName("from")]
        public DateTime From { get; set; }
        [JsonPropertyName("to")]
        public DateTime To { get; set; }
        //Navigation Properties
    }
}
