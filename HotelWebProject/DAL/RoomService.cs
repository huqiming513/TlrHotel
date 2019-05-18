using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;

namespace DAL
{
    public class RoomService
    {
        #region 对房间的查询
        /// <summary>
        /// 获取所有房间分类
        /// </summary>
        /// <returns></returns>
        public List<RoomCategory> GetAllCategory()
        {
            string sql = "SELECT * FROM RoomCategory";
            List<RoomCategory> list = new List<RoomCategory>();
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while (objReader.Read())
            {
                list.Add(new RoomCategory()
                {
                    CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                    CategoryName = objReader["CategoryName"].ToString(),
                    UnitPrice = Convert.ToInt32(objReader["UnitPrice"]),
                });
            }
            objReader.Close();
            return list;
        }

        /// <summary>
        /// 通过id获取房间
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public RoomCategory GetRoomById(string categoryId)
        {
            string sql = "SELECT * from RoomCategory where CategoryId = @CategoryId";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@CategoryId", categoryId) };
            RoomCategory room = null;

            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            if (objReader.Read())
            {
                room = new RoomCategory()
                {
                    CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                    CategoryName = objReader["CategoryName"].ToString(),
                    UnitPrice = Convert.ToInt32(objReader["UnitPrice"])
                };
            }
            objReader.Close();
            return room;
        }
        #endregion

        #region 对房间的增删改
        /// <summary>
        /// 新增房间返回ID
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public int AddRoom(RoomCategory room)
        {
            string sql = "INSERT INTO RoomCategory(CategoryName,UnitPrice)";
            sql += "VALUES(@CategoryName,@UnitPrice);SELECT @@identity";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CategoryName",room.CategoryName),
                new SqlParameter("@UnitPrice",room.UnitPrice),
            };
            return Convert.ToInt32(SQLHelper.GetSingleResult(sql, param));
        }

        /// <summary>
        /// 删除房间
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public int DeleteRoom(string categoryId)
        {
            string sql = "DELETE FROM RoomCategory WHERE CategoryId=@CategoryId";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@CategoryId", categoryId) };
            return SQLHelper.Update(sql, param);
        }

        /// <summary>
        /// 修改房间
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public int ModifyRoom(RoomCategory room)
        {
            string sql = "UPDATE RoomCategory SET CategoryName=@CategoryName,UnitPrice=@UnitPrice WHERE CategoryId=@CategoryId";
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@CategoryName",room.CategoryName),
                    new SqlParameter("@UnitPrice",room.UnitPrice),
                    new SqlParameter("@CategoryId",room.CategoryId)

            };
            return SQLHelper.Update(sql, param);
        }
        #endregion

        #region 和订房相关
        public int OrderBook(RoomOrder order)
        {
            string sql = "INSERT INTO RoomOrder(CheckInTime,CheckOutTime,RoomCategoryId,CustomerName,CustomerPhone,Comments) VALUES(@CheckInTime,@CheckOutTime,@RoomCategoryId,@CustomerName,@CustomerPhone,@Comments);";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@CheckInTime",order.CheckInTime),
                new SqlParameter("@CheckOutTime",order.CheckOutTime),
                new SqlParameter("@RoomCategoryId",order.RoomCategoryId),
                new SqlParameter("@CustomerName",order.CustomerName),
                new SqlParameter("@CustomerPhone",order.CustomerPhone),
                new SqlParameter("@Comments",order.Comments),
            };
            return SQLHelper.Update(sql, param);
        }


        public int ModifyOrderStatus(string orderId, string orderStatus)
        {
            string sql = "UPDATE RoomOrder SET OrderStatus=@OrderStatus WHERE OrderId=@OrderId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@OrderStatus",orderStatus),
                new SqlParameter("@OrderId",orderId),
            };
            return SQLHelper.Update(sql, param);
        }

        public List<RoomOrder> GetAllRoomOrder()
        {
            string sql = "SELECT RoomOrder.*,RoomCategory.CategoryName FROM RoomOrder,RoomCategory WHERE RoomOrder.RoomCategoryId = RoomCategory.CategoryId AND OrderStatus != 2 ORDER BY OrderTime DESC;";
            List<RoomOrder> list = new List<RoomOrder>();
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while (objReader.Read())
            {
                list.Add(new RoomOrder()
                {
                    OrderId = Convert.ToInt32(objReader["OrderId"]),
                    CheckInTime = Convert.ToDateTime(objReader["CheckInTime"]),
                    CheckOutTime = Convert.ToDateTime(objReader["CheckOutTime"]),
                    RoomCategoryId = Convert.ToInt32(objReader["RoomCategoryId"]),
                    RoomCategory = new RoomCategory()
                    {
                        CategoryName = objReader["CategoryName"].ToString()
                    },
                    CustomerName = objReader["CustomerName"].ToString(),
                    CustomerPhone = objReader["CustomerPhone"].ToString(),
                    Comments = objReader["Comments"].ToString(),
                    OrderTime = Convert.ToDateTime(objReader["OrderTime"]),
                    OrderStatus = Convert.ToInt32(objReader["OrderStatus"]),
                });

            }
            return list;
        }
        #endregion

    }
}
