using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class  admin_pt_examiners_unit_online_request_profile : Page
{
    public string adminID = "";
    public int lt_mi_app = 0;
    public int lt_mi_rej = 0;
    public int lt_n = 0;
    public zues z = new zues();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["pwalletID"] != null)
        {
            if (this.Session["pwalletID"].ToString() != "")
            {
                this.adminID = this.Session["pwalletID"].ToString();
            }
            else
            {
                base.Response.Redirect("../lo.aspx");
            }
        }
        this.lt_n = this.z.getRenPtInfoRSCnt("2", "Valid");
        this.lt_mi_rej = this.z.getRenPtInfoRSCnt("2", "Refused");
        this.lt_mi_app = this.z.getRenPtInfoRSCnt("3", "Approved");
    }

  
}

