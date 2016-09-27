using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class  admin_pt_examiners_unit_a_contact_details : Page
{
    public string admin = "";
    public string admin_status = "0";
    public int file_len = 0x400;
    public string file_string = "Xavier";
    public string html_msg = "";
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
    public Odyssey ody = new Odyssey();
    public string pID;
    public string rbval_text = "";
    public string serverpath = "";
    public string succ = "0";
    public pt t = new pt();
    public zues.Adminz x_admin = new zues.Adminz();
    public string xcomments = "";
    public string xofficer;
    public zues z = new zues();

    protected void Confirm_Click(object sender, EventArgs e)
    {
        if ((this.txt_response_date.Text != "") && (this.comment.Text != ""))
        {
            this.Verify.Visible = true;
            this.Confirm.Visible = false;
        }
        else
        {
            this.Verify.Visible = false;
            this.Confirm.Visible = true;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Submit.Visible = false;
        if (this.rbValid.SelectedValue == "Patentable")
        {
            this.admin_status = "5";
            this.Submit.Visible = true;
        }
        else if (this.rbValid.SelectedValue == "Not-Patentable")
        {
            this.admin_status = "4";
            this.Submit.Visible = true;
        }
        this.serverpath = base.Server.MapPath("~/");
        string path = this.serverpath + @"Handlers\bf.kez";
        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path, true);
            this.file_string = reader.ReadToEnd();
            reader.Close();
            if (this.file_string != null)
            {
                string oldValue = this.file_string.Substring(0, this.file_string.IndexOf("</BitStrength>") + 14);
                this.file_string = this.file_string.Replace(oldValue, "");
            }
        }
        if ((this.txt_response_date.Text != "") && (this.comment.Text != ""))
        {
            this.Verify.Visible = true;
            this.Confirm.Visible = false;
        }
        else
        {
            this.Verify.Visible = false;
            this.Confirm.Visible = true;
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
            this.lt_mi = this.t.getPtInfoByUserID(this.pID);
            this.lt_rep = this.t.getRepListByUserID(this.lt_mi[0].log_staff);
            this.lt_stage = this.t.getStageByUserID(this.lt_mi[0].log_staff);
            this.lt_app = this.t.getApplicantByvalidationID(this.lt_mi[0].log_staff);
            this.lt_inv = this.t.getInventorByvalidationID(this.lt_mi[0].log_staff);
            this.lt_assinfo = this.t.getAssignment_infoByvalidationID(this.lt_mi[0].log_staff);
            this.lt_xpri = this.t.getPriority_infoByvalidationID(this.lt_mi[0].log_staff);
            this.lt_tm_office = this.z.getPtOfficeDetailsByID(this.lt_mi[0].log_staff);
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
                this.xcomments = this.xcomments + "<tr>";
                this.xcomments = this.xcomments + "<td class=\"coltbbg\" colspan=\"2\" align=\"center\">";
                this.xcomments = this.xcomments + "&nbsp;";
                this.xcomments = this.xcomments + "</td>";
                this.xcomments = this.xcomments + "</tr>";
            }
        }
        else
        {
            base.Response.Redirect("./a_contact.aspx");
        }
    }

    protected void rbValid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.rbValid.SelectedValue == "Patentable")
        {
            this.admin_status = "5";
            this.Submit.Visible = true;
        }
        else if (this.rbValid.SelectedValue == "Not-Patentable")
        {
            this.admin_status = "4";
            this.Submit.Visible = true;
        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        if (this.rbValid.SelectedValue == "Patentable")
        {
            this.admin_status = "5";
            this.Submit.Visible = true;
        }
        else if (this.rbValid.SelectedValue == "Not-Patentable")
        {
            this.admin_status = "4";
            this.Submit.Visible = true;
        }
        this.succ = this.z.a_tm_office(this.lt_mi[0].log_staff, this.admin_status, this.rbValid.SelectedValue, this.new_comment.Text, "", "", "", this.admin);
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
        if ((this.txt_response_date.Text != "") && (this.comment.Text != ""))
        {
            this.Verify.Visible = true;
            this.Confirm.Visible = false;
        }
        else
        {
            this.Verify.Visible = false;
            this.Confirm.Visible = true;
        }
        zues.Contact_form cf = new zues.Contact_form();
        Email email = new Email();
        cf.pwalletID = this.pID;
        cf.response_deadline = this.txt_response_date.Text;
        cf.xofficerID = this.admin;
        cf.xmsg = this.comment.Text;
        cf.sent_status = "0";
        cf.reg_date = DateTime.Now.ToString("yyyy-MM-dd");
        cf.xvisible = "1";
        this.succ = this.z.a_contact_form(cf);
        if (this.succ != "0")
        {
            this.x_admin = this.z.getAdminDetails(this.admin);
            string subject = "Message from " + this.z.getRoleNameByID(this.x_admin.xroleID) + " concerning application: " + this.t.ValidationIDByPwalletID(this.lt_mi[0].log_staff);
            string from = this.ody.DecryptString(this.x_admin.xemail, this.file_len, this.file_string);
            this.html_msg = this.html_msg + "<html><head id='Head1' runat='server'><title></title>";
            this.html_msg = this.html_msg + "<style type='text/css'>";
            this.html_msg = this.html_msg + ".tbbg{padding:0;margin:0 auto;width:100%;height:20px;background-color:#006699;text-align:center;color:#fff;font-weight:bold;border-color:#006699;}";
            this.html_msg = this.html_msg + "</style></head><body><form id='form1' runat='server'><div>";
            this.html_msg = this.html_msg + "<table align='center' width='800px' >";
            if (this.lt_mi.Count > 0)
            {
                this.html_msg = this.html_msg + "<tr><td width='100%' colspan='2' style='background-color:#999999;' align='center'>---<b>CONTACT APPLICANT FORM</b> ---</td></tr>";
                this.html_msg = this.html_msg + "<tr> <td width='50%' align='right'> &nbsp;FILING/APPLICATION DATE : </td>";
                this.html_msg = this.html_msg + "<td>" + this.lt_mi[0].reg_date + "&nbsp;</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>REGISTRATION NUMBER :</td>";
                this.html_msg = this.html_msg + "<td>" + this.lt_mi[0].reg_number + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>&nbsp;ONLINE APPLICATION ID : </td>";
                this.html_msg = this.html_msg + "<td>OAI/PT/" + this.t.ValidationIDByPwalletID(this.lt_mi[0].log_staff) + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td colspan='2' class='tbbg'>---PATENT INFORMATION --- </td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>&nbsp;PATENT TYPE :</td>";
                this.html_msg = this.html_msg + "<td>" + this.lt_mi[0].xtype + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>&nbsp;TITLE OF INVENTION :</td>";
                this.html_msg = this.html_msg + "<td>" + this.lt_mi[0].title_of_invention + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>TRANSACTION ID :</td><td>" + this.lt_stage[0].validationID + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>TRANSACTION AMOUNT :</td><td>" + this.lt_stage[0].amt + " NGN</td></tr>";
            }
            if (this.lt_app.Count > 0)
            {
                this.html_msg = this.html_msg + "<tr><td class='tbbg' colspan='2'>--- APPLICANT INFORMATION ---</td></tr>";
                for (int i = 0; i < this.lt_app.Count; i++)
                {
                    this.html_msg = string.Concat(new object[] { this.html_msg, "<tr><td align='left' colspan='2' style='background-color:#999999;'><strong>APPLICANT ", i, 1, "</strong></td></tr>" });
                    this.html_msg = this.html_msg + "<tr><td align='right'>NAME :</td><td>" + this.lt_app[i].xname + "</td></tr>";
                    this.html_msg = this.html_msg + "<tr><td align='right'>ADDRESS :</td><td>" + this.lt_app[i].address + "</td></tr>";
                    this.html_msg = this.html_msg + "<tr><td align='right'>PHONE NUMBER :</td><td>" + this.lt_app[i].xmobile + "</td></tr>";
                    this.html_msg = this.html_msg + "<tr><td align='right'>E-MAILS :</td><td>" + this.lt_app[i].xemail + "</td></tr>";
                    this.html_msg = this.html_msg + "<tr><td align='right'>NATIONALITY :</td><td>" + this.t.getCountryName(this.lt_app[i].nationality) + "</td></tr>";
                }
            }
            if (this.lt_inv.Count > 0)
            {
                this.html_msg = this.html_msg + "<tr><td class='tbbg' colspan='2'>--- TRUE INVENTOR INFORMATION ---</td></tr>";
                for (int j = 0; j < this.lt_inv.Count; j++)
                {
                    this.html_msg = string.Concat(new object[] { this.html_msg, "<tr><td align='left' colspan='2' style='background-color:#999999;'><strong>INVENTOR ", j, 1, "</strong></td></tr>" });
                    this.html_msg = this.html_msg + "<tr><td align='right'>NAME :</td><td>" + this.lt_inv[j].xname + "</td></tr>";
                    this.html_msg = this.html_msg + "<tr><td align='right'>ADDRESS :</td><td>" + this.lt_inv[j].address + "</td></tr>";
                    this.html_msg = this.html_msg + "<tr><td align='right'>PHONE NUMBER :</td><td>" + this.lt_inv[j].xmobile + "</td></tr>";
                    this.html_msg = this.html_msg + "<tr><td align='right'>E-MAILS :</td><td>" + this.lt_inv[j].xemail + "</td></tr>";
                    this.html_msg = this.html_msg + "<tr><td align='right'>NATIONALITY :</td><td>" + this.t.getCountryName(this.lt_inv[j].nationality) + "</td></tr>";
                }
            }
            if (this.lt_assinfo.Count > 0)
            {
                this.html_msg = this.html_msg + "<tr><td class='tbbg' colspan='2'>--- ASSIGNMENT INFORMATION ---</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>DATE OF ASSIGNMENT :</td><td>" + this.lt_assinfo[0].date_of_assignment + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='left' colspan='2' style='background-color:#999999;'><strong>ASSIGNEE >></strong></td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>NAME :</td><td>" + this.lt_assinfo[0].assignee_name + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>ADDRESS :</td><td>" + this.lt_assinfo[0].assignee_address + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>NATIONALITY :</td><td>" + this.t.getCountryName(this.lt_assinfo[0].assignee_nationality) + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='left' colspan='2' style='background-color:#999999;'><strong>ASSIGNOR >></strong></td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>NAME :</td><td>" + this.lt_assinfo[0].assignor_name + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>ADDRESS&nbsp; :</td><td>" + this.lt_assinfo[0].assignor_address + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>NATIONALITY :</td><td>" + this.t.getCountryName(this.lt_assinfo[0].assignor_nationality) + "</td></tr>";
            }
            if (this.lt_xpri.Count > 0)
            {
                this.html_msg = this.html_msg + "<tr><td colspan='2' class='tbbg'>--- PRIORITY INFORMATION ---</td></tr>";
                this.html_msg = this.html_msg + "<tr><td colspan='2' style='border:0px outset silver; padding: 0px;'><table width='100%'>";
                this.html_msg = this.html_msg + "<tr style='background-color:#999999;'><td style='width:10%;'><strong>S/N</strong></td><td style='width:30%;'><strong>COUNTRY</strong></td>";
                this.html_msg = this.html_msg + "<td style='width:30%;'><strong>APPLICATION NUMBER</strong></td><td style='width:30%;'><strong>DATE</strong></td></tr>";
                for (int k = 0; k < this.lt_xpri.Count; k++)
                {
                    this.html_msg = string.Concat(new object[] { this.html_msg, "<tr ><td>", k, 1, "</td><td>", this.t.getCountryName(this.lt_xpri[k].countryID), "</td>" });
                    this.html_msg = this.html_msg + "<td>" + this.lt_xpri[k].app_no + "</td><td>" + this.lt_xpri[k].xdate + "</td></tr>";
                }
                this.html_msg = this.html_msg + "</table></td></tr>";
            }
            if (this.lt_rep.Count > 0)
            {
                this.html_msg = this.html_msg + "<tr><td colspan='2' class='tbbg'>--- ADDRESS OF SERVICE IN NIGERIA ---</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>ATTORNEY CODE :</td>";
                this.html_msg = this.html_msg + "<td>" + this.lt_rep[0].agent_code + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>ATTORNEY NAME :</td><td>" + this.lt_rep[0].xname + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>NATIONALITY :</td><td>" + this.t.getCountryName(this.lt_rep[0].nationality) + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>COUNTRY :</td><td>" + this.t.getCountryName(this.lt_rep[0].country) + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>STATE :</td><td>" + this.t.getStateName(this.lt_rep[0].state) + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>&nbsp;ADDRESS :</td>";
                this.html_msg = this.html_msg + "<td>" + this.lt_rep[0].address + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>PHONE NUMBER : </td><td>" + this.lt_rep[0].xmobile + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>E-MAIL : </td><td>" + this.lt_rep[0].xemail + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td colspan='2' class='tbbg'>--- DOCUMENTS ATTACHED ---</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>LETTER OF AUTHORIZATION OF AGENT(FORM 2) :</td><td >";
                if (this.lt_mi[0].loa_doc != "")
                {
                    this.html_msg = this.html_msg + "ATTACHED";
                }
                else
                {
                    this.html_msg = this.html_msg + "NONE";
                }
                this.html_msg = this.html_msg + "</td></tr><tr><td align='right'>CLAIM(S) :</td><td >";
                if (this.lt_mi[0].claim_doc != "")
                {
                    this.html_msg = this.html_msg + "ATTACHED";
                }
                else
                {
                    this.html_msg = this.html_msg + "NONE";
                }
                this.html_msg = this.html_msg + "</td></tr><tr><td align='right'>PCT DOCUMENT:</td><td >";
                if (this.lt_mi[0].pct_doc != "")
                {
                    this.html_msg = this.html_msg + "ATTACHED";
                }
                else
                {
                    this.html_msg = this.html_msg + "NONE";
                }
                this.html_msg = this.html_msg + "</td></tr><tr><td align='right'>DEED OF ASSIGNMENT:</td><td >";
                if (this.lt_mi[0].doa_doc != "")
                {
                    this.html_msg = this.html_msg + "ATTACHED";
                }
                else
                {
                    this.html_msg = this.html_msg + "NONE";
                }
                this.html_msg = this.html_msg + "</td></tr>";
                this.html_msg = this.html_msg + "<tr><td align='right'>COMPLETE SPECIFICATION (FORM 3):</td><td >";
                if (this.lt_mi[0].spec_doc != "")
                {
                    this.html_msg = this.html_msg + "ATTACHED";
                }
                else
                {
                    this.html_msg = this.html_msg + "NONE";
                }
                this.html_msg = this.html_msg + "</td></tr>";
            }
            this.html_msg = this.html_msg + "<tr><td class='tbbg' colspan='2' align='center'>  --- MESSAGE FROM COMMERCIAL LAW DEPARTMENT --- </td></tr>";
            this.html_msg = this.html_msg + "<tr><td align='center' colspan='2'>" + this.comment.Text + "</td></tr>";
            this.html_msg = this.html_msg + "<tr><td class='tbbg' colspan='2' align='center'>  &nbsp;</td></tr>";
            this.html_msg = this.html_msg + "<tr><td align='right'>REQUESTING UNIT: </td><td >" + this.z.getRoleNameByID(this.x_admin.xroleID) + "</td></tr>";
            this.html_msg = this.html_msg + "<tr><td align='right'>REQUESTING OFFICER: </td><td >" + this.x_admin.xname + "</td></tr>";
            this.html_msg = this.html_msg + "<tr><td align='right'>DEADLINE FOR RESPONSE:</td><td >" + this.txt_response_date.Text + "</td></tr>";
            this.html_msg = this.html_msg + "<tr><td align='right'>CONTACT PHONE NUMBER: </td><td >" + this.x_admin.xtelephone1 + "</td></tr><tr><td class='tbbg' colspan='2'>&nbsp;</td></tr>";
            this.html_msg = this.html_msg + "</table></div></form></body></html>";
            if (email.sendMail(this.z.getRoleNameByID(this.x_admin.xroleID).ToUpper(), this.lt_rep[0].xemail, from, subject, this.html_msg, "") == "sent")
            {
                if (this.z.e_Contact_formStatus(this.succ, "1") > 0)
                {
                    base.Response.Write("<script language=JavaScript>alert('Message sent successfully')</script>");
                    base.Response.Redirect("./profile.aspx");
                }
                else
                {
                    base.Response.Write("<script language=JavaScript>alert('The form could not be updated, Please check your internet connection or try again later')</script>");
                }
            }
            else
            {
                base.Response.Write("<script language=JavaScript>alert('The E-mail could not be sent, Please check your internet connection or try again later')</script>");
            }
        }
        else
        {
            base.Response.Write("<script language=JavaScript>alert('The form could not be saved, Please check your internet connection or try again later')</script>");
        }
    }

  
}

