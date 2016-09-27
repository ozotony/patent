using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class xindex_ren : Page
{
    public string agentemail = "";
    public string agentname = "";
    public string agentpnumber = "";
    public string agt = "";
    public string amt = "";
    public string applicantemail = "";
    public string applicantname = "";
    public string applicantpnumber = "";
    public string fee_detailsID = "";
    public string hwalletID = "";
    public string item_code = "";
    public string log_staffID = "0";
    public string payment_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
    public string product_title = "";
    public string pwalletID = "0";
    public string serverpath = "";
    public pt t = new pt();
    public string transID = "";
    public string xapplication = "";
    public string xgt = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["transID"] = null;
        Session["amt"] = null;
        Session["agt"] = null;
        Session["xgt"] = null;
        Session["applicantname"] = null;
        Session["applicantemail"] = null;
        Session["applicantpnumber"] = null;
        Session["agentname"] = null;
        Session["agentemail"] = null;
        Session["agentpnumber"] = null;
        Session["product_title"] = null;
        Session["item_code"] = null;
        Session["xapplication"] = null;
        Session["pwalletID"] = null;
        Session["log_staffID"] = null;
        Session["xapplication"] = null;
        Session["log_staffID"] = log_staffID;
        serverpath = Server.MapPath("~/");
        transID = Request.Params["transID"];
        amt = Request.Params["amt"];
        agt = Request.Params["agt"];
        xgt = Request.Params["xgt"];
        item_code = Request.Params["item_code"];
        hwalletID = Request.Params["hwalletID"];
        fee_detailsID = Request.Params["fee_detailsID"];
        if ((Request.Params["applicantname"] != null) && Request.Params["applicantname"].Contains("%26"))
        {
            applicantname = Request.Params["applicantname"].Replace("%26", "&");
        }
        else
        {
            applicantname = Request.Params["applicantname"];
        }
        applicantemail = Request.Params["applicantemail"];
        applicantpnumber = Request.Params["applicantpnumber"];
        agentname = Request.Params["agentname"];
        agentemail = Request.Params["agentemail"];
        agentpnumber = Request.Params["agentpnumber"];
        if ((Request.Params["product_title"] != null) && Request.Params["product_title"].Contains("%26"))
        {
            product_title = Request.Params["product_title"].Replace("%26", "&");
        }
        else
        {
            product_title = Request.Params["product_title"];
        }
        item_code = Request.Params["item_code"];
        if ((((((transID != "") && (amt != "")) && ((agt != "") && (xgt != ""))) && (((applicantname != "") && (applicantemail != "")) && ((applicantpnumber != "") && (agentname != "")))) && (((agentemail != "") && (agentpnumber != "")) && (product_title != ""))) && (item_code != ""))
        {
            if (Session["xapplication"] != null)
            {
                xapplication = Session["xapplication"].ToString();
                if (xapplication != transID)
                {
                }
            }
            else
            {
                Session["xapplication"] = transID;
            }
            Session["transID"] = transID;
            Session["amt"] = amt;
            Session["agt"] = agt;
            Session["xgt"] = xgt;
            Session["applicantname"] = applicantname;
            Session["applicantemail"] = applicantemail;
            Session["applicantpnumber"] = applicantpnumber;
            Session["agentname"] = agentname;
            Session["agentemail"] = agentemail;
            Session["agentpnumber"] = agentpnumber;
            Session["product_title"] = product_title;
            Session["item_code"] = item_code;
            Session["hwalletID"] = hwalletID;
            Session["fee_detailsID"] = fee_detailsID;
            Session["serverpath"] = serverpath;
            serverpath = serverpath.Replace('\\', '/');
            if (t.getRenStageIDByvalidationID(transID.Trim()) > 0)
            {
                Response.Redirect("./xreturn_ren.aspx");
            }
        }
        else if (Convert.ToInt32(hwalletID) > 0)
        {
            Response.Redirect("http://ipo.cldng.com/A/profile.aspx");
        }
        else
        {
            Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
        }
    }

 
}

