using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class admin_pt_verification_unit_profile : Page
{
    public string adminID = "";
    public long lt_mi = 0L;
    public long lt_mi_contact = 0L;
    public long lt_mi_r = 0L;
    public int or_cnt = 0;
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
        lt_mi = z.getPtInfoRSCnt("1", "Fresh");
        lt_mi_r = z.getPtInfoRSCnt("1", "Invalid");
        lt_mi_contact = z.getPtInfoRSCnt("1", "V_Contact");
        or_cnt = z.getRenPtInfoRSCnt("1", "Fresh") + z.getRenPtInfoRSCnt("1", "Invalid");
    }

   
}

