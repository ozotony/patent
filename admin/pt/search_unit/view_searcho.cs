﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class admin_pt_search_unit_view_searcho : Page
{
    public string admin = "";
    public int export;
    public List<string> fulltext = new List<string>();
    public int kword_cnt;
    public string lga_id = "";
    public string log_officer = "";
    public List<List<pt.PtInfo>> lt_lt_mi = new List<List<pt.PtInfo>>();
    public List<pt.PtInfo> lt_mi = new List<pt.PtInfo>();
    public List<string> lt_searchcri = new List<string>();
    public List<int> lt_tot = new List<int>();
    public string markID;
    public List<string> new_search_text = new List<string>();
    public StringBuilder sbFulltext = new StringBuilder();
    public string searchcri = "";
    public string searchstr = "";
    public pt.SWallet swallet = new pt.SWallet();
    public pt t = new pt();
    public int totsearch;
    public string xresults = "";

    protected void btnPrevBack_Click(object sender, EventArgs e)
    {
        base.Response.Redirect(this.ViewState["PreviousPage"].ToString());
    }

    public string calcPercentile(decimal tot, decimal val)
    {
        decimal num = 0M;
        num = (val / tot) * 100M;
        return num.ToString("#.##");
    }

    public string convertMarkList2Html(List<pt.PtInfo> xm, string xquery, int tot, int val, string final)
    {
        string str = "";
        str = str + "<tr ><td class=\"\" align=\"center\" colspan=\"8\">";
        if (final != "100")
        {
            object obj2 = str;
            str = string.Concat(new object[] { obj2, "<strong>", xm.Count, "</strong> RECORDS FOUND FOR SEARCH QUERY <strong>\"", xquery.ToUpper(), " \" </strong>=><em> PERCENTILE=<strong>", this.calcPercentile(tot, val), "</strong></em>%</td>" });
        }
        else
        {
            object obj3 = str;
            str = string.Concat(new object[] { obj3, "<strong>", xm.Count, "</strong> RECORDS FOUND FOR SEARCH QUERY <strong>\"", xquery.ToUpper(), " \" </strong> </td>" });
        }
        str = str + "</tr><tr><td width=\"5%\" class=\"tdcolheader\">S/N</td><td width=\"20%\" class=\"tdcolheader\">REGISTRATION NUMBER </td> <td width=\"30%\" class=\"tdcolheader\"> PRODUCT TITLE </td><td width=\"20%\" class=\"tdcolheader\">PT TYPE</td><td width=\"10%\" class=\"tdcolheader\">FILING DATE</td><td width=\"10%\" class=\"tdcolheader\" colspan=\"2\"> &nbsp;</td></tr><tr><td class=\"\" align=\"center\" colspan=\"7\"><table class=\"xtreme\" width=\"100%\">";
        int num = 1;
        for (int i = 0; i < xm.Count; i++)
        {
            object obj4 = str + "<tr>";
            str = ((string.Concat(new object[] { obj4, "<td width=\"5%\" align=\"center\" class=\"xstyle\">", num, "</td>" }) + "<td width=\"20%\" align=\"center\" class=\"xstyle\">" + xm[i].reg_number.ToString() + "</td><td width=\"30%\" align=\"center\" class=\"xstyle\">" + xm[i].title_of_invention.ToString() + "</td><td width=\"20%\" align=\"center\" class=\"xstyle\">" + xm[i].xtype + "</td><td width=\"10%\" align=\"center\" class=\"xstyle\">" + xm[i].reg_date.ToString() + " </td> <td width=\"10%\" align=\"center\" class=\"xstyle\">") + "<a href=view_search_details.aspx?x=" + xm[i].xID + " target=\"_blank\">View</a>") + "</td></tr>";
            num++;
        }
        return (str + "</table></td></tr>");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.ViewState["PreviousPage"] = base.Request.UrlReferrer;
        }
        if (this.Session["pwalletID"] != null)
        {
            if (this.Session["pwalletID"].ToString() != "")
            {
                this.admin = this.Session["pwalletID"].ToString();
            }
            else
            {
                base.Response.Redirect("./xcontrol.aspx");
            }
        }
        else
        {
            base.Response.Redirect("./xcontrol.aspx");
        }
        if (base.Request.QueryString["x"] != null)
        {
            this.xmarkID.Value = base.Request.QueryString["x"].ToString();
            this.xlof_officer.Value = this.admin;
        }
        this.swallet = this.t.getSwalletByID(this.xmarkID.Value);
        if (this.swallet.mark_infoID != null)
        {
            string item = this.swallet.search_str.Replace("'", "");
            string xclass = this.swallet.xclass;
            foreach (string str3 in item.Split(new char[] { ' ' }))
            {
                if (str3 != "")
                {
                    List<pt.PtInfo> list = new List<pt.PtInfo>();
                    int count = 0;
                    list = this.t.getSearchPtInfoRS(str3, null, xclass);
                    if (list.Count > 0)
                    {
                        for (int k = 0; k < list.Count; k++)
                        {
                            if (!this.lt_searchcri.Contains(list[k].xID))
                            {
                                this.lt_searchcri.Add(list[k].xID);
                            }
                        }
                        this.fulltext.Add(str3);
                        count = list.Count;
                        this.lt_tot.Add(count);
                        this.lt_lt_mi.Add(list);
                    }
                }
            }
            foreach (string str4 in this.fulltext)
            {
                string str5 = str4 + " ";
                this.new_search_text.Add(str5);
                this.sbFulltext.Append(str5);
            }
            this.kword_cnt = this.fulltext.Count;
            if (this.new_search_text.Count > 0)
            {
                List<pt.PtInfo> list2 = new List<pt.PtInfo>();
                list2 = this.t.getSearchPtInfoRS("", this.new_search_text, xclass);
                if (list2.Count > 0)
                {
                    for (int m = 0; m < list2.Count; m++)
                    {
                        if (!this.lt_searchcri.Contains(list2[m].xID))
                        {
                            this.lt_searchcri.Add(list2[m].xID);
                        }
                    }
                    this.lt_tot.Add(list2.Count);
                    this.totsearch += this.lt_tot[this.lt_tot.Count - 1];
                    this.lt_lt_mi.Add(list2);
                }
            }
            this.fulltext.Add(item);
            this.searchstr = this.sbFulltext.ToString().Trim();
            for (int i = 0; i < this.lt_searchcri.Count; i++)
            {
                if (i != (this.lt_searchcri.Count - 1))
                {
                    this.searchcri = this.searchcri + this.lt_searchcri[i] + ",";
                }
                else
                {
                    this.searchcri = this.searchcri + this.lt_searchcri[i];
                }
            }
            this.xsearchcri.Value = this.searchcri;
            this.xsearchstr.Value = this.searchstr;
            string final = "";
            for (int j = 0; j < this.lt_lt_mi.Count; j++)
            {
                if (j != (this.lt_lt_mi.Count - 1))
                {
                    this.xresults = this.xresults + this.convertMarkList2Html(this.lt_lt_mi[j], this.fulltext[j], this.totsearch, this.lt_tot[j], "");
                }
                else
                {
                    final = "100";
                    this.xresults = this.xresults + this.convertMarkList2Html(this.lt_lt_mi[j], this.fulltext[j], this.totsearch, this.lt_tot[j], final);
                }
            }
            if (this.xresults == "")
            {
                this.xresults = this.xresults + "<tr >";
                this.xresults = this.xresults + "<td class=\"\" align=\"center\" colspan=\"7\">";
                this.xresults = this.xresults + "<strong>NO</strong> RECORD WAS FOUND FOR SEARCH QUERY <strong>\"" + item.ToUpper() + " \" </strong> </td>";
                this.xresults = this.xresults + "</td>";
                this.xresults = this.xresults + "</tr>";
            }
        }
    }

}

