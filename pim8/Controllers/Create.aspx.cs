using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pim8.Controllers
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, System.EventArgs e)
        {
            if (TextBox1.Text == "" || datepicker1.Text == "" || datepicker2.Text == "")
            {
                Response.Write("<script>alert('Somente a descrição pode ficar em branco!')</script>");
            } else if (DateTime.ParseExact(datepicker1.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture) < 
                DateTime.ParseExact(datepicker2.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture)  )
            {
                Response.Write("<script>alert('Data de inicio começa depois da data do fim.')</script>");
            } else if (DateTime.ParseExact(datepicker1.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture) < 
                DateTime.Today )
            {
                Response.Write("<script>alert('A data de fim não pode estar no passado, como poderá entregá-la?')</script>");
            }else
            {
                OleDbConnection conn = null;
                try
                {
                    conn = new OleDbConnection(
                        "Provider=Microsoft.Jet.OLEDB.4.0; " +
                        "Data Source=" + Server.MapPath("../App_Data/PIM8.mdb"));
                    conn.Open();

                    OleDbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "INSERT INTO Tasks (TaskName, DateTimeEnd, DateTimeStart, Noticy) VALUES (?, ?, ?, ?)";

                    cmd.Parameters.AddWithValue("TaskName", TextBox1.Text);
                    cmd.Parameters.AddWithValue("DateTimeEnd", datepicker1.Text);
                    cmd.Parameters.AddWithValue("DateTimeStart", datepicker2.Text);
                    cmd.Parameters.AddWithValue("Noticy", TextBox4.Text);
                    cmd.ExecuteNonQuery();
                }
                //  catch (Exception e)
                //  {
                //      Response.Write(e.Message);
                //      Response.End();
                //  }
                finally
                {
                    if (conn != null) conn.Close();
                    Response.Redirect("~/Controllers/WebForm1.aspx");
                }
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            datepicker2.Text =  DateTime.Today.ToString();
            datepicker1.Text =  DateTime.Today.ToString();
            TextBox4.Text = "";
           
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Controllers/WebForm1.aspx");
        }
        private void ExecuteNonQuery(string sql)
        {
            OleDbConnection conn = null;
            try
            {
                conn = new OleDbConnection(
                    "Provider=Microsoft.Jet.OLEDB.4.0; " +
                    "Data Source=" + Server.MapPath("../App_Data/PIM8.mdb"));
                conn.Open();

                OleDbCommand cmd =
                    new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            //  catch (Exception e)
            //  {
            //      Response.Write(e.Message);
            //      Response.End();
            //  }
            finally
            {
                if (conn != null) conn.Close();
            }
        }
    }
}