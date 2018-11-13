using System;
using System.Web.UI.WebControls;

using System.Data.OleDb;
using System.Data;
using System.Collections.Generic;
using System.Net;

namespace pim8.Controllers
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack) ReadRecords();
            alertEndTasks();
        }

        private void alertEndTasks()
        {
            List<Models.Task> outDateTasks = new List<Models.Task>();
            OleDbConnection conn = null;
            conn = new OleDbConnection(
                    "Provider=Microsoft.Jet.OLEDB.4.0; " +
                    "Data Source=" + Server.MapPath("../App_Data/PIM8.mdb"));
            conn.Open();
            OleDbCommand cmd =
                new OleDbCommand("Select * FROM Tasks", conn);
            cmd.Connection = conn;

            //cmd.CommandText = "SELECT FROM Tasks WHEN `DateTimeEnd` < @today";
            cmd.CommandText = "SELECT * FROM Tasks WHERE (((tasks.[DateTimeEnd])<@today));";
            cmd.Parameters.AddWithValue("@today", (string)DateTime.Now.ToShortDateString());
            OleDbDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Models.Task taskOutdatedFromDB = new Models.Task();
                taskOutdatedFromDB.fieldName = (string)reader["TaskName"];
                taskOutdatedFromDB.dateTimeEnd = (DateTime)reader["DateTimeEnd"];
                outDateTasks.Add(taskOutdatedFromDB);
            }
            string textToAlert = "";
            foreach (Models.Task taskOutDated in outDateTasks)
            {
                textToAlert = textToAlert + "Nome da tarefa: " + taskOutDated.fieldName + "\\n" +
                        "Dia de vencimento: " + taskOutDated.dateTimeEnd.ToString() + "\\n\\n";
            }
            Response.Write("<script>alert('"+ textToAlert +"')</script>");
            cmd.Connection.Close();
        }

        private void ReadRecords()
        {
            OleDbDataAdapter da;
            OleDbConnection conn = null;
            DataSet ds = new DataSet();
            try
            {
                conn = new OleDbConnection(
                    "Provider=Microsoft.Jet.OLEDB.4.0; " +
                    "Data Source=" + Server.MapPath("../App_Data/PIM8.mdb"));
                conn.Open();

                OleDbCommand cmd =
                    new OleDbCommand("Select * FROM Tasks", conn);

                cmd.Connection = conn;
                da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
                cmd.ExecuteNonQuery();

                datagrid.DataSource = ds;
                datagrid.DataBind();
                conn.Close();
            }
            //        catch (Exception e)
            //        {
            //            Response.Write(e.Message);
            //            Response.End();
            //        }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            datagrid.CurrentPageIndex = e.NewPageIndex;
            ReadRecords();
        }
        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            datagrid.EditItemIndex = e.Item.ItemIndex;
            ReadRecords();
        }
        protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            datagrid.EditItemIndex = -1;
            ReadRecords();
        }
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            OleDbConnection conn = null;

            conn = new OleDbConnection(
                    "Provider=Microsoft.Jet.OLEDB.4.0; " +
                    "Data Source=" + Server.MapPath("../App_Data/PIM8.mdb"));
            conn.Open();

            OleDbCommand cmd =
                new OleDbCommand("Select * FROM Tasks", conn);

            cmd.Connection = conn;

            int ID = (int)datagrid.DataKeys[(int)e.Item.ItemIndex];
            cmd.CommandText = "Delete from Tasks where ID = @ID";
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            datagrid.EditItemIndex = -1;
            ReadRecords();
        }
        protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {


            int ID = (int)datagrid.DataKeys[(int)e.Item.ItemIndex];

            string name = ((TextBox)e.Item.Cells[0].Controls[0]).Text;
            string dateTimeEnd = ((TextBox)e.Item.Cells[1].Controls[0]).Text;
            string dateTimeStart = ((TextBox)e.Item.Cells[2].Controls[0]).Text;
            string noticy = ((TextBox)e.Item.Cells[3].Controls[0]).Text;

            try
            {
                if (DateTime.Parse(dateTimeEnd) < DateTime.Parse(dateTimeStart))
                {
                    Response.Write("<script>alert('Data de inicio começa depois da data do fim.')</script>");
                } else if (name == "") {
                    Response.Write("<script>alert('Nome da atividade em branco!')</script>");
                }
                else {
                    OleDbConnection conn = null;
                    try
                    {
                        conn = new OleDbConnection(
                            "Provider=Microsoft.Jet.OLEDB.4.0; " +
                            "Data Source=" + Server.MapPath("../App_Data/PIM8.mdb"));
                        conn.Open();

                        OleDbCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "UPDATE Tasks SET TaskName = @TaskName, DateTimeEnd = @DateTimeEnd, " +
                            "DateTimeStart = @DateTimeStart, noticy = @noticy " +
                            "WHERE ID = @ID";

                        cmd.Parameters.AddWithValue("@TaskName", name);
                        cmd.Parameters.AddWithValue("@DateTimeEnd", dateTimeEnd);
                        cmd.Parameters.AddWithValue("@DateTimeStart", dateTimeStart);
                        cmd.Parameters.AddWithValue("@Noticy", noticy);
                        cmd.Parameters.AddWithValue("@ID", ID);


                        cmd.ExecuteNonQuery();
                    }
                    finally
                    {
                        if (conn != null) conn.Close();
                        datagrid.EditItemIndex = -1;
                        ReadRecords();
                    }
                }
            }
            catch(Exception dateException)
            {
                
            }



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
        protected void btnAddTask_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("~/Controllers/Create.aspx");
        }
        protected void Btnpdf_Click(object sender, EventArgs e)

        {

            string FilePath = Server.MapPath("../Content/PIM8-ERICKBUENOSILVA.pdf");

            WebClient User = new WebClient();

            Byte[] FileBuffer = User.DownloadData(FilePath);

            if (FileBuffer != null)

            {

                Response.ContentType = "application/pdf";

                Response.AddHeader("content-length", FileBuffer.Length.ToString());

                Response.BinaryWrite(FileBuffer);

            }

        }
    }
}