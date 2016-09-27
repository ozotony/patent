using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class  admin_pt_acceptance_unit_n_renewal : Page
{
    public string admin = "";
    public string criteria = "";
    public string criteria_type = "";
    public string data_status = "Valid";
    public string dateFrom = "";
    public string dateFromArr = "";
    public string dateTo = "";
    public string dateToArr = "";
    public string item_code = "P003";
    public List<zues.Renewal> lt_mi = new List<zues.Renewal>();
    public int max;
    public List<string> pages = new List<string>();
    public string stage = "2";
    public long x_cnt = 0L;
    public zues z = new zues();

    protected void btnReloadPage_Click(object sender, EventArgs e)
    {
        lt_mi = z.getRenPtInfoRSX(stage, data_status, item_code, 0, max);
        Session["x_cnt"] = x_cnt = lt_mi.Count;
        Session["lt_mi"] = lt_mi;
        gvX.DataSource = lt_mi;
        gvX.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        List<string> source = new List<string>();
        string str = kword.Value.Replace("'", "");
        dateFrom = z.formatSearchDate(datepickerFrom.Value);
        dateTo = z.formatSearchDate(datepickerTo.Value);
        if ((dateTo == "") || (dateTo == null))
        {
            dateTo = DateTime.Today.Date.ToString("yyyy-MM-dd");
        }
        foreach (string str2 in str.Split(new char[] { ' ' }))
        {
            if (str2 != "")
            {
                source.Add(str2);
            }
        }
        if (selectSearchCriteria.SelectedValue == "product_title")
        {
            if (lt_mi.Count<zues.Renewal>() > 0)
            {
                criteria = string.Concat(new object[] { lt_mi.Count<zues.Renewal>(), " result(s) found for search criteria (", kword.Value, ")!!" });
            }
            else
            {
                criteria = "No result found for search criteria (" + kword.Value + ")!!";
            }
        }
        else if (source.Count<string>() == 1)
        {
            if (lt_mi.Count<zues.Renewal>() <= 0)
            {
                criteria = "No result found for search criteria (" + kword.Value + ")!!";
            }
        }
        else
        {
            criteria = "The Application number cannot be more one (1) !!";
        }
    }

    protected void gvX_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvX.PageIndex = e.NewPageIndex;
        if (Session["lt_mi"] != null)
        {
            lt_mi.Clear();
            lt_mi = (List<zues.Renewal>) Session["lt_mi"];
        }
        gvX.DataSource = lt_mi;
        gvX.DataBind();
        if (Session["x_cnt"] != null)
        {
            x_cnt = Convert.ToInt32(Session["x_cnt"]);
        }
    }

    protected void gvX_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "TmViewClick")
        {
            GridViewRow namingContainer = (GridViewRow) ((ImageButton) e.CommandSource).NamingContainer;
            int rowIndex = namingContainer.RowIndex;
            string str = e.CommandArgument.ToString();
            Response.Redirect("n_renewal_details.aspx?x=" + str);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        max = Convert.ToInt32(ConfigurationManager.AppSettings["a_ren_unit_limit"]);
        if (!IsPostBack)
        {
            gvX.PageSize = 100;
            Session["lt_m"] = null;
            Session["x_cnt"] = null;
            lt_mi = z.getRenPtInfoRSX(stage, data_status, item_code, 0, max);
            Session["x_cnt"] = x_cnt = lt_mi.Count;
            Session["lt_mi"] = lt_mi;
            gvX.DataSource = lt_mi;
            gvX.DataBind();
        }
        else if (Session["x_cnt"] != null)
        {
            x_cnt = Convert.ToInt32(Session["x_cnt"]);
        }
    }

}

