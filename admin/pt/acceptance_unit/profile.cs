using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class  admin_pt_acceptance_unit_profile : Page
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
        lt_mi = z.getPtInfoRSCnt("4", "Futher Review");
        lt_mi_r = z.getPtInfoRSCnt("5", "Review Patent");
        lt_mi_contact = z.getPtInfoRSCnt("4", "A_Contact");
        or_cnt = (z.getRenPtInfoRSCnt("2", "Valid") + z.getRenPtInfoRSCnt("3", "Approved")) + z.getRenPtInfoRSCnt("2", "Refused");
    }

}

