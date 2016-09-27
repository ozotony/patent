using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class  admin_pt_registrar_unit_registrar_details : Page
{
    public string admin = "";
    public string admin_status = "5";
    public List<pt.Applicant> lt_app = new List<pt.Applicant>();
    public List<pt.Assignment_info> lt_assinfo = new List<pt.Assignment_info>();
    public List<pt.Inventor> lt_inv = new List<pt.Inventor>();
    public List<pt.PtInfo> lt_mi = new List<pt.PtInfo>();
    public List<pt.Stage> lt_p = new List<pt.Stage>();
    public List<pt.Representative> lt_rep = new List<pt.Representative>();
    public List<pt.Stage> lt_stage = new List<pt.Stage>();
    public List<zues.Adminz> lt_tm_admin_details = new List<zues.Adminz>();
    public List<zues.PtOffice> lt_tm_office = new List<zues.PtOffice>();
    public List<zues.Adminz> lt_x_admin_details = new List<zues.Adminz>();
    public List<pt.Priority_info> lt_xpri = new List<pt.Priority_info>();
    public string pID;
    public string rbval_text = "";
    public string search_doc_succ1 = "";
    public string search_doc_succ2 = "";
    public string search_doc_succ3 = "";
    public string succ = "";
    public pt.SWallet swallet = new pt.SWallet();
    public pt t = new pt();
    public string xcomments = "";
    public string xofficer;
    public zues z = new zues();

    protected void Page_Load(object sender, EventArgs e)
    {
        Verify.Visible = false;
        if (rbValid.SelectedValue == "Grant Patent")
        {
            admin_status = "6";
            Verify.Visible = true;
        }
        else if (rbValid.SelectedValue == "Review Patent")
        {
            admin_status = "5";
            Verify.Visible = true;
        }
        else if (rbValid.SelectedValue == "R_Contact")
        {
            admin_status = "5";
            Verify.Visible = true;
        }
        if (Request.QueryString["x"] != null)
        {
            if (Session["pwalletID"] != null)
            {
                if (Session["pwalletID"].ToString() != "")
                {
                    admin = Session["pwalletID"].ToString();
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
            pID = Request.QueryString["x"].ToString();
            swallet = t.getSwalletByID(pID);
            lt_mi = t.getPtInfoByUserID(pID);
            lt_p = t.getPwalletDetailsByID(lt_mi[0].log_staff);
            lt_tm_office = z.getPtOfficeDetailsByID(lt_mi[0].log_staff);
            lt_rep = t.getRepListByUserID(lt_mi[0].log_staff);
            lt_stage = t.getStageByUserID(lt_mi[0].log_staff);
            lt_app = t.getApplicantByvalidationID(lt_mi[0].log_staff);
            lt_inv = t.getInventorByvalidationID(lt_mi[0].log_staff);
            lt_assinfo = t.getAssignment_infoByvalidationID(lt_mi[0].log_staff);
            lt_xpri = t.getPriority_infoByvalidationID(lt_mi[0].log_staff);
            for (int i = 0; i < lt_tm_office.Count; i++)
            {
                xcomments = xcomments + "<tr>";
                xcomments = xcomments + "<td align=\"center\" colspan=\"2\">";
                xcomments = xcomments + "<strong>" + lt_tm_office[i].xcomment.ToUpper() + "</strong><br />";
                lt_x_admin_details = z.getTmAdminDetailsByID(lt_tm_office[i].xofficer);
                xcomments = xcomments;
                string vname = "";
                string xrole = "";
                string xreg_date = "";
                try
                {
                    vname = lt_x_admin_details[0].xname.ToUpper();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    xrole = z.getRoleNameByID(lt_x_admin_details[0].xroleID).ToUpper();
                }
                catch (Exception ee)
                {

                }

                try
                {
                    xreg_date = lt_tm_office[i].reg_date.ToUpper();
                }
                catch (Exception ee)
                {

                }
                xcomments = xcomments + "COMMENT BY: <strong>" + vname + "( " + xrole + ")</strong><br />   Date: <strong>" + xreg_date + "</strong>";
                xcomments = xcomments + "</td>";
                xcomments = xcomments + "</tr>";
                if (lt_tm_office[i].xdoc1 != "")
                {
                    xcomments = xcomments + "<tr>";
                    xcomments = xcomments + "<td colspan=\"2\" align=\"center\">";
                    xcomments = xcomments + "View Document 1: <a href=" + lt_tm_office[i].xdoc1 + " target='_blank'>View</a>";
                    xcomments = xcomments + "</td>";
                    xcomments = xcomments + "</tr>";
                }
                if (lt_tm_office[i].xdoc2 != "")
                {
                    xcomments = xcomments + "<tr>";
                    xcomments = xcomments + "<td colspan=\"2\" align=\"center\">";
                    xcomments = xcomments + "View Document 2: <a href=" + lt_tm_office[i].xdoc2 + " target='_blank'>View</a>";
                    xcomments = xcomments + "</td>";
                    xcomments = xcomments + "</tr>";
                }
                if (lt_tm_office[i].xdoc3 != "")
                {
                    xcomments = xcomments + "<tr>";
                    xcomments = xcomments + "<td colspan=\"2\" align=\"center\">";
                    xcomments = xcomments + "View Document 3: <a href=" + lt_tm_office[i].xdoc3 + " target='_blank'>View</a>";
                    xcomments = xcomments + "</td>";
                    xcomments = xcomments + "</tr>";
                }
                if (lt_tm_office[i].admin_status == "3")
                {
                    xcomments = xcomments + "<tr>";
                    xcomments = xcomments + "<td class=\"coltbbg\" colspan=\"2\" align=\"center\">";
                    xcomments = xcomments + "--- SUPPORTING SEARCH DOCUMENTS ---";
                    xcomments = xcomments + "</td>";
                    xcomments = xcomments + "</tr>";
                    xcomments = xcomments + "<tr>";
                    xcomments = xcomments + "<td align=\"right\">";
                    xcomments = xcomments + "Attached Document:";
                    xcomments = xcomments + "</td>";
                    xcomments = xcomments + "<td>";
                    if ((swallet.search_str != "") && (swallet.search_str != null))
                    {
                        xcomments = xcomments + "<a href=view_search_details.aspx?x=" + pID + " target='_blank'>View</a>";
                    }
                    else
                    {
                        xcomments = xcomments + "NONE";
                    }
                    xcomments = xcomments + "</td>";
                    xcomments = xcomments + "</tr>";
                    xcomments = xcomments + "<tr>";
                    xcomments = xcomments + "<td class=\"coltbbg\" colspan=\"2\" align=\"center\">";
                    xcomments = xcomments + "&nbsp;";
                    xcomments = xcomments + "</td>";
                    xcomments = xcomments + "</tr>";
                }
            }
        }
        else
        {
            Response.Redirect("./pt_profile.aspx");
        }
    }

    protected void rbValid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbValid.SelectedValue == "Grant Patent")
        {
            admin_status = "6";
            Verify.Visible = true;
        }
        else if (rbValid.SelectedValue == "Review Patent")
        {
            admin_status = "5";
            Verify.Visible = true;
        }
        else if (rbValid.SelectedValue == "R_Contact")
        {
            admin_status = "5";
            Verify.Visible = true;
        }
    }

    protected void Verify_Click(object sender, EventArgs e)
    {
        succ = z.a_tm_office(lt_mi[0].log_staff, admin_status, rbValid.SelectedValue, comment.Text, "", "", "", admin);
        if (succ != "0")
        {
            Response.Write("<script language=JavaScript>alert('Data updated successfully')</script>");
            Response.Redirect("./pt_profile.aspx");
        }
        else
        {
            Response.Write("<script language=JavaScript>alert('Data not updated, Please try again later')</script>");
        }
    }

  
}

