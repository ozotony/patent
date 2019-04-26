<%@ WebHandler Language="C#" Class="PostRecordal" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;


public class PostRecordal : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        JavaScriptSerializer ser = new JavaScriptSerializer();
        var pp =( context.Request["vid"]);

        var pp2 =( context.Request["vid2"]);
        var pp3 =( context.Request["vid3"]);
        var pp4 =( context.Request["vid4"]);
        var pp5 =( context.Request["vid5"]);
        var pp6 =( context.Request["vid6"]);

        //   List<String>dd = ser.Deserialize<List<String>>(pp);

        pt.Applicant[] dd = ser.Deserialize<pt.Applicant[]>(pp);
        pt.Inventor[] dd2 = ser.Deserialize<pt.Inventor[]>(pp2);
        pt.PtInfo[] dd3 = ser.Deserialize<pt.PtInfo[]>(pp3);
        pt.Assignment_info[] dd4 = ser.Deserialize<pt.Assignment_info[]>(pp4);

        var applicant2 = JsonConvert.SerializeObject(dd);
        var Inventor2 = JsonConvert.SerializeObject(dd2);
        var PtInfo2 = JsonConvert.SerializeObject(dd3);
        var Assignment_info2 = JsonConvert.SerializeObject(dd4);


        //before image 

        Reports mm = new Reports();
        pt t = new pt();
        // mm.Stage =  t.getStageByUserID2(dd[0].log_staff);
        var kkk = t.getPtInfoByUserID(dd3[0].xID);
        var PtInfo = JsonConvert.SerializeObject( t.getPtInfoByUserID(dd[0].ID));
        var Applicant = JsonConvert.SerializeObject( t.getApplicantByvalidationID(kkk[0].log_staff) );
        var Assignment_info = JsonConvert.SerializeObject (t.getAssignment_infoByvalidationID(kkk[0].log_staff));
        var Inventor = JsonConvert.SerializeObject (t.getInventorByvalidationID(kkk[0].log_staff) );
        var Priority_info =JsonConvert.SerializeObject (t.getPriority_infoByvalidationID(kkk[0].log_staff) );

        Recordal_Result pp10 = t.InsertRecordal(kkk[0].log_staff, pp6, pp5, "");
        t.InsertRecordalApplicant(pp10.Recordal_Id, Applicant, applicant2);
        t.InsertRecordalPtInfo(pp10.Recordal_Id, PtInfo, PtInfo2);
        t.InsertRecordalAssignment_info(pp10.Recordal_Id, Assignment_info, Assignment_info2);
        t.InsertRecordalInventor_info(pp10.Recordal_Id, Inventor, Inventor2);
        //  t.InsertRecordalPriority_info(pp10.Recordal_Id, Priority_info, Priority_info2);

        // context.Response.ContentType = "text/plain";
        // context.Response.Write("Hello World");
        pp10.TransactionId = kkk[0].log_staff;
        context.Response.ContentType = "application/json";
        context.Response.Write(ser.Serialize(pp10));
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}