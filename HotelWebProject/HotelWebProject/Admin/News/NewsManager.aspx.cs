using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HotelWebProject.Admin
{
    public partial class NewsManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.rptList.DataSource = new DAL.NewsService().GetNews(50);
                this.rptList.DataBind();

            }
         
        }       
        protected void btn_Click(object sender,EventArgs e)
        {
            string newsId = ((LinkButton)sender).CommandArgument;
            try
            {
                new DAL.NewsService().DeleteNews(newsId);
                this.rptList.DataSource = new DAL.NewsService().GetNews(50);
                this.rptList.DataBind();

            }
            catch (Exception ex)
            {

                this.ltaMsg.Text = "<script>alert('删除失败!"+ex.Message+"')</script>";
            }
        }
    }
}