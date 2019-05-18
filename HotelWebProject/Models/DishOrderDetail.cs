using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    public class DishOrderDetail
    {
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int DishCount { get; set; }

        public static DataTable TableSchema
        {
            get
            {
                DataTable dt = new DataTable();
                dt.TableName = "DishOrderDetail";
                dt.Columns.AddRange(new DataColumn[] {
                    new DataColumn("OrderId",typeof(int)),
                    new DataColumn("DishId",typeof(int)),
                    new DataColumn("DishCount",typeof(int))
                });
                return dt;
            }
        }
    }
}
