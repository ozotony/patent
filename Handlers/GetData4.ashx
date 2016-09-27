<%@ WebHandler Language="C#" Class="GetData4" %>

using System;
using System.Web;

public class GetData4 : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        System.Web.Script.Serialization.JavaScriptSerializer ser = new System.Web.Script.Serialization.JavaScriptSerializer();
        zues z2 = new zues();
        var pp = context.Request["vid"];
         var pp2 = context.Request["vid2"];
        pt zz = new pt();
        pt.PtInfo kk = zz.getPtInfoByPwalletID4(pp,pp2);
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