using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    public class DeskOrder
    {
        public int OrderId { get; set; }
        public string HotelName { get; set; }
        public DateTime ConsumeTime { get; set; }
        public int ConsumePersons { get; set; }
        public string DeskType { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string Comments { get; set; }
        public DateTime OrderTime { get; set; }
        public int OrderStatus { get; set; }
    }
}
