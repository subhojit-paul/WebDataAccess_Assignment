using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebDataAccessComtrols
{
    public partial class Disconnected : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=JulDotNetBatch2020;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from EmployeeTbl",conn);
            SqlCommand cmd1 = new SqlCommand("select * from BookTbl", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds = new DataSet();
            da.Fill(ds, "Employee");
            da1.Fill(ds, "Book");
            GridView1.DataSource = ds.Tables["Employee"];
            GridView1.DataBind();
            GridView2.DataSource = ds.Tables["Book"];
            GridView2.DataBind();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}