using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using Models;
using Newtonsoft.Json;

namespace HotelWebProject.Pages
{
    public partial class DishesShow : System.Web.UI.Page
    {
        public static DishOrder dishOrder;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.rptList.DataSource = new DAL.DishService().GetDishes("");
                this.rptList.DataBind();
            }
        }
          
        /// <summary>
        /// 接收前台发送的桌号和订单详情，返回完整订单信息
        /// </summary>
        /// <param name="deskId">桌号</param>
        /// <param name="orderDetails">订单详情</param>
        /// <returns></returns>
        [WebMethod]
        public static string GetDishOrder(int deskId,List<DishOrderDetail> orderDetails)
        {
            dishOrder = new DAL.DishService().GenerateDishOrder(deskId, orderDetails);
            return JsonConvert.SerializeObject(dishOrder);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            HttpResult res = new DAL.DishService().SaveDishOrder(dishOrder);
            if (res.Status)
            {
                Alert("提交成功");
            }else
            {
                Alert("提交失败");
            }
        }

        private void Alert(string msg)
        {
            Response.Write(string.Format("<script>alert('{0}');</script>", msg));
        }
    }
}