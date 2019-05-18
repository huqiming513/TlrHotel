using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
namespace HotelWebProject.Admin.Room
{
    public partial class RoomPublish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Operation"] == "0")
                {
                    this.btnEdit.Visible = false;
                }
                else if (Request.QueryString["Operation"] == "1")
                {
                    this.btnPublish.Visible = false;
                    string categoryId = Request.QueryString["CategoryId"];
                    if (categoryId == null || categoryId == "")
                    {
                        Response.Redirect("~/Admin/Defalut.aspx");
                        return;
                    }
                    RoomCategory room = new DAL.RoomService().GetRoomById(categoryId);
                    if (room == null)
                    {
                        Response.Redirect("~/Admin/Defalut.aspx");
                        return;
                    }
                    ViewState["CategoryId"] = categoryId;
                    //显示信息
                    this.txtDishName.Text = room.CategoryName;
                    this.txtUnitPrice.Text = room.UnitPrice.ToString();
                    this.dishImage.ImageUrl = "~/Images/room/" + categoryId + ".jpg";

                }
            }
            this.ltaMsg.Text = "";

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            if (this.txtDishName.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入房间名称！')</script>";
                return;
            }
            if (this.txtUnitPrice.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入房间价格！')</script>";
                return;
            }
          
            //封装对象
            RoomCategory room = new RoomCategory()
            {
                CategoryName = this.txtDishName.Text.Trim(),
                UnitPrice = Convert.ToInt32(this.txtUnitPrice.Text.Trim()),
            };
            if (ViewState["CategoryId"] != null)//如果是修改则需要封装菜品编号
            {
                room.CategoryId = Convert.ToInt32(ViewState["CategoryId"]);
            }
            //提交数据
            try
            {
                if (this.btnPublish.Visible)
                {
                    if (!this.fulImage.HasFile)//如果是新增则需要选择图片
                    {
                        this.ltaMsg.Text = "<script>alert('请选择房间照片！')</script>";
                        return;
                    }
                    //提交菜品信息，并返回菜品编号
                    this.ltaMsg.Text = "<script>alert('" + room.CategoryName.Trim() + "')</script>";
                    int dishId = new DAL.RoomService().AddRoom(room);
                    //上传图片
                    this.UploadImage(dishId);
                    this.ltaMsg.Text = "<script>alert('添加成功')</script>";
                    //清空以前输入的内容
                    this.txtDishName.Text = "";
                    this.txtUnitPrice.Text = "";

                }
                else
                {
                    new DAL.RoomService().ModifyRoom(room);
                    //上传图片
                    this.UploadImage(room.CategoryId);
                    // this.ltaMsg.Text = "<script>alert('修改成功')</script>";
                    Response.Write("<script>location.href='/Admin/Dishes/DishesManager.aspx';</script>");

                }
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script>alert('添加失败!" + ex.Message + "')</script>";

            }

        }
        private void UploadImage(int dishId)
        {
            if (!this.fulImage.HasFile) return;
            double fileLength = this.fulImage.FileContent.Length / (1024.0 * 1024.0);
            if (fileLength > 2.0)
            {
                this.ltaMsg.Text = "<script>alert('图片最大不能超过2M！')</script>";
                return;
            }
            String fileName = this.fulImage.FileName;
            if (fileName.Substring(fileName.LastIndexOf(".")).ToLower() != ".jpg")
            {
                this.ltaMsg.Text = "<script>alert('图片格式不对！')</script>";
            }
            fileName = dishId + ".jpg";
            try
            {
                string path = Server.MapPath("~/Images/room");
                this.fulImage.SaveAs(path + "/" + fileName);

            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script>alert('图片删除失败!" + ex.Message + "')</script>";
            }
        }
    }
}