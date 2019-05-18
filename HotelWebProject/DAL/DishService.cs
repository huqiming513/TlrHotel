using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Models;
using Newtonsoft.Json;

namespace DAL
{
    public class DishService
    {

        #region 和点餐相关的方法
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<DishOrder> GetDishOrder()
        {
            string sql = "SELECT * FROM DishOrder;";
            List<DishOrder> list = new List<DishOrder>();
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while (objReader.Read())
            {
                list.Add(new DishOrder()
                {
                    OrderId = Convert.ToInt32(objReader["OrderId"]),
                    DeskId = Convert.ToInt32(objReader["DeskId"]),
                    SumPrice = Convert.ToInt32(objReader["SumPrice"]),
                    OrderTime = Convert.ToDateTime(objReader["OrderTime"]),
                });
            }
            objReader.Close();
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DishOrder GetDishOrderById(int orderId)
        {
            string sql = "SELECT * FROM DishOrder WHERE OrderId = @OrderId;";
            DishOrder dishOrder = new DishOrder();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@OrderId",orderId)
            };

            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            if (objReader.Read())
            {
                dishOrder = new DishOrder()
                {
                    OrderId = Convert.ToInt32(objReader["OrderId"]),
                    DeskId = Convert.ToInt32(objReader["DeskId"]),
                    DishDetails = GetDishOrderDetailByOrderId(orderId),
                    SumPrice = Convert.ToInt32(objReader["SumPrice"]),
                    OrderTime = Convert.ToDateTime(objReader["OrderTime"])
                };
            }
            objReader.Close();
            return dishOrder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<DishOrderDetail> GetDishOrderDetailByOrderId(int orderId)
        {
            string sql = "SELECT DishOrderDetail.*,Dishes.DishName,Dishes.UnitPrice FROM DishOrderDetail,Dishes WHERE OrderId=@OrderId AND DishOrderDetail.DishId = Dishes.DishId;";
            List<DishOrderDetail> list = new List<DishOrderDetail>();
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@OrderId",orderId)
            };
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            while (objReader.Read())
            {
                list.Add(new DishOrderDetail()
                {
                    OrderId = Convert.ToInt32(objReader["OrderId"]),
                    DishId = Convert.ToInt32(objReader["DishId"]),
                    Dish = new Dish()
                    {
                        DishName = Convert.ToString(objReader["DishName"]),
                        UnitPrice = Convert.ToInt32(objReader["UnitPrice"])
                    },
                    DishCount = Convert.ToInt32(objReader["DishCount"]),
                });
            }

            objReader.Close();
            return list;
        }
        
        /// <summary>
        /// 将订单保存到数据库
        /// </summary>
        /// <param name="dishOrder"></param>
        /// <returns></returns>
        public HttpResult SaveDishOrder(DishOrder dishOrder)
        {
            string sql = string.Format("INSERT INTO DishOrder VALUES(@DeskId,@SumPrice,@OrderTime);SELECT SCOPE_IDENTITY();");
            SqlParameter[] param =
            {
                new SqlParameter("@DeskId", dishOrder.DeskId),
                new SqlParameter("@SumPrice", dishOrder.SumPrice),
            };
            int orderId = Convert.ToInt32(SQLHelper.GetSingleResult(sql, param));
            if (orderId > 0)
            {
                DataTable dt = DishOrderDetail.TableSchema;
                foreach (DishOrderDetail detail in dishOrder.DishDetails)
                {
                    DataRow dr = dt.NewRow();
                    dr["OrderId"] = orderId;
                    dr["DishId"] = detail.DishId;
                    dr["DishCount"] = detail.DishCount;
                    dt.Rows.Add(dr);
                }
                SQLHelper.MultyInsert(dt);
                return new HttpResult(true, "ok");

            }
            return new HttpResult(false, "error");
        }

        /// <summary>
        /// 根据桌号和带菜品编号的菜品生成菜单
        /// </summary>
        /// <param name="deskId"></param>
        /// <param name="orderDetails"></param>
        /// <returns></returns>
        public DishOrder GenerateDishOrder(int deskId, List<DishOrderDetail> orderDetails)
        {
            // 补全DishOrderDetail中的Dish属性值
            CompleteDishDetailsWithTheirIds(orderDetails);
            // 根据补全后的DishOrderDetail获取餐品总价
            int sumPrice = GetSumPriceByDishOrderDetailList(orderDetails);

            DishOrder dishOrder = new DishOrder();
            dishOrder.DeskId = deskId;
            dishOrder.DishDetails = orderDetails;
            dishOrder.SumPrice = sumPrice;
            dishOrder.OrderTime = DateTime.Now;

            return dishOrder;
        }

        /// <summary>
        /// 根据DishOrderDetail中的DishId属性，查询点餐详情中的全部Dish
        /// </summary>
        /// <param name="orderDetails"></param>
        public void CompleteDishDetailsWithTheirIds(List<DishOrderDetail> orderDetails)
        {
            string idsStr = "(";
            for (int i = 0; i < orderDetails.Count; i++)
            {
                if (i > 0)
                {
                    idsStr += ",";
                }
                idsStr += orderDetails[i].DishId;

            }
            idsStr += ")";

            string sql = string.Format("SELECT * FROM Dishes WHERE DishId IN {0};", idsStr);

            int index = 0;
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while (objReader.Read())
            {
                orderDetails[index++].Dish = new Dish()
                {
                    DishId = Convert.ToInt32(objReader["DishId"]),
                    DishName = objReader["DishName"].ToString(),
                    UnitPrice = Convert.ToInt32(objReader["UnitPrice"])
                };
            }
            objReader.Close();
        }

        /// <summary>
        /// 根据订单详情计算菜品总价
        /// </summary>
        /// <param name="orderDetails"></param>
        /// <returns></returns>
        public int GetSumPriceByDishOrderDetailList(List<DishOrderDetail> orderDetails)
        {
            int sumPrice = 0;
            foreach (DishOrderDetail detail in orderDetails)
            {
                sumPrice += detail.Dish.UnitPrice * detail.DishCount;
            }
            return sumPrice;
        }
        #endregion

        #region 获取菜品分类
        public List<DishCategory> GetAllCategory()
        {
            string sql = "select CategoryId,CategoryName from DishCategory";
            List<DishCategory> list = new List<DishCategory>();
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while (objReader.Read())
            {
                list.Add(new DishCategory()
                {
                    CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                    CategoryName = objReader["CategoryName"].ToString()
                });
            }
            objReader.Close();
            return list;
        }
        #endregion

        #region 获取菜品
        /// <summary>
        /// 获取招牌菜品
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<Dish> GetRecommandedDishes()
        {
            string sql = "SELECT * FROM Dishes WHERE IsGood = 1;";
            List<Dish> list = new List<Dish>();
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while (objReader.Read())
            {
                list.Add(new Dish()
                {
                    DishId = Convert.ToInt32(objReader["DishId"]),
                    DishName = objReader["DishName"].ToString(),
                    UnitPrice = Convert.ToInt32(objReader["UnitPrice"])
                });
            }
            objReader.Close();
            return list;
        }

        /// <summary>
        /// 根据品类获取菜品
        /// </summary>
        /// <param name="categoryId">传指定品类id，不传就是所有品类</param>
        /// <returns></returns>
        public List<Dish> GetDishes(string categoryId)
        {
            string sql = "select DishId,DishName,UnitPrice,Dishes.CategoryId,CategoryName from Dishes inner join DishCategory on DishCategory.CategoryId=Dishes.CategoryId";
            List<Dish> list = new List<Dish>();
            SqlDataReader objReader = null;
            if (categoryId == null || categoryId == string.Empty)
            {
                objReader = SQLHelper.GetReader(sql);
            }
            else
            {
                sql += " where Dishes.CategoryId=@CategoryId";
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter("@CategoryId",categoryId)
                };
                objReader = SQLHelper.GetReader(sql, param);
            }
            while (objReader.Read())
            {
                list.Add(new Dish()
                {
                    DishId = Convert.ToInt32(objReader["DishId"]),
                    CategoryName = objReader["CategoryName"].ToString(),
                    DishName = objReader["DishName"].ToString(),
                    UnitPrice = Convert.ToInt32(objReader["UnitPrice"])
                });
            }
            objReader.Close();
            return list;
        }
        /// <summary>
        /// 通过id获取菜品
        /// </summary>
        /// <param name="dishId"></param>
        /// <returns></returns>
        public Dish GetDishById(string dishId)
        {
            string sql = "select DishId,DishName,UnitPrice,CategoryId from Dishes where DishId = @DishId";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@DishId", dishId) };
            Dish objDish = null;
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            if (objReader.Read())
            {
                objDish = new Dish()
                {
                    DishId = Convert.ToInt32(objReader["DishId"]),
                    CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                    DishName = objReader["DishName"].ToString(),
                    UnitPrice = Convert.ToInt32(objReader["UnitPrice"])
                };
            }
            objReader.Close();
            return objDish;
        }
        #endregion

        #region 菜品的增删改
        /// <summary>
        /// 新增菜品返回ID
        /// </summary>
        /// <param name="objDish"></param>
        /// <returns></returns>
        public int AddDish(Dish objDish)
        {
            string sql = "insert into Dishes(DishName,UnitPrice,CategoryId)";
            sql += "values(@DishName,@UnitPrice,@CategoryId);SELECT @@identity";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@DishName",objDish.DishName),
                new SqlParameter("@UnitPrice",objDish.UnitPrice),
                new SqlParameter("@CategoryId",objDish.CategoryId)
            };
            string ss = sql;
            return Convert.ToInt32(SQLHelper.GetSingleResult(sql, param));
        }
        /// <summary>
        /// 删除菜品
        /// </summary>
        /// <param name="dishId"></param>
        /// <returns></returns>
        public int DeleteDish(string dishId)
        {
            string sql = "delete from Dishes where DishId=@DishId";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@DishId", dishId) };
            return SQLHelper.Update(sql, param);
        }

        /// <summary>
        /// 修改菜品
        /// </summary>
        /// <param name="objDish"></param>
        /// <returns></returns>
        public int ModifyDish(Dish objDish)
        {
            string sql = "update Dishes set DishName=@DishName,UnitPrice=@UnitPrice,@CategoryId=@CategoryId where DishId=@DishId";
            SqlParameter[] param = new SqlParameter[]
            {
                    new SqlParameter("@DishName",objDish.DishName),
                    new SqlParameter("@UnitPrice",objDish.UnitPrice),
                    new SqlParameter("@CategoryId",objDish.CategoryId),
                    new SqlParameter("@DishId",objDish.DishId)

            };
            return SQLHelper.Update(sql, param);
        }

        #endregion

    }
}
