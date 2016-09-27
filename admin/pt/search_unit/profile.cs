using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class admin_pt_search_unit_profile : Page
{
    public string adminID = "";
    public long lt_mi = 0L;
    public long lt_mi_contact = 0L;
    public long lt_mi_r = 0L;
    public zues z = new zues();

    public int or_cnt = 0;

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
        this.lt_mi = this.z.getPtInfoRSCnt("2", "Valid");
        this.lt_mi_r = this.z.getPtInfoRSCnt("3", "Further Search");
        this.lt_mi_contact = this.z.getPtInfoRSCnt("2", "S_Contact");
        this.or_cnt = (this.z.getRenPtInfoRSCnt("2", "Valid") + this.z.getRenPtInfoRSCnt("3", "Approved")) + this.z.getRenPtInfoRSCnt("2", "Refused");
    }

   
}

