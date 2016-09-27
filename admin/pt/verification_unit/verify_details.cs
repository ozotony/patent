﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class admin_pt_verification_unit_verify_details : Page
{
    public string admin = "";
    public string admin_status = "2";
    public List<pt.Applicant> lt_app = new List<pt.Applicant>();
    public List<pt.Assignment_info> lt_assinfo = new List<pt.Assignment_info>();
    public List<pt.Inventor> lt_inv = new List<pt.Inventor>();
    public List<pt.PtInfo> lt_mi = new List<pt.PtInfo>();
    public List<pt.Representative> lt_rep = new List<pt.Representative>();
    public List<pt.Stage> lt_stage = new List<pt.Stage>();
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
        }
        else
        {
            Response.Redirect("./verify_data.aspx");
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
            Response.Redirect("./profile.aspx");
        }
        else
        {
            Response.Write("<script language=JavaScript>alert('Data not verified, Please try again later')</script>");
        }
    }

   
}

