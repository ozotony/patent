using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class admin_pt_verification_unit_verify_invalid_data_details : Page
{
    public string admin = "";
    public string admin_status = "2";
    public List<pt.Applicant> lt_app = new List<pt.Applicant>();
    public List<pt.Assignment_info> lt_assinfo = new List<pt.Assignment_info>();
    public List<pt.Inventor> lt_inv = new List<pt.Inventor>();
    public List<pt.PtInfo> lt_mi = new List<pt.PtInfo>();
    public List<pt.Representative> lt_rep = new List<pt.Representative>();
    public List<pt.Stage> lt_stage = new List<pt.Stage>();
    public List<zues.PtOffice> lt_tm_office = new List<zues.PtOffice>();
    public List<zues.Adminz> lt_x_admin_details = new List<zues.Adminz>();
    public List<pt.Priority_info> lt_xpri = new List<pt.Priority_info>();
    public string mark_infoID;
    public string pID;
    public string rbval_text = "";
    public string succ;
    public pt t = new pt();
    public string xcomments = "";
    public string xofficer;
    public zues z = new zues();

    protected void Page_Load(object sender, EventArgs e)
    {
        Verify.Visible = false;
        if (rbValid.SelectedValue == "Valid")
        {
            admin_status = "2";
            Verify.Visible = true;
        }
        else if (rbValid.SelectedValue == "Invalid")
        {
            admin_status = "1";
            Verify.Visible = true;
        }
        else if (rbValid.SelectedValue == "V_Contact")
        {
            admin_status = "1";
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
            lt_mi = t.getPtInfoByUserID(pID);
            lt_rep = t.getRepListByUserID(lt_mi[0].log_staff);
            lt_stage = t.getStageByUserID(lt_mi[0].log_staff);
            lt_app = t.getApplicantByvalidationID(lt_mi[0].log_staff);
            lt_inv = t.getInventorByvalidationID(lt_mi[0].log_staff);
            lt_assinfo = t.getAssignment_infoByvalidationID(lt_mi[0].log_staff);
            lt_xpri = t.getPriority_infoByvalidationID(lt_mi[0].log_staff);
            lt_tm_office = z.getPtOfficeDetailsByID(lt_mi[0].log_staff);
            for (int i = 0; i < lt_tm_office.Count; i++)
            {
                xcomments = xcomments + "<tr>";
                xcomments = xcomments + "<td align=\"center\" colspan=\"2\">";
                xcomments = xcomments + "<strong>" + lt_tm_office[i].xcomment.ToUpper() + "</strong><br />";
                lt_x_admin_details = z.getTmAdminDetailsByID(lt_tm_office[i].xofficer);
                if (lt_x_admin_details.Count > 0)
                {
                    xcomments = xcomments + "COMMENT BY: <strong>" + lt_x_admin_details[0].xname.ToUpper() + "( " + z.getRoleNameByID(lt_x_admin_details[0].xroleID).ToUpper() + " )</strong><br />   Date: <strong>" + lt_tm_office[i].reg_date.ToUpper() + "</strong>";
                }
                else
                {
                    xcomments = xcomments + "COMMENT BY: <strong> NA</strong>";
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
        else
        {
            Response.Redirect("./profile.aspx");
        }
    }

    protected void rbValid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbValid.SelectedValue == "Valid")
        {
            admin_status = "2";
            Verify.Visible = true;
        }
        else if (rbValid.SelectedValue == "Invalid")
        {
            admin_status = "1";
            Verify.Visible = true;
        }
        else if (rbValid.SelectedValue == "V_Contact")
        {
            admin_status = "1";
            Verify.Visible = true;
        }
    }

    protected void Verify_Click(object sender, EventArgs e)
    {
        succ = z.a_tm_office(lt_mi[0].log_staff, admin_status, rbValid.SelectedValue, comment.Text, "", "", "", admin);
        if (succ != "0")
        {
            Response.Write("<script language=JavaScript>alert('Data verified successfully')</script>");
            Response.Redirect("./verify_data.aspx");
        }
        else
        {
            Response.Write("<script language=JavaScript>alert('Data not verified, Please try again later')</script>");
        }
    }

}

