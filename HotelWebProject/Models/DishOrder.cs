using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    public class DishOrder
    {
        public int OrderId { get; set; }
        public int DeskId { get; set; }
        public List<DishOrderDetail> DishDetails { get; set; }
        public int SumPrice { get; set; }
        public DateTime OrderTime { get; set; }

        public string FormattedOrderTime { get { return OrderTime.ToString("yyyy-MM-dd HH:mm:ss"); } }
    }
}
