using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class admin_pt_verification_unit_v_contact : Page
{
    public string admin = "";
    public int back;
    public string criteria = "";
    public string criteria_type = "";
    public string dateFrom = "";
    public string dateFromArr = "";
    public string dateTo = "";
    public string dateToArr = "";
    public long dis;
    public string enrolleeRS = "";
    public string enrolleeRS1 = "";
    public long eu;
    public int export;
    public string kw = "";
    public string lga_id = "";
    public long limit;
    public List<zues.PtInfo> lt_mi = new List<zues.PtInfo>();
    public long nume;
    public List<string> pages = new List<string>();
    public string r_sectorRS = "";
    public string row_enrolleeRS;
    public string select_search = "";
    public int selectLga;
    public string selectzone = "";
    public string sh = "";
    public int totsearch;
    public string touch;
    public string x_enrolleeRS;
    public string xRS = "";
    public zues z = new zues();

    protected void btnReloadPage_Click(object sender, EventArgs e)
    {
        //lt_mi = z.getPtInfoRSX("1", "V_Contact", dis.ToString(), limit.ToString());
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //List<string> fulltext = new List<string>();
        //string str = kword.Value.Replace("'", "");
        //dateFrom = z.formatSearchDate(datepickerFrom.Value);
        //dateTo = z.formatSearchDate(datepickerTo.Value);
        //if ((dateTo == "") || (dateTo == null))
        //{
        //    dateTo = DateTime.Today.Date.ToString("yyyy-MM-dd");
        //}
        //foreach (string str2 in str.Split(new char[] { ' ' }))
        //{
        //    if (str2 != "")
        //    {
        //        fulltext.Add(str2);
        //    }
        //}
        //if (selectSearchCriteria.SelectedValue == "product_title")
        //{
        //    lt_mi = z.getAdminSearchPtInfoRS("1", "V_Contact", selectSearchCriteria.SelectedValue, fulltext, dateFrom, dateTo);
        //    if (lt_mi.Count<zues.PtInfo>() > 0)
        //    {
        //        criteria = string.Concat(new object[] { lt_mi.Count<zues.PtInfo>(), " result(s) found for search criteria (", kword.Value, ")!!" });
        //    }
        //    else
        //    {
        //        criteria = "No result found for search criteria (" + kword.Value + ")!!";
        //    }
        //}
        //else if (fulltext.Count<string>() == 1)
        //{
        //    if (lt_mi.Count<zues.PtInfo>() > 0)
        //    {
        //        lt_mi = z.getAdminSearchPtInfoRS("1", "V_Contact", selectSearchCriteria.SelectedValue, fulltext, dateFrom, dateTo);
        //    }
        //    else
        //    {
        //        criteria = "No result found for search criteria (" + kword.Value + ")!!";
        //    }
        //}
        //else
        //{
        //    criteria = "The Application number cannot be more one (1) !!";
        //}
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["pwalletID"] != null)
        {
            if (Session["pwalletID"].ToString() != "")
            {
                admin = Session["pwalletID"].ToString();
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
        //limit = 50L;
        //nume = z.getPtInfoRSCnt("1", "V_Contact");
        //long num = nume / limit;
        //if ((num > 0L) && (nume > (num * limit)))
        //{
        //    num += 1L;
        //}
        //for (long i = 1L; i <= num; i += 1L)
        //{
        //    string item = string.Concat(new object[] { "<a href=\"#\" onclick=\"doPostResults('", i, "');\">", i, "</a>" });
        //    pages.Add(item);
        //}
        //if (Request.Params["eu"] != null)
        //{
        //    eu = Convert.ToInt64(Request.Params["eu"].ToString()) - 1L;
        //}
        //else
        //{
        //    eu = 0L;
        //}
        //dis = (eu * limit) + 1L;
        //limit = (eu * limit) + limit;
        //if (Session["pwalletID"] != null)
        //{
        //    if (Session["pwalletID"].ToString() != "")
        //    {
        //        admin = Session["pwalletID"].ToString();
        //    }
        //    else
        //    {
        //        Response.Redirect("../lo.aspx");
        //    }
        //}
        //else
        //{
        //    Response.Redirect("../lo.aspx");
        //}
        //lt_mi = z.getPtInfoRSX("1", "V_Contact", dis.ToString(), limit.ToString());
    }

   
}

