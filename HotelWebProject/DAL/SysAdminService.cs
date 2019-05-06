using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using Models;
/// <summary>
/// 管理员数据访问
/// </summary>
namespace DAL
{
   public class SysAdminService
    {
        public SysAdmin AdminLogin(string loginId,string loginPwd)
        {
            string sql = "select LoginName from SYsAdmins where LoginId=@LoginId and LoginPwd=@LoginPwd";
            SqlParameter[] param = new SqlParameter[]
            {
            new SqlParameter("@LoginId",loginId),
            new SqlParameter("@LoginPwd", loginPwd)
            };
            SysAdmin objAdmin = null;
            object result = SQLHelper.GetSingleResult(sql, param);
            if(result!=null)
            {
                objAdmin = new SysAdmin()
                {
                    LoginId = Convert.ToInt32(loginId),
                    LoginName = result.ToString(),
                    LoginPwd = loginId
                };
            }
            return objAdmin;
        }
    }
}
