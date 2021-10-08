using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Model
{
    public class CheckRoomResponse
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<FreeScheduleModel> Schedule { get; set; }
    }
}
