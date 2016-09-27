using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class admin_pt_x_unit_appstatus : Page
{
    public string admin = "";
    public string agt;
    public string data_status = "N/A";
    public List<pt.Applicant> lt_appx = new List<pt.Applicant>();
    public List<pt.Assignment_info> lt_assinfox = new List<pt.Assignment_info>();
    public List<pt.Inventor> lt_invx = new List<pt.Inventor>();
    public List<pt.PtInfo> lt_mi = new List<pt.PtInfo>();
    public List<pt.PtInfo> lt_mix = new List<pt.PtInfo>();
    public List<pt.Stage> lt_pw = new List<pt.Stage>();
    public pt.Representative lt_rep = new pt.Representative();
    public List<pt.Representative> lt_repx = new List<pt.Representative>();
    public List<pt.Stage> lt_stagex = new List<pt.Stage>();
    public List<pt.Priority_info> lt_xprix = new List<pt.Priority_info>();
    public string r;
    public int refill = 0;
    public int showt;
    public string status = "N/A";
    public pt t = new pt();
    public zues z = new zues();

    protected void BtnCheckStatus_Click(object sender, EventArgs e)
    {
        Response.Redirect("./appstatus.aspx");
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
                agt = lt_pw[0].applicantID;
                Session["agt"] = lt_pw[0].applicantID;
                pt.Stage stage = t.getStatusIDByvalidationID(xref.Text.Trim());
                lt_mix = t.getPtInfoByPwalletID(lt_pw[0].ID);
                lt_repx = t.getRepListByUserID(lt_pw[0].ID);
                lt_stagex = t.getStageByUserID(lt_pw[0].ID);
                lt_appx = t.getApplicantByvalidationID(lt_pw[0].ID);
                lt_invx = t.getInventorByvalidationID(lt_pw[0].ID);
                lt_assinfox = t.getAssignment_infoByvalidationID(lt_pw[0].ID);
                lt_xprix = t.getPriority_infoByvalidationID(lt_pw[0].ID);
                Session["xvid"] = xref.Text;
                showt = 1;
                if ((((Convert.ToInt32(stage.status) == 1) && (lt_appx.Count >= 1)) && ((lt_mix.Count == 1) && (lt_stagex.Count == 1))) && (lt_repx.Count == 1))
                {
                    if ((((((lt_mix[0].pt_desc == "") || (lt_mix[0].spec_doc == "")) || ((lt_mix[0].loa_doc == "") || (lt_mix[0].claim_doc == ""))) || (((lt_mix[0].pct_doc == "") || (lt_mix[0].doa_doc == "")) || ((lt_appx[0].address == "") || (lt_appx[0].xmobile == "")))) || (lt_repx[0].address == "")) || (lt_repx[0].xmobile == ""))
                    {
                        status = "Filing";
                        data_status = "Uncompleted";
                        refill = 1;
                    }
                    else
                    {
                        refill = 0;
                        showStatus(lt_pw);
                    }
                }
                else if ((Convert.ToInt32(stage.status) == 1) && ((((lt_appx.Count >= 1) || (lt_mix.Count == 1)) || (lt_stagex.Count == 1)) || (lt_repx.Count == 1)))
                {
                    status = "Filing";
                    data_status = "Uncompleted";
                    refill = 1;
                }
                else if (Convert.ToInt32(stage.status) > 1)
                {
                    refill = 0;
                    if (lt_pw.Count != 0)
                    {
                        Session["xvid"] = xref.Text;
                        lt_mi = t.getPtInfoByUserID(lt_pw[0].ID);
                        lt_rep = t.getRepByUserID(lt_pw[0].ID);
                        showStatus(lt_pw);
                    }
                    else
                    {
                        status = "N/A";
                    }
                }
            }
        }
        else
        {
            Response.Write("<script language=JavaScript>alert('PLEASE ENTER A VALID REFERENCE NUMBER')</script>");
        }
    }

    public void showStatus(List<pt.Stage> lt_p)
    {
        if (lt_p[0].status == "1")
        {
            status = "Payment Verification Office";
            if (lt_p[0].data_status == "Fresh")
            {
                data_status = "Untreated";
            }
            else if (lt_p[0].data_status == "Invalid")
            {
                data_status = "Invalid";
            }
            else if (lt_p[0].data_status == "V_Contact")
            {
                data_status = "Being processed";
            }
        }
        if (lt_p[0].status == "2")
        {
            status = "Patent Search Office";
            if (lt_p[0].data_status == "Valid")
            {
                data_status = "Successfully reviewed";
            }
            else if (lt_p[0].data_status == "S_Contact")
            {
                data_status = "Being processed";
            }
        }
        if (lt_p[0].status == "3")
        {
            status = "Patent Examiner 1 Office";
            if (lt_p[0].data_status == "Further Search")
            {
                data_status = "Further search required";
                status = "Patent Search Office";
            }
            else if (lt_p[0].data_status == "E_Contact")
            {
                data_status = "Being processed";
            }
            else if (lt_p[0].data_status == "Search Conducted")
            {
                data_status = "Successfully reviewed";
            }
            else if (lt_p[0].data_status == "Refused")
            {
                data_status = "Refused";
            }
        }
        if (lt_p[0].status == "4")
        {
            status = "Patent Approving Office";
            if (lt_p[0].data_status == "Not-Patentable")
            {
                data_status = "Not-patentable";
                status = "Patent Examiner 1 Office";
            }
            else if (lt_p[0].data_status == "A_Contact")
            {
                data_status = "Being processed";
            }
            else if (lt_p[0].data_status == "Futher Review")
            {
                data_status = "Successfully reviewed";
            }
        }
        if (lt_p[0].status == "5")
        {
            status = "Registrars Office";
            if (lt_p[0].data_status == "Review Patent")
            {
                data_status = "Being reviewed";
                status = "Patent Approving Office";
            }
            else if (lt_p[0].data_status == "R_Contact")
            {
                data_status = "Being processed";
            }
            else if (lt_p[0].data_status == "Patentable")
            {
                data_status = "Successfully reviewed";
            }
        }
        if (lt_p[0].status == "6")
        {
            status = "Registrars Office";
            if (lt_p[0].data_status == "Grant Patent")
            {
                data_status = "Patent granted";
            }
        }
    }

}

