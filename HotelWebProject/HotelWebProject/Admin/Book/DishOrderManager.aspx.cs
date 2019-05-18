using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelWebProject.Admin.Book
{
    public partial class DishOrderManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDishOrder();
            }
        }

        protected void lbtnOperation(object sender, EventArgs e)
        {
            int orderId = Convert.ToInt32(((LinkButton)sender).CommandArgument);

            this.ltaMsg.Text = string.Format("<script>app.dishOrder = JSON.parse('{0}');$('#myModal').modal('show');</script>", JsonConvert.SerializeObject(new DAL.DishService().GetDishOrderById(orderId)));
        }

        /// <summary>
        /// 更新DeskOrder显示
        /// </summary>
        public void BindDishOrder()
        {
            this.rptList.DataSource = new DAL.DishService().GetDishOrder();
            this.rptList.DataBind();
        }
    }
}