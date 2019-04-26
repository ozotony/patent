using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_pt_examiners_unit_edit_ren : System.Web.UI.Page
{
    public pt t = new pt();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Page.IsPostBack))
        {



        }

    }

    protected void lvAZSubjectSeriesLinks_ItemDataBound(object sender, ListViewItemEventArgs e)
    {

        if (RenewalListView.EditIndex == (e.Item as ListViewDataItem).DataItemIndex)
        {
            System.Web.UI.HtmlControls.HtmlSelect SeriesId = (System.Web.UI.HtmlControls.HtmlSelect)e.Item.FindControl("type");
            string title = ((TextBox)e.Item.FindControl("TextBox1")).Text;
            SeriesId.Value = title;
        }

    }

    private void UpdateCustomer(string customerID, ListViewItem editItem)
    {
        if (IsValid)
        {

            String vid = ((Label)editItem.FindControl("Label4")).Text;

            pt.Renewal nn = new pt.Renewal();
            string title = ((TextBox)editItem.FindControl("title")).Text;
            string regno = ((TextBox)editItem.FindControl("regno")).Text;
            string appno = ((TextBox)editItem.FindControl("appno")).Text;
            string appdate = ((TextBox)editItem.FindControl("appdate")).Text;
            string xname = ((TextBox)editItem.FindControl("xname")).Text;
            string xaddy = ((TextBox)editItem.FindControl("xaddy")).Text;
            string xmobile = ((TextBox)editItem.FindControl("xmobile")).Text;
            string xemail = ((TextBox)editItem.FindControl("xemail")).Text;
            string type = ((System.Web.UI.HtmlControls.HtmlSelect)editItem.FindControl("type")).Value;
            string agt_code = ((TextBox)editItem.FindControl("agt_code")).Text;
            string agt_name = ((TextBox)editItem.FindControl("agt_name")).Text;
            string agt_addy = ((TextBox)editItem.FindControl("agt_addy")).Text;
            string agt_mobile = ((TextBox)editItem.FindControl("agt_mobile")).Text;
            string agt_email = ((TextBox)editItem.FindControl("agt_email")).Text;
            string last_rwl_date = ((TextBox)editItem.FindControl("last_rwl_date")).Text;
            string reg_date = ((TextBox)editItem.FindControl("reg_date")).Text;
            //  string log_staff = ((TextBox)editItem.FindControl("log_staff")).Text;
            nn.title = title;
            nn.reg_no = regno;
            nn.app_no = appno;
            nn.app_date = appdate;
            nn.xname = xname;
            nn.xaddy = xaddy;
            nn.xmobile = xmobile;
            nn.xemail = xemail;
            nn.type = type;
            nn.agt_code = agt_code;
            nn.agt_name = agt_name;
            nn.agt_addy = agt_addy;
            nn.agt_mobile = agt_mobile;
            nn.agt_email = agt_email;
            nn.last_rwl_date = last_rwl_date;
            nn.reg_date = reg_date;
            nn.log_staff = vid;

            updateRenewal(nn);

        }
    }
    protected void RenewalListView_ItemCanceling(object sender, ListViewCancelEventArgs e)
    {
        ((ListView)sender).EditIndex = -1;
        List<pt.Renewal> pp = getAddressServiceByID(TextBox6.Text);
        RenewalListView.DataSource = pp;
        RenewalListView.DataBind();
    }
    protected void RenewalListView_ItemEditing(object sender, ListViewEditEventArgs e)
    {
        RenewalListView.EditIndex = e.NewEditIndex;
        List<pt.Renewal> pp = getAddressServiceByID(TextBox6.Text);
        RenewalListView.DataSource = pp;
        RenewalListView.DataBind();

        Page page = HttpContext.Current.CurrentHandler as Page;
        page.ClientScript.RegisterStartupScript(typeof(Page), "Test", "<script type='text/javascript'>doEdit();</script>");
    }

    protected void EmployeesListView_OnItemCommand(object sender, ListViewCommandEventArgs e)
    {

        switch (e.CommandName)
        {
            case "Insert":
                {
                    // InsertCustomer(e.Item);
                    break;
                }

            case "Insert2":
                {
                    //  InsertCustomer(e.Item);
                    break;
                }
            case "Save":
                {
                    UpdateCustomer(e.CommandArgument as string, e.Item);
                    ((ListView)sender).EditIndex = -1;
                    List<pt.Renewal> pp = getAddressServiceByID(TextBox6.Text);
                    RenewalListView.DataSource = pp;
                    RenewalListView.DataBind();
                    ClientScriptManager csm = Page.ClientScript;
                    string message = "<Script Language='JavaScript'>alert(' " + "Record Updated   Successfully" + " ');</Script>";
                    csm.RegisterStartupScript(this.GetType(), "Exception", message, false);
                    break;
                }
            case "Del":
                {
                    int vid = Convert.ToInt32(e.CommandArgument);

                    flushXpwalletByID(vid);
                    flushRenewalByID(vid);

                    List<pt.Renewal> pp = getAddressServiceByID(TextBox6.Text);
                    RenewalListView.DataSource = pp;
                    RenewalListView.DataBind();
                    ClientScriptManager csm = Page.ClientScript;
                    string message = "<Script Language='JavaScript'>alert(' " + "Record Deleted   Successfully" + " ');</Script>";
                    csm.RegisterStartupScript(this.GetType(), "Exception", message, false);
                    break;
                }

            case "Cancel":
                {
                    RenewalListView.InsertItemPosition = InsertItemPosition.None;
                    RenewalListView.DataBind();
                    break;
                }
            case "Edit":
                {
                    RenewalListView.InsertItemPosition = InsertItemPosition.None;
                    break;
                }
        }
    }

    public string Connect()
    {
        return ConfigurationManager.ConnectionStrings["cldConnectionString"].ConnectionString;
    }

    public string updateRenewal(pt.Renewal aa)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE renewal SET title=@title,type=@type,reg_no=@reg_no,app_no=@app_no,app_date=@app_date,xname=@xname ,xmobile=@xmobile ,xemail=@xemail,xaddy=@xaddy,  ";
        command.CommandText += " agt_code=@agt_code,agt_name=@agt_name,agt_addy=@agt_addy,agt_mobile=@agt_mobile,agt_email=@agt_email,last_rwl_date=@last_rwl_date ,reg_date=@reg_date ";
        command.CommandText += " WHERE log_staff=@papp ";
        connection.Open();
        command.Parameters.Add("@title", SqlDbType.NVarChar);
        command.Parameters.Add("@type", SqlDbType.NVarChar);
        command.Parameters.Add("@reg_no", SqlDbType.NVarChar);
        command.Parameters.Add("@app_no", SqlDbType.NVarChar);
        command.Parameters.Add("@app_date", SqlDbType.NVarChar);
        command.Parameters.Add("@xname", SqlDbType.NVarChar);
        command.Parameters.Add("@xmobile", SqlDbType.NVarChar);
        command.Parameters.Add("@xemail", SqlDbType.NVarChar);
        command.Parameters.Add("@xaddy", SqlDbType.Text);

        command.Parameters.Add("@agt_code", SqlDbType.NVarChar);
        command.Parameters.Add("@agt_name", SqlDbType.NVarChar);
        command.Parameters.Add("@agt_addy", SqlDbType.Text);
        command.Parameters.Add("@agt_mobile", SqlDbType.NVarChar);
        command.Parameters.Add("@agt_email", SqlDbType.NVarChar);
        command.Parameters.Add("@last_rwl_date", SqlDbType.NVarChar);
        command.Parameters.Add("@reg_date", SqlDbType.NVarChar);


        command.Parameters.Add("@papp", SqlDbType.NVarChar);
        command.Parameters["@title"].Value = aa.title;
        command.Parameters["@type"].Value = aa.type;
        command.Parameters["@reg_no"].Value = aa.reg_no;
        command.Parameters["@app_no"].Value = aa.app_no;
        command.Parameters["@app_date"].Value = aa.app_date;
        command.Parameters["@xname"].Value = aa.xname;
        command.Parameters["@xmobile"].Value = aa.xmobile;
        command.Parameters["@xemail"].Value = aa.xemail;
        command.Parameters["@papp"].Value = aa.log_staff;
        command.Parameters["@xaddy"].Value = aa.xaddy;

        command.Parameters["@agt_code"].Value = aa.agt_code;
        command.Parameters["@agt_name"].Value = aa.agt_name;
        command.Parameters["@agt_addy"].Value = aa.agt_addy;
        command.Parameters["@agt_mobile"].Value = aa.agt_mobile;
        command.Parameters["@agt_email"].Value = aa.agt_email;
        command.Parameters["@last_rwl_date"].Value = aa.last_rwl_date;
        command.Parameters["@reg_date"].Value = aa.reg_date;

        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        string admin = Session["pwalletID"].ToString();
        pt.XPwallet xxs = t.getXPwalletDetailsByID2(TextBox6.Text);
        t.activity_log(admin, "Edit Renewal", "Update", xxs.ID, xxs.data_status, "", "", "", "", "", "");
        return str2;
    }

    public void flushRenewalByID(Int64 id)
    {
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("DELETE from renewal where log_staff=" + id, connection);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void flushXpwalletByID(Int64 id)
    {
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("DELETE from x_pwallet where id=" + id, connection);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }



    public List<pt.Renewal> getAddressServiceByID(string ID)
    {
        List<pt.Renewal> list = new List<pt.Renewal>();
        //  new AddressService();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM renewal AS e  INNER JOIN x_pwallet AS p     ON e.log_staff = p.ID  WHERE validationID='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            pt.Renewal item = new pt.Renewal
            {
                xID = Convert.ToInt64(reader["xID"]).ToString(),
                title = reader["title"].ToString(),
                type = reader["type"].ToString(),
                reg_no = reader["reg_no"].ToString(),
                app_no = reader["app_no"].ToString(),
                app_date = reader["app_date"].ToString(),
                xname = reader["xname"].ToString(),
                xaddy = reader["xaddy"].ToString(),
                xmobile = reader["xmobile"].ToString(),
                xemail = reader["xemail"].ToString(),
                agt_code = reader["agt_code"].ToString(),
                agt_name = reader["agt_name"].ToString(),
                agt_addy = reader["agt_addy"].ToString(),
                agt_mobile = reader["agt_mobile"].ToString(),
                agt_email = reader["agt_email"].ToString(),
                last_rwl_date = reader["last_rwl_date"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                reg_time = reader["reg_time"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                visible = ID,

            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        List<pt.Renewal> pp = getAddressServiceByID(TextBox6.Text);
        RenewalListView.DataSource = pp;
        RenewalListView.DataBind();

    }
}