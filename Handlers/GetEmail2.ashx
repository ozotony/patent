<%@ WebHandler Language="C#" Class="GetEmail2" %>

using System;
using System.Web;

public class GetEmail2 : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        var pp = context.Request["vid"];
        String dd = "";
        System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
        pt zz = new pt();
        //pp2.updateEmail(pp);
        Email4 kk = zz.getEmail2(pp);




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