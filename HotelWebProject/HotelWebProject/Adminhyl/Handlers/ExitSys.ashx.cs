using System.Web;
using System.Web.SessionState;
namespace HotelWebProject.Adminhyl.Handlers
{
    /// <summary>
    /// ExitSys 的摘要说明
    /// </summary>
    public class ExitSys : IHttpHandler,IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Session.Abandon();
            context.Response.Redirect("~/Adminhyl/AdminLogin.aspx");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}