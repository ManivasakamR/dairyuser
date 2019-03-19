using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Register : System.Web.UI.Page
{

    public SQLContext DBContext;
    public SqlCommand _SqlCommand;
    public SqlDataAdapter _SqlDataAdapter;
    public SqlDataReader _SqlDataReader;
    public DataTable _DataTable;
    protected void Page_Load(object sender, EventArgs e)
    {
        DBContext = new SQLContext();
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    protected void BtnRegister_Click1(object sender, EventArgs e)
    {
        int count = 0;
        SqlCommand cmd = new SqlCommand("select count(*) from Tbl_User_Details where Var_Udtl_Email='" + TxtEmail.Text + "'", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            count = dr.GetInt32(0);
        }
        dr.Close();

        if (count == 1)
        {
            MyServerControlDiv.Controls.Add(new LiteralControl("<div class='alert alert-danger alert-dismissible' style='margin-top:5px;' role='alert'>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<strong> Email already exists! </strong> Please try to register with another one. "));
            MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));
        }
        else
        {
            try
            {
                _SqlCommand = new SqlCommand();
                string userId = getUserID();
                string qry = "insert into Tbl_User_Details "
                    + "values('" + userId + "','" + TxtUsername.Text + "','" + TxtEmail.Text + "'," + TxtMobile.Text + ",'" + TxtCity.Text + "','" + TxtArea.Text + "','" + TxtApartment.Text + "','" + TxtDoor.Text + "'," + TxtRM.Text + "," + TxtRE.Text + "," + TxtPin.Text + ",'" + TxtPassword.Text + "','" + getQRCode() + "')";
                _SqlCommand = new SqlCommand(qry, DBContext._SqlConnection);
                _SqlCommand.ExecuteNonQuery();
                HttpCookie DairyUser = new HttpCookie("DairyUser");
                DairyUser["UserId"] = userId;
                DairyUser.Expires.Add(new TimeSpan(762, 0, 0));
                Response.Cookies.Add(DairyUser);
                sendWelcocmeNotifications(userId,TxtUsername.Text);
                Response.Redirect("Purchase.aspx", false);
            }
            catch (Exception exc)
            {
                Response.Redirect("ReqError.aspx");
            }
        }
    }
    public void sendWelcocmeNotifications(String _userId, String _userName)
    {
        string greetingMsg = "Hello "+_userName+"! we are welcome you to our application. we hope that you feel very happy with our service thankyou. Regards, team Divine Admin. ";
        string abtQr = "Dear "+_userName+ "! our delivery person need your qr identity on your door for carry our service better. Please find it on show qr menu in your app, print and stik on your door. thankyou. Regards, team Divine Admin.";
        string abtPay = "Dear " + _userName + "! our vendors need payment at the end of every month to do our service more efficient. Be aware about to pay at month endings. thankyou. Regards, team Divine Admin.";
        SqlCommand _SqlCommand1 = new SqlCommand("insert into Tbl_User_Notifications values('"+ getNotID() + "','"+_userId+"','"+ greetingMsg + "')", DBContext._SqlConnection);
        _SqlCommand1.ExecuteNonQuery();
        SqlCommand _SqlCommand2 = new SqlCommand("insert into Tbl_User_Notifications values('" + getNotID() + "','" + _userId + "','" + abtQr + "')", DBContext._SqlConnection);
        _SqlCommand2.ExecuteNonQuery();
        SqlCommand _SqlCommand3 = new SqlCommand("insert into Tbl_User_Notifications values('" + getNotID() + "','" + _userId + "','" + abtPay + "')", DBContext._SqlConnection);                
        _SqlCommand3.ExecuteNonQuery();
    }
    private string getNotID()
    {
        string count = "0";
        SqlCommand cmd = new SqlCommand("select count(*) from Tbl_User_Notifications", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            count = dr.GetValue(0).ToString();
        }
        int nc = Convert.ToInt32(count);
        nc++;
        string ncount = nc.ToString();
        string NotID = "DivineNotif00" + ncount;
        dr.Close();
        return NotID;
    }

    private string getUserID()
    {
        string count="0";
        SqlCommand cmd = new SqlCommand("select count(*) from Tbl_User_Details", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read()) {
            count = dr.GetValue(0).ToString();
        }
        int nc = Convert.ToInt32(count);
        nc++;
        string ncount = nc.ToString();
        string UserID = "DivineUser00"+ncount;
        dr.Close();
        return UserID;
    }

    private int getQRCode()
    {
        int count = 0;
        SqlCommand cmd = new SqlCommand("select count(*) from Tbl_User_Details", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            count = dr.GetInt32(0);
        }
        int pattern = 5900065;
        dr.Close();
        return pattern+count+1;
    }
}

