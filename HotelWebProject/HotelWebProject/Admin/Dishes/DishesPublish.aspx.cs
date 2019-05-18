using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
namespace HotelWebProject.Admin
{
    public partial class DishesPublish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                this.ddlCategory.DataValueField = "CategoryId";
                this.ddlCategory.DataTextField = "CategoryName";
                this.ddlCategory.DataSource = new DAL.DishService().GetAllCategory();
                this.ddlCategory.DataBind();
                if(Request.QueryString["Operation"]== "0")
                {
                    this.btnEdit.Visible = false;
                }
                else if(Request.QueryString["Operation"]=="1")
                {
                    this.btnPublish.Visible = false;
                    string dishId = Request.QueryString["DishId"];
                    if(dishId == null ||dishId=="")
                    {
                        Response.Redirect("~/Admin/Defalut.aspx");
                        return;
                    }
                    Dish objDish = new DAL.DishService().GetDishById(dishId);
                    if(objDish == null)
                    {
                        Response.Redirect("~/Admin/Defalut.aspx");
                        return;
                    }
                    ViewState["dishId"] = dishId;
                    //显示信息
                    this.txtDishName.Text = objDish.DishName;
                    this.txtUnitPrice.Text = objDish.UnitPrice.ToString();
                    this.ddlCategory.SelectedValue = objDish.CategoryId.ToString();
                    this.dishImage.ImageUrl = "~/Images/dish/" + dishId + ".png";
                 
                }
            }
            this.ltaMsg.Text = "";
           
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            if(this.txtDishName.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入菜品名称！')</script>";
                return;
            }
            if(this.ddlCategory.SelectedIndex == -1)
            {
                this.ltaMsg.Text = "<script>alert('请输入菜品分类！')</script>";
                return;
            }
            if(this.txtUnitPrice.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入菜品价格！')</script>";
                return;
            }
            if(!Common.DataValidate.IsInteger(this.txtUnitPrice.Text.Trim()))
            {
                this.ltaMsg.Text = "<script>alert('菜品价格必须是整数')</script>";
                return;
            }
            //封装对象
            Models.Dish objDish = new Dish()
            {
                DishName = this.txtDishName.Text.Trim(),
                UnitPrice = Convert.ToInt32(this.txtUnitPrice.Text.Trim()),
                CategoryId = Convert.ToInt32(this.ddlCategory.SelectedValue)
            };
            if(ViewState["dishId"]!=null)//如果是修改则需要封装菜品编号
            {
                objDish.DishId = Convert.ToInt32(ViewState["dishId"]);
            }
            //提交数据
            try
            {
                if(this.btnPublish.Visible)
                {
                    if(!this.fulImage.HasFile)//如果是新增则需要选择图片
                    {
                        this.ltaMsg.Text = "<script>alert('请选择菜品照片！')</script>";
                        return;
                    }
                    //提交菜品信息，并返回菜品编号
                    this.ltaMsg.Text = "<script>alert('"+objDish.DishName.Trim()+"')</script>";
                    int dishId = new DAL.DishService().AddDish(objDish);
                    //上传图片
                    this.UploadImage(dishId);
                    this.ltaMsg.Text = "<script>alert('添加成功')</script>";
                    //清空以前输入的内容
                    this.txtDishName.Text = "";
                    this.txtUnitPrice.Text = "";
                    this.ddlCategory.SelectedIndex = -1;


                }
                else
                {
                    new DAL.DishService().ModifyDish(objDish);
                    //上传图片
                    this.UploadImage(objDish.DishId);
                    // this.ltaMsg.Text = "<script>alert('修改成功')</script>";
                    Response.Write("<script>location.href='/Admin/Dishes/DishesManager.aspx';</script>");

                }
            }catch(Exception ex)
            {
                this.ltaMsg.Text = "<script>alert('添加失败!" + ex.Message + "')</script>";

            }
          
        }
        private void UploadImage(int dishId)
        {
            if (!this.fulImage.HasFile) return;
            double fileLength = this.fulImage.FileContent.Length / (1024.0 * 1024.0);
            if(fileLength>2.0)
            {
                this.ltaMsg.Text = "<script>alert('图片最大不能超过2M！')</script>";
                return;
            }
            String fileName = this.fulImage.FileName;
            if (fileName.Substring(fileName.LastIndexOf(".")).ToLower() != ".png")
            {
                this.ltaMsg.Text = "<script>alert('图片格式不对！')</script>";
            }
            fileName = dishId + ".png";
            try
            {
                string path = Server.MapPath("~/Images/dish");
                this.fulImage.SaveAs(path + "/" + fileName);

            }catch(Exception ex)
            {
                this.ltaMsg.Text = "<script>alert('图片删除失败!" + ex.Message + "')</script>";
            }
        }
    }
}