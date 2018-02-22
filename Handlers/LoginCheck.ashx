<%@ WebHandler Language="C#" Class="LoginCheck" %>

using System;
using System.Web;
using System.Web.Script.Serialization;


public class LoginCheck : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
       string new_hash = "";


            JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp = context.Request["vv"];

            Login dd = ser.Deserialize<Login>(pp);

            zues ff = new zues();

            String  vip = ff.CheckLogin(dd);
            //var session = HttpContext.Current.Session;

          //  context.Session["pwalletID"] = vip;

            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(vip));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}