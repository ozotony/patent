using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class xxindex : Page
{
    public string agent = "";
    public string agentemail = "";
    public string agentpnumber = "";
    public string aid = "";
    public string amt = "";
    public string cname = "";
    public string fee_detailsID = "";
    public string hwalletID = "0";
    public string pc = "";
    public string product_title = "";
    public string pwalletID = "0";
    public pt t = new pt();
    public string transID = "";
    public string vid = "";
    public string x = "";
    public string xapplication = "";
    public string xgt = "";
    public string xrep = "";
    public string xuserType = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["vid"] = null;
        Session["amt"] = null;
        Session["aid"] = null;
        Session["gt"] = null;
        Session["pc"] = null;
        Session["agentemail"] = null;
        Session["cname"] = null;
        Session["agentpnumber"] = null;
        Session["product_title"] = null;
        Session["xapplication"] = null;
        Session["pwalletID"] = null;
        Session["xapplication"] = null;
        Session["fee_detailsID"] = null;
        Session["item_code"] = null;
        Session["hwalletID"] = null;
        string str = Server.MapPath("~/");
        transID = Request.Params["transID"];
        amt = Request.Params["amt"];
        agent = Request.Params["agent"];
        xgt = Request.Params["xgt"];
        pc = Request.Params["pc"];
        hwalletID = Request.Params["hwalletID"];
        fee_detailsID = Request.Params["fee_detailsID"];
        if ((Request.Params["cname"] != null) && Request.Params["cname"].Contains("%26"))
        {
            cname = Request.Params["cname"].Replace("%26", "&");
        }
        else
        {
            cname = Request.Params["cname"];
        }
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
        Session["hwalletID"] = hwalletID;
        Session["fee_detailsID"] = fee_detailsID;
        if (((((transID != "") && (amt != "")) && ((agent != "") && (xgt != ""))) && (((cname != "") && (agentemail != "")) && ((agentpnumber != "") && (product_title != "")))) && (pc != ""))
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
            Session["vid"] = transID;
            Session["amt"] = amt;
            Session["aid"] = agent;
            Session["gt"] = xgt;
            Session["pc"] = pc;
            Session["agentemail"] = agentemail;
            Session["cname"] = cname;
            Session["agentpnumber"] = agentpnumber;
            Session["product_title"] = product_title;
            Session["serverpath"] = str;
            if (t.getStageIDByvalidationID(transID.Trim()) > 0)
            {
                Response.Redirect("./xxreturn.aspx");
            }
        }
        else
        {
            Response.Redirect("http://ipo.cldng.com/a_login.aspx");
        }
    }

  
}

