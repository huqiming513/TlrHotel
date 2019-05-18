using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelWebProject.Admin
{
    public partial class DishesManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DAL.DishService objService = new DAL.DishService();
                //初始化下拉框
                this.ddlCategory.DataValueField = "CategoryId";
                this.ddlCategory.DataTextField = "CategoryName";
                this.ddlCategory.DataSource = new DAL.DishService().GetAllCategory();
                this.ddlCategory.DataBind();
                //显示所有菜品
                this.rptList.DataSource = objService.GetDishes(null);
                this.rptList.DataBind();
            }
           
        }
        //根据编号查询
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            this.rptList.DataSource = new DAL.DishService().GetDishes(this.ddlCategory.SelectedValue.ToString());
            this.rptList.DataBind();
        }
        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            string dishId = ((LinkButton)sender).CommandArgument;
            try
            {
                new DAL.DishService().DeleteDish(dishId);
                //刷新
                this.rptList.DataSource = new DAL.DishService().GetDishes("");
                this.rptList.DataBind();
            }
            catch (Exception ex)
            {

                this.ltaMsg.Text = "<script>alert('删除失败!" + ex.Message + "')</script>";
            }
        }
    }
}