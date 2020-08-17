using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebDataAccessComtrols
{
    public partial class ConnectedObjects : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=JulDotNetBatch2020;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;

        public void ShowGrid()
        {
            conn.Open();

            cmd = new SqlCommand("select * from EmployeeTbl", conn);
           dr = cmd.ExecuteReader();
            dt = new DataTable(); //empty Table

            dt.Load(dr);
            GridView1.DataSource = dt;

            GridView1.DataBind();
            dr.Close();
            conn.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowGrid();
            }
            //using (SqlConnection conn=new SqlConnection())
            //{

            //}
           
            //SqlConnection c = new SqlConnection();

           


            /* while (dr.Read())
             {
                 GridView1.DataSource = dr;
                 DropDownList1.DataSource = dr[1];
                 DropDownList1.SelectedItem= (List)dr[1];
                 GridView1.DataBind();

                 DropDownList1.DataBind();

             }*/
            
           


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnInEmp_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into EmployeeTbl (empName,empSal) values('" + TxtEName.Text + "',"+TxtESal.Text+")",conn);
            int x = cmd.ExecuteNonQuery();
           
            conn.Close();
            ShowGrid();



        }

        protected void BtnUpdataPara_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Update EmployeeTbl set empName=@empName,empSal=@empSal where " +
                "empId=@empId ", conn);
            cmd.Parameters.Add("@empId", SqlDbType.Int).Value = Convert.ToInt32(TxtEId.Text);
            cmd.Parameters.Add("@empName", SqlDbType.VarChar, 20).Value = TxtEName.Text;
            cmd.Parameters.Add("@empSal", SqlDbType.Float).Value = Convert.ToSingle(TxtESal.Text);
            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("Alert(one row updated)");
            }
            conn.Close();
            ShowGrid();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("sp_DeleteEmp",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empid", SqlDbType.Int).Value = Convert.ToInt32(TxtEId.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowGrid();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("sp_searchEmp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@empid", SqlDbType.Int).Value = Convert.ToInt32(TxtEId.Text);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                TxtEName.Text = dr[0].ToString();
                TxtESal.Text = dr["empSal"].ToString();

            }
            else
            {
                Label1.Text = "Please insert correct employee ID";
               // TxtEName.Text = "Emp doeswnt exist";
             //   TxtESal.Visible = false;
            }
            dr.Close();
            conn.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("sp_insertEmp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empname",TxtEName.Text);
            cmd.Parameters.AddWithValue("@empsal",TxtESal.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowGrid();
        }

        protected void btnInPara_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Insert into EmployeeTbl (empName,empSal) values (@empName ,@empSal)", conn);
            cmd.Parameters.Add("@empId", SqlDbType.Int).Value = Convert.ToInt32(TxtEId.Text);
            cmd.Parameters.Add("@empName", SqlDbType.VarChar, 20).Value = TxtEName.Text;
            cmd.Parameters.Add("@empSal", SqlDbType.Float).Value = Convert.ToSingle(TxtESal.Text);
            if (cmd.ExecuteNonQuery() > 0)
            {
                Response.Write("Alert(one row INserted)");
            }
            conn.Close();
            ShowGrid();
        }

        protected void btnUpdateQtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Update EmployeTbl set Empname='" + TxtEName.Text + "',EmpSal='" + TxtESal.Text + "' where EmpId='" + TxtEId.Text + "'", conn);
           cmd.ExecuteNonQuery();

            conn.Close();
            ShowGrid();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("sp_updateEmp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empid", TxtEId.Text);

            cmd.Parameters.AddWithValue("@empname", TxtEName.Text);
            cmd.Parameters.AddWithValue("@empsal", TxtESal.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowGrid();
        }

        protected void btnDeleteQtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from EmployeeTbl where empid='"+TxtEId.Text+"'", conn);
            cmd.ExecuteNonQuery();

            conn.Close();
            ShowGrid();
        }

        protected void btnDeletePara_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("Delete from EmployeeTbl where empId='"+TxtEId.Text+"'", conn);

            cmd.ExecuteNonQuery();
           
            conn.Close();
            ShowGrid();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

        }
    }
}