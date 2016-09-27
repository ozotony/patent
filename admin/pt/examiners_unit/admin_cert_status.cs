using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class  admin_pt_examiners_unit_admin_cert_status : Page
{
    public pt.XPwallet c_p = new pt.XPwallet();
    public pt.Renewal c_ren = new pt.Renewal();
    public string current_date;
    public string msg = "";
    public pt t = new pt();

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((((this.Session["transID"] != null) && (this.Session["transID"].ToString() != "")) && (this.Session["x_code"] != null)) && (this.Session["x_code"].ToString() != ""))
        {
            this.c_p = this.t.getXPwalletDetailsByCode(this.Session["transID"].ToString(), this.Session["x_code"].ToString());
            if (this.c_p.ID != null)
            {
                this.c_ren = this.t.getRenewalByLogstaffID(this.c_p.ID);
                if (this.c_ren.xID != null)
                {
                    this.transID.Text = this.c_p.validationID;
                    this.payment_date.Text = this.c_p.reg_date;
                    this.p_title.Text = this.c_ren.title;
                    this.p_app_no.Text = this.c_ren.app_no;
                    this.p_type.Text = this.c_ren.type;
                    this.p_app_date.Text = this.c_ren.app_date;
                    this.p_xname.Text = this.c_ren.xname;
                    this.p_xaddy.Text = this.c_ren.xaddy;
                    this.p_xmobile.Text = this.c_ren.xmobile;
                    this.p_xemail.Text = this.c_ren.xemail;
                    this.p_agt_code.Text = this.c_ren.agt_code;
                    this.p_agt_name.Text = this.c_ren.agt_name;
                    this.p_agt_addy.Text = this.c_ren.agt_addy;
                    this.p_agt_mobile.Text = this.c_ren.agt_mobile;
                    this.p_agt_email.Text = this.c_ren.agt_email;
                    this.p_due_date.Text = Convert.ToDateTime(this.c_ren.last_rwl_date).AddYears(1).ToString("yyyy-MM-dd");
                    this.p_next_due_date.Text = Convert.ToDateTime(this.c_ren.last_rwl_date).AddYears(2).ToString("yyyy-MM-dd");
                }
            }
            else
            {
                this.msg = "NO ENTRY EXISTS WITH THE DETAILS ABOVE,PLEASE CHECK THE DETAILS AND TRY AGAIN!!";
            }
        }
        else
        {
            base.Response.Write("<script language=JavaScript>alert('PLEASE ENTER A VALID REFERENCE NUMBER')</script>");
        }
    }

   
}

