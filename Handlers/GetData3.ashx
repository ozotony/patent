<%@ WebHandler Language="C#" Class="GetData3" %>

using System;
using System.Web;

public class GetData3 : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
        zues z2 = new zues();
        var pp = context.Request["vid"];
        var pp2 = context.Request["vid2"];
        System.Collections.Generic.List<zues.PtInfo> kk = z2.getAcceptedRSX2(pp,"1", "1");
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