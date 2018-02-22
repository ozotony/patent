using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class  admin_pt_examiners_unit_profile : Page
{
    public string adminID = "";
    public long lt_app_mi = 0L;
    public long lt_app_mi_contact = 0L;
    public long lt_app_mi_r = 0L;
    public long lt_mi = 0L;
    public long lt_mi_a = 0L;
    public long lt_mi_contact = 0L;
    public long lt_mi_r = 0L;
    public long lt_mi_ref = 0L;
    public int or_cnt = 0;
    public zues z = new zues();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["adminx"] != null)
        {
            String vvv = Request.Form["adminx"];

            Session["pwalletID"] = vvv;

        }
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
        this.lt_mi = this.z.getPtInfoRSCnt("3", "Search Conducted");
        this.lt_mi_r = this.z.getPtInfoRSCnt("4", "Not-Patentable");
        this.lt_mi_ref = this.z.getPtInfoRSCnt("3", "Refused");
        this.lt_mi_contact = this.z.getPtInfoRSCnt("3", "E_Contact");
        this.lt_mi_a = this.z.getAcceptedRSCnt("5");
        this.lt_app_mi = this.z.getPtInfoRSCnt("4", "Futher Review");
        this.lt_app_mi_r = this.z.getPtInfoRSCnt("5", "Review Patent");
        this.lt_app_mi_contact = this.z.getPtInfoRSCnt("4", "A_Contact");
        this.or_cnt = (this.z.getRenPtInfoRSCnt("2", "Valid") + this.z.getRenPtInfoRSCnt("3", "Approved")) + this.z.getRenPtInfoRSCnt("2", "Refused");
    }

}

