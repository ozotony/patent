using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Patent_Recorder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["transID"] != null)
        {
            xname.Value = Convert.ToString(Request.Form["transID"]);
            vtranid.Value= Convert.ToString(Request.Form["vtranid"]);
            vamount.Value = Convert.ToString(Request.Form["vamount"]);
            // vamount

        }
        }
}