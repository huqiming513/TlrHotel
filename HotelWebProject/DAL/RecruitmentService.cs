using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Data.SqlClient;
namespace DAL
{
    public class RecruitmentService
    {
        public int PublishRecruitment(Recruitment objRecruitment)
        {
            string sql = "insert into Recruitment(PostName,PostType,PostPlace,PostDesc,";
            sql += "PostRequire,Experience,EduBackground,RequireCount,";
            sql += "Manager,PhoneNumber,Email)";
            sql += "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')";
            sql = string.Format(sql, objRecruitment.PostName,
                objRecruitment.PostName,
                objRecruitment.PostPlace,
                objRecruitment.PostDesc,
                objRecruitment.PostRequire,
                objRecruitment.Experience,
                objRecruitment.EduBackground,
                objRecruitment.RequireCount,
                objRecruitment.Manager,
                objRecruitment.PhoneNumber,
                objRecruitment.Email);
            return SQLHelper.Update(sql);
        }
        public List<Recruitment> GetAllRecList()
        {
            string sql = "select PostId,PostName,PostType,PostPlace,PostDesc,PostRequire,Experience,EduBackground,RequireCount,Manager,PhoneNumber,Email from Recruitment";
            List<Recruitment> list = new List<Recruitment>();
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            while(objReader.Read())
            {
                list.Add(new Recruitment()
                {
                    PostId = Convert.ToInt32(objReader["PostId"]),
                    PostName = objReader["PostName"].ToString(),
                    PostPlace = objReader["PostPlace"].ToString(),
                    RequireCount = Convert.ToInt32(objReader["RequireCount"]),
                    PostType = objReader["PostType"].ToString(),
                    PostRequire = objReader["PostRequire"].ToString(),
                    Experience = objReader["Experience"].ToString(),
                    EduBackground = objReader["EduBackground"].ToString(),
                    Manager = objReader["Manager"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    Email = objReader["Email"].ToString(),

                });
                
            }
            objReader.Close();
            return list;
        }
    }
}
