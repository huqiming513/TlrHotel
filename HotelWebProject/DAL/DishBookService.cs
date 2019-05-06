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
    public class DishBookService
    {
        public int Book(DIshBook objDishBook)
        {
            string sql = "insert into DishBook(HotelName,ConsumeTime,ConsumePersons,RoomType,CustomerName,";
            sql += "CustomerPhone,CustomerEmail,Comments)";
            sql += "values(@HotelName,@ConsumeTime,@ConsumePersons,@RoomType,@CustomerName,@CustomerPhone,@CustomerEmail,@Comments)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@HotelName",objDishBook.HotelName),
                new SqlParameter("@ConsumeTime",objDishBook.ConsumeTime),
                new SqlParameter("@ConsumePersons",objDishBook.ConsumePersons),
                new SqlParameter("@RoomType",objDishBook.RoomType),
                new SqlParameter("@CustomerName",objDishBook.CustomerName),
                new SqlParameter("@CustomerPhone",objDishBook.CustomerPhone),
                new SqlParameter("@CustomerEmail",objDishBook.CustomerEmail),
                new SqlParameter("@Comments",objDishBook.Comments),

            };
            String ssqq = sql;
            return SQLHelper.Update(sql, param);
        }
        public int ModifyBook(string bookId,string orderStatus)
        {
            string sql = "update DishBook set OrderStatus=@OrderStatus where BookId=@BookId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@OrderStatus",orderStatus),
                new SqlParameter("@BookId",bookId),
            };
            return SQLHelper.Update(sql, param);
        }
        public List<DIshBook>GetAllDishBook()
        {
            string sql = "select BookId,HotelName,ConsumeTime,ConsumePersons,RoomType,CustomerName,";
            sql += "CustomerPhone,CustomerEmail,Comments,BookTime,OrderStatus from DishBook";
            sql += " where OrderStatus=0 or OrderStatus=1 order by BookTime DESC";
            List<DIshBook> list = new List<DIshBook>();
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while(objReader.Read())
            {
                list.Add(new DIshBook()
                {
                    HotelName = objReader["HotelName"].ToString(),
                    BookId = Convert.ToInt32(objReader["BookId"]),
                    CustomerName = objReader["CustomerName"].ToString(),
                    ConsumeTime = Convert.ToDateTime(objReader["ConsumeTime"]),
                    ConsumePersons = Convert.ToInt32(objReader["ConsumePersons"]),
                    RoomType = objReader["RoomType"].ToString(),
                    CustomerPhone = objReader["CustomerPhone"].ToString(),
                    CustomerEmail = objReader["CustomerEmail"].ToString(),
                    Comments = objReader["Comments"].ToString(),
                    BookTime = Convert.ToDateTime(objReader["BookTime"]),
                    OrderStatus = Convert.ToInt32(objReader["OrderStatus"]),

                });
              
            }
            objReader.Close();
            return list;
        }
    }
}
