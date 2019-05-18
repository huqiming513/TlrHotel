using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelWebProject.Admin.Room
{
    public partial class RoomManager : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DAL.DishService objService = new DAL.DishService();
                //显示所有房间
                BindRoomCategory();
            }

        }

        protected void lbtnDel_Click(object sender, EventArgs e)
        {
            string categoryId = ((LinkButton)sender).CommandArgument;
            try
            {
                new DAL.RoomService().DeleteRoom(categoryId);
                //刷新
                BindRoomCategory();
            }
            catch (Exception ex)
            {

                this.ltaMsg.Text = "<script>alert('删除失败!" + ex.Message + "')</script>";
            }
        }

        public void BindRoomCategory()
        {
            this.rptList.DataSource = new DAL.RoomService().GetAllCategory();
            this.rptList.DataBind();
        }
    
    }
}