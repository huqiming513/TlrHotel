﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelWebProject.Pages
{
    public partial class Environment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.rptList.DataSource = new DAL.RoomService().GetAllCategory();
                this.rptList.DataBind();
            }
        }
    }
}