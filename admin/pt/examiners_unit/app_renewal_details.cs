using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class  admin_pt_examiners_unit_app_renewal_details : Page
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
            this.c_x = this.t.getRenewalByID(this.pID);
            this.Session["Cx"] = this.c_x;
            this.c_p = this.t.getXPwalletDetailsByID(this.c_x.log_staff);
            this.lt_tm_office = this.z.getXPtOfficeDetailsByID(this.c_x.log_staff);
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
            }
            this.payment_date.Text = this.c_p.reg_date;
            this.transID.Text = this.c_p.validationID;
            this.p_type.Text = this.c_x.type;
            this.p_title.Text = this.c_x.title;
            this.p_item_code.Text = this.c_p.item_code;
            this.p_app_no.Text = this.c_x.app_no;
            this.p_app_date.Text = this.c_x.app_date;
            this.p_xname.Text = this.c_x.xname;
            this.p_xaddy.Text = this.c_x.xaddy;
            this.p_xemail.Text = this.c_x.xemail;
            this.p_xmobile.Text = this.c_x.xmobile;
            this.p_agt_addy.Text = this.c_x.agt_addy;
            this.p_agt_code.Text = this.c_x.agt_code;
            this.p_agt_email.Text = this.c_x.agt_email;
            this.p_agt_mobile.Text = this.c_x.agt_mobile;
            this.p_agt_name.Text = this.c_x.agt_name;
            this.p_last_rwl_date.Text = this.c_x.last_rwl_date;
            this.p_due_date.Text = Convert.ToDateTime(this.c_x.last_rwl_date).AddYears(1).ToString("yyyy-MM-dd");
        }
        else
        {
            base.Response.Redirect("./app_renewal.aspx");
        }
    }

    protected void Verify_Click(object sender, EventArgs e)
    {
        this.Session["transID"] = null;
        this.Session["x_code"] = null;
        this.Session["transID"] = this.transID.Text;
        this.Session["x_code"] = this.c_p.log_officer;
        base.Response.Redirect("./admin_cert_status.aspx");
    }

}

