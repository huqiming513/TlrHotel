using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelWebProject.Adminhyl
{
    public partial class BookManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          if(!IsPostBack)
            {
                this.rptList.DataSource = new DAL.DishBookService().GetAllDishBook();
                this.rptList.DataBind();
            }
        }
        protected void lbtnOperation(object sender, EventArgs e)
        {
            string bookId = ((LinkButton)sender).CommandArgument;
            string status = ((LinkButton)sender).CommandName;
            try
            {
                new DAL.DishBookService().ModifyBook(bookId, status);
                this.ltaMsg.Text = "<script>alert('操作成功')</script>";
                this.rptList.DataSource = new DAL.DishBookService().GetAllDishBook();
                this.rptList.DataBind();
            }
            catch (Exception ex)
            {

                this.ltaMsg.Text = "<script>alert('操作失败')</script>";
            }
        }


    }
}