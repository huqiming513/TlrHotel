using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HotelWebProject.CompanyInfo
{
    public partial class RecruitmentDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string postId = Request.QueryString["PostId"];
                if(postId !=null&&postId!="")
                {

                }
                else
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            
        }
    }
}