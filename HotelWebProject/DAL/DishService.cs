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
    public class DishService
    {
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
        /// <summary>
        /// 新增菜品返回ID
        /// </summary>
        /// <param name="objDish"></param>
        /// <returns></returns>
        public int AddDish(Dish objDish)
        {
            string sql = "insert into Dishes(DishName,UnitPrice,CategoryId)";
            sql += "values(@DishName,@UnitPrice,@CategoryId);select @@identity";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@DishName",objDish.DishName),
                new SqlParameter("@UnitPrice",objDish.UnitPrice),
                new SqlParameter("@CategoryId",objDish.CategoryId)
            };
            string ss = sql;
            return Convert.ToInt32(SQLHelper.GetSingleResult(sql,param));
        }

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
        public int ModifyDish(Dish objDish)
        {
            String sql = "update Dishes set DishName=@DishName,UnitPrice=@UnitPrice,@CategoryId=@CategoryId where DishId=@DishId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@DishName",objDish.DishName),
                new SqlParameter("@UnitPrice",objDish.UnitPrice),
                new SqlParameter("@CategoryId",objDish.CategoryId),
                new SqlParameter("@DishId",objDish.DishId)

            };
            return SQLHelper.Update(sql,param);
        }
        public int DeleteDish(string dishId)
        {
            string sql = "delete from Dishes where DishId=@DishId";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@DishId", dishId) };
            return SQLHelper.Update(sql, param);
        }
    }
}
