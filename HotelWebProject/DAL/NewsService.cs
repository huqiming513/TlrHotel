using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    /// <summary>
    /// 新闻管理数据访问类
    /// </summary>
    public class NewsService
    {
        public int PublishNews(News objNews)
        {
            string sql = "INSERT INTO News(NewsTitle,NewsContents,CategoryId) VALUES(@NewsTitle,@NewsContents,@CategoryId)";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NewsTitle",objNews.NewsTitle),
                new SqlParameter("@NewsContents",objNews.NewsContents),
                new SqlParameter("@CategoryId",objNews.CategoryId),

            };
            return SQLHelper.Update(sql, param);
        }
        public int ModifyNews(News objNews)
        {
            string sql = "update News set NewsTitle=@NewsTitle,NewsContents=@NewsContents,CategoryId=@CategoryId where NewsId=@NewsId;";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NewsTitle",objNews.NewsTitle),
                new SqlParameter("@NewsContents",objNews.NewsContents),
                new SqlParameter("@CategoryId",objNews.CategoryId),
                new SqlParameter("@NewsId",objNews.NewsId),
            };
            return SQLHelper.Update(sql, param);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public int DeleteNews(string newsId)
        {
            string sql = "delete from News where NewsId=@NewsId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NewsId",newsId)
            };
            return SQLHelper.Update(sql, param);
        }

        public List<News> GetNews(int count)
        {
            string sql = "select top " + count + " NewsId,NewsTitle,NewsContents,NewsCategory.CategoryId,CategoryName,PublishTime from News";
            sql += " inner join NewsCategory on NewsCategory.CategoryId=News.CategoryId Order by PublishTime DESC";
            List<News> list = new List<News>();
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while (objReader.Read())
            {
                list.Add(new News()
                {
                    NewsId = Convert.ToInt32(objReader["NewsId"]),
                    NewsTitle = objReader["NewsTitle"].ToString(),
                    CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                    CategoryName = objReader["categoryName"].ToString(),
                    PublishTime = Convert.ToDateTime(objReader["PublishTime"]),
                    NewsContents = objReader["NewsContents"].ToString()
                });
            }
            objReader.Close();
            return list;
        }
        /// <summary>
        /// 根据新闻ID查看
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public News GetNewsById(string newsId)
        {
            string sql = "select NewsId,NewsTitle,NewsContents,CategoryId,PublishTime from News where NewsId=@NewsId";
            SqlParameter[] param = new SqlParameter[]
             {
                new SqlParameter("@NewsId",newsId)
             };
            News objNews = null;
            SqlDataReader objReader = SQLHelper.GetReader(sql, param);
            if (objReader.Read())
            {
                objNews = new News()
                {
                    NewsId = Convert.ToInt32(objReader["NewsId"]),
                    NewsTitle = objReader["NewsTitle"].ToString(),
                    NewsContents = objReader["NewsContents"].ToString(),
                    CategoryId = Convert.ToInt32(objReader["CategoryId"]),
                    // CategoryName = objReader["categoryName"].ToString(),
                    PublishTime = Convert.ToDateTime(objReader["PublishTime"])
                };
            }
            objReader.Close();
            return objNews;
        }
    }
}
