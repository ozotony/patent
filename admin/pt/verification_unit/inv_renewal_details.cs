﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class admin_pt_verification_unit_inv_renewal_details : Page
{
    public string admin = "";
    public string admin_status = "2";
    public pt.XPwallet c_p = new pt.XPwallet();
    public pt.Renewal c_x = new pt.Renewal();
    public List<zues.XPtOffice> lt_tm_office = new List<zues.XPtOffice>();
    public List<zues.Adminz> lt_x_admin_details = new List<zues.Adminz>();
    public string pID;
    public string rbval_text = "";
    public string succ;
    public pt t = new pt();
    public string x_infoID;
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
            c_x = t.getRenewalByID(pID);
            c_p = t.getXPwalletDetailsByID(c_x.log_staff);
            lt_tm_office = z.getXPtOfficeDetailsByID(c_x.log_staff);
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
            }
            payment_date.Text = c_p.reg_date;
            transID.Text = c_p.validationID;
            p_type.Text = c_x.type;
            p_title.Text = c_x.title;
            p_item_code.Text = c_p.item_code;
            p_app_no.Text = c_x.app_no;
            p_app_date.Text = c_x.app_date;
            p_xname.Text = c_x.xname;
            p_xaddy.Text = c_x.xaddy;
            p_xemail.Text = c_x.xemail;
            p_xmobile.Text = c_x.xmobile;
            p_agt_addy.Text = c_x.agt_addy;
            p_agt_code.Text = c_x.agt_code;
            p_agt_email.Text = c_x.agt_email;
            p_agt_mobile.Text = c_x.agt_mobile;
            p_agt_name.Text = c_x.agt_name;
            p_last_rwl_date.Text = c_x.last_rwl_date;
            p_due_date.Text = Convert.ToDateTime(c_x.last_rwl_date).AddYears(1).ToString("yyyy-MM-dd");
        }
        else
        {
            Response.Redirect("./inv_renewal.aspx");
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
    }

    protected void Verify_Click(object sender, EventArgs e)
    {
        succ = z.a_x_pt_office(c_x.log_staff, admin_status, rbValid.SelectedValue, comment.Text, "", "", "", admin);
        if (succ != "0")
        {
            Response.Write("<script language=JavaScript>alert('Data verified successfully')</script>");
            Response.Redirect("./profile.aspx");
        }
        else
        {
            Response.Write("<script language=JavaScript>alert('Data not verified, Please try again later')</script>");
        }
    }

}

