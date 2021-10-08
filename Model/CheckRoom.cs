using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_2.Model
{
    public class CheckRoom
    {
        public DateTime CheckRoomDate { get; set; }
        public int Capacity { get; set; }
    }
}
