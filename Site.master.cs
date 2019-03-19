﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSignOff_Click(object sender, EventArgs e)
    {
        HttpCookie DairyUser = new HttpCookie("DairyUser");
        DairyUser["UserId"] = "";
        DairyUser.Expires.Add(new TimeSpan(0, 0, 0));
        Response.Cookies.Add(DairyUser);
        Response.Redirect("Purchase.aspx", false);
    }
}
