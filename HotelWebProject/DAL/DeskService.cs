using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Models;
namespace DAL
{
    public class DeskService
    {
        public int OrderBook(DeskOrder deskBook)
        {
            string sql = "INSERT INTO DeskOrder(ConsumeTime,ConsumePersons,DeskType,CustomerName,CustomerPhone,Comments) VALUES(@ConsumeTime,@ConsumePersons,@DeskType,@CustomerName,@CustomerPhone,@Comments);";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ConsumeTime",deskBook.ConsumeTime),
                new SqlParameter("@ConsumePersons",deskBook.ConsumePersons),
                new SqlParameter("@DeskType",deskBook.DeskType),
                new SqlParameter("@CustomerName",deskBook.CustomerName),
                new SqlParameter("@CustomerPhone",deskBook.CustomerPhone),
                new SqlParameter("@Comments",deskBook.Comments),
            };
            return SQLHelper.Update(sql, param);
        }

        public int ModifyOrderStatus(string orderId, string orderStatus)
        {
            string sql = "UPDATE DeskOrder SET OrderStatus=@OrderStatus WHERE OrderId=@OrderId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@OrderStatus",orderStatus),
                new SqlParameter("@OrderId",orderId),
            };
            return SQLHelper.Update(sql, param);
        }


        public List<DeskOrder> GetAllDeskOrder()
        {
            string sql = "SELECT * FROM DeskOrder WHERE OrderStatus != 2;";
            List<DeskOrder> list = new List<DeskOrder>();
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while (objReader.Read())
            {
                list.Add(new DeskOrder()
                {
                    OrderId = Convert.ToInt32(objReader["OrderId"]),
                    CustomerName = objReader["CustomerName"].ToString(),
                    ConsumeTime = Convert.ToDateTime(objReader["ConsumeTime"]),
                    ConsumePersons = Convert.ToInt32(objReader["ConsumePersons"]),
                    DeskType = objReader["DeskType"].ToString(),
                    CustomerPhone = objReader["CustomerPhone"].ToString(),
                    Comments = objReader["Comments"].ToString(),
                    OrderTime = Convert.ToDateTime(objReader["OrderTime"]),
                    OrderStatus = Convert.ToInt32(objReader["OrderStatus"]),
                });

            }
            return list;
        }
    }
}
