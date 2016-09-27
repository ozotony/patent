using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class  admin_pt_examiners_unit_examination_details : Page
{
    public string admin = "";
    public string admin_status = "3";
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
        this.Verify.Visible = false;
        this.Refuse.Visible = false;
        if (this.rbValid.SelectedValue == "Futher Review")
        {
            this.admin_status = "4";
            this.Verify.Visible = true;
            this.Refuse.Visible = false;
        }
        else if (this.rbValid.SelectedValue == "Further Search")
        {
            this.admin_status = "3";
            this.Verify.Visible = true;
            this.Refuse.Visible = false;
        }
        else if (this.rbValid.SelectedValue == "E_Contact")
        {
            this.admin_status = "3";
            this.Verify.Visible = true;
            this.Refuse.Visible = false;
        }

        else if (this.rbValid.SelectedValue == "Refused")
        {
            this.admin_status = "3";
            this.Verify.Visible = false;
            this.Refuse.Visible = true;
        }
        else if (this.rbValid.SelectedValue == "Patentable")
        {
            this.admin_status = "5";
            this.Verify.Visible = true;
            this.Refuse.Visible = false;
        }
        if (base.Request.QueryString["x"] != null)
        {
            if (base.Session["pwalletID"] != null)
            {
                if (base.Session["pwalletID"].ToString() != "")
                {
                    this.admin = base.Session["pwalletID"].ToString();
                }
                else
                {
                    base.Response.Redirect("../lo.aspx");
                }
            }
            else
            {
                base.Response.Redirect("../lo.aspx");
            }
            this.pID = base.Request.QueryString["x"].ToString();
            this.swallet = this.t.getSwalletByID(this.pID);
            this.lt_mi = this.t.getPtInfoByUserID(this.pID);
            this.lt_p = this.t.getPwalletDetailsByID(this.lt_mi[0].log_staff);
            this.lt_tm_office = this.z.getPtOfficeDetailsByID(this.lt_mi[0].log_staff);
            this.lt_rep = this.t.getRepListByUserID(this.lt_mi[0].log_staff);
            this.lt_stage = this.t.getStageByUserID(this.lt_mi[0].log_staff);
            this.lt_app = this.t.getApplicantByvalidationID(this.lt_mi[0].log_staff);
            this.lt_inv = this.t.getInventorByvalidationID(this.lt_mi[0].log_staff);
            this.lt_assinfo = this.t.getAssignment_infoByvalidationID(this.lt_mi[0].log_staff);
            this.lt_xpri = this.t.getPriority_infoByvalidationID(this.lt_mi[0].log_staff);
     
            xname.Value = lt_rep[0].agent_code;
            xname2.Value = lt_mi[0].title_of_invention;

            xname3.Value =lt_mi[0].reg_number;
            xname4.Value = "OAI/PT/" + t.ValidationIDByPwalletID(lt_mi[0].log_staff);
            xname5.Value = lt_mi[0].log_staff;
            for (int i = 0; i < this.lt_tm_office.Count; i++)
            {
                this.xcomments = this.xcomments + "<tr>";
                this.xcomments = this.xcomments + "<td align=\"center\" colspan=\"2\">";
                this.xcomments = this.xcomments + "<strong>" + this.lt_tm_office[i].xcomment.ToUpper() + "</strong><br />";
                this.lt_x_admin_details = this.z.getTmAdminDetailsByID(this.lt_tm_office[i].xofficer);
                if (lt_x_admin_details.Count > 0)
                {
                    xcomments = xcomments + "COMMENT BY: <strong>" + lt_x_admin_details[0].xname.ToUpper() + "( " + z.getRoleNameByID(lt_x_admin_details[0].xroleID).ToUpper() + " )</strong><br />   Date: <strong>" + lt_tm_office[i].reg_date.ToUpper() + "</strong>";
                }
                else
                {
                    xcomments = xcomments + "COMMENT BY: <strong> NA</strong>";
                } 
                this.xcomments = this.xcomments + "</td>";
                this.xcomments = this.xcomments + "</tr>";
                if (this.lt_tm_office[i].xdoc1 != "")
                {
                    this.xcomments = this.xcomments + "<tr>";
                    this.xcomments = this.xcomments + "<td colspan=\"2\" align=\"center\">";
                    this.xcomments = this.xcomments + "View Document 1: <a href=" + this.lt_tm_office[i].xdoc1 + " target='_blank'>View</a>";
                    this.xcomments = this.xcomments + "</td>";
                    this.xcomments = this.xcomments + "</tr>";
                }
                if (this.lt_tm_office[i].xdoc2 != "")
                {
                    this.xcomments = this.xcomments + "<tr>";
                    this.xcomments = this.xcomments + "<td colspan=\"2\" align=\"center\">";
                    this.xcomments = this.xcomments + "View Document 2: <a href=" + this.lt_tm_office[i].xdoc2 + " target='_blank'>View</a>";
                    this.xcomments = this.xcomments + "</td>";
                    this.xcomments = this.xcomments + "</tr>";
                }
                if (this.lt_tm_office[i].xdoc3 != "")
                {
                    this.xcomments = this.xcomments + "<tr>";
                    this.xcomments = this.xcomments + "<td colspan=\"2\" align=\"center\">";
                    this.xcomments = this.xcomments + "View Document 3: <a href=" + this.lt_tm_office[i].xdoc3 + " target='_blank'>View</a>";
                    this.xcomments = this.xcomments + "</td>";
                    this.xcomments = this.xcomments + "</tr>";
                }
                if (this.lt_tm_office[i].admin_status == "3")
                {
                    this.xcomments = this.xcomments + "<tr>";
                    this.xcomments = this.xcomments + "<td class=\"coltbbg\" colspan=\"2\" align=\"center\">";
                    this.xcomments = this.xcomments + "--- SUPPORTING SEARCH DOCUMENTS ---";
                    this.xcomments = this.xcomments + "</td>";
                    this.xcomments = this.xcomments + "</tr>";
                    this.xcomments = this.xcomments + "<tr>";
                    this.xcomments = this.xcomments + "<td align=\"right\">";
                    this.xcomments = this.xcomments + "Attached Document:";
                    this.xcomments = this.xcomments + "</td>";
                    this.xcomments = this.xcomments + "<td>";
                    if ((this.swallet.search_str != "") && (this.swallet.search_str != null))
                    {
                        this.xcomments = this.xcomments + "<a href=view_search_details.aspx?x=" + this.pID + " target='_blank'>View</a>";
                    }
                    else
                    {
                        this.xcomments = this.xcomments + "NONE";
                    }
                    this.xcomments = this.xcomments + "</td>";
                    this.xcomments = this.xcomments + "</tr>";
                    this.xcomments = this.xcomments + "<tr>";
                    this.xcomments = this.xcomments + "<td class=\"coltbbg\" colspan=\"2\" align=\"center\">";
                    this.xcomments = this.xcomments + "&nbsp;";
                    this.xcomments = this.xcomments + "</td>";
                    this.xcomments = this.xcomments + "</tr>";
                }
            }
        }
        else
        {
            base.Response.Redirect("./profile.aspx");
        }
    }

    protected void rbValid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.rbValid.SelectedValue == "Futher Review")
        {
            this.admin_status = "4";
            this.Verify.Visible = true;
            this.Refuse.Visible = false;
        }
        else if (this.rbValid.SelectedValue == "Further Search")
        {
            this.admin_status = "3";
            this.Verify.Visible = true;
            this.Refuse.Visible = false;
        }
        else if (this.rbValid.SelectedValue == "E_Contact")
        {
            this.admin_status = "3";
            this.Verify.Visible = true;
            this.Refuse.Visible = false;
        }

        else if (this.rbValid.SelectedValue == "Refused")
        {
            this.admin_status = "3";
            this.Verify.Visible = false;
            this.Refuse.Visible = true;
        }
        else if (this.rbValid.SelectedValue == "Patentable")
        {
            this.admin_status = "5";
            this.Verify.Visible = true;
            this.Refuse.Visible = false;
        }
    }

    protected void Refuse_Click(object sender, EventArgs e)
    {
        this.succ = this.z.a_tm_office(this.lt_mi[0].log_staff, this.admin_status, this.rbValid.SelectedValue, this.comment.Text, "", "", "", this.admin);
        if (this.succ != "0")
        {
            base.Response.Write("<script language=JavaScript>alert('Data updated successfully')</script>");
            base.Response.Redirect("./profile.aspx");
        }
        else
        {
            base.Response.Write("<script language=JavaScript>alert('Data not updated, Please try again later')</script>");
        }
    }
    protected void Verify_Click(object sender, EventArgs e)
    {
        this.succ = this.z.a_tm_office(this.lt_mi[0].log_staff, this.admin_status, this.rbValid.SelectedValue, this.comment.Text, "", "", "", this.admin);
        if (this.succ != "0")
        {
            base.Response.Write("<script language=JavaScript>alert('Data updated successfully')</script>");
            base.Response.Redirect("./profile.aspx");
        }
        else
        {
            base.Response.Write("<script language=JavaScript>alert('Data not updated, Please try again later')</script>");
        }
    }

  
}

