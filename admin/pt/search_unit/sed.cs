﻿using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public  partial class admin_pt_search_unit_sed : Page
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
        this.Session["f"] = "";
        this.Session["t"] = "";
        base.Response.Redirect("./sed.aspx");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        this.Session["f"] = "";
        this.Session["t"] = "";
        this.Session["f"] = this.selectFromYear.SelectedValue + "-" + this.selectFromMonth.SelectedValue + "-" + this.selectFromDay.SelectedValue;
        this.Session["t"] = this.selectToYear.SelectedValue + "-" + this.selectToMonth.SelectedValue + "-" + this.selectToDay.SelectedValue;
        base.Response.Redirect("./sed.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["f"] != null)
        {
            this.fromdate = this.Session["f"].ToString();
        }
        if (this.Session["t"] != null)
        {
            this.todate = this.Session["t"].ToString();
        }
        if (this.Session["pwalletID"] != null)
        {
            if (this.Session["pwalletID"].ToString() != "")
            {
                this.adminID = this.Session["pwalletID"].ToString();
            }
            else
            {
                base.Response.Redirect("../lo.aspx");
            }
        }
        else
        {
            base.Response.Redirect("../lo.aspx");
        }
        if ((this.fromdate != "") && (this.todate != ""))
        {
            this.g_total = this.z.getTotalEntriesByDate("", this.fromdate, this.todate);
            this.g_utotal = this.z.getTotalEntriesByDate("2", this.fromdate, this.todate);
            this.g_new = this.z.getTotalEntryCountStageByDate("2", "Valid", this.fromdate, this.todate);
            this.g_treated = this.z.getTotalEntryCountStageByDate("2", "", this.fromdate, this.todate);
            this.g_rejected = this.z.getTotalEntryCountByStage("2", "Not-registrable");
        }
        else
        {
            this.g_total = this.z.getTotalEntries("");
            this.g_utotal = this.z.getTotalEntries("2");
            this.g_new = this.z.getTotalEntryCountByStage("2", "Valid");
            this.g_treated = this.z.getTotalEntryCountByStage("2", "");
            this.g_rejected = this.z.getTotalEntryCountByStage("2", "Not-registrable");
        }
        for (int i = 0x7d0; i <= 0x7e4; i++)
        {
            this.selectFromYear.Items.Add(i.ToString());
            this.selectToYear.Items.Add(i.ToString());
        }
        for (int j = 1; j <= 12; j++)
        {
            this.selectFromMonth.Items.Add(string.Format("{0:d2}", j));
            this.selectToMonth.Items.Add(string.Format("{0:d2}", j));
        }
        for (int k = 1; k <= 0x1f; k++)
        {
            this.selectFromDay.Items.Add(string.Format("{0:d2}", k));
            this.selectToDay.Items.Add(string.Format("{0:d2}", k));
        }
    }

   
}

