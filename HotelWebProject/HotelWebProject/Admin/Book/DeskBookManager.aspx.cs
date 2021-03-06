﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelWebProject.Admin
{
    public partial class DeskBookManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindDeskOrder();
            }
        }
        protected void lbtnOperation(object sender, EventArgs e)
        {
            string bookId = ((LinkButton)sender).CommandArgument;
            string status = ((LinkButton)sender).CommandName;
            try
            {
                new DAL.DeskService().ModifyOrderStatus(bookId, status);
                BindDeskOrder();
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script>alert('操作失败')</script>";
            }
        }

        /// <summary>
        /// 更新DeskOrder显示
        /// </summary>
        public void BindDeskOrder()
        {
            this.rptList.DataSource = new DAL.DeskService().GetAllDeskOrder();
            this.rptList.DataBind();
        }

    }
}