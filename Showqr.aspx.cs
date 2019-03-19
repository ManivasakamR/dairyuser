using QRCoder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ZXing;

public partial class _Default : System.Web.UI.Page
{
    public SQLContext DBContext;
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie DairyUser = Request.Cookies["DairyUser"];
        String name = DairyUser["UserId"].ToString();
        var writer = new BarcodeWriter();
        writer.Format = BarcodeFormat.QR_CODE;
        var result = writer.Write(name);
        string path = Server.MapPath("~/images/QRImage.jpg");
        var barcodeBitmap = new Bitmap(result);
        using (MemoryStream memory = new MemoryStream())
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                byte[] bytes = memory.ToArray();
                fs.Write(bytes, 0, bytes.Length);
            }
        }
        imgQRCode.Visible = true;
        imgQRCode.ImageUrl = "~/images/QRImage.jpg";
        DBContext = new SQLContext();
        String UserName = "";        
        SqlCommand cmd = new SqlCommand("select Var_Udtl_Name from Tbl_User_Details where Var_Udtl_Uid='" + name +"'", DBContext._SqlConnection);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            UserName = dr.GetValue(0).ToString();
        }                
        dr.Close();
        //LblUserName.Text = UserName;
        var h2 = new HtmlGenericControl("h2");        
        h2.InnerHtml = UserName;
        MyServerControlDiv.Controls.Add(h2);
    }    
}