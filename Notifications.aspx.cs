using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    SQLContext DBContext;
    public string cookieUserId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DBContext = new SQLContext();
        HttpCookie DairyUser = Request.Cookies["DairyUser"];
        cookieUserId = DairyUser["UserId"].ToString();
        getNotifications();
    }
    protected void BtnPay_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://retail.onlinesbi.com/retail/login.htm");
    }
    public void getNotifications()
    {
        SqlCommand cmd = new SqlCommand("select Var_Unot_UNotification from Tbl_User_Notifications where  Var_Unot_UId='"+ cookieUserId + "'", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        int i = 0;
        while (dr.Read())
        {
            i++;
            MyServerControlDiv.Controls.Add(new LiteralControl("<div class='alert alert-info alert-dismissible' role='alert'>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert'><span aria-hidden='true'>&times;</span></button>"));     
            MyServerControlDiv.Controls.Add(new LiteralControl("<strong> No: "+i+" </strong>"+dr.GetValue(0).ToString()+"."));
            MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));            
        }
        if (i == 0)
        {
            MyServerControlDiv.Controls.Add(new LiteralControl("<div class='alert alert-success alert-dismissible' role='alert'>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<strong> No notifications Yet! </strong>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));
        }
        dr.Close();
    }
}