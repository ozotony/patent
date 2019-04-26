using System;
using log4net;

using System.Collections.Generic;
using System.Data;

using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.UI.HtmlControls;


public partial class admin_pt_examiners_unit_edit_form : System.Web.UI.Page
{
    public string admin = "";
    public string agentemail;
    public string agentpnumber;
    public string aid = "";
    public string amt = "";
    public string app_updateID = "0";
    public string assinfo_updateID = "0";
    public pt.Applicant c_app = new pt.Applicant();
    public pt.Assignment_info c_assinfo = new pt.Assignment_info();
    public pt.Inventor c_inv = new pt.Inventor();
    public pt.Priority_info c_pri = new pt.Priority_info();
    public pt.PtInfo c_ptinfo = new pt.PtInfo();
    public pt.Representative c_rep = new pt.Representative();
    public string cname = "";
    public string gt = "";
    public string inv_updateID = "0";
    public List<SortedList<string, string>> lt_app = new List<SortedList<string, string>>();
    public List<pt.Applicant> lt_appx = new List<pt.Applicant>();
    public List<pt.Assignment_info> lt_assinfox = new List<pt.Assignment_info>();
    public List<SortedList<string, string>> lt_inv = new List<SortedList<string, string>>();
    public List<pt.Inventor> lt_invx = new List<pt.Inventor>();
    public List<pt.PtInfo> lt_mix = new List<pt.PtInfo>();
    public List<SortedList<string, string>> lt_pri = new List<SortedList<string, string>>();
    public List<pt.Stage> lt_pwx = new List<pt.Stage>();
    public List<pt.Representative> lt_repx = new List<pt.Representative>();
    public List<pt.Stage> lt_stagex = new List<pt.Stage>();
    public List<pt.Applicant> lt_xapp = new List<pt.Applicant>();
    public List<pt.Inventor> lt_xinv = new List<pt.Inventor>();
    public List<pt.Priority_info> lt_xpri = new List<pt.Priority_info>();
    public List<pt.Priority_info> lt_xprix = new List<pt.Priority_info>();
    public string mix_updateID = "0";
    public string pc = "";
    public string pri_updateID = "0";
    public string pt_succ = "";
    public string rep_updateID = "0";
    public int showt;
    public SortedList<string, string> sl_xx = new SortedList<string, string>();
    public string status = "0";
    public pt t = new pt();
    public string transID = "";
    public string vid = "";
    public string xapplication = "";
    protected string xreg_date = DateTime.Now.ToString("yyyy-MM-dd");
    protected string xvisible = "1";
    public string oldproduct_title;
    public string oldclass;
    public string oldname;

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

    protected void btnDashBoard_Click(object sender, EventArgs e)
    {
        Response.Redirect("./profile.aspx");
    }

    protected void ButtonAddApp_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid_App_gv(); showt = 1;
    }

    protected void ButtonAddInv_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid_Inv_gv(); showt = 1;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["pwalletID"] != null)
        {
            if (Session["pwalletID"].ToString() != "")
            {
                admin = Session["pwalletID"].ToString();
                Session["xofficer"] = admin;
            }
            else
            {
                Response.Redirect("../lo.aspx");
            }
        }
        else
        {
            Response.Redirect("../lo.aspx");
        }
        if (!IsPostBack)
        {
            Session["loa_doc"] = null;
            Session["claim_doc"] = null;
            Session["pct_doc"] = null;
            Session["doa_doc"] = null;
            Session["spec_doc"] = null;
            Session["loa_doc_no"] = null;
            Session["claim_doc_no"] = null;
            Session["pct_doc_no"] = null;
            Session["doa_doc_no"] = null;
            Session["pc"] = null;
        }
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        if (xref.Text != "")
        {
            int num;
            int num2;
            lt_pwx = t.getStageByUserIDAdmin(xref.Text.Trim());
            int vstatus = Convert.ToInt32(lt_pwx[0].status);
            string vstatus3 = lt_pwx[0].data_status;

            if (vstatus > 3 || vstatus3 == "Refused")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "showDialogue", "showDialogue('" + "Sorry You Cannot Edit Application At this Stage" + "');", true);
                return;
            }

            else
            {

               
            }
            if (lt_pwx.Count > 0)
            {
                Session["vid"] = xref.Text.Trim();
                Session["lt_pwx"] = lt_pwx;
                Session["log_staff"] = lt_pwx[0].ID;
                rep_code.Text = lt_pwx[0].applicantID;
                lt_mix = t.getPtInfoByPwalletID(lt_pwx[0].ID);
                lt_repx = t.getRepListByUserID(lt_pwx[0].ID);
                lt_stagex = t.getStageByUserID(lt_pwx[0].ID);
                lt_appx = t.getApplicantByvalidationID(lt_pwx[0].ID);
                oldname = lt_appx[0].xname;
                lt_invx = t.getInventorByvalidationID(lt_pwx[0].ID);
                lt_assinfox = t.getAssignment_infoByvalidationID(lt_pwx[0].ID);
                lt_xprix = t.getPriority_infoByvalidationID(lt_pwx[0].ID);
            }
            SetInitialRow_App_gv();
            SetInitialRow_Inv_gv();
            SetInitialRow_Pri_gv();
            if (Session["vid"] != null)
            {
                transID = Session["vid"].ToString();
            }
            if (lt_mix.Count > 0)
            {
                string str = "../";
                Session["lt_mix"] = lt_mix;
                Session["pc"] = lt_mix[0].xtype;
                Session["loa_doc"] = str + lt_mix[0].loa_doc;
                Session["claim_doc"] = str + lt_mix[0].claim_doc;
                Session["pct_doc"] = str + lt_mix[0].pct_doc;
                Session["doa_doc"] = str + lt_mix[0].doa_doc;
                Session["spec_doc"] = str + lt_mix[0].spec_doc;
                Session["loa_doc_no"] = lt_mix[0].loa_no;
                Session["claim_doc_no"] = lt_mix[0].claim_no;
                Session["pct_doc_no"] = lt_mix[0].pct_no;
                Session["doa_doc_no"] = lt_mix[0].doa_no;

                lbl_type.Text = lt_mix[0].xtype;
                oldproduct_title = lt_mix[0].title_of_invention;
                txt_title_of_invention.Text = lt_mix[0].title_of_invention;
                txt_pt_desc.Text = lt_mix[0].pt_desc;
                TextBox1.Text = lt_mix[0].reg_date;

            }
            if (lt_assinfox.Count > 0)
            {
                Session["lt_assinfox"] = lt_assinfox;
                txt_assignment_date.Text = lt_assinfox[0].date_of_assignment;
                txt_assignee_name.Text = lt_assinfox[0].assignee_name;
                txt_assignee_address.Text = lt_assinfox[0].assignee_address;
                select_assignee_nationality.SelectedIndex = Convert.ToInt32(lt_assinfox[0].assignee_nationality) - 1;
                txt_assignor_name.Text = lt_assinfox[0].assignor_name;
                txt_assignor_address.Text = lt_assinfox[0].assignor_address;
                select_assignor_nationality.SelectedIndex = Convert.ToInt32(lt_assinfox[0].assignor_nationality) - 1;
            }
            if (lt_repx.Count > 0)
            {
                Session["lt_repx"] = lt_repx;
                rep_code.Text = lt_repx[0].agent_code;
                rep_xname.Text = lt_repx[0].xname;
                txt_rep_email.Text = lt_repx[0].xemail;
                txt_rep_telephone.Text = lt_repx[0].xmobile;
                select_rep_state.SelectedIndex = Convert.ToInt32(lt_repx[0].state) - 1;
                txt_rep_address.Text = lt_repx[0].address;
            }
            if (lt_xprix.Count > 0)
            {
                Session["lt_xprix"] = lt_xprix;
                for (num = 0; num < lt_xprix.Count; num++)
                {
                    num2 = num + 1;
                    UpdateNewRowToGrid_Pri_gv(lt_xprix[num].app_no, lt_xprix[num].xdate, lt_xprix[num].countryID, num2, lt_xprix[num].xID);

                }

                //    select_country_pri.SelectedIndex = Convert.ToInt32(lt_xprix[0].countryID) - 1;
                // txt_application_no_pri.Text = lt_xprix[0].app_no;
                // txt_date_pri.Text = lt_xprix[0].xdate;
            }
            if (lt_appx.Count > 0)
            {
                Session["lt_appx"] = lt_appx;
                for (num = 0; num < lt_appx.Count; num++)
                {
                    num2 = num + 1;
                    UpdateNewRowToGrid_App_gv(lt_appx[num].xname, lt_appx[num].address, lt_appx[num].xemail, lt_appx[num].xmobile, Convert.ToInt32(lt_appx[num].nationality), num2);
                }
            }
            if (lt_invx.Count > 0)
            {
                Session["lt_invx"] = lt_invx;
                for (num = 0; num < lt_invx.Count; num++)
                {
                    num2 = num + 1;
                    UpdateNewRowToGrid_Inv_gv(lt_invx[num].xname, lt_invx[num].address, lt_invx[num].xemail, lt_invx[num].xmobile, Convert.ToInt32(lt_invx[num].nationality), num2);
                }
            }
            showt = 1;
            admin = Session["pwalletID"].ToString();
            lt_pwx = (List<pt.Stage>)Session["lt_pwx"];


        }
        else
        {
            Response.Write("<script language=JavaScript>alert('PLEASE ENTER A VALID REFERENCE NUMBER')</script>");
        }
    }

    protected void SaveAll_Click(object sender, EventArgs e)
    {

        int num;
        if (Session["lt_pwx"] != null)
        {
            lt_pwx.Clear();
            lt_pwx = (List<pt.Stage>)Session["lt_pwx"];


        }
        if (Session["lt_mix"] != null)
        {
            lt_mix.Clear();
            lt_mix = (List<pt.PtInfo>)Session["lt_mix"];
            c_ptinfo.xID = lt_mix[0].xID;
        }
        if (Session["lt_repx"] != null)
        {
            lt_repx.Clear();
            lt_repx = (List<pt.Representative>)Session["lt_repx"];
            c_rep.ID = lt_repx[0].ID;
        }
        if (Session["lt_appx"] != null)
        {
            lt_appx.Clear();
            lt_appx = (List<pt.Applicant>)Session["lt_appx"];
        }
        if (Session["lt_invx"] != null)
        {
            lt_invx.Clear();
            lt_invx = (List<pt.Inventor>)Session["lt_invx"];
        }
        if (Session["lt_assinfox"] != null)
        {
            lt_assinfox.Clear();
            lt_assinfox = (List<pt.Assignment_info>)Session["lt_assinfox"];
            c_assinfo.ID = lt_assinfox[0].ID;
        }
        if (Session["lt_xprix"] != null)
        {
            lt_xprix.Clear();
            lt_xprix = (List<pt.Priority_info>)Session["lt_xprix"];
            c_pri.xID = lt_xprix[0].xID;
        }
        SetLatestRowsFromGrid_App_gv();
        SetLatestRowsFromGrid_Inv_gv();
        c_ptinfo.reg_number = "";
        c_ptinfo.xtype = lbl_type.Text;
        c_ptinfo.title_of_invention = txt_title_of_invention.Text;
        c_ptinfo.pt_desc = txt_pt_desc.Text;
        if (lt_pwx.Count > 0)
        {
            t.updatePwalletDate(lt_pwx[0].ID, TextBox1.Text);
            c_ptinfo.log_staff = lt_pwx[0].ID;
        }
        c_ptinfo.reg_date = TextBox1.Text;
        try
        {
            lt_mix[0].reg_date = TextBox1.Text;



            if ((lt_mix[0].reg_date == null) || (c_ptinfo.reg_date == ""))
            {
                c_ptinfo.reg_date = xreg_date;
            }
            else
            {
                c_ptinfo.reg_date = lt_mix[0].reg_date;
            }

        }

        catch (Exception ee)
        {

        }
        c_ptinfo.xvisible = xvisible;
        c_ptinfo.claim_no = "0";
        c_ptinfo.loa_no = "0";
        c_ptinfo.pct_no = "0";
        c_ptinfo.doa_no = "0";
        c_assinfo.date_of_assignment = txt_assignment_date.Text;
        c_assinfo.assignee_name = txt_assignee_name.Text;
        c_assinfo.assignee_address = txt_assignee_address.Text;
        c_assinfo.assignee_nationality = select_assignee_nationality.SelectedValue;
        c_assinfo.assignor_name = txt_assignor_name.Text;
        c_assinfo.assignor_address = txt_assignor_address.Text;
        c_assinfo.assignor_nationality = select_assignor_nationality.SelectedValue;
        if (lt_pwx.Count > 0)
        {
            c_assinfo.log_staff = lt_pwx[0].ID;
        }
        c_assinfo.visible = xvisible;
        c_rep.agent_code = rep_code.Text;
        c_rep.xname = rep_xname.Text;
        c_rep.nationality = "160";
        c_rep.country = "160";
        c_rep.state = select_rep_state.SelectedValue;
        c_rep.address = txt_rep_address.Text;
        c_rep.xmobile = txt_rep_telephone.Text;
        c_rep.xemail = txt_rep_email.Text;
        c_rep.reg_date = TextBox1.Text;
        if ((c_rep.reg_date == null) || (c_rep.reg_date == ""))
        {
            c_rep.reg_date = xreg_date;
        }
        c_rep.visible = xvisible;
        if (lt_pwx.Count > 0)
        {
            c_rep.log_staff = lt_pwx[0].ID;
        }
        if (Session["lt_app"] != null)
        {
            lt_app = (List<SortedList<string, string>>)Session["lt_app"];
        }
        if (Session["lt_inv"] != null)
        {
            lt_inv = (List<SortedList<string, string>>)Session["lt_inv"];
        }
        if (Session["lt_pri"] != null)
        {
            lt_pri = (List<SortedList<string, string>>)Session["lt_pri"];
        }
        if (lt_app.Count > 0)
        {
            for (num = 0; num < lt_app.Count; num++)
            {
                pt.Applicant applicant = new pt.Applicant
                {
                    xname = lt_app[num]["txt_name_app"],
                    address = lt_app[num]["txt_address_app"],
                    xemail = lt_app[num]["txt_email_app"],
                    xmobile = lt_app[num]["txt_mobile_app"],
                    nationality = lt_app[num]["select_app_nationality"]
                };
                if (Session["log_staff"] != null)
                {
                    applicant.log_staff = Session["log_staff"].ToString();
                }
                applicant.visible = xvisible;
                c_app = null;
                c_app = applicant;
                lt_xapp.Add(c_app);
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
                if (Session["log_staff"] != null)
                {
                    inventor.log_staff = Session["log_staff"].ToString();
                }
                inventor.visible = xvisible;
                c_inv = null;
                c_inv = inventor;
                lt_xinv.Add(c_inv);
            }
        }
        c_pri.countryID = select_country_pri.SelectedValue;
        c_pri.app_no = txt_application_no_pri.Text;
        c_pri.xdate = txt_date_pri.Text;
        if (Session["log_staff"] != null)
        {
            c_pri.log_staff = Session["log_staff"].ToString();
        }
        c_pri.xvisible = xvisible;
        lt_xpri.Add(c_pri);
        if (((((lt_mix.Count == 0) && (lt_repx.Count == 0)) && ((lt_appx.Count == 0) && (lt_invx.Count == 0))) && (lt_assinfox.Count == 0)) && (lt_xprix.Count == 0))
        {
            pt_succ = t.addNewPatent(lt_xapp, lt_xpri, lt_xinv, c_ptinfo, c_assinfo, c_rep);


        }
        else
        {

            if (lt_repx.Count == 0)
            {
                rep_updateID = t.addRepresentative(c_rep);
            }
            else
            {
                rep_updateID = t.updateRepresentative(c_rep);
            }
            if (lt_assinfox.Count == 0)
            {
                if (((((c_assinfo.assignee_name != null) && (c_assinfo.assignee_name != "")) && ((c_assinfo.date_of_assignment != null) && (c_assinfo.date_of_assignment != ""))) && (c_assinfo.ID != null)) && (c_assinfo.ID != ""))
                {
                    assinfo_updateID = t.addAssignment_info(c_assinfo);
                }
            }
            else if (((c_assinfo.ID != null)) && (c_assinfo.ID != ""))
            {
                assinfo_updateID = t.updateAssignment_info(c_assinfo);
            }
            if (lt_xprix.Count == 0)
            {

                //   pri_updateID = t.addPriority_info(c_pri);
            }
            else
            {
                foreach (GridViewRow row in Gridview1.Rows)
                {
                    String box = ((TextBox)row.FindControl("txt_name_pri")).Text;
                    String box2 = ((TextBox)row.FindControl("txt_pri_date")).Text;

                    String box3 = ((TextBox)row.FindControl("vid")).Text;

                    String box4 = ((DropDownList)row.FindControl("select_inv_nationality2")).SelectedValue;
                    var dd = "";
                    c_pri.app_no = box;
                    c_pri.countryID = box4;
                    c_pri.xdate = box2;

                    c_pri.xID = box3;
                    if (box3 != "")
                    {
                        pri_updateID = t.updatePriority_info(c_pri);

                    }
                    // TextBox box = ((TextBox)row.FindControl("txt_name_pri");

                }


                for (num = 0; num < lt_pri.Count; num++)
                {
                    //  pri_updateID = t.updatePriority_info(c_pri);

                }
            }
            if (lt_xapp.Count == 0)
            {
                foreach (pt.Applicant applicant2 in lt_xapp)
                {
                    if ((applicant2.xname != null) && (applicant2.xname != ""))
                    {
                        app_updateID = t.addApplicant(applicant2);
                    }
                }
            }
            else
            {
                t.deleteApplicant(lt_pwx[0].ID);
                foreach (pt.Applicant applicant2 in lt_xapp)
                {
                    if ((applicant2.xname != null) && (applicant2.xname != ""))
                    {
                        app_updateID = t.addApplicant(applicant2);
                    }
                }
            }
            if (lt_xinv.Count == 0)
            {
                foreach (pt.Inventor inventor2 in lt_xinv)
                {
                    if ((inventor2.xname != null) && (inventor2.xname != ""))
                    {
                        inv_updateID = t.addInventor(inventor2);
                    }

                    else
                    {
                        t.deleteInventor(inventor2.log_staff);

                    }


                }
            }
            else
            {
                t.deleteInventor(lt_pwx[0].ID);
                foreach (pt.Inventor inventor2 in lt_xinv)
                {
                    if ((inventor2.xname != null) && (inventor2.xname != ""))
                    {

                        inv_updateID = t.addInventor(inventor2);
                    }

                    else
                    {
                        t.deleteInventor(inventor2.log_staff);

                    }
                }
            }
            if (lt_mix.Count == 0)
            {
                mix_updateID = t.addPt(c_ptinfo);
                t.updatePtReg(mix_updateID, c_ptinfo.xtype);
                Session["mix_updateID"] = c_ptinfo.xID;
                if (Convert.ToInt32(mix_updateID) > 0)
                {
                    Response.Redirect("./edit_form_docs.aspx");
                }
            }
            else
            {
                mix_updateID = t.updatePtInfo(c_ptinfo);
                // t.updatePtReg(c_ptinfo.xID, c_ptinfo.xtype);
                Session["mix_updateID"] = c_ptinfo.xID;
                if (Convert.ToInt32(mix_updateID) > 0)
                {
                    Response.Redirect("./edit_form_docs.aspx");
                }
            }

            t.activity_log(admin, "Edit Application", "Update", lt_pwx[0].ID, lt_pwx[0].data_status, oldproduct_title, txt_title_of_invention.Text, oldname, lt_app[0]["txt_name_app"], "", "");
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
        table.Columns.Add(new DataColumn("RowNumber_inv2", typeof(string)));
        table.Columns.Add(new DataColumn("inv_Column3", typeof(string)));
        row = table.NewRow();
        row["RowNumber_inv2"] = 1;
        row["inv_Column3"] = string.Empty;
        table.Rows.Add(row);
        ViewState["InvTable2"] = table;
        Gridview1.DataSource = table;
        Gridview1.DataBind();
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
                TextBox box = (TextBox)Gridview1.Rows[num].Cells[1].FindControl("txt_name_pri");
                TextBox box2 = (TextBox)Gridview1.Rows[num].Cells[1].FindControl("txt_pri_date");

                DropDownList list = (DropDownList)Gridview1.Rows[num].Cells[1].FindControl("select_inv_nationality2");
                TextBox box3 = (TextBox)Gridview1.Rows[num].Cells[1].FindControl("vid");
                box.Text = lt_pri[i]["txt_name_pri"];
                box2.Text = lt_pri[i]["txt_pri_date"];

                list.SelectedIndex = Convert.ToInt32(lt_pri[i]["select_inv_nationality2"]) - 1;
                box3.Text = lt_pri[i]["vid"];
                num++;
            }
        }
    }

    private void UpdateNewRowToGrid_App_gv(string name, string addy, string email, string mob, int nationality, int sn)
    {
        int num = 0;
        if (ViewState["AppTable"] != null)
        {
            DataTable table = (DataTable)ViewState["AppTable"];
            DataRow row = null;
            TextBox box = (TextBox)gv_app.Rows[num].Cells[1].FindControl("txt_name_app");
            TextBox box2 = (TextBox)gv_app.Rows[num].Cells[1].FindControl("txt_address_app");
            TextBox box3 = (TextBox)gv_app.Rows[num].Cells[1].FindControl("txt_email_app");
            TextBox box4 = (TextBox)gv_app.Rows[num].Cells[1].FindControl("txt_mobile_app");
            DropDownList list = (DropDownList)gv_app.Rows[num].Cells[1].FindControl("select_app_nationality");
            row = table.NewRow();
            row["RowNumber_app"] = sn + 1;
            table.Rows[0]["app_Column1"] = name;
            table.Rows[0]["app_Column1"] = addy;
            table.Rows[0]["app_Column1"] = email;
            table.Rows[0]["app_Column1"] = mob;
            table.Rows[0]["app_Column1"] = nationality;
            SortedList<string, string> item = new SortedList<string, string>();
            item["txt_name_app"] = name;
            item["txt_address_app"] = addy;
            item["txt_email_app"] = email;
            item["txt_mobile_app"] = mob;
            item["select_app_nationality"] = Convert.ToString(nationality);
            lt_app.Add(item);
            num++;
            Session["lt_app"] = lt_app;
            table.Rows.Add(row);
            ViewState["AppTable"] = table;
            gv_app.DataSource = table;
            gv_app.DataBind();
        }
        else
        {
            Response.Write("ViewState is null");
        }
        SetPreviousData_App_gv();
    }

    private void UpdateNewRowToGrid_Inv_gv(string name, string addy, string email, string mob, int nationality, int sn)
    {
        int num = 0;
        if (ViewState["InvTable"] != null)
        {
            DataTable table = (DataTable)ViewState["InvTable"];
            DataRow row = null;
            TextBox box = (TextBox)gv_inv.Rows[num].Cells[1].FindControl("txt_name_inv");
            TextBox box2 = (TextBox)gv_inv.Rows[num].Cells[1].FindControl("txt_address_inv");
            TextBox box3 = (TextBox)gv_inv.Rows[num].Cells[1].FindControl("txt_email_inv");
            TextBox box4 = (TextBox)gv_inv.Rows[num].Cells[1].FindControl("txt_mobile_inv");
            DropDownList list = (DropDownList)gv_inv.Rows[num].Cells[1].FindControl("select_inv_nationality");
            row = table.NewRow();
            row["RowNumber_inv"] = sn + 1;
            table.Rows[0]["inv_Column2"] = name;
            table.Rows[0]["inv_Column2"] = addy;
            table.Rows[0]["inv_Column2"] = email;
            table.Rows[0]["inv_Column2"] = mob;
            table.Rows[0]["inv_Column2"] = nationality;
            SortedList<string, string> item = new SortedList<string, string>();
            item["txt_name_inv"] = name;
            item["txt_address_inv"] = addy;
            item["txt_email_inv"] = email;
            item["txt_mobile_inv"] = mob;
            item["select_inv_nationality"] = Convert.ToString(nationality);
            lt_inv.Add(item);
            num++;
            Session["lt_inv"] = lt_inv;
            table.Rows.Add(row);
            ViewState["InvTable"] = table;
            gv_inv.DataSource = table;
            gv_inv.DataBind();
        }
        else
        {
            Response.Write("ViewState is null");
        }
        SetPreviousData_Inv_gv();
    }

    private void UpdateNewRowToGrid_Pri_gv(string name, string addy, string nationality, int sn, string xid)
    {
        int num = 0;
        if (ViewState["InvTable2"] != null)
        {
            DataTable table = (DataTable)ViewState["InvTable2"];
            DataRow row = null;
            TextBox box = (TextBox)Gridview1.Rows[num].Cells[1].FindControl("txt_name_pri");
            TextBox box2 = (TextBox)Gridview1.Rows[num].Cells[1].FindControl("txt_pri_date");



            DropDownList list = (DropDownList)Gridview1.Rows[num].Cells[1].FindControl("select_inv_nationality2");
            TextBox box3 = (TextBox)Gridview1.Rows[num].Cells[1].FindControl("vid");
            row = table.NewRow();
            row["RowNumber_inv2"] = sn + 1;
            table.Rows[0]["inv_Column3"] = name;
            table.Rows[0]["inv_Column3"] = addy;

            table.Rows[0]["inv_Column3"] = nationality;
            table.Rows[0]["inv_Column3"] = xid;
            SortedList<string, string> item = new SortedList<string, string>();
            item["txt_name_pri"] = name;
            item["txt_pri_date"] = addy;



            item["select_inv_nationality2"] = Convert.ToString(nationality);

            item["vid"] = xid;

            lt_pri.Add(item);
            num++;
            Session["lt_pri"] = lt_pri;
            table.Rows.Add(row);
            ViewState["InvTable2"] = table;
            Gridview1.DataSource = table;
            Gridview1.DataBind();
        }
        else
        {
            Response.Write("ViewState is null");
        }
        //  SetPreviousData_Inv_gv();

        SetPreviousData_Pri_gv();
    }

}