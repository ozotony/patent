using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class admin_pt_verification_unit_n_renewal_details : Page
{
    public string admin = "";
    public string admin_status = "2";
    public pt.XPwallet c_p = new pt.XPwallet();
    public pt.Renewal c_x = new pt.Renewal();
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
            Response.Redirect("./n_renewal.aspx");
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

