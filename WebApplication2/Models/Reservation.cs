using System;

namespace WebApplication2.Models
{
    public class Reservation
    {
        public int id { get; set; } 
        public string reservationDate { get; set; }
        public string shiftEntity { get; set; }
        public bool taken { get; set; }
        public ClassroomDto classroomEntity { get; set; }
    }
}
