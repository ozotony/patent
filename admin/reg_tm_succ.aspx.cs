using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_reg_tm_succ : System.Web.UI.Page
{

    protected void btn_menu_Click(object sender, EventArgs e)
    {
        Response.Redirect("./pt/x_unit/profile.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
}