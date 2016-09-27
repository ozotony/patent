using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class multiple : Page
{
   
    private void AddNewRowToGrid()
    {
        int num = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable table = (DataTable) ViewState["CurrentTable"];
            DataRow row = null;
            if (table.Rows.Count > 0)
            {
                for (int i = 1; i <= table.Rows.Count; i++)
                {
                    TextBox box = (TextBox) Gridview1.Rows[num].Cells[1].FindControl("TextBox1");
                    TextBox box2 = (TextBox) Gridview1.Rows[num].Cells[2].FindControl("TextBox2");
                    TextBox box3 = (TextBox) Gridview1.Rows[num].Cells[3].FindControl("TextBox3");
                    row = table.NewRow();
                    row["RowNumber"] = i + 1;
                    table.Rows[i - 1]["Column1"] = box.Text;
                    table.Rows[i - 1]["Column2"] = box2.Text;
                    table.Rows[i - 1]["Column3"] = box3.Text;
                    num++;
                }
                table.Rows.Add(row);
                ViewState["CurrentTable"] = table;
                Gridview1.DataSource = table;
                Gridview1.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        SetPreviousData();
    }

    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetInitialRow();
        }
    }

    private void SetInitialRow()
    {
        DataTable table = new DataTable();
        DataRow row = null;
        table.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        table.Columns.Add(new DataColumn("Column1", typeof(string)));
        table.Columns.Add(new DataColumn("Column2", typeof(string)));
        table.Columns.Add(new DataColumn("Column3", typeof(string)));
        row = table.NewRow();
        row["RowNumber"] = 1;
        row["Column1"] = string.Empty;
        row["Column2"] = string.Empty;
        row["Column3"] = string.Empty;
        table.Rows.Add(row);
        ViewState["CurrentTable"] = table;
        Gridview1.DataSource = table;
        Gridview1.DataBind();
    }

    private void SetPreviousData()
    {
        int num = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable table = (DataTable) ViewState["CurrentTable"];
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    TextBox box = (TextBox) Gridview1.Rows[num].Cells[1].FindControl("TextBox1");
                    TextBox box2 = (TextBox) Gridview1.Rows[num].Cells[2].FindControl("TextBox2");
                    TextBox box3 = (TextBox) Gridview1.Rows[num].Cells[3].FindControl("TextBox3");
                    box.Text = table.Rows[i]["Column1"].ToString();
                    box2.Text = table.Rows[i]["Column2"].ToString();
                    box3.Text = table.Rows[i]["Column3"].ToString();
                    num++;
                }
            }
        }
    }

  
}

