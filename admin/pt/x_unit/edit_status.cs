using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class admin_pt_x_unit_edit_status : Page
{
    public string admin = "";
    public string agt;
    public zues.PtOffice c_office = new zues.PtOffice();
    public string data_status = "N/A";
    public List<pt.PtInfo> lt_mi = new List<pt.PtInfo>();
    public List<pt.Stage> lt_pw = new List<pt.Stage>();
    public pt.Representative lt_rep = new pt.Representative();
    public string r;
    public int showt;
    public string status = "N/A";
    public pt t = new pt();
    public string trans_status = "";
    public zues z = new zues();

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
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        if (xref.Text != "")
        {
            if (xref.Text.Contains("OAI/PT/"))
            {
                xref.Text = xref.Text.Replace("OAI/PT/", "");
            }
            r = xref.Text;
            lt_pw = t.getStageByUserIDAdmin(xref.Text);
           
            if (lt_pw.Count > 0)
            {
                Session["pwID"] = lt_pw[0].ID;
                agt = lt_pw[0].applicantID;
                Session["xvid"] = xref.Text;
                Session["edit_transID"] = xref.Text;
                lt_mi = t.getPtInfoByUserID(lt_pw[0].ID);
                lt_rep = t.getRepByUserID(lt_pw[0].ID);
                if (lt_pw[0].status == "1")
                {
                    status = "Payment Verification Office";
                    if (lt_pw[0].data_status == "Fresh")
                    {
                        data_status = "Untreated";
                    }
                    else if (lt_pw[0].data_status == "Invalid")
                    {
                        data_status = "Invalid";
                    }
                    else if (lt_pw[0].data_status == "V_Contact")
                    {
                        data_status = "Being processed";
                    }
                }
                if (lt_pw[0].status == "2")
                {
                    status = "Patent Search Office";
                    if (lt_pw[0].data_status == "Valid")
                    {
                        data_status = "Successfully reviewed";
                    }
                    else if (lt_pw[0].data_status == "S_Contact")
                    {
                        data_status = "Being processed";
                    }
                }
                if (lt_pw[0].status == "3")
                {
                    status = "Patent Examiner 1 Office";
                    if (lt_pw[0].data_status == "Further Search")
                    {
                        data_status = "Further search required";
                        status = "Patent Search Office";
                    }
                    else if (lt_pw[0].data_status == "E_Contact")
                    {
                        data_status = "Being processed";
                    }
                    else if (lt_pw[0].data_status == "Search Conducted")
                    {
                        data_status = "Successfully reviewed";
                    }
                    else if (lt_pw[0].data_status == "Refused")
                    {
                        data_status = "Refused";
                    }
                }
                if (lt_pw[0].status == "4")
                {
                    status = "Patent Approving Office";
                    if (lt_pw[0].data_status == "Not-Patentable")
                    {
                        data_status = "Not-patentable";
                        status = "Patent Examiner 1 Office";
                    }
                    else if (lt_pw[0].data_status == "A_Contact")
                    {
                        data_status = "Being processed";
                    }
                    else if (lt_pw[0].data_status == "Futher Review")
                    {
                        data_status = "Successfully reviewed";
                    }
                }
                if (lt_pw[0].status == "5")
                {
                    status = "Registrars Office";
                    if (lt_pw[0].data_status == "Review Patent")
                    {
                        data_status = "Being reviewed";
                        status = "Patent Approving Office";
                    }
                    else if (lt_pw[0].data_status == "R_Contact")
                    {
                        data_status = "Being processed";
                    }
                    else if (lt_pw[0].data_status == "Patentable")
                    {
                        data_status = "Successfully reviewed";
                    }
                }
                if (lt_pw[0].status == "6")
                {
                    status = "Registrars Office";
                    if (lt_pw[0].data_status == "Grant Patent")
                    {
                        data_status = "Patent granted";
                    }
                }
                showt = 1;
                trans_status = "Current Office: <b>" + status + "</b>; Status: <b>" + data_status + "</b>";
            }
            else
            {
                status = "N/A";
                trans_status = "Current Office: " + status;
            }
        }
        else
        {
            Response.Write("<script language=JavaScript>alert('PLEASE ENTER A VALID REFERENCE NUMBER')</script>");
        }
        lt_pw = t.getStageByUserIDAdmin(xref.Text);
        t.activity_log(admin, "Edit Status", "Update", lt_pw[0].ID, lt_pw[0].data_status,"","","","","","");
    }

    protected void UpdateApplicant_Click(object sender, EventArgs e)
    {
        if (Session["pwID"] != null)
        {
            c_office.pwalletID = Session["pwID"].ToString();
        }
        c_office.data_status = select_xoffice.SelectedValue.Split(new char[] { '|' })[0];
        c_office.admin_status = select_xoffice.SelectedValue.Split(new char[] { '|' })[1];
        c_office.xcomment = "REVERSAL PROCESS: " + txt_comment.Text;
        c_office.xdoc1 = "";
        c_office.xdoc2 = "";
        c_office.xdoc3 = "";
        c_office.xofficer = Session["pwalletID"].ToString();
        c_office.reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
        c_office.xvisible = "1";
        if (z.addReversal(c_office) > 0)
        {
            txt_comment.Text = "";
            select_xoffice.SelectedIndex = 0;
            if (Session["edit_transID"] != null)
            {
                trans_status = "<strong>THE STATUS FOR TRANSACTION ID " + Session["edit_transID"].ToString() + " FOR HAS BEEN UPDATED SUCCESSFULLY!!</strong>";
            }
            showt = 1;
        }
    }

   
}

