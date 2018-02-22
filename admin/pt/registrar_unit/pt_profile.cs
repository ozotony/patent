using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class  admin_pt_registrar_unit_pt_profile : Page
{
    public string adminID = "";
    public long lt_mi = 0L;
    public long lt_mi_c = 0L;
    public long lt_mi_contact = 0L;
    public zues z = new zues();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["adminx"] != null)
        {
            String vvv = Request.Form["adminx"];

            Session["pwalletID"] = vvv;

        }
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
        else
        {
            Response.Redirect("../lo.aspx");
        }
        lt_mi = z.getPtInfoRSCnt("5", "Patentable");
        lt_mi_c = z.getPtInfoRSCnt("6", "Grant Patent");
        lt_mi_contact = z.getPtInfoRSCnt("5", "R_Contact");
    }

}

