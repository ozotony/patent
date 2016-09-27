using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ren_temp : Page
{
    public string xconfirm = "0";
    public string xvalue = "";

    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        xconfirm = "1";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

  
}

