using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.OleDb;
using System.Data;

namespace pim8.Controllers
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack) ReadRecords();
        }

        private void ReadRecords()
        {
            OleDbDataAdapter da;
            OleDbConnection conn = null;
            OleDbDataReader reader = null;
            DataSet ds = new DataSet();
            try
            {
                conn = new OleDbConnection(
                    "Provider=Microsoft.Jet.OLEDB.4.0; " +
                    "Data Source=" + Server.MapPath("../App_Data/PIM8.mdb"));
                conn.Open();

                OleDbCommand cmd =
                    new OleDbCommand("Select * FROM Tasks", conn);
                //reader = cmd.ExecuteReader();

                cmd.Connection = conn;
                da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
                //conn.Open();
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
                if (reader != null) reader.Close();
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
            cmd.CommandText = "Delete from Tasks where ID=" + ID;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            datagrid.EditItemIndex = -1;
            ReadRecords();
        }
        protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {


            int ID = (int)datagrid.DataKeys[(int)e.Item.ItemIndex];

            string name = ((TextBox)e.Item.Cells[1].Controls[0]).Text;
            string dateTimeEnd = ((TextBox)e.Item.Cells[2].Controls[0]).Text;
            string dateTimeStart = ((TextBox)e.Item.Cells[2].Controls[0]).Text;


            string sql =
                "UPDATE Tasks SET TaskName=\"" + name +
                "\", DateTimeEnd=\"" + dateTimeEnd +
                "\", DateTimeStart=\"" + dateTimeStart +
                "\"" +
                " WHERE ID=" + ID;
            ExecuteNonQuery(sql);

            string description = null;
            if ((description = ((TextBox)e.Item.Cells[2].Controls[0]).Text) != null)
            {
                string sqlD =
                "UPDATE Tasks SET Description=\"" + description +
                " WHERE ID=" + ID;
                ExecuteNonQuery(sqlD);
            }

            datagrid.EditItemIndex = -1;
            ReadRecords();

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
            string sql =
                "INSERT INTO Tasks (TaskName, DateTimeEnd, DateTimeStart, Description" +
                "VALUES (\"new\", \"new\")";

            ExecuteNonQuery(sql);
            ReadRecords();
        }
    }
}