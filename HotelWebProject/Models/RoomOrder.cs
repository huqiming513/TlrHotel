using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    public class RoomOrder
    {
        public int OrderId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public int RoomCategoryId { get; set; }
        public RoomCategory RoomCategory { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string Comments { get; set; }
        public DateTime OrderTime { get; set; }
        public int OrderStatus { get; set; }
    }
}
