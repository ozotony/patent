using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_pt_search_unit_app_renewal2 : System.Web.UI.Page
{
    public string admin = "";
    public string criteria = "";
    public string criteria_type = "";
    public string data_status = "Approved";
    public string dateFrom = "";
    public string dateFromArr = "";
    public string dateTo = "";
    public string dateToArr = "";
    public string item_code = "P003";
    public List<zues.Renewal> lt_mi = new List<zues.Renewal>();
    public int max;
    public List<string> pages = new List<string>();
    public string stage = "3";
    public long x_cnt = 0L;
    public zues z = new zues();

    protected void btnReloadPage_Click(object sender, EventArgs e)
    {
        //this.lt_mi = this.z.getRenPtInfoRSX(this.stage, this.data_status, this.item_code, 0, this.max);
        //this.Session["x_cnt"] = this.x_cnt = this.lt_mi.Count;
        //this.Session["lt_mi"] = this.lt_mi;
        //this.gvX.DataSource = this.lt_mi;
        //this.gvX.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //List<string> source = new List<string>();
        //string str = this.kword.Value.Replace("'", "");
        //this.dateFrom = this.z.formatSearchDate(this.datepickerFrom.Value);
        //this.dateTo = this.z.formatSearchDate(this.datepickerTo.Value);
        //if ((this.dateTo == "") || (this.dateTo == null))
        //{
        //    this.dateTo = DateTime.Today.Date.ToString("yyyy-MM-dd");
        //}
        //foreach (string str2 in str.Split(new char[] { ' ' }))
        //{
        //    if (str2 != "")
        //    {
        //        source.Add(str2);
        //    }
        //}
        //if (this.selectSearchCriteria.SelectedValue == "product_title")
        //{
        //    if (this.lt_mi.Count<zues.Renewal>() > 0)
        //    {
        //        this.criteria = string.Concat(new object[] { this.lt_mi.Count<zues.Renewal>(), " result(s) found for search criteria (", this.kword.Value, ")!!" });
        //    }
        //    else
        //    {
        //        this.criteria = "No result found for search criteria (" + this.kword.Value + ")!!";
        //    }
        //}
        //else if (source.Count<string>() == 1)
        //{
        //    if (this.lt_mi.Count<zues.Renewal>() <= 0)
        //    {
        //        this.criteria = "No result found for search criteria (" + this.kword.Value + ")!!";
        //    }
        //}
        //else
        //{
        //    this.criteria = "The Application number cannot be more one (1) !!";
        //}
    }

    protected void gvX_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //this.gvX.PageIndex = e.NewPageIndex;
        //if (this.Session["lt_mi"] != null)
        //{
        //    this.lt_mi.Clear();
        //    this.lt_mi = (List<zues.Renewal>)this.Session["lt_mi"];
        //}
        //this.gvX.DataSource = this.lt_mi;
        //this.gvX.DataBind();
        //if (this.Session["x_cnt"] != null)
        //{
        //    this.x_cnt = Convert.ToInt32(this.Session["x_cnt"]);
        //}
    }

    protected void gvX_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "TmViewClick")
        //{
        //    GridViewRow namingContainer = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
        //    int rowIndex = namingContainer.RowIndex;
        //    string str = e.CommandArgument.ToString();
        //    base.Response.Redirect("app_renewal_details.aspx?x=" + str);
        //}
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //this.max = Convert.ToInt32(ConfigurationManager.AppSettings["a_ren_unit_limit"]);
        //if (!base.IsPostBack)
        //{
        //    this.gvX.PageSize = 100;
        //    this.Session["lt_m"] = null;
        //    this.Session["x_cnt"] = null;
        //    this.lt_mi = this.z.getRenPtInfoRSX(this.stage, this.data_status, this.item_code, 0, this.max);
        //    this.Session["x_cnt"] = this.x_cnt = this.lt_mi.Count;
        //    this.Session["lt_mi"] = this.lt_mi;
        //    this.gvX.DataSource = this.lt_mi;
        //    this.gvX.DataBind();
        //}
        //else if (this.Session["x_cnt"] != null)
        //{
        //    this.x_cnt = Convert.ToInt32(this.Session["x_cnt"]);
        //}
    }
}