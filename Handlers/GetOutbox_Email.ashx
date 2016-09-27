<%@ WebHandler Language="C#" Class="GetOutbox_Email" %>

using System;
using System.Web;

public class GetOutbox_Email : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
        zues z2 = new zues();
      //  var pp = context.Request["vid"];
        pt zz = new pt();
        System.Collections.Generic.List<Email4> kk = zz.getOutboxEmails();
        ser.MaxJsonLength = Int32.MaxValue;

        context.Response.ContentType = "application/json";
        context.Response.Write(ser.Serialize(kk));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}