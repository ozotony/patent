<%@ WebHandler Language="C#" Class="addRenewal" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Transactions;

public class addRenewal : IHttpHandler {
    //(serverpath, transID, agt, amt, log_staffID,item_code
    public string transID = ""; public string amt = ""; public string agt = ""; public string pwalletID = "0";
    public string log_staffID = "0";  public string item_code = ""; public string serverpath = "";
    
    protected string reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
    protected string reg_time = DateTime.Today.ToUniversalTime().ToString("hh:mm:ss tt");
    public string json = ""; public string hwalletID = "";
    public int succ = 0;
    public JavaScriptSerializer js = new JavaScriptSerializer();
    public pt.Renewal x = new pt.Renewal();
    public pt p = new pt();
    
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";
        try
        {
            if ((context.Request.Form["title"] != null) && (context.Request.Form["title"] != ""))
            {
                x.title = context.Request.Form["title"].ToString();
            }
            if ((context.Request.Form["type"] != null) && (context.Request.Form["type"] != ""))
            {
                x.type = context.Request.Form["type"].ToString();
            }
            if ((context.Request.Form["app_no"] != null) && (context.Request.Form["app_no"] != ""))
            {
                x.app_no = context.Request.Form["app_no"].ToString();
            }
            if ((context.Request.Form["app_date"] != null) && (context.Request.Form["app_date"] != ""))
            {
                x.app_date = context.Request.Form["app_date"].ToString();
            }
            if ((context.Request.Form["xname"] != null) && (context.Request.Form["xname"] != ""))
            {
                x.xname = context.Request.Form["xname"].ToString();
            }
            if ((context.Request.Form["xaddy"] != null) && (context.Request.Form["xaddy"] != ""))
            {
                x.xaddy = context.Request.Form["xaddy"].ToString();
            }
            if ((context.Request.Form["xmobile"] != null) && (context.Request.Form["xmobile"] != ""))
            {
                x.xmobile = context.Request.Form["xmobile"].ToString();
            }
            if ((context.Request.Form["xemail"] != null) && (context.Request.Form["xemail"] != ""))
            {
                x.xemail = context.Request.Form["xemail"].ToString();
            }

            if ((context.Request.Form["agt_code"] != null) && (context.Request.Form["agt_code"] != ""))
            {
                x.agt_code = context.Request.Form["agt_code"].ToString();
            }
            if ((context.Request.Form["agt_name"] != null) && (context.Request.Form["agt_name"] != ""))
            {
                x.agt_name = context.Request.Form["agt_name"].ToString();
            }
            if ((context.Request.Form["agt_addy"] != null) && (context.Request.Form["agt_addy"] != ""))
            {
                x.agt_addy = context.Request.Form["agt_addy"].ToString();
            }
            if ((context.Request.Form["agt_mobile"] != null) && (context.Request.Form["agt_mobile"] != ""))
            {
                x.agt_mobile = context.Request.Form["agt_mobile"].ToString();
            }
            if ((context.Request.Form["agt_email"] != null) && (context.Request.Form["agt_email"] != ""))
            {
                x.agt_email = context.Request.Form["agt_email"].ToString();
            }
            if ((context.Request.Form["last_rwl_date"] != null) && (context.Request.Form["last_rwl_date"] != ""))
            {
                x.last_rwl_date = context.Request.Form["last_rwl_date"].ToString();
            }
            if ((context.Request.Form["xid"] != null) && (context.Request.Form["xid"] != ""))
            {
                x.log_staff = context.Request.Form["xid"].ToString();
            }
            if ((context.Request.Form["hwalletID"] != null) && (context.Request.Form["hwalletID"] != ""))
            {
                hwalletID = context.Request.Form["hwalletID"].ToString();
            }

            if ((context.Request.Form["transID"] != null) && (context.Request.Form["transID"] != ""))
            {
                transID = context.Request.Form["transID"].ToString();
            }
            if ((context.Request.Form["serverpath"] != null) && (context.Request.Form["serverpath"] != ""))
            {
                serverpath = context.Request.Form["serverpath"].ToString();
            }
            if ((context.Request.Form["amt"] != null) && (context.Request.Form["amt"] != ""))
            {
                amt = context.Request.Form["amt"].ToString();
            }
            if ((context.Request.Form["log_staffID"] != null) && (context.Request.Form["log_staffID"] != ""))
            {
                log_staffID = context.Request.Form["log_staffID"].ToString();
            }
            if ((context.Request.Form["item_code"] != null) && (context.Request.Form["item_code"] != ""))
            {
                item_code = context.Request.Form["item_code"].ToString();
            }

            x.reg_no = "";

            x.reg_date = reg_date; x.reg_time = reg_time; x.visible = "1"; x.sync = "0";

            if ((transID!= "")&&(x.agt_code != "")&&(amt != "")&&(log_staffID!= "")&&(item_code != ""))
            {
                pwalletID = p.addXPwallet(serverpath,transID,x.agt_code,amt,log_staffID,item_code);

                if (Convert.ToInt32(pwalletID) > 0)
                {
                    x.log_staff = pwalletID;
                    
                    succ = p.addRenewal(x);
                    if (succ > 0)
                    {
                        if (Convert.ToInt32(hwalletID) > 0)
                        {
                            string status = p.updateHwallet(hwalletID, "Used", reg_date, x.title).ToString();
                        }
                        json = js.Serialize(succ);
                        json = "{\"msg\":" + json + "}";
                        context.Response.Write(json);
                    }
                    else
                    {
                        json = js.Serialize("0");
                        json = "{\"msg\":" + json + "}";
                        context.Response.Write(json);
                    }

                }
                else
                {
                    //Bounce the person back
                    if (Convert.ToInt32(hwalletID) > 0)
                    {
                        context.Response.Redirect("http://ipo.cldng.com/A/profile.aspx");
                    }
                    else
                    {
                        context.Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            XWriter2 pp = new XWriter2();
            string message = transID + " " + DateTime.Now;

            string vpath = System.Web.HttpContext.Current.Server.MapPath("~/") + "PatentLog/Renewal/" + transID + ".txt";

            pp.WriteToFile(message, vpath);

            string ex1 = ex.ToString();
            json = js.Serialize("0");
            json = "{\"msg\":" + json + "}";
            context.Response.Write(json);
        } 
    }

 
    public bool IsReusable {
        get {
            return false;
        }
    }

}