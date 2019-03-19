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
        getPurchases();
    }
    public void gethdr() {
        MyServerControlDiv.Controls.Add(new LiteralControl("<div style='margin-top:10px;' class='alert alert-info alert-dismissible' role='alert'>"));
        MyServerControlDiv.Controls.Add(new LiteralControl("<button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>"));        
    }
    public void getHead() {
        MyServerControlDiv.Controls.Add(new LiteralControl("<h1 style='text-align:center; font-size:18px;'><strong>Pending payments are</strong></h1>"));
        MyServerControlDiv.Controls.Add(new LiteralControl("<table style='margin-top:8px; margin-bottom:8px;'>"));
        MyServerControlDiv.Controls.Add(new LiteralControl("<tr><th>Date</th><th>Mor</th><th>Eve</th></tr>"));
    }
    public void getftr() {
        MyServerControlDiv.Controls.Add(new LiteralControl("</div>"));
    }
    public void clsTbl() {
        MyServerControlDiv.Controls.Add(new LiteralControl("</table>"));
    }
    public void getPurchases()
    {
        SqlCommand cmd = new SqlCommand("select Var_Purdtl_PrId,Dt_Purdtl_Date,Flt_Purdtl_Morning,Flt_Purdtl_Evening from Tbl_Purchase_Details where  Var_Purdtl_UId='" + cookieUserId + "' order by DAY(Dt_Purdtl_Date)", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        int i = 0;
        Double qty = 0;
        gethdr();     
        while (dr.Read())
        {
            i++;
            if (i == 1) {
                getHead();                
            }                        
            MyServerControlDiv.Controls.Add(new LiteralControl("<tr><td>"+DateTime.Parse(dr.GetValue(1).ToString()).ToString("dd-MM-yyyy")+"</td>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<td>" + dr.GetValue(2).ToString() + " </td> "));
            MyServerControlDiv.Controls.Add(new LiteralControl("<td>" + dr.GetValue(3).ToString() + "</td> </tr>"));            
            qty += Convert.ToDouble(dr.GetValue(2).ToString())+ Convert.ToDouble(dr.GetValue(3).ToString());

        }
        if (i == 0)
        {            
            MyServerControlDiv.Controls.Add(new LiteralControl("<strong> No pending payments! </strong>"));         
        }
        if (i > 0)
        {
            double tot = qty * 41;
            clsTbl();
            MyServerControlDiv.Controls.Add(new LiteralControl("<strong> Quantity bought: </strong> " + qty + " Ltr. <br/>"));
            MyServerControlDiv.Controls.Add(new LiteralControl("<strong> Amount to pay: </strong> "+ tot +" INR."));
        }
        dr.Close();
        getftr();
    }

    protected void BtnPay_Click(object sender, EventArgs e)
    {
        Response.Redirect("https://retail.onlinesbi.com/retail/login.htm");
    }
}