<%@ WebHandler Language="C#" Class="PostTransaction" %>

using System;
using System.Web;
    using System.Web.Script.Serialization;

public class PostTransaction : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
       JavaScriptSerializer ser = new JavaScriptSerializer();
            var pp =( context.Request["vid"]);

           //   List<String>dd = ser.Deserialize<List<String>>(pp);

          AppTransaction[] dd = ser.Deserialize<AppTransaction[]>(pp);

            int vlength = dd.Length;
            zues bb = new zues();
            for (int i = 0; i < dd.Length; i++)
            {
                

                if (dd[i].Status == "Search")
                {
                    bb.g_pwalletStatus2(dd[i].online_id, "2", "Valid");

                }

               

              

               
                //  String ds2 = dd[i].online_id;
            }

                //string online = dd[0].online_id;





            context.Response.ContentType = "application/json";
            context.Response.Write(ser.Serialize(dd));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}