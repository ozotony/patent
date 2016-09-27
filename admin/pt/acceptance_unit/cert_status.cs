using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class  admin_pt_acceptance_unit_cert_status : Page
{   
    public pt.XPwallet c_p = new pt.XPwallet();
    public pt.Renewal c_ren = new pt.Renewal();
    public string current_date;
    public string msg = "";
    public int showt;
    public pt t = new pt();

    protected void BtnCheckStatus_Click(object sender, EventArgs e)
    {
        Response.Redirect("./cert_status.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["agt"] != null)
        {
        }
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        if ((xref.Text != "") && (x_code.Text != ""))
        {
            c_p = t.getXPwalletDetailsByCode(xref.Text, x_code.Text);
            if (c_p.ID != null)
            {
                c_ren = t.getRenewalByLogstaffID(c_p.ID);
                if (c_ren.xID != null)
                {
                    transID.Text = c_p.validationID;
                    payment_date.Text = c_p.reg_date;
                    p_title.Text = c_ren.title;
                    p_app_no.Text = c_ren.app_no;
                    p_type.Text = c_ren.type;
                    p_app_date.Text = c_ren.app_date;
                    p_xname.Text = c_ren.xname;
                    p_xaddy.Text = c_ren.xaddy;
                    p_xmobile.Text = c_ren.xmobile;
                    p_xemail.Text = c_ren.xemail;
                    p_agt_code.Text = c_ren.agt_code;
                    p_agt_name.Text = c_ren.agt_name;
                    p_agt_addy.Text = c_ren.agt_addy;
                    p_agt_mobile.Text = c_ren.agt_mobile;
                    p_agt_email.Text = c_ren.agt_email;
                    p_due_date.Text = Convert.ToDateTime(c_ren.last_rwl_date).AddYears(1).ToString("yyyy-MM-dd");
                    p_next_due_date.Text = Convert.ToDateTime(c_ren.last_rwl_date).AddYears(2).ToString("yyyy-MM-dd");
                    showt = 1;
                }
            }
            else
            {
                msg = "NO ENTRY EXISTS WITH THE DETAILS ABOVE,PLEASE CHECK THE DETAILS AND TRY AGAIN!!";
                showt = 0;
            }
        }
        else
        {
            Response.Write("<script language=JavaScript>alert('PLEASE ENTER A VALID REFERENCE NUMBER')</script>");
            showt = 0;
        }
    }

}

