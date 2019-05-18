using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HotelWebProject.Pages
{
    public partial class DishesBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ddlRoomType.DataValueField = "CategoryId";
                this.ddlRoomType.DataTextField = "CategoryName";
                this.ddlRoomType.DataSource = new DAL.RoomService().GetAllCategory();
                this.ddlRoomType.DataBind();
            }
        }

  
        protected void btnBook_Click(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(this.ddlOrderType.SelectedValue))
            {
                case 1:
                    SubmitDeskOrder();
                    break;
                case 2:
                    SubmitRoomOrder();
                    break;
                default:
                    break;
            }
            

        }

        private void SubmitDeskOrder()
        {
           
            if (this.txtConsumeTime.Text.Trim().Length == 0)
            {
                ShowMessageAlert("请输入消费时间!");
                return;
            }
            if (this.txtPersons.Text.Trim().Length == 0)
            {
                ShowMessageAlert("请输入消费人数!");
                return;
            }
            if (this.ddlDeskType.SelectedIndex == -1)
            {
                ShowMessageAlert("请选择包间类型!");
                return;
            }
            if (this.txtCustomerName.Text.Trim().Length == 0)
            {
                ShowMessageAlert("请输入预订人姓名!");
                return;
            }
            if (this.txtPersons.Text.Trim().Length == 0)
            {
                ShowMessageAlert("请输入联系电话!");
                return;
            }
            if (this.txtValidateCode.Text.Trim().Length == 0)
            {
                ShowMessageAlert("请输入验证码!");
                return;
            }
            if (this.txtValidateCode.Text.Trim() != Session["CheckCode"].ToString())
            {
                ShowMessageAlert("验证码不正确!");
                return;
            }

            DeskOrder objDishBook = new DeskOrder()
            {
                CustomerName = this.txtCustomerName.Text.Trim(),
                ConsumeTime = Convert.ToDateTime(this.txtConsumeTime.Text),
                CustomerPhone = this.txtPhoneNumber.Text.Trim(),
                ConsumePersons = Convert.ToInt32(this.txtPersons.Text),
                DeskType = this.ddlDeskType.Text,
                Comments = this.txtComment.Text.Trim() == "" ? "无" : this.txtComment.Text.Trim()
            };

            try
            {
                new DAL.DeskService().OrderBook(objDishBook);
                this.ltaMsg.Text = "<script>alert('预定成功');location.href='/Pages/Default.aspx'</script>";
            }
            catch (Exception ex)
            {
                ShowMessageAlert("提交失败" + ex.Message);
            }
        }
        private void SubmitRoomOrder()
        {

            if (this.tbCheckInTime.Text.Trim().Length == 0)
            {
                ShowMessageAlert("请选择预计入住时间!");
                return;
            }
            if (this.tbCheckOutTime.Text.Trim().Length == 0)
            {
                ShowMessageAlert("请选择预计退房时间!");
                return;
            }
            if (this.ddlRoomType.SelectedIndex == -1)
            {
                ShowMessageAlert("请选择房间类型!");
                return;
            }
            if (this.txtCustomerName.Text.Trim().Length == 0)
            {
                ShowMessageAlert("请输入预订人姓名!");
                return;
            }
            if (this.txtPhoneNumber.Text.Trim().Length == 0)
            {
                ShowMessageAlert("请输入联系电话!");
                return;
            }
            if (this.txtValidateCode.Text.Trim().Length == 0)
            {
                ShowMessageAlert("请输入验证码!");
                return;
            }
            if (this.txtValidateCode.Text.Trim() != Session["CheckCode"].ToString())
            {
                ShowMessageAlert("验证码不正确!");
                return;
            }

            RoomOrder roomBook = new RoomOrder()
            {
                CheckInTime = Convert.ToDateTime(this.tbCheckInTime.Text),
                CheckOutTime = Convert.ToDateTime(this.tbCheckOutTime.Text),
                RoomCategoryId = Convert.ToInt32(this.ddlRoomType.SelectedValue),
                CustomerName = this.txtCustomerName.Text.Trim(),
                CustomerPhone = this.txtPhoneNumber.Text.Trim(),
                Comments = this.txtComment.Text.Trim() == "" ? "无" : this.txtComment.Text.Trim()
            };

            try
            {
                new DAL.RoomService().OrderBook(roomBook);

                this.ltaMsg.Text = "<script>alert('预定成功');location.href='/Pages/Default.aspx'</script>";
            }
            catch (Exception ex)
            {
                ShowMessageAlert("提交失败" + ex.Message);
            }
        }


        private void ShowMessageAlert(string msg)
        {
            this.ltaMsg.Text = string.Format("<script>alert(\"{0}\")</script>", msg);
        }
    }
}