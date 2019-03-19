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
    }

    protected void BtnRaise_Click(object sender, EventArgs e)
    {
        try
        {
            String CompId = getComplaintID();
            SqlCommand cmd = new SqlCommand("insert into Tbl_User_Complaints values('" + CompId + "','" + cookieUserId + "','" + TxtAreaComplaint.Text + "')", DBContext._SqlConnection);
            cmd.ExecuteNonQuery();
            MyServerControlDiv.Controls.Add(new LiteralControl("<div class='alert alert-info alert-dismissible' style='margin-top:8px;' role='alert'>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("Your complaint has been<strong> received.</strong> we will respond you back shortly, <strong>Thankyou.</strong>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));
        }
        catch (Exception ex)
        {
            Response.Redirect("ReqError.aspx");
        }
    }
    public string getComplaintID()
    {
        string count = "0";
        SqlCommand cmd = new SqlCommand("select count(*) from Tbl_User_Complaints", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            count = dr.GetValue(0).ToString();
        }
        int nc = Convert.ToInt32(count);
        nc++;
        string ncount = nc.ToString();
        string CompId = "Com" + ncount;
        dr.Close();
        return CompId;
    }
}