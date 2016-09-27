using Brettle.Web.NeatUpload;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class xapplication : Page
{
    public string ack_status = "0";
    public string agent = "";
    public string agentemail;
    public string agentpnumber;
    public string aid = "";
    public string amt = "";
    public string claim_newfilename = "0";
    public string cname = "";
    public string doa_newfilename = "0";
    public string doc_path = "";
    public string gt = "";
    public string hwalletID = "";
    public string loa_newfilename = "0";    
    public string log_staffID = "0";
    public List<SortedList<string, string>> lt_app = new List<SortedList<string, string>>();
    public List<SortedList<string, string>> lt_inv = new List<SortedList<string, string>>();
    public List<SortedList<string, string>> lt_pri = new List<SortedList<string, string>>();
    public string pc = "";
    public string pct_newfilename = "0";
    public int pt_succ = 0;
    public string pwalletID = "0";
    public string serverpath = "";
    public SortedList<string, string> sl_xx = new SortedList<string, string>();
    public string spec_newfilename = "0";
    public string status = "0";
    public pt t = new pt();
    public string transID = "";
    public string vid = "";
    public string x_application = "";
    protected string xreg_date = DateTime.Now.ToString("yyyy-MM-dd");
    protected string xvisible = "1";

    private void AddNewRowToGrid_App_gv()
    {
        int num = 0;
        if (ViewState["AppTable"] != null)
        {
            DataTable table = (DataTable) ViewState["AppTable"];
            DataRow row = null;
            if (table.Rows.Count > 0)
            {
                for (int i = 1; i <= table.Rows.Count; i++)
                {
                    TextBox box = (TextBox) gv_app.Rows[num].Cells[1].FindControl("txt_name_app");
                    TextBox box2 = (TextBox) gv_app.Rows[num].Cells[1].FindControl("txt_address_app");
                    TextBox box3 = (TextBox) gv_app.Rows[num].Cells[1].FindControl("txt_email_app");
                    TextBox box4 = (TextBox) gv_app.Rows[num].Cells[1].FindControl("txt_mobile_app");
                    DropDownList list = (DropDownList) gv_app.Rows[num].Cells[1].FindControl("select_app_nationality");
                    row = table.NewRow();
                    row["RowNumber_app"] = i + 1;
                    table.Rows[i - 1]["app_Column1"] = box.Text;
                    table.Rows[i - 1]["app_Column1"] = box2.Text;
                    table.Rows[i - 1]["app_Column1"] = box3.Text;
                    table.Rows[i - 1]["app_Column1"] = box4.Text;
                    table.Rows[i - 1]["app_Column1"] = list.SelectedValue;
                    SortedList<string, string> item = new SortedList<string, string>();
                    item["txt_name_app"] = box.Text;
                    item["txt_address_app"] = box2.Text;
                    item["txt_email_app"] = box3.Text;
                    item["txt_mobile_app"] = box4.Text;
                    item["select_app_nationality"] = list.SelectedValue;
                    lt_app.Add(item);
                    num++;
                }
                Session["lt_app"] = lt_app;
                table.Rows.Add(row);
                ViewState["AppTable"] = table;
                gv_app.DataSource = table;
                gv_app.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        SetPreviousData_App_gv();
    }

    private void AddNewRowToGrid_Inv_gv()
    {
        int num = 0;
        if (ViewState["InvTable"] != null)
        {
            DataTable table = (DataTable) ViewState["InvTable"];
            DataRow row = null;
            if (table.Rows.Count > 0)
            {
                for (int i = 1; i <= table.Rows.Count; i++)
                {
                    TextBox box = (TextBox) gv_inv.Rows[num].Cells[1].FindControl("txt_name_inv");
                    TextBox box2 = (TextBox) gv_inv.Rows[num].Cells[1].FindControl("txt_address_inv");
                    TextBox box3 = (TextBox) gv_inv.Rows[num].Cells[1].FindControl("txt_email_inv");
                    TextBox box4 = (TextBox) gv_inv.Rows[num].Cells[1].FindControl("txt_mobile_inv");
                    DropDownList list = (DropDownList) gv_inv.Rows[num].Cells[1].FindControl("select_inv_nationality");
                    row = table.NewRow();
                    row["RowNumber_inv"] = i + 1;
                    table.Rows[i - 1]["inv_Column2"] = box.Text;
                    table.Rows[i - 1]["inv_Column2"] = box2.Text;
                    table.Rows[i - 1]["inv_Column2"] = box3.Text;
                    table.Rows[i - 1]["inv_Column2"] = box4.Text;
                    table.Rows[i - 1]["inv_Column2"] = list.SelectedValue;
                    SortedList<string, string> item = new SortedList<string, string>();
                    item["txt_name_inv"] = box.Text;
                    item["txt_address_inv"] = box2.Text;
                    item["txt_email_inv"] = box3.Text;
                    item["txt_mobile_inv"] = box4.Text;
                    item["select_inv_nationality"] = list.SelectedValue;
                    lt_inv.Add(item);
                    num++;
                }
                Session["lt_inv"] = lt_inv;
                table.Rows.Add(row);
                ViewState["InvTable"] = table;
                gv_inv.DataSource = table;
                gv_inv.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        SetPreviousData_Inv_gv();
    }

    private void AddNewRowToGrid_Pri_gv()
    {
        int num = 0;
        if (ViewState["PriTable"] != null)
        {
            DataTable table = (DataTable) ViewState["PriTable"];
            DataRow row = null;
            if (table.Rows.Count > 0)
            {
                for (int i = 1; i <= table.Rows.Count; i++)
                {
                    DropDownList list = (DropDownList) gv_pri.Rows[num].Cells[1].FindControl("select_country_pri");
                    TextBox box = (TextBox) gv_pri.Rows[num].Cells[2].FindControl("txt_application_no_pri");
                    TextBox box2 = (TextBox) gv_pri.Rows[num].Cells[3].FindControl("txt_date_pri");
                    row = table.NewRow();
                    row["RowNumber_pri"] = i + 1;
                    table.Rows[i - 1]["pri_Column2"] = list.Text;
                    table.Rows[i - 1]["pri_Column3"] = box.Text;
                    table.Rows[i - 1]["pri_Column4"] = box2.Text;
                    SortedList<string, string> item = new SortedList<string, string>();
                    item["select_country_pri"] = list.Text;
                    item["txt_application_no_pri"] = box.Text;
                    item["txt_date_pri"] = box2.Text;
                    lt_pri.Add(item);
                    num++;
                }
                Session["lt_pri"] = lt_pri;
                table.Rows.Add(row);
                ViewState["PriTable"] = table;
                gv_pri.DataSource = table;
                gv_pri.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        SetPreviousData_Pri_gv();
    }

    protected void ButtonAddApp_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid_App_gv();
    }

    protected void ButtonAddInv_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid_Inv_gv();
    }

    protected void ButtonAddPri_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid_Pri_gv();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txt_loa_no.Text = "1";
            txt_claim_no.Text = "1";
            txt_pct_no.Text = "1";
            txt_doa_no.Text = "1";
        }
        if ((((((Session["serverpath"] != null) && (Session["serverpath"].ToString() != "")) && ((Session["aid"] != null) && (Session["aid"].ToString() != ""))) && (((Session["amt"] != null) && (Session["amt"].ToString() != "")) && ((Session["vid"] != null) && (Session["vid"].ToString() != "")))) && (Session["hwalletID"] != null)) && (Session["hwalletID"].ToString() != ""))
        {
            serverpath = Session["serverpath"].ToString();
            agent = Session["aid"].ToString();
            amt = Session["amt"].ToString();
            transID = Session["vid"].ToString();
            hwalletID = Session["hwalletID"].ToString();
        }
        else
        {
            Response.Redirect("http://ipo.cldng.com/A/profile.aspx");
        }
        if (Session["pc"] != null)
        {
            pc = Session["pc"].ToString();
            if (pc == "P001")
            {
                lbl_type.Text = "CONVENTIONAL";
            }
            else
            {
                lbl_type.Text = "NON-CONVENTIONAL";
            }
        }
        else
        {
            Response.Redirect("http://ipo.cldng.com/A/profile.aspx");
        }
        if (Session["loa_newfilename"] != null)
        {
            loa_newfilename = Session["loa_newfilename"].ToString();
        }
        if (Session["claim_newfilename"] != null)
        {
            claim_newfilename = Session["claim_newfilename"].ToString();
        }
        if (Session["pct_newfilename"] != null)
        {
            pct_newfilename = Session["pct_newfilename"].ToString();
        }
        if (Session["doa_newfilename"] != null)
        {
            doa_newfilename = Session["doa_newfilename"].ToString();
        }
        if (Session["spec_newfilename"] != null)
        {
            spec_newfilename = Session["spec_newfilename"].ToString();
        }
        if (Session["aid"] != null)
        {
            rep_code.Text = Session["aid"].ToString();
        }
        if (!Page.IsPostBack)
        {
            SetInitialRow_App_gv();
            SetInitialRow_Inv_gv();
            SetInitialRow_Pri_gv();
            if (Session["vid"] != null)
            {
                transID = Session["vid"].ToString();
                rep_code.Text = Session["vid"].ToString();
            }
            Session["xref"] = Convert.ToInt32(Session["xref"]) + 1;
            if (Session["xref"].ToString() != "1")
            {
            }
            if (((Session["x_application"] != null) && (Session["x_application"].ToString() != "")) && (transID != Session["x_application"].ToString()))
            {
            }
            if (Session["cname"] != null)
            {
                rep_xname.Text = Session["cname"].ToString();
            }
            if (Session["agentemail"] != null)
            {
                txt_rep_email.Text = Session["agentemail"].ToString();
            }
            if (Session["agentpnumber"] != null)
            {
                txt_rep_telephone.Text = Session["agentpnumber"].ToString();
            }
            if (Session["product_title"] != null)
            {
                txt_title_of_invention.Text = Session["product_title"].ToString();
            }
        }
    }

    protected void SaveAll_Click(object sender, EventArgs e)
    {
        TransactionOptions transactionOptions = new TransactionOptions {
            IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromMinutes(10.0)
        };
        TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        try
        {
            int num;
            SetLatestRowsFromGrid_App_gv();
            SetLatestRowsFromGrid_Inv_gv();
            SetLatestRowsFromGrid_Pri_gv();
            pt.PtInfo info = new pt.PtInfo();
            pt.Assignment_info _info = new pt.Assignment_info();
            pt.Representative representative = new pt.Representative();
            List<pt.Applicant> list = new List<pt.Applicant>();
            List<pt.Inventor> list2 = new List<pt.Inventor>();
            List<pt.Priority_info> list3 = new List<pt.Priority_info>();
            info.reg_number = "";
            info.xtype = lbl_type.Text;
            info.title_of_invention = txt_title_of_invention.Text;
            info.pt_desc = txt_pt_desc.Text;
            if (Session["pwalletID"] != null)
            {
                info.log_staff = Session["pwalletID"].ToString();
            }
            info.reg_date = xreg_date;
            info.xvisible = xvisible;
            info.claim_no = "0";
            info.loa_no = "0";
            info.pct_no = "0";
            info.doa_no = "0";
            _info.date_of_assignment = txt_assignment_date.Text;
            _info.assignee_name = txt_assignee_name.Text;
            _info.assignee_address = txt_assignee_address.Text;
            _info.assignee_nationality = select_assignee_nationality.SelectedValue;
            _info.assignor_name = txt_assignor_name.Text;
            _info.assignor_address = txt_assignor_address.Text;
            _info.assignor_nationality = select_assignor_nationality.SelectedValue;
            if (Session["pwalletID"] != null)
            {
                _info.log_staff = Session["pwalletID"].ToString();
            }
            _info.visible = xvisible;
            representative.agent_code = rep_code.Text;
            representative.xname = rep_xname.Text;
            representative.nationality = "160";
            representative.country = "160";
            representative.state = select_rep_state.SelectedValue;
            representative.address = txt_rep_address.Text;
            representative.xmobile = txt_rep_telephone.Text;
            representative.xemail = txt_rep_email.Text;
            representative.reg_date = xreg_date;
            representative.visible = xvisible;
            if (Session["pwalletID"] != null)
            {
                representative.log_staff = Session["pwalletID"].ToString();
            }
            lt_app = (List<SortedList<string, string>>) Session["lt_app"];
            lt_inv = (List<SortedList<string, string>>) Session["lt_inv"];
            lt_pri = (List<SortedList<string, string>>) Session["lt_pri"];
            if (lt_app.Count > 0)
            {
                for (num = 0; num < lt_app.Count; num++)
                {
                    pt.Applicant item = new pt.Applicant {
                        xname = lt_app[num]["txt_name_app"],
                        address = lt_app[num]["txt_address_app"],
                        xemail = lt_app[num]["txt_email_app"],
                        xmobile = lt_app[num]["txt_mobile_app"],
                        nationality = lt_app[num]["select_app_nationality"]
                    };
                    if (Session["pwalletID"] != null)
                    {
                        item.log_staff = Session["pwalletID"].ToString();
                    }
                    item.visible = xvisible;
                    list.Add(item);
                }
            }
            if (lt_inv.Count > 0)
            {
                for (num = 0; num < lt_inv.Count; num++)
                {
                    pt.Inventor inventor = new pt.Inventor {
                        xname = lt_inv[num]["txt_name_inv"],
                        address = lt_inv[num]["txt_address_inv"],
                        xemail = lt_inv[num]["txt_email_inv"],
                        xmobile = lt_inv[num]["txt_mobile_inv"],
                        nationality = lt_inv[num]["select_inv_nationality"]
                    };
                    if (Session["pwalletID"] != null)
                    {
                        inventor.log_staff = Session["pwalletID"].ToString();
                    }
                    inventor.visible = xvisible;
                    list2.Add(inventor);
                }
            }
            if (lt_pri.Count > 0)
            {
                for (num = 0; num < lt_pri.Count; num++)
                {
                    pt.Priority_info _info2 = new pt.Priority_info {
                        countryID = lt_pri[num]["select_country_pri"],
                        app_no = lt_pri[num]["txt_application_no_pri"],
                        xdate = lt_pri[num]["txt_date_pri"]
                    };
                    if (Session["pwalletID"] != null)
                    {
                        _info2.log_staff = Session["pwalletID"].ToString();
                    }
                    _info2.xvisible = xvisible;
                    list3.Add(_info2);
                }
            }
            Session["pwalletID"] = pwalletID;
            pt_succ = t.addNewPatentX(list, list3, list2, info, _info, representative, transID, agent, amt, hwalletID);
            if (pt_succ > 0)
            {
                Session["new_ptID"] = null;
                Session["new_ptID"] = pt_succ;
            }
            if (Session["new_ptID"] != null)
            {
                string str;
                string str2;
                doc_path = Server.MapPath("~/") + "admin/pt/docz/" + Session["new_ptID"].ToString() + "/";
                if (!Directory.Exists(doc_path))
                {
                    Directory.CreateDirectory(doc_path);
                }
                if (IsValid && fu_loa_doc.HasFile)
                {
                    loa_newfilename = Path.Combine(doc_path, fu_loa_doc.FileName.Replace(" ", "_"));
                    fu_loa_doc.MoveTo(Path.Combine(doc_path, fu_loa_doc.FileName.Replace(" ", "_")), MoveToOptions.Overwrite);
                    Session["txt_loa_no"] = txt_loa_no.Text;
                }
                if (IsValid && fu_claim_doc.HasFile)
                {
                    claim_newfilename = Path.Combine(doc_path, fu_claim_doc.FileName.Replace(" ", "_"));
                    fu_claim_doc.MoveTo(claim_newfilename, MoveToOptions.Overwrite);
                    Session["txt_claim_no"] = txt_claim_no.Text;
                }
                if (IsValid && fu_pct_doc.HasFile)
                {
                    pct_newfilename = Path.Combine(doc_path, fu_pct_doc.FileName.Replace(" ", "_"));
                    fu_pct_doc.MoveTo(pct_newfilename, MoveToOptions.Overwrite);
                    Session["txt_pct_no"] = txt_pct_no.Text;
                }
                if (IsValid && fu_doa_doc.HasFile)
                {
                    doa_newfilename = Path.Combine(doc_path, fu_doa_doc.FileName.Replace(" ", "_"));
                    fu_doa_doc.MoveTo(doa_newfilename, MoveToOptions.Overwrite);
                    Session["txt_doa_no"] = txt_doa_no.Text;
                }
                if (IsValid && fu_spec_doc.HasFile)
                {
                    spec_newfilename = Path.Combine(doc_path, fu_spec_doc.FileName.Replace(" ", "_"));
                    fu_spec_doc.MoveTo(spec_newfilename, MoveToOptions.Overwrite);
                }
                loa_newfilename = loa_newfilename.Replace(Server.MapPath("~/") + "admin/pt/", "");
                claim_newfilename = claim_newfilename.Replace(Server.MapPath("~/") + "admin/pt/", "");
                pct_newfilename = pct_newfilename.Replace(Server.MapPath("~/") + "admin/pt/", "");
                doa_newfilename = doa_newfilename.Replace(Server.MapPath("~/") + "admin/pt/", "");
                spec_newfilename = spec_newfilename.Replace(Server.MapPath("~/") + "admin/pt/", "");
                Session["loa_newfilename"] = loa_newfilename;
                Session["claim_newfilename"] = claim_newfilename;
                Session["pct_newfilename"] = pct_newfilename;
                Session["doa_newfilename"] = doa_newfilename;
                Session["spec_newfilename"] = spec_newfilename;
                if (pc == "P001")
                {
                    if ((((loa_newfilename != "0") && (claim_newfilename != "0")) && ((pct_newfilename != "0") && (doa_newfilename != "0"))) && (spec_newfilename != "0"))
                    {
                        if (Session["txt_loa_no"] != null)
                        {
                            txt_loa_no.Text = Session["txt_loa_no"].ToString();
                        }
                        if (Session["txt_claim_no"] != null)
                        {
                            txt_claim_no.Text = Session["txt_claim_no"].ToString();
                        }
                        if (Session["txt_pct_no"] != null)
                        {
                            txt_pct_no.Text = Session["txt_pct_no"].ToString();
                        }
                        if (Session["txt_doa_no"] != null)
                        {
                            txt_doa_no.Text = Session["txt_doa_no"].ToString();
                        }
                        if (t.updatePtDocz(spec_newfilename, loa_newfilename, txt_loa_no.Text, claim_newfilename, txt_claim_no.Text, pct_newfilename, txt_pct_no.Text, doa_newfilename, txt_doa_no.Text, Session["new_ptID"].ToString()) != "0")
                        {
                            str = "";
                            str2 = "";
                            if (Session["vid"] != null)
                            {
                                str = Session["vid"].ToString();
                            }
                            if (Session["gt"] != null)
                            {
                                str2 = Session["gt"].ToString();
                            }
                            status = t.updateHwallet(hwalletID, "Used", xreg_date, txt_title_of_invention.Text).ToString();
                            if (Convert.ToInt32(status) > 0)
                            {
                                ack_status = "1";
                                if (Session["vid"] != null)
                                {
                                    Response.Redirect("./tm_acknowledgement.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + Session["vid"].ToString(), false);
                                }
                                else
                                {
                                    Response.Redirect("./appstatus.aspx", false);
                                }
                            }
                            else
                            {
                                Response.Redirect("./appstatus.aspx", false);
                            }
                            scope.Complete();
                            status = "1";
                        }
                        else
                        {
                            scope.Dispose();
                        }
                    }
                }
                else if (((loa_newfilename != "0") && (claim_newfilename != "0")) && (spec_newfilename != "0"))
                {
                    if (Session["txt_loa_no"] != null)
                    {
                        txt_loa_no.Text = Session["txt_loa_no"].ToString();
                    }
                    if (Session["txt_claim_no"] != null)
                    {
                        txt_claim_no.Text = Session["txt_claim_no"].ToString();
                    }
                    if (Session["txt_pct_no"] != null)
                    {
                        txt_pct_no.Text = Session["txt_pct_no"].ToString();
                    }
                    if (Session["txt_doa_no"] != null)
                    {
                        txt_doa_no.Text = Session["txt_doa_no"].ToString();
                    }
                    if (t.updatePtDocz(spec_newfilename, loa_newfilename, txt_loa_no.Text, claim_newfilename, txt_claim_no.Text, pct_newfilename, txt_pct_no.Text, doa_newfilename, txt_doa_no.Text, Session["new_ptID"].ToString()) != "0")
                    {
                        str = "";
                        str2 = "";
                        if (Session["vid"] != null)
                        {
                            str = Session["vid"].ToString();
                        }
                        if (Session["gt"] != null)
                        {
                            str2 = Session["gt"].ToString();
                        }
                        status = t.updateHwallet(hwalletID, "Used", xreg_date, txt_title_of_invention.Text).ToString();
                        if (Convert.ToInt32(status) > 0)
                        {
                            ack_status = "1";
                            if (Session["vid"] != null)
                            {
                                Response.Redirect("./tm_acknowledgement.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + Session["vid"].ToString(), false);
                            }
                            else
                            {
                                Response.Redirect("./appstatus.aspx", false);
                            }
                        }
                        else
                        {
                            Response.Redirect("./appstatus.aspx", false);
                        }

                        scope.Complete();
                        status = "1";
                    }
                    else
                    {
                        scope.Dispose();
                    }
                }
            }
            else
            {
                scope.Dispose();
            }
        }
        catch (Exception exception)
        {
            string str3 = exception.ToString();
            scope.Dispose();
        }
        finally
        {
            if (scope != null)
            {
                scope.Dispose();
            }
        }
     
    }

    private void SetInitialRow_App_gv()
    {
        DataTable table = new DataTable();
        DataRow row = null;
        table.Columns.Add(new DataColumn("RowNumber_app", typeof(string)));
        table.Columns.Add(new DataColumn("app_Column1", typeof(string)));
        row = table.NewRow();
        row["RowNumber_app"] = 1;
        row["app_Column1"] = string.Empty;
        table.Rows.Add(row);
        ViewState["AppTable"] = table;
        gv_app.DataSource = table;
        gv_app.DataBind();
    }

    private void SetInitialRow_Inv_gv()
    {
        DataTable table = new DataTable();
        DataRow row = null;
        table.Columns.Add(new DataColumn("RowNumber_inv", typeof(string)));
        table.Columns.Add(new DataColumn("inv_Column2", typeof(string)));
        row = table.NewRow();
        row["RowNumber_inv"] = 1;
        row["inv_Column2"] = string.Empty;
        table.Rows.Add(row);
        ViewState["InvTable"] = table;
        gv_inv.DataSource = table;
        gv_inv.DataBind();
    }

    private void SetInitialRow_Pri_gv()
    {
        DataTable table = new DataTable();
        DataRow row = null;
        table.Columns.Add(new DataColumn("RowNumber_pri", typeof(string)));
        table.Columns.Add(new DataColumn("pri_Column2", typeof(string)));
        table.Columns.Add(new DataColumn("pri_Column3", typeof(string)));
        table.Columns.Add(new DataColumn("pri_Column4", typeof(string)));
        row = table.NewRow();
        row["RowNumber_pri"] = 1;
        row["pri_Column2"] = string.Empty;
        row["pri_Column3"] = string.Empty;
        row["pri_Column4"] = string.Empty;
        table.Rows.Add(row);
        ViewState["PriTable"] = table;
        gv_pri.DataSource = table;
        gv_pri.DataBind();
    }

    protected void SetLatestRowsFromGrid_App_gv()
    {
        int num = 0;
        lt_app.Clear();
        if (ViewState["AppTable"] != null)
        {
            DataTable table = (DataTable) ViewState["AppTable"];
            DataRow row = null;
            if (table.Rows.Count > 0)
            {
                for (int i = 1; i <= table.Rows.Count; i++)
                {
                    TextBox box = (TextBox) gv_app.Rows[num].Cells[1].FindControl("txt_name_app");
                    TextBox box2 = (TextBox) gv_app.Rows[num].Cells[1].FindControl("txt_address_app");
                    TextBox box3 = (TextBox) gv_app.Rows[num].Cells[1].FindControl("txt_email_app");
                    TextBox box4 = (TextBox) gv_app.Rows[num].Cells[1].FindControl("txt_mobile_app");
                    DropDownList list = (DropDownList) gv_app.Rows[num].Cells[1].FindControl("select_app_nationality");
                    row = table.NewRow();
                    row["RowNumber_app"] = i + 1;
                    table.Rows[i - 1]["app_Column1"] = box.Text;
                    table.Rows[i - 1]["app_Column1"] = box2.Text;
                    table.Rows[i - 1]["app_Column1"] = box3.Text;
                    table.Rows[i - 1]["app_Column1"] = box4.Text;
                    table.Rows[i - 1]["app_Column1"] = list.SelectedValue;
                    SortedList<string, string> item = new SortedList<string, string>();
                    item["txt_name_app"] = box.Text;
                    item["txt_address_app"] = box2.Text;
                    item["txt_email_app"] = box3.Text;
                    item["txt_mobile_app"] = box4.Text;
                    item["select_app_nationality"] = list.SelectedValue;
                    if ((box.Text != "") && (box.Text != null))
                    {
                        lt_app.Add(item);
                    }
                    num++;
                }
                Session["lt_app"] = lt_app;
                table.Rows.Add(row);
                ViewState["AppTable"] = table;
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
    }

    protected void SetLatestRowsFromGrid_Inv_gv()
    {
        int num = 0;
        lt_inv.Clear();
        if (ViewState["InvTable"] != null)
        {
            DataTable table = (DataTable) ViewState["InvTable"];
            DataRow row = null;
            if (table.Rows.Count > 0)
            {
                for (int i = 1; i <= table.Rows.Count; i++)
                {
                    TextBox box = (TextBox) gv_inv.Rows[num].Cells[1].FindControl("txt_name_inv");
                    TextBox box2 = (TextBox) gv_inv.Rows[num].Cells[1].FindControl("txt_address_inv");
                    TextBox box3 = (TextBox) gv_inv.Rows[num].Cells[1].FindControl("txt_email_inv");
                    TextBox box4 = (TextBox) gv_inv.Rows[num].Cells[1].FindControl("txt_mobile_inv");
                    DropDownList list = (DropDownList) gv_inv.Rows[num].Cells[1].FindControl("select_inv_nationality");
                    row = table.NewRow();
                    row["RowNumber_inv"] = i + 1;
                    table.Rows[i - 1]["inv_Column2"] = box.Text;
                    table.Rows[i - 1]["inv_Column2"] = box2.Text;
                    table.Rows[i - 1]["inv_Column2"] = box3.Text;
                    table.Rows[i - 1]["inv_Column2"] = box4.Text;
                    table.Rows[i - 1]["inv_Column2"] = list.SelectedValue;
                    SortedList<string, string> item = new SortedList<string, string>();
                    item["txt_name_inv"] = box.Text;
                    item["txt_address_inv"] = box2.Text;
                    item["txt_email_inv"] = box3.Text;
                    item["txt_mobile_inv"] = box4.Text;
                    item["select_inv_nationality"] = list.SelectedValue;
                    if ((box.Text != "") && (box.Text != null))
                    {
                        lt_inv.Add(item);
                    }
                    num++;
                }
                Session["lt_inv"] = lt_inv;
                table.Rows.Add(row);
                ViewState["InvTable"] = table;
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
    }

    protected void SetLatestRowsFromGrid_Pri_gv()
    {
        int num = 0;
        lt_pri.Clear();
        if (ViewState["PriTable"] != null)
        {
            DataTable table = (DataTable) ViewState["PriTable"];
            DataRow row = null;
            if (table.Rows.Count > 0)
            {
                for (int i = 1; i <= table.Rows.Count; i++)
                {
                    DropDownList list = (DropDownList) gv_pri.Rows[num].Cells[1].FindControl("select_country_pri");
                    TextBox box = (TextBox) gv_pri.Rows[num].Cells[2].FindControl("txt_application_no_pri");
                    TextBox box2 = (TextBox) gv_pri.Rows[num].Cells[3].FindControl("txt_date_pri");
                    row = table.NewRow();
                    row["RowNumber_pri"] = i + 1;
                    table.Rows[i - 1]["pri_Column2"] = list.Text;
                    table.Rows[i - 1]["pri_Column3"] = box.Text;
                    table.Rows[i - 1]["pri_Column4"] = box2.Text;
                    SortedList<string, string> item = new SortedList<string, string>();
                    item["select_country_pri"] = list.Text;
                    item["txt_application_no_pri"] = box.Text;
                    item["txt_date_pri"] = box2.Text;
                    if ((box.Text != "") && (box.Text != null))
                    {
                        lt_pri.Add(item);
                    }
                    num++;
                }
                Session["lt_pri"] = lt_pri;
                table.Rows.Add(row);
                ViewState["PriTable"] = table;
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
    }

    private void SetPreviousData_App_gv()
    {
        int num = 0;
        if (lt_app.Count > 0)
        {
            for (int i = 0; i < lt_app.Count; i++)
            {
                TextBox box = (TextBox) gv_app.Rows[num].Cells[1].FindControl("txt_name_app");
                TextBox box2 = (TextBox) gv_app.Rows[num].Cells[1].FindControl("txt_address_app");
                TextBox box3 = (TextBox) gv_app.Rows[num].Cells[1].FindControl("txt_email_app");
                TextBox box4 = (TextBox) gv_app.Rows[num].Cells[1].FindControl("txt_mobile_app");
                DropDownList list = (DropDownList) gv_app.Rows[num].Cells[1].FindControl("select_app_nationality");
                box.Text = lt_app[i]["txt_name_app"];
                box2.Text = lt_app[i]["txt_address_app"];
                box3.Text = lt_app[i]["txt_email_app"];
                box4.Text = lt_app[i]["txt_mobile_app"];
                list.SelectedIndex = Convert.ToInt32(lt_app[i]["select_app_nationality"]) - 1;
                num++;
            }
        }
    }

    private void SetPreviousData_Inv_gv()
    {
        int num = 0;
        if (lt_inv.Count > 0)
        {
            for (int i = 0; i < lt_inv.Count; i++)
            {
                TextBox box = (TextBox) gv_inv.Rows[num].Cells[1].FindControl("txt_name_inv");
                TextBox box2 = (TextBox) gv_inv.Rows[num].Cells[1].FindControl("txt_address_inv");
                TextBox box3 = (TextBox) gv_inv.Rows[num].Cells[1].FindControl("txt_email_inv");
                TextBox box4 = (TextBox) gv_inv.Rows[num].Cells[1].FindControl("txt_mobile_inv");
                DropDownList list = (DropDownList) gv_inv.Rows[num].Cells[1].FindControl("select_inv_nationality");
                box.Text = lt_inv[i]["txt_name_inv"];
                box2.Text = lt_inv[i]["txt_address_inv"];
                box3.Text = lt_inv[i]["txt_email_inv"];
                box4.Text = lt_inv[i]["txt_mobile_inv"];
                list.SelectedIndex = Convert.ToInt32(lt_inv[i]["select_inv_nationality"]) - 1;
                num++;
            }
        }
    }

    private void SetPreviousData_Pri_gv()
    {
        int num = 0;
        if (lt_pri.Count > 0)
        {
            for (int i = 0; i < lt_pri.Count; i++)
            {
                DropDownList list = (DropDownList) gv_pri.Rows[num].Cells[1].FindControl("select_country_pri");
                TextBox box = (TextBox) gv_pri.Rows[num].Cells[2].FindControl("txt_application_no_pri");
                TextBox box2 = (TextBox) gv_pri.Rows[num].Cells[3].FindControl("txt_date_pri");
                list.Text = lt_pri[i]["select_country_pri"];
                box.Text = lt_pri[i]["txt_application_no_pri"];
                box2.Text = lt_pri[i]["txt_date_pri"];
                num++;
            }
        }
    }

  
}

