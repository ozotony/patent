using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class  admin_pt_acceptance_unit_online_request_profile : Page
{
    public string adminID = "";
    public int lt_mi_app = 0;
    public int lt_mi_rej = 0;
    public int lt_n = 0;
    public zues z = new zues();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["pwalletID"] != null)
        {
            if (Session["pwalletID"].ToString() != "")
            {
                adminID = Session["pwalletID"].ToString();
            }
            else
            {
                Response.Redirect("../lo.aspx");
            }
        }
        lt_n = z.getRenPtInfoRSCnt("2", "Valid");
        lt_mi_rej = z.getRenPtInfoRSCnt("2", "Refused");
        lt_mi_app = z.getRenPtInfoRSCnt("3", "Approved");
    }

 
}

