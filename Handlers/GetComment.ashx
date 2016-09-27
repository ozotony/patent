<%@ WebHandler Language="C#" Class="GetComment" %>

using System;
using System.Web;

public class GetComment : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
        zues z2 = new zues();
        var pp = context.Request["vid"];

        System.Collections.Generic.List<zues.PtOffice> kk = z2.getPtOfficeDetailsByID3(pp);
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