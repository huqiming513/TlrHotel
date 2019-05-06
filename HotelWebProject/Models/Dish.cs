using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Serializable]
    public class Dish
    {
        public int DishId { get; set; }
        public string DishName { get; set; }
        public int UnitPrice { get; set; }
        public int CategoryId { get; set; }
        //
        public string CategoryName { get; set; }
    }
}
