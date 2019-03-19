using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Default2 : System.Web.UI.Page
{
    public SQLContext DBContext;
    public SqlCommand _SqlCommand;
    public SqlDataAdapter _SqlDataAdapter;
    public SqlDataReader _SqlDataReader;
    public DataTable _DataTable;
    public string cookieUserId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DBContext = new SQLContext();
        HttpCookie DairyUser = Request.Cookies["DairyUser"];
        try
        {
            if (DairyUser["UserId"].ToString().Length > 0)
            {                
                cookieUserId = DairyUser["UserId"].ToString();           
            }            
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Default.aspx", false);
        }
    }
    public void loadData()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select Flt_Udtl_reqMor,Flt_Udtl_reqEve from Tbl_User_Details where Var_Udtl_Uid='" + cookieUserId + "'", DBContext._SqlConnection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TxtReqMor.Text = dr.GetValue(0).ToString();
                TxtReqEve.Text = dr.GetValue(1).ToString();
            }
            MyServerControlDiv.Controls.Add(new LiteralControl("<div class='alert alert-info alert-dismissible' style='margin-top:8px;' role='alert'>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("Your<strong> current requirements </strong>are above!"));
            MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));
            dr.Close();
        }
        catch (Exception ex) {
            Response.Redirect("ReqError.aspx");
        }
    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        try {
            SqlCommand cmd = new SqlCommand("update Tbl_User_Details set Flt_Udtl_reqMor=" + TxtReqMor.Text + ",Flt_Udtl_reqEve=" + TxtReqEve.Text + " where Var_Udtl_Uid='" + cookieUserId + "'", DBContext._SqlConnection);
            cmd.ExecuteNonQuery();         
            MyServerControlDiv.Controls.Add(new LiteralControl("<div class='alert alert-success alert-dismissible' style='margin-top:8px;' role='alert'>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("Your<strong> requirements </strong>are updated!"));
            MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));
        }
        catch (Exception ex)
        {
            Response.Redirect("ReqError.aspx");
        }
    }

    protected void BtnCurrent_Click(object sender, EventArgs e)
    {
        loadData(); 
    }
}