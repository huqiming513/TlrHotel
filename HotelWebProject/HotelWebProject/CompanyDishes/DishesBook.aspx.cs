using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HotelWebProject.CompanyDishes
{
    public partial class DishesBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            if(this.txtCustomerName.Text.Trim().Length==0)
            {
                this.ltaMsg.Text = "<script>alert('请输入姓名!')</script>";
                return;
            }
            if (this.txtConsumeTime.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入消费时间!')</script>";
                return;
            }
            if (this.txtPersons.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入消费人数!')</script>";
                return;
            }
            if (!Common.DataValidate.IsInteger(this.txtPersons.Text.Trim()))
            {
                this.ltaMsg.Text = "<script>alert('消费人数为整数!')</script>";
                return;
            }
            if (this.txtPersons.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入联系电话!')</script>";
                return;
            }
            if (this.ddlRoomType.SelectedIndex==-1)
            {
                this.ltaMsg.Text = "<script>alert('请选择包间类型!')</script>";
                return;
            }
            if (this.ddlHotelName.SelectedIndex == -1)
            {
                this.ltaMsg.Text = "<script>alert('请选择分店名称!')</script>";
                return;
            }
            if (this.txtValidateCode.Text.Trim().Length== 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入验证码')</script>";
                return;
            }
            if(this.txtValidateCode.Text.Trim()!=Session["CheckCode"].ToString())
            {
                this.ltaMsg.Text = "<script>alert('验证码不正确')</script>";
                return;
            }
            Models.DIshBook objDishBook = new Models.DIshBook()
            {
                CustomerName = this.txtCustomerName.Text.Trim(),
                HotelName = this.ddlHotelName.Text,
                ConsumeTime = Convert.ToDateTime(this.txtConsumeTime.Text),
                CustomerPhone = this.txtPhoneNumber.Text.Trim(),
                CustomerEmail = this.txtEmail.Text.Trim(),
                ConsumePersons = Convert.ToInt32(this.txtPersons.Text),
                RoomType = this.ddlRoomType.Text,
                Comments = this.txtComment.Text.Trim() == "" ? "无" : this.txtComment.Text.Trim()
            };
            try
            {
                this.ltaMsg.Text = "<script>alert('预定成功')</script>";
                new DAL.DishBookService().Book(objDishBook);
                this.ltaMsg.Text = "<script>alert('预定成功');location.href='/Default.aspx'</script>";
               
            }
            catch (Exception ex)
            {

                this.ltaMsg.Text = "<script>alert('提交失败"+ex.Message+"')</script>";
            }

        }
    }
}