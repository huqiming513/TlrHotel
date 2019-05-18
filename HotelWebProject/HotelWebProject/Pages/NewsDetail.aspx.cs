using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

namespace HotelWebProject.Pages
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string newsId = Request.Params["NewsId"];
                if(newsId!=null&&newsId!=string.Empty)
                {
                    News objNews = new DAL.NewsService().GetNewsById(newsId);
                    if(objNews==null)
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        this.newsContents.InnerHtml = objNews.NewsContents;
                        this.newsTitle.InnerText = objNews.NewsTitle;
                        this.publishTime.InnerText = "发布时间：" + objNews.PublishTime.ToShortDateString();
                    }
                }
            }
         
        }
    }
}