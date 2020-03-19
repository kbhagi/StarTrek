using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page 
{
    OleDbConnection con;
    OleDbCommand cmd;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        using (con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\BHARGAVA K\Documents\Visual Studio 2008\WebSites\StarTrek\StarTrek.mdb"))
        {
            string Query = "INSERT into userdetails(UserName,Education,Location) VALUES(@UserName, @Education, @Location)";
            cmd = new OleDbCommand(Query,con);
            cmd.Parameters.AddWithValue("@UserName", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Education", txtEducation.Text);
            cmd.Parameters.AddWithValue("@Location", txtLocation.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            txtUsername.Text = "";
            txtEducation.Text = "";
            txtLocation.Text = "";
        }
        BindUserDetails();
    }
    protected void BindUserDetails()
    {
        DataSet ds = new DataSet();
        string strquery = "SELECT * FROM userdetails";
        using (con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\BHARGAVA K\Documents\Visual Studio 2008\WebSites\StarTrek\StarTrek.mdb"))
        {
            using (cmd = new OleDbCommand(strquery, con))
            {
                OleDbDataAdapter Da = new OleDbDataAdapter(cmd);
                Da.Fill(ds);
            }
        }
        gvDetails.DataSource = ds;
        gvDetails.DataBind();
    }
}
