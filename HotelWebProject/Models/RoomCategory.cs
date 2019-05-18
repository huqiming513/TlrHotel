using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    public class RoomCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int UnitPrice { get; set; }
    }
}
