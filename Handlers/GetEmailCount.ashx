<%@ WebHandler Language="C#" Class="GetEmailCount" %>

using System;
using System.Web;
using System.Web.Script.Serialization;

public class GetEmailCount : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var pp = context.Request["vid"];
        var pp3 = context.Request["vid2"];
        String dd = "";
        JavaScriptSerializer ser = new JavaScriptSerializer();
        pt pp2 = new pt();
        //  pp2.updateEmail(pp);
        Int32 kk = pp2.getEmailCount2(pp,pp3);




        // XObjs.Registration kk = pp2.getRegistrationBySubagentRegistrationID(pp);



        context.Response.ContentType = "application/json";
        context.Response.Write(ser.Serialize(kk));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}