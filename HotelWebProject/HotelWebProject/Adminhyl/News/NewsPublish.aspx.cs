using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;
using DAL;
namespace HotelWebProject.Adminhyl
{
    public partial class NewsPublish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //判断修改还是发布
                if (Request.QueryString["Operation"] == "0")
                {
                    this.btnModify.Visible = false;
                }
                else if (Request.QueryString["Operation"] == "1")
                {
                    this.btnPublish.Visible = false;
                    string newsId = Request.QueryString["newsId"];
                    ViewState["newsId"] = newsId;
                    News objNews = new NewsService().GetNewsById(newsId);
                    if (objNews == null) Response.Redirect("~/Adminhyl/Default.aspx");
                    else
                    {
                        this.txtContent.Value = objNews.NewsContents;
                        this.txtNewsTitle.Text = objNews.NewsTitle;
                        this.ddlCategory.SelectedValue = objNews.CategoryId.ToString();
                    }

                }
                else Response.Redirect("~/Adminhyl/Default.aspx");
            }
            this.ltaMsg.Text = "";
        }
        //发布和修改新闻
        protected void btnPublish_Click(object sender, EventArgs e)
        {
            // this.ltaMsg.Text = "<script>alert('请输入新闻标题!')</script>";
            if (this.txtNewsTitle.Text.Trim().Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入新闻标题!')</script>";
                return;
            }
            if (this.txtContent.Value.Length == 0)
            {
                this.ltaMsg.Text = "<script>alert('请输入新闻内容!')</script>";
                return;
            }
            if (this.ddlCategory.SelectedIndex == -1)
            {
                this.ltaMsg.Text = "<script>alert('请选择新闻分类!')</script>";
                return;
            }
            // this.ltaMsg.Text = "<script>alert('"+this.txtNewsTitle.Text.Trim()+"')</script>";
            //this.ltaMsg.Text = "<script>alert('" + this.txtContent.Value + "')</script>";
            //this.ltaMsg.Text = "<script>alert('" + this.txtNewsTitle + "')</script>";
            //封装新闻对象
            News objNews = new News()
            {
                NewsTitle = this.txtNewsTitle.Text.Trim(),
                CategoryId = Convert.ToInt32(this.ddlCategory.SelectedValue),
                NewsContents = this.txtContent.Value
            };
            if (ViewState["newsId"] != null)
            {
                objNews.NewsId = Convert.ToInt32(ViewState["newsId"]);
            }
            try
            {

                if (this.btnPublish.Visible)
                {

                    new NewsService().PublishNews(objNews);
                    Response.Write("<script>alert('发布成功');location.href='/Adminhyl/News/NewsManager.aspx'</script>");
                    this.txtContent.Value = "";
                    this.txtNewsTitle.Text = "";
                    this.ddlCategory.SelectedIndex = -1;
                    //return;
                }
                else
                {
                    new NewsService().ModifyNews(objNews);
                    this.ltaMsg.Text = "<script>alert('修改成功')</script>";
                }
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text =string.Format("<script>alert('提交失败:{0}')</script>",ex.Message.ToString());
            }

        }
    }
}