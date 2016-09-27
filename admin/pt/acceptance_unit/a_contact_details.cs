using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class  admin_pt_acceptance_unit_a_contact_details : Page
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
        if ((txt_response_date.Text != "") && (comment.Text != ""))
        {
            Verify.Visible = true;
            Confirm.Visible = false;
        }
        else
        {
            Verify.Visible = false;
            Confirm.Visible = true;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Submit.Visible = false;
        if (rbValid.SelectedValue == "Patentable")
        {
            admin_status = "5";
            Submit.Visible = true;
        }
        else if (rbValid.SelectedValue == "Not-Patentable")
        {
            admin_status = "4";
            Submit.Visible = true;
        }
        serverpath = Server.MapPath("~/");
        string path = serverpath + @"Handlers\bf.kez";
        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path, true);
            file_string = reader.ReadToEnd();
            reader.Close();
            if (file_string != null)
            {
                string oldValue = file_string.Substring(0, file_string.IndexOf("</BitStrength>") + 14);
                file_string = file_string.Replace(oldValue, "");
            }
        }
        if ((txt_response_date.Text != "") && (comment.Text != ""))
        {
            Verify.Visible = true;
            Confirm.Visible = false;
        }
        else
        {
            Verify.Visible = false;
            Confirm.Visible = true;
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
            Response.Redirect("./a_contact.aspx");
        }
    }

    protected void rbValid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbValid.SelectedValue == "Patentable")
        {
            admin_status = "5";
            Submit.Visible = true;
        }
        else if (rbValid.SelectedValue == "Not-Patentable")
        {
            admin_status = "4";
            Submit.Visible = true;
        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        if (rbValid.SelectedValue == "Patentable")
        {
            admin_status = "5";
            Submit.Visible = true;
        }
        else if (rbValid.SelectedValue == "Not-Patentable")
        {
            admin_status = "4";
            Submit.Visible = true;
        }
        succ = z.a_tm_office(lt_mi[0].log_staff, admin_status, rbValid.SelectedValue, new_comment.Text, "", "", "", admin);
        if (succ != "0")
        {
            Response.Write("<script language=JavaScript>alert('Data updated successfully')</script>");
            Response.Redirect("./profile.aspx");
        }
        else
        {
            Response.Write("<script language=JavaScript>alert('Data not updated, Please try again later')</script>");
        }
    }

    protected void Verify_Click(object sender, EventArgs e)
    {
        if ((txt_response_date.Text != "") && (comment.Text != ""))
        {
            Verify.Visible = true;
            Confirm.Visible = false;
        }
        else
        {
            Verify.Visible = false;
            Confirm.Visible = true;
        }
        zues.Contact_form cf = new zues.Contact_form();
        Email email = new Email();
        cf.pwalletID = pID;
        cf.response_deadline = txt_response_date.Text;
        cf.xofficerID = admin;
        cf.xmsg = comment.Text;
        cf.sent_status = "0";
        cf.reg_date = DateTime.Now.ToString("yyyy-MM-dd");
        cf.xvisible = "1";
        succ = z.a_contact_form(cf);
        if (succ != "0")
        {
            x_admin = z.getAdminDetails(admin);
            string subject = "Message from " + z.getRoleNameByID(x_admin.xroleID) + " concerning application: " + t.ValidationIDByPwalletID(lt_mi[0].log_staff);
            string from = ody.DecryptString(x_admin.xemail, file_len, file_string);
            html_msg = html_msg + "<html><head id='Head1' runat='server'><title></title>";
            html_msg = html_msg + "<style type='text/css'>";
            html_msg = html_msg + ".tbbg{padding:0;margin:0 auto;width:100%;height:20px;background-color:#006699;text-align:center;color:#fff;font-weight:bold;border-color:#006699;}";
            html_msg = html_msg + "</style></head><body><form id='form1' runat='server'><div>";
            html_msg = html_msg + "<table align='center' width='800px' >";
            if (lt_mi.Count > 0)
            {
                html_msg = html_msg + "<tr><td width='100%' colspan='2' style='background-color:#999999;' align='center'>---<b>CONTACT APPLICANT FORM</b> ---</td></tr>";
                html_msg = html_msg + "<tr> <td width='50%' align='right'> &nbsp;FILING/APPLICATION DATE : </td>";
                html_msg = html_msg + "<td>" + lt_mi[0].reg_date + "&nbsp;</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>REGISTRATION NUMBER :</td>";
                html_msg = html_msg + "<td>" + lt_mi[0].reg_number + "</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>&nbsp;ONLINE APPLICATION ID : </td>";
                html_msg = html_msg + "<td>OAI/PT/" + t.ValidationIDByPwalletID(lt_mi[0].log_staff) + "</td></tr>";
                html_msg = html_msg + "<tr><td colspan='2' class='tbbg'>---PATENT INFORMATION --- </td></tr>";
                html_msg = html_msg + "<tr><td align='right'>&nbsp;PATENT TYPE :</td>";
                html_msg = html_msg + "<td>" + lt_mi[0].xtype + "</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>&nbsp;TITLE OF INVENTION :</td>";
                html_msg = html_msg + "<td>" + lt_mi[0].title_of_invention + "</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>TRANSACTION ID :</td><td>" + lt_stage[0].validationID + "</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>TRANSACTION AMOUNT :</td><td>" + lt_stage[0].amt + " NGN</td></tr>";
            }
            if (lt_app.Count > 0)
            {
                html_msg = html_msg + "<tr><td class='tbbg' colspan='2'>--- APPLICANT INFORMATION ---</td></tr>";
                for (int i = 0; i < lt_app.Count; i++)
                {
                    html_msg = string.Concat(new object[] { html_msg, "<tr><td align='left' colspan='2' style='background-color:#999999;'><strong>APPLICANT ", i, 1, "</strong></td></tr>" });
                    html_msg = html_msg + "<tr><td align='right'>NAME :</td><td>" + lt_app[i].xname + "</td></tr>";
                    html_msg = html_msg + "<tr><td align='right'>ADDRESS :</td><td>" + lt_app[i].address + "</td></tr>";
                    html_msg = html_msg + "<tr><td align='right'>PHONE NUMBER :</td><td>" + lt_app[i].xmobile + "</td></tr>";
                    html_msg = html_msg + "<tr><td align='right'>E-MAILS :</td><td>" + lt_app[i].xemail + "</td></tr>";
                    html_msg = html_msg + "<tr><td align='right'>NATIONALITY :</td><td>" + t.getCountryName(lt_app[i].nationality) + "</td></tr>";
                }
            }
            if (lt_inv.Count > 0)
            {
                html_msg = html_msg + "<tr><td class='tbbg' colspan='2'>--- TRUE INVENTOR INFORMATION ---</td></tr>";
                for (int j = 0; j < lt_inv.Count; j++)
                {
                    html_msg = string.Concat(new object[] { html_msg, "<tr><td align='left' colspan='2' style='background-color:#999999;'><strong>INVENTOR ", j, 1, "</strong></td></tr>" });
                    html_msg = html_msg + "<tr><td align='right'>NAME :</td><td>" + lt_inv[j].xname + "</td></tr>";
                    html_msg = html_msg + "<tr><td align='right'>ADDRESS :</td><td>" + lt_inv[j].address + "</td></tr>";
                    html_msg = html_msg + "<tr><td align='right'>PHONE NUMBER :</td><td>" + lt_inv[j].xmobile + "</td></tr>";
                    html_msg = html_msg + "<tr><td align='right'>E-MAILS :</td><td>" + lt_inv[j].xemail + "</td></tr>";
                    html_msg = html_msg + "<tr><td align='right'>NATIONALITY :</td><td>" + t.getCountryName(lt_inv[j].nationality) + "</td></tr>";
                }
            }
            if (lt_assinfo.Count > 0)
            {
                html_msg = html_msg + "<tr><td class='tbbg' colspan='2'>--- ASSIGNMENT INFORMATION ---</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>DATE OF ASSIGNMENT :</td><td>" + lt_assinfo[0].date_of_assignment + "</td></tr>";
                html_msg = html_msg + "<tr><td align='left' colspan='2' style='background-color:#999999;'><strong>ASSIGNEE >></strong></td></tr>";
                html_msg = html_msg + "<tr><td align='right'>NAME :</td><td>" + lt_assinfo[0].assignee_name + "</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>ADDRESS :</td><td>" + lt_assinfo[0].assignee_address + "</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>NATIONALITY :</td><td>" + t.getCountryName(lt_assinfo[0].assignee_nationality) + "</td></tr>";
                html_msg = html_msg + "<tr><td align='left' colspan='2' style='background-color:#999999;'><strong>ASSIGNOR >></strong></td></tr>";
                html_msg = html_msg + "<tr><td align='right'>NAME :</td><td>" + lt_assinfo[0].assignor_name + "</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>ADDRESS&nbsp; :</td><td>" + lt_assinfo[0].assignor_address + "</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>NATIONALITY :</td><td>" + t.getCountryName(lt_assinfo[0].assignor_nationality) + "</td></tr>";
            }
            if (lt_xpri.Count > 0)
            {
                html_msg = html_msg + "<tr><td colspan='2' class='tbbg'>--- PRIORITY INFORMATION ---</td></tr>";
                html_msg = html_msg + "<tr><td colspan='2' style='border:0px outset silver; padding: 0px;'><table width='100%'>";
                html_msg = html_msg + "<tr style='background-color:#999999;'><td style='width:10%;'><strong>S/N</strong></td><td style='width:30%;'><strong>COUNTRY</strong></td>";
                html_msg = html_msg + "<td style='width:30%;'><strong>APPLICATION NUMBER</strong></td><td style='width:30%;'><strong>DATE</strong></td></tr>";
                for (int k = 0; k < lt_xpri.Count; k++)
                {
                    html_msg = string.Concat(new object[] { html_msg, "<tr ><td>", k, 1, "</td><td>", t.getCountryName(lt_xpri[k].countryID), "</td>" });
                    html_msg = html_msg + "<td>" + lt_xpri[k].app_no + "</td><td>" + lt_xpri[k].xdate + "</td></tr>";
                }
                html_msg = html_msg + "</table></td></tr>";
            }
            if (lt_rep.Count > 0)
            {
                html_msg = html_msg + "<tr><td colspan='2' class='tbbg'>--- ADDRESS OF SERVICE IN NIGERIA ---</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>ATTORNEY CODE :</td>";
                html_msg = html_msg + "<td>" + lt_rep[0].agent_code + "</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>ATTORNEY NAME :</td><td>" + lt_rep[0].xname + "</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>NATIONALITY :</td><td>" + t.getCountryName(lt_rep[0].nationality) + "</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>COUNTRY :</td><td>" + t.getCountryName(lt_rep[0].country) + "</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>STATE :</td><td>" + t.getStateName(lt_rep[0].state) + "</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>&nbsp;ADDRESS :</td>";
                html_msg = html_msg + "<td>" + lt_rep[0].address + "</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>PHONE NUMBER : </td><td>" + lt_rep[0].xmobile + "</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>E-MAIL : </td><td>" + lt_rep[0].xemail + "</td></tr>";
                html_msg = html_msg + "<tr><td colspan='2' class='tbbg'>--- DOCUMENTS ATTACHED ---</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>LETTER OF AUTHORIZATION OF AGENT(FORM 2) :</td><td >";
                if (lt_mi[0].loa_doc != "")
                {
                    html_msg = html_msg + "ATTACHED";
                }
                else
                {
                    html_msg = html_msg + "NONE";
                }
                html_msg = html_msg + "</td></tr><tr><td align='right'>CLAIM(S) :</td><td >";
                if (lt_mi[0].claim_doc != "")
                {
                    html_msg = html_msg + "ATTACHED";
                }
                else
                {
                    html_msg = html_msg + "NONE";
                }
                html_msg = html_msg + "</td></tr><tr><td align='right'>PCT DOCUMENT:</td><td >";
                if (lt_mi[0].pct_doc != "")
                {
                    html_msg = html_msg + "ATTACHED";
                }
                else
                {
                    html_msg = html_msg + "NONE";
                }
                html_msg = html_msg + "</td></tr><tr><td align='right'>DEED OF ASSIGNMENT:</td><td >";
                if (lt_mi[0].doa_doc != "")
                {
                    html_msg = html_msg + "ATTACHED";
                }
                else
                {
                    html_msg = html_msg + "NONE";
                }
                html_msg = html_msg + "</td></tr>";
                html_msg = html_msg + "<tr><td align='right'>COMPLETE SPECIFICATION (FORM 3):</td><td >";
                if (lt_mi[0].spec_doc != "")
                {
                    html_msg = html_msg + "ATTACHED";
                }
                else
                {
                    html_msg = html_msg + "NONE";
                }
                html_msg = html_msg + "</td></tr>";
            }
            html_msg = html_msg + "<tr><td class='tbbg' colspan='2' align='center'>  --- MESSAGE FROM COMMERCIAL LAW DEPARTMENT --- </td></tr>";
            html_msg = html_msg + "<tr><td align='center' colspan='2'>" + comment.Text + "</td></tr>";
            html_msg = html_msg + "<tr><td class='tbbg' colspan='2' align='center'>  &nbsp;</td></tr>";
            html_msg = html_msg + "<tr><td align='right'>REQUESTING UNIT: </td><td >" + z.getRoleNameByID(x_admin.xroleID) + "</td></tr>";
            html_msg = html_msg + "<tr><td align='right'>REQUESTING OFFICER: </td><td >" + x_admin.xname + "</td></tr>";
            html_msg = html_msg + "<tr><td align='right'>DEADLINE FOR RESPONSE:</td><td >" + txt_response_date.Text + "</td></tr>";
            html_msg = html_msg + "<tr><td align='right'>CONTACT PHONE NUMBER: </td><td >" + x_admin.xtelephone1 + "</td></tr><tr><td class='tbbg' colspan='2'>&nbsp;</td></tr>";
            html_msg = html_msg + "</table></div></form></body></html>";
            if (email.sendMail(z.getRoleNameByID(x_admin.xroleID).ToUpper(), lt_rep[0].xemail, from, subject, html_msg, "") == "sent")
            {
                if (z.e_Contact_formStatus(succ, "1") > 0)
                {
                    Response.Write("<script language=JavaScript>alert('Message sent successfully')</script>");
                    Response.Redirect("./profile.aspx");
                }
                else
                {
                    Response.Write("<script language=JavaScript>alert('The form could not be updated, Please check your internet connection or try again later')</script>");
                }
            }
            else
            {
                Response.Write("<script language=JavaScript>alert('The E-mail could not be sent, Please check your internet connection or try again later')</script>");
            }
        }
        else
        {
            Response.Write("<script language=JavaScript>alert('The form could not be saved, Please check your internet connection or try again later')</script>");
        }
    }

}

