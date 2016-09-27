using Brettle.Web.NeatUpload;
using Ipo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class xindex: System.Web.UI.Page
{
    public string agent = "";
    public string agentemail = "";
    public string agentpnumber = "";
    public string aid = "";
    public string amt = "";
    public string agentname = "";
    public string fee_detailsID = "";
    public string hwalletID = "0";
    public string log_staffID = "0";
    public string pc = "";
    public string product_title = "";
    public string pwalletID = "0";
    public pt t = new pt();
    public string transID = "";
    public string vid = "";
    public string x = "";
    public string xapplication = "";
    public string xgt = "";
    public string xrep = "";
    public string xuserType = "";
    public string cname = "";
    public string agt = "";
    public string applicantname = "";
    public string applicantemail = "";
    public string applicantpnumber = "";
    public string applicant_addy = "";
    public string item_code = "";
    public string ack_status = "0";
    public string claim_newfilename = "0";
    public string doa_newfilename = "0";
    public string doc_path = "";
    public string gt = "";
    public GatewayService ipo_gateway = new GatewayService();
    public string loa_newfilename = "0";
    public List<SortedList<string, string>> lt_app = new List<SortedList<string, string>>();
    public List<SortedList<string, string>> lt_inv = new List<SortedList<string, string>>();
    public List<SortedList<string, string>> lt_pri = new List<SortedList<string, string>>();
    public string pct_newfilename = "0";
    public SortedList<string, string> sl_xx = new SortedList<string, string>();
    public string spec_newfilename = "0";
    public string status = "0";
    public List<pt.Applicant> list = new List<pt.Applicant>();
    public List<pt.Inventor> list2 = new List<pt.Inventor>();
    public List<pt.Priority_info> list3 = new List<pt.Priority_info>();
    public pt.PtInfo info = new pt.PtInfo();
    public pt.Assignment_info _info = new pt.Assignment_info();
    public pt.Representative representative = new pt.Representative();
    protected string xreg_date = DateTime.Now.ToString("yyyy-MM-dd");
    protected string xvisible = "1";
    public List<pt.Applicant> lt_app2 = new List<pt.Applicant>();
    public List<pt.Assignment_info> lt_assinfo = new List<pt.Assignment_info>();
    public List<pt.Inventor> lt_inv2 = new List<pt.Inventor>();
    public List<pt.PtInfo> lt_mi = new List<pt.PtInfo>();
    public List<pt.Representative> lt_rep = new List<pt.Representative>();
    public List<pt.Stage> lt_stage = new List<pt.Stage>();
    public List<pt.Priority_info> lt_xpri = new List<pt.Priority_info>();
    public int num3 = 0;
    public string validationID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((!Page.IsPostBack))
        {
            string serverpath = Server.MapPath("~/");
            transID = Request.Params["transID"];
            amt = Request.Params["amt"];
            agent = Request.Params["agent"];
            cname = Request.Params["cname"];
            applicantname = Request.Params["applicantname"];
            applicantemail = Request.Params["applicantemail"];
            applicantpnumber = Request.Params["applicantpnumber"];
            applicant_addy = Request.Params["applicant_addy"];
            item_code = Request.Params["item_code"];
            fee_detailsID = Request.Params["fee_detailsID"];
            xgt = Request.Params["xgt"];
            pc = Request.Params["pc"];
            hwalletID = Request.Params["hwalletID"];
            fee_detailsID = Request.Params["fee_detailsID"];
            if ((Request.Params["agentname"] != null) && Request.Params["agentname"].Contains("%26"))
            {
                agentname = Request.Params["agentname"].Replace("%26", "&");
            }
            else
            {
                agentname = Request.Params["agentname"];
            }
            agentemail = Request.Params["agentemail"];
            agentpnumber = Request.Params["agentpnumber"];
            if ((Request.Params["product_title"] != null) && Request.Params["product_title"].Contains("%26"))
            {
                product_title = Request.Params["product_title"].Replace("%26", "&");
            }
            else
            {
                product_title = Request.Params["product_title"];
            }
            Session["hwalletID"] = hwalletID;
            Session["fee_detailsID"] = fee_detailsID;
            if (((((transID != "") && (amt != "")) && ((agent != "") && (xgt != ""))) && (((agentname != "") && (agentemail != "")) && ((agentpnumber != "") && (product_title != "")))) && (pc != ""))
            {
                if (Session["xapplication"] != null)
                {
                    xapplication = Session["xapplication"].ToString();
                    if (xapplication != transID)
                    {
                    }
                }
                else
                {
                    Session["xapplication"] = transID;
                }
                Session["vid"] = transID;
                Session["amt"] = amt;
                Session["aid"] = agent;
                Session["gt"] = xgt;
                Session["pc"] = pc;
                Session["agentemail"] = agentemail;
                Session["agentname"] = agentname;
                Session["agentpnumber"] = agentpnumber;
                Session["product_title"] = product_title;
                Session["fee_detailsID"] = fee_detailsID;
                if (transID != null)
                {
                    if (t.getStageIDByvalidationID(transID) > 0)   { Response.Redirect("./xreturn.aspx"); }
                    else {   }
                }
            }
            else
            {
                if ((hwalletID != null) && (Convert.ToInt32(hwalletID) > 0))//From Portal B i.e ipo.cldng.com
                {
                    Response.Redirect("http://ipo.cldng.com/a_login.aspx");
                }
                else
                {
                    Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                }

            }
        }
        else
        {
            if ((Session["pc"] != null) && (Session["pc"].ToString() != ""))
            {
                pc = Session["pc"].ToString();
                if (pc == "P001")
                { loa_newfilename = "0"; claim_newfilename = "0"; pct_newfilename = "0"; doa_newfilename = "0"; spec_newfilename = "0"; }
                else
                { loa_newfilename = "0"; claim_newfilename = "0"; pct_newfilename = "1"; doa_newfilename = "1"; spec_newfilename = "0"; }
            }
        }
    }
    protected void btnDashboard_Click(object sender, EventArgs e)
    {
        if ((Session["hwalletID"] != null) && (Session["hwalletID"].ToString() != ""))
        {
            Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
        }
        else
        {
            if ((hwalletID != null) && (Convert.ToInt32(hwalletID) > 0))//From Portal B i.e ipo.cldng.com
            {
                Response.Redirect("http://ipo.cldng.com/a_login.aspx");
            }
            else
            {
                Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
            }
            // Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
        }
    }

    private void AddNewRowToGrid_App_gv()
    {
        int num = 0;
        if (ViewState["AppTable"] != null)
        {
            DataTable table = (DataTable)ViewState["AppTable"];
            DataRow row = null;
            if (table.Rows.Count > 0)
            {
                for (int i = 1; i <= table.Rows.Count; i++)
                {
                    TextBox box = (TextBox)gv_app.Rows[num].Cells[1].FindControl("txt_name_app");
                    TextBox box2 = (TextBox)gv_app.Rows[num].Cells[1].FindControl("txt_address_app");
                    TextBox box3 = (TextBox)gv_app.Rows[num].Cells[1].FindControl("txt_email_app");
                    TextBox box4 = (TextBox)gv_app.Rows[num].Cells[1].FindControl("txt_mobile_app");
                    DropDownList list = (DropDownList)gv_app.Rows[num].Cells[1].FindControl("select_app_nationality");
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
            DataTable table = (DataTable)ViewState["InvTable"];
            DataRow row = null;
            if (table.Rows.Count > 0)
            {
                for (int i = 1; i <= table.Rows.Count; i++)
                {
                    TextBox box = (TextBox)gv_inv.Rows[num].Cells[1].FindControl("txt_name_inv");
                    TextBox box2 = (TextBox)gv_inv.Rows[num].Cells[1].FindControl("txt_address_inv");
                    TextBox box3 = (TextBox)gv_inv.Rows[num].Cells[1].FindControl("txt_email_inv");
                    TextBox box4 = (TextBox)gv_inv.Rows[num].Cells[1].FindControl("txt_mobile_inv");
                    DropDownList list = (DropDownList)gv_inv.Rows[num].Cells[1].FindControl("select_inv_nationality");
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
            DataTable table = (DataTable)ViewState["PriTable"];
            DataRow row = null;
            if (table.Rows.Count > 0)
            {
                for (int i = 1; i <= table.Rows.Count; i++)
                {
                    DropDownList list = (DropDownList)gv_pri.Rows[num].Cells[1].FindControl("select_country_pri");
                    TextBox box = (TextBox)gv_pri.Rows[num].Cells[2].FindControl("txt_application_no_pri");
                    TextBox box2 = (TextBox)gv_pri.Rows[num].Cells[3].FindControl("txt_date_pri");
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
       

    protected void Proceed_Click(object sender, EventArgs e)
    {
        tt.Visible = false;
        tt2.Visible = true;

        txt_loa_no.Text = "1"; txt_claim_no.Text = "1";txt_pct_no.Text = "1"; txt_doa_no.Text = "1";
        
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
            aid = Session["aid"].ToString();
        }

        if (Session["agentname"] != null)
        {
            rep_xname.Text = Session["agentname"].ToString();
        }
        SetInitialRow_App_gv();
        SetInitialRow_Inv_gv();
        SetInitialRow_Pri_gv();
        if (Session["vid"] != null)
        {
            transID = Session["vid"].ToString();
            rep_code.Text = Session["aid"].ToString();
        }
        Session["xref"] = Convert.ToInt32(Session["xref"]) + 1;
        if (Session["xref"].ToString() != "1")
        {
        }
        if (((Session["xapplication"] != null) && (Session["xapplication"].ToString() != "")) && (transID != Session["xapplication"].ToString()))
        {
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
    protected void SaveAll_Click(object sender, EventArgs e)
    {
        aid = Session["aid"].ToString();
        amt = Session["amt"].ToString();
        transID = Session["vid"].ToString();
        TransactionOptions transactionOptions = new TransactionOptions
        {


            IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,

            Timeout = TimeSpan.FromMinutes(10.0)
        };
        TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, transactionOptions);

       
            int num;
            SetLatestRowsFromGrid_App_gv();
            SetLatestRowsFromGrid_Inv_gv();
            SetLatestRowsFromGrid_Pri_gv();

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
            pc = (String)Session["pc"];
            if (Session["pwalletID"] != null)
            {
                representative.log_staff = Session["pwalletID"].ToString();
            }
            lt_app = (List<SortedList<string, string>>)Session["lt_app"];
            lt_inv = (List<SortedList<string, string>>)Session["lt_inv"];
            lt_pri = (List<SortedList<string, string>>)Session["lt_pri"];
            if (lt_app.Count > 0)
            {
                for (num = 0; num < lt_app.Count; num++)
                {
                    pt.Applicant item = new pt.Applicant
                    {
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
                    pt.Inventor inventor = new pt.Inventor
                    {
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
                    pt.Priority_info _info2 = new pt.Priority_info
                    {
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
            if (Session["hwalletID"] != null)
            {
                hwalletID = Session["hwalletID"].ToString();
               // status = t.updateHwallet(hwalletID, "Used", xreg_date, txt_title_of_invention.Text).ToString();
            }
        
            
            num3 = t.addNewPatentX(list, list3, list2, info, _info, representative, transID, aid, amt, hwalletID);
            if (num3 > 0)
            {
              //  Session["new_ptID"] = null;
                Session["new_ptID"] = num3;
            }
            else
            {

                Response.Redirect("tt2.aspx");
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
                            if ((hwalletID != null) && (Convert.ToInt32(hwalletID) > 0))
                            {
                               
                                ws_payx.payxSoapClient ws_p = new ws_payx.payxSoapClient();
                                status = Convert.ToString(ws_p.UpdateHwallet(hwalletID, "Used", xreg_date, txt_title_of_invention.Text));
                              
                             
                            }
                            else
                            {
                                try
                                {
                                //  status = ipo_gateway.UpdateTransaction(str, str2, "1");
                                status = "1";
                            }
                                catch (Exception ee)
                                {
                                    status = "1";
                                }
                            }
                           
                         
                            if (status == "1")
                            {
                                ack_status = "1";
                                if (Session["vid"] != null)
                                {
                                    scope.Complete();
                                    scope.Dispose();

                            //  string vd =    t.ValidationIDByPwalletID(Session["new_ptID"].ToString());
                                    Label5.Text = "OAI/PT/" + Session["vid"].ToString();
                                    tt3.Visible = true;
                                    tt2.Visible = false;

                                    if ((Session["pc"] != null) && (Session["pc"].ToString() != ""))
                                    {
                                        pc = Session["pc"].ToString();
                                        if (pc == "P001")
                                        { loa_newfilename = "0"; claim_newfilename = "0"; pct_newfilename = "0"; doa_newfilename = "0"; spec_newfilename = "0"; }
                                        else
                                        { loa_newfilename = "0"; claim_newfilename = "0"; pct_newfilename = "1"; doa_newfilename = "1"; spec_newfilename = "0"; }
                                    }


                                    // Response.Redirect("./tm_acknowledgement.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + Session["vid"].ToString(), false);
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
                        }
                        else
                        {
                            Response.Redirect("tt5.aspx");
                            scope.Dispose();
                        }
                    }

                    else
                    {
                        Response.Redirect("tt4.aspx");
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
                    if (pc.Trim() == "P002")
                    {

                        loa_newfilename = "0";
                        claim_newfilename = "0";
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

                        if ((hwalletID != null) && (Convert.ToInt32(hwalletID) > 0))
                        {
                            ws_payx.payxSoapClient ws_p = new ws_payx.payxSoapClient();
                            status = Convert.ToString(ws_p.UpdateHwallet(hwalletID, "Used", xreg_date, txt_title_of_invention.Text));

                          //  status = "1";
                          
                        }
                        else
                        {
                            try
                            {
                            // status = ipo_gateway.UpdateTransaction(str, str2, "1");
                            status = "1";
                        }

                            catch (Exception ee)
                            {
                                status = "1";
                            }
                        }
                        //  status = ipo_gateway.UpdateTransaction(str, str2, "1");
                  
                    //    status = "1";
                        if (status == "1")
                        {
                            ack_status = "1";
                            if (Session["vid"] != null)
                            {
                                scope.Complete();
                                scope.Dispose();
                               // string vd = t.ValidationIDByPwalletID(Session["new_ptID"].ToString());
                                Label5.Text = "OAI/PT/" + Session["vid"].ToString();
                                tt3.Visible = true;
                                tt2.Visible = false;

                                if ((Session["pc"] != null) && (Session["pc"].ToString() != ""))
                                {
                                    pc = Session["pc"].ToString();
                                    if (pc == "P001")
                                    { loa_newfilename = "0"; claim_newfilename = "0"; pct_newfilename = "0"; doa_newfilename = "0"; spec_newfilename = "0"; }
                                    else
                                    { loa_newfilename = "0"; claim_newfilename = "0"; pct_newfilename = "1"; doa_newfilename = "1"; spec_newfilename = "0"; }
                                }
                              //  pc = (String)Session["pc"];
                                // Response.Redirect("./tm_acknowledgement.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + Session["vid"].ToString(), false);
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
                    }
                    else
                    {
                       scope.Dispose();
                    }
                }
            }
            else
            {
                Response.Redirect("tt3.aspx");
                scope.Dispose();
            }
       
       
    }

    protected void newsProviderID_DataBound(object sender, EventArgs e)
    {
        //simple test   
        select_assignee_nationality.SelectedValue = "160";
    }

    protected void newsProviderID_DataBound2(object sender, EventArgs e)
    {
        //simple test   
        select_assignor_nationality.SelectedValue = "160";
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
            DataTable table = (DataTable)ViewState["AppTable"];
            DataRow row = null;
            if (table.Rows.Count > 0)
            {
                for (int i = 1; i <= table.Rows.Count; i++)
                {
                    TextBox box = (TextBox)gv_app.Rows[num].Cells[1].FindControl("txt_name_app");
                    TextBox box2 = (TextBox)gv_app.Rows[num].Cells[1].FindControl("txt_address_app");
                    TextBox box3 = (TextBox)gv_app.Rows[num].Cells[1].FindControl("txt_email_app");
                    TextBox box4 = (TextBox)gv_app.Rows[num].Cells[1].FindControl("txt_mobile_app");
                    DropDownList list = (DropDownList)gv_app.Rows[num].Cells[1].FindControl("select_app_nationality");
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
            DataTable table = (DataTable)ViewState["InvTable"];
            DataRow row = null;
            if (table.Rows.Count > 0)
            {
                for (int i = 1; i <= table.Rows.Count; i++)
                {
                    TextBox box = (TextBox)gv_inv.Rows[num].Cells[1].FindControl("txt_name_inv");
                    TextBox box2 = (TextBox)gv_inv.Rows[num].Cells[1].FindControl("txt_address_inv");
                    TextBox box3 = (TextBox)gv_inv.Rows[num].Cells[1].FindControl("txt_email_inv");
                    TextBox box4 = (TextBox)gv_inv.Rows[num].Cells[1].FindControl("txt_mobile_inv");
                    DropDownList list = (DropDownList)gv_inv.Rows[num].Cells[1].FindControl("select_inv_nationality");
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
            DataTable table = (DataTable)ViewState["PriTable"];
            DataRow row = null;
            if (table.Rows.Count > 0)
            {
                for (int i = 1; i <= table.Rows.Count; i++)
                {
                    DropDownList list = (DropDownList)gv_pri.Rows[num].Cells[1].FindControl("select_country_pri");
                    TextBox box = (TextBox)gv_pri.Rows[num].Cells[2].FindControl("txt_application_no_pri");
                    TextBox box2 = (TextBox)gv_pri.Rows[num].Cells[3].FindControl("txt_date_pri");
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
                TextBox box = (TextBox)gv_app.Rows[num].Cells[1].FindControl("txt_name_app");
                TextBox box2 = (TextBox)gv_app.Rows[num].Cells[1].FindControl("txt_address_app");
                TextBox box3 = (TextBox)gv_app.Rows[num].Cells[1].FindControl("txt_email_app");
                TextBox box4 = (TextBox)gv_app.Rows[num].Cells[1].FindControl("txt_mobile_app");
                DropDownList list = (DropDownList)gv_app.Rows[num].Cells[1].FindControl("select_app_nationality");
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
                TextBox box = (TextBox)gv_inv.Rows[num].Cells[1].FindControl("txt_name_inv");
                TextBox box2 = (TextBox)gv_inv.Rows[num].Cells[1].FindControl("txt_address_inv");
                TextBox box3 = (TextBox)gv_inv.Rows[num].Cells[1].FindControl("txt_email_inv");
                TextBox box4 = (TextBox)gv_inv.Rows[num].Cells[1].FindControl("txt_mobile_inv");
                DropDownList list = (DropDownList)gv_inv.Rows[num].Cells[1].FindControl("select_inv_nationality");
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
                DropDownList list = (DropDownList)gv_pri.Rows[num].Cells[1].FindControl("select_country_pri");
                TextBox box = (TextBox)gv_pri.Rows[num].Cells[2].FindControl("txt_application_no_pri");
                TextBox box2 = (TextBox)gv_pri.Rows[num].Cells[3].FindControl("txt_date_pri");
                list.Text = lt_pri[i]["select_country_pri"];
                box.Text = lt_pri[i]["txt_application_no_pri"];
                box2.Text = lt_pri[i]["txt_date_pri"];
                num++;
            }
        }
    }
   
}