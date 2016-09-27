using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ved : Page
{
    public string adminID = "";
    public string fromdate = "";
    public string g_new = "0";
    public string g_rejected = "0";
    public string g_total = "0";
    public string g_treated = "0";
    public string g_utotal = "0";
    public string todate = "";
    public zues z = new zues();

    protected void btnAll_Click(object sender, EventArgs e)
    {
        Session["f"] = "";
        Session["t"] = "";
        Response.Redirect("./ved.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Session["f"] = "";
        Session["t"] = "";
        Session["f"] = selectFromYear.SelectedValue + "-" + selectFromMonth.SelectedValue + "-" + selectFromDay.SelectedValue;
        Session["t"] = selectToYear.SelectedValue + "-" + selectToMonth.SelectedValue + "-" + selectToDay.SelectedValue;
        Response.Redirect("./ved.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["f"] != null)
        {
            fromdate = Session["f"].ToString();
        }
        if (Session["t"] != null)
        {
            todate = Session["t"].ToString();
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
        if ((fromdate != "") && (todate != ""))
        {
            g_total = z.getTotalEntriesByDate("", fromdate, todate);
            g_utotal = z.getTotalEntriesByDate("1", fromdate, todate);
            g_new = z.getTotalEntryCountStageByDate("1", "Fresh", fromdate, todate);
            g_treated = z.getTotalEntryCountStageByDate("1", "", fromdate, todate);
            g_rejected = z.getTotalEntryCountByStage("1", "Invalid");
        }
        else
        {
            g_total = z.getTotalEntries("");
            g_utotal = z.getTotalEntries("1");
            g_new = z.getTotalEntryCountByStage("1", "Fresh");
            g_treated = z.getTotalEntryCountByStage("1", "");
            g_rejected = z.getTotalEntryCountByStage("1", "Invalid");
        }
        for (int i = 0x7d0; i <= 0x7e4; i++)
        {
            selectFromYear.Items.Add(i.ToString());
            selectToYear.Items.Add(i.ToString());
        }
        for (int j = 1; j <= 12; j++)
        {
            selectFromMonth.Items.Add(string.Format("{0:d2}", j));
            selectToMonth.Items.Add(string.Format("{0:d2}", j));
        }
        for (int k = 1; k <= 0x1f; k++)
        {
            selectFromDay.Items.Add(string.Format("{0:d2}", k));
            selectToDay.Items.Add(string.Format("{0:d2}", k));
        }
    }

 
}

