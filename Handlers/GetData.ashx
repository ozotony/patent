<%@ WebHandler Language="C#" Class="GetData" %>

using System;
using System.Web;

public class GetData : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
        zues z2 = new zues();
        var pp = context.Request["vid"];
        var pp2 = context.Request["vid2"];
        System.Collections.Generic.List<zues.PtInfo> kk = z2.getPtInfoRSX2(pp, pp2, "1", "1");
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