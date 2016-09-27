using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class admin_pt_x_unit_profile : Page
{
    public string adminID = "";

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
        else
        {
            Response.Redirect("../lo.aspx");
        }
    }

   
}

