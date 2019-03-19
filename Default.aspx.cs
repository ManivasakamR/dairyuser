using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    public SQLContext DBContext;
    public SqlCommand _SqlCommand;
    public SqlDataAdapter _SqlDataAdapter;
    public SqlDataReader _SqlDataReader;
    public DataTable _DataTable;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        DBContext = new SQLContext();
        
        HttpCookie DairyUser = Request.Cookies["DairyUser"];
        try
        {
            if (DairyUser["UserId"].ToString().Length > 0)
            {
                Response.Redirect("Purchase.aspx",false);
            }
        }
        catch (Exception ex) {
            
        }
        
        
        
    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {

        checkUser();
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
    public void checkUser() {
        string userId = "";        
        int count = 0;        
        SqlCommand cmd = new SqlCommand("select count(*) from Tbl_User_Details where Var_Udtl_Email='" + TxtUsername.Text+ "' and Var_Udtl_Password='"+TxtPassword.Text+"'", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            count = dr.GetInt32(0);
        }                        
        dr.Close();
        if (count != 1)
        {            
            MyServerControlDiv.Controls.Add(new LiteralControl("<div class='alert alert-danger alert-dismissible' style='margin-top:5px;' role='alert'>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<strong> Invalid email or password! </strong> try again "));
            MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));
        }
        else
        {            
            cmd = new SqlCommand("select Var_Udtl_Uid from Tbl_User_Details where Var_Udtl_Email='" + TxtUsername.Text + "' and Var_Udtl_Password='" + TxtPassword.Text + "'", DBContext._SqlConnection);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                userId = dr.GetValue(0).ToString();
            }            
            dr.Close();
            HttpCookie DairyUser = new HttpCookie("DairyUser");
            DairyUser["UserId"] = userId;
            DairyUser.Expires.Add(new TimeSpan(168, 0, 0));
            Response.Cookies.Add(DairyUser);
            Response.Redirect("Purchase.aspx", false);
        }        
    }

    protected void TxtUsername_TextChanged(object sender, EventArgs e)
    {                     
    }
}