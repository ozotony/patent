using System;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ren_ack : Page
{
    protected void btnDashboard_Click(object sender, EventArgs e)
    {
        if ((Session["hwalletID"] != null) && (Session["hwalletID"].ToString() != ""))
        {
            Response.Redirect(ConfigurationManager.AppSettings["ipo_profile_page"]);
        }
        else
        {
            Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.Params["transID"] != null) && (Request.Params["transID"].ToString() != ""))
        {
            transID.Text = Request.Params["transID"].ToString();
        }
        if ((Request.Params["payment_date"] != null) && (Request.Params["payment_date"].ToString() != ""))
        {
            payment_date.Text = Request.Params["payment_date"].ToString();
        }
        if ((Request.Params["title"] != null) && (Request.Params["title"].ToString() != ""))
        {
            p_title.Text = Request.Params["title"].ToString();
        }
        if ((Request.Params["app_no"] != null) && (Request.Params["app_no"].ToString() != ""))
        {
            p_app_no.Text = Request.Params["app_no"].ToString();
        }
        if ((Request.Params["type"] != null) && (Request.Params["type"].ToString() != ""))
        {
            p_type.Text = Request.Params["type"].ToString();
        }
        if ((Request.Params["app_date"] != null) && (Request.Params["app_date"].ToString() != ""))
        {
            p_app_date.Text = Request.Params["app_date"].ToString();
        }
        if ((Request.Params["xname"] != null) && (Request.Params["xname"].ToString() != ""))
        {
            p_xname.Text = Request.Params["xname"].ToString();
        }
        if ((Request.Params["xaddy"] != null) && (Request.Params["xaddy"].ToString() != ""))
        {
            p_xaddy.Text = Request.Params["xaddy"].ToString();
        }
        if ((Request.Params["xmobile"] != null) && (Request.Params["xmobile"].ToString() != ""))
        {
            p_xmobile.Text = Request.Params["xmobile"].ToString();
        }
        if ((Request.Params["xemail"] != null) && (Request.Params["xemail"].ToString() != ""))
        {
            p_xemail.Text = Request.Params["xemail"].ToString();
        }
        if ((Request.Params["agt_code"] != null) && (Request.Params["agt_code"].ToString() != ""))
        {
            p_agt_code.Text = Request.Params["agt_code"].ToString();
        }
        if ((Request.Params["agt_name"] != null) && (Request.Params["agt_name"].ToString() != ""))
        {
            p_agt_name.Text = Request.Params["agt_name"].ToString();
        }
        if ((Request.Params["agt_addy"] != null) && (Request.Params["agt_addy"].ToString() != ""))
        {
            p_agt_addy.Text = Request.Params["agt_addy"].ToString();
        }
        if ((Request.Params["agt_mobile"] != null) && (Request.Params["agt_mobile"].ToString() != ""))
        {
            p_agt_mobile.Text = Request.Params["agt_mobile"].ToString();
        }
        if ((Request.Params["agt_email"] != null) && (Request.Params["agt_email"].ToString() != ""))
        {
            p_agt_email.Text = Request.Params["agt_email"].ToString();
        }
        if ((Request.Params["last_rwl_date"] != null) && (Request.Params["last_rwl_date"].ToString() != ""))
        {
            p_last_rwl_date.Text = Request.Params["last_rwl_date"].ToString();
            p_due_date.Text = Convert.ToDateTime(p_last_rwl_date.Text).AddYears(1).ToString("yyyy-MM-dd");
        }
    }

    
}

