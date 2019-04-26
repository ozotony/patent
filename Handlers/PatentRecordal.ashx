<%@ WebHandler Language="C#" Class="PatentRecordal" %>

using System;
using System.Web;
using System.Web.Script.Serialization;

public class PatentRecordal : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        var pp = context.Request["vid"];
        String dd = "";
        JavaScriptSerializer ser = new JavaScriptSerializer();
        pt t = new pt();
        Reports mm = new Reports();
      mm.Stage =  t.getStageByUserID3(pp);
        mm.PtInfo =  t.getPtInfoByPwalletID(mm.Stage[0].ID);
       mm.Applicant = t.getApplicantByvalidationID(mm.Stage[0].ID);
       mm.Assignment_info = t.getAssignment_infoByvalidationID(mm.Stage[0].ID);
       mm.Inventor = t.getInventorByvalidationID(mm.Stage[0].ID);
       mm.Priority_info =t.getPriority_infoByvalidationID(mm.Stage[0].ID);
              ser.MaxJsonLength = Int32.MaxValue;
        context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(mm));

          

        
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}