using log4net;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class n_renewal : Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.Params["payment_date"] != null) && (Request.Params["payment_date"].ToString() != ""))
        {
            payment_date.Value = Request.Params["payment_date"].ToString();
        }
        if ((Request.Params["transID"] != null) && (Request.Params["transID"].ToString() != ""))
        {
            transID.Value = Request.Params["transID"].ToString();
        }
        if ((Request.Params["applicantname"] != null) && (Request.Params["applicantname"].ToString() != ""))
        {
            xname.Value = Request.Params["applicantname"].ToString();
        }
        if ((Request.Params["applicantemail"] != null) && (Request.Params["applicantemail"].ToString() != ""))
        {
            xemail.Value = Request.Params["applicantemail"].ToString();
        }
        if ((Request.Params["applicantpnumber"] != null) && (Request.Params["applicantpnumber"].ToString() != ""))
        {
            xmobile.Value = Request.Params["applicantpnumber"].ToString();
        }
        if ((Request.Params["agt"] != null) && (Request.Params["agt"].ToString() != ""))
        {
            agt_code.Value = Request.Params["agt"].ToString();
        }
        if ((Request.Params["agentname"] != null) && (Request.Params["agentname"].ToString() != ""))
        {
            agt_name.Value = Request.Params["agentname"].ToString();
        }
        if ((Request.Params["agentemail"] != null) && (Request.Params["agentemail"].ToString() != ""))
        {
            agt_email.Value = Request.Params["agentemail"].ToString();
        }
        if ((Request.Params["agentpnumber"] != null) && (Request.Params["agentpnumber"].ToString() != ""))
        {
            agt_mobile.Value = Request.Params["agentpnumber"].ToString();
        }
        if ((Request.Params["product_title"] != null) && (Request.Params["product_title"].ToString() != ""))
        {
            title.Value = Request.Params["product_title"].ToString();
        }
        if ((Request.Params["item_code"] != null) && (Request.Params["item_code"].ToString() != ""))
        {
            item_code.Value = Request.Params["item_code"].ToString();
        }
        if ((Request.Params["amt"] != null) && (Request.Params["amt"].ToString() != ""))
        {
            amt.Value = Request.Params["amt"].ToString();
        }
        if ((Request.Params["serverpath"] != null) && (Request.Params["serverpath"].ToString() != ""))
        {
            serverpath.Value = Request.Params["serverpath"].ToString();
        }
        log_staffID.Value = "0";
        if ((Session["hwalletID"] != null) && (Session["hwalletID"].ToString() != ""))
        {
            hwalletID.Value = Session["hwalletID"].ToString();
        }
        else
        {
            hwalletID.Value = "0";
        }
    }

}

