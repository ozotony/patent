using Brettle.Web.NeatUpload;
using Ipo;
using log4net;
using System;
using System.IO;
using System.Web;


using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class application_docs : Page
{
    public string ack_status = "0";
    public string claim_newfilename = "0";
    public string doa_newfilename = "0";
    public string doc_path = "";
    public GatewayService ipo_gateway = new GatewayService();
    public string loa_newfilename = "0";
    public string pc = "0";
    public string pct_newfilename = "0";
    public string serverpath;
    public string spec_newfilename = "0";
    public string status = "0";
    public pt t = new pt();

    protected void btn_ack_Click(object sender, EventArgs e)
    {
        if (Session["vid"] != null)
        {
            Response.Redirect("./tm_acknowledgement.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=" + Session["vid"].ToString());
        }
        else
        {
            Response.Redirect("./appstatus.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["pc"] != null)
        {
            pc = Session["pc"].ToString();
        }
        if (Session["loa_newfilename"] != null)
        {
            loa_newfilename = Session["loa_newfilename"].ToString();
        }
        if (Session["claim_newfilename"] != null)
        {
            claim_newfilename = Session["claim_newfilename"].ToString();
        }
        if (Session["pct_newfilename"] != null)
        {
            pct_newfilename = Session["pct_newfilename"].ToString();
        }
        if (Session["doa_newfilename"] != null)
        {
            doa_newfilename = Session["doa_newfilename"].ToString();
        }
        if (Session["spec_newfilename"] != null)
        {
            spec_newfilename = Session["spec_newfilename"].ToString();
        }
        btn_all_doc.Click += new EventHandler(upload_Clicked);
        serverpath = Server.MapPath("~/");
        if (!Page.IsPostBack)
        {
            txt_loa_no.Text = "1";
            txt_claim_no.Text = "1";
            txt_pct_no.Text = "1";
            txt_doa_no.Text = "1";
        }
    }

    private void upload_Clicked(object sender, EventArgs e)
    {
        try
        {
           
            if (Session["new_ptID"] != null)
            {
                string str;
                string str2;
                doc_path = Server.MapPath("~/") + "admin/pt/docz/" + Session["new_ptID"].ToString() + "/";
                if (!Directory.Exists(doc_path))
                {
                    Directory.CreateDirectory(doc_path);
                }
                if (IsValid && fu_loa_doc.HasFile)
                {
                    loa_newfilename = Path.Combine(doc_path, fu_loa_doc.FileName.Replace(" ", "_"));
                    fu_loa_doc.MoveTo(Path.Combine(doc_path, fu_loa_doc.FileName.Replace(" ", "_")), MoveToOptions.Overwrite);
                    Session["txt_loa_no"] = txt_loa_no.Text;
                }
                if (IsValid && fu_claim_doc.HasFile)
                {
                    claim_newfilename = Path.Combine(doc_path, fu_claim_doc.FileName.Replace(" ", "_"));
                    fu_claim_doc.MoveTo(claim_newfilename, MoveToOptions.Overwrite);
                    Session["txt_claim_no"] = txt_claim_no.Text;
                }
                if (IsValid && fu_pct_doc.HasFile)
                {
                    pct_newfilename = Path.Combine(doc_path, fu_pct_doc.FileName.Replace(" ", "_"));
                    fu_pct_doc.MoveTo(pct_newfilename, MoveToOptions.Overwrite);
                    Session["txt_pct_no"] = txt_pct_no.Text;
                }
                if (IsValid && fu_doa_doc.HasFile)
                {
                    doa_newfilename = Path.Combine(doc_path, fu_doa_doc.FileName.Replace(" ", "_"));
                    fu_doa_doc.MoveTo(doa_newfilename, MoveToOptions.Overwrite);
                    Session["txt_doa_no"] = txt_doa_no.Text;
                }
                if (IsValid && fu_spec_doc.HasFile)
                {
                    spec_newfilename = Path.Combine(doc_path, fu_spec_doc.FileName.Replace(" ", "_"));
                    fu_spec_doc.MoveTo(spec_newfilename, MoveToOptions.Overwrite);
                }
                loa_newfilename = loa_newfilename.Replace(Server.MapPath("~/") + "admin/pt/", "");
                claim_newfilename = claim_newfilename.Replace(Server.MapPath("~/") + "admin/pt/", "");
                pct_newfilename = pct_newfilename.Replace(Server.MapPath("~/") + "admin/pt/", "");
                doa_newfilename = doa_newfilename.Replace(Server.MapPath("~/") + "admin/pt/", "");
                spec_newfilename = spec_newfilename.Replace(Server.MapPath("~/") + "admin/pt/", "");
                Session["loa_newfilename"] = loa_newfilename;
                Session["claim_newfilename"] = claim_newfilename;
                Session["pct_newfilename"] = pct_newfilename;
                Session["doa_newfilename"] = doa_newfilename;
                Session["spec_newfilename"] = spec_newfilename;
                if (pc == "P001")
                {
                    if ((((loa_newfilename != "0") && (claim_newfilename != "0")) && ((pct_newfilename != "0") && (doa_newfilename != "0"))) && (spec_newfilename != "0"))
                    {
                        if (Session["txt_loa_no"] != null)
                        {
                            txt_loa_no.Text = Session["txt_loa_no"].ToString();
                        }
                        if (Session["txt_claim_no"] != null)
                        {
                            txt_claim_no.Text = Session["txt_claim_no"].ToString();
                        }
                        if (Session["txt_pct_no"] != null)
                        {
                            txt_pct_no.Text = Session["txt_pct_no"].ToString();
                        }
                        if (Session["txt_doa_no"] != null)
                        {
                            txt_doa_no.Text = Session["txt_doa_no"].ToString();
                        }
                        if (t.updatePtDocz(spec_newfilename, loa_newfilename, txt_loa_no.Text, claim_newfilename, txt_claim_no.Text, pct_newfilename, txt_pct_no.Text, doa_newfilename, txt_doa_no.Text, Session["new_ptID"].ToString()) != "0")
                        {
                            str = "";
                            str2 = "";
                            if (Session["vid"] != null)
                            {
                                str = Session["vid"].ToString();
                            }
                            if (Session["gt"] != null)
                            {
                                str2 = Session["gt"].ToString();
                            }
                            status = ipo_gateway.UpdateTransaction(str, str2, "1");
                            if (status == "1")
                            {
                                ack_status = "1";
                            }
                        }
                    }
                }
                else if (((loa_newfilename != "0") && (claim_newfilename != "0")) && (spec_newfilename != "0"))
                {
                    if (Session["txt_loa_no"] != null)
                    {
                        txt_loa_no.Text = Session["txt_loa_no"].ToString();
                    }
                    if (Session["txt_claim_no"] != null)
                    {
                        txt_claim_no.Text = Session["txt_claim_no"].ToString();
                    }
                    if (Session["txt_pct_no"] != null)
                    {
                        txt_pct_no.Text = Session["txt_pct_no"].ToString();
                    }
                    if (Session["txt_doa_no"] != null)
                    {
                        txt_doa_no.Text = Session["txt_doa_no"].ToString();
                    }
                    if (t.updatePtDocz(spec_newfilename, loa_newfilename, txt_loa_no.Text, claim_newfilename, txt_claim_no.Text, pct_newfilename, txt_pct_no.Text, doa_newfilename, txt_doa_no.Text, Session["new_ptID"].ToString()) != "0")
                    {
                        str = "";
                        str2 = "";
                        if (Session["vid"] != null)
                        {
                            str = Session["vid"].ToString();
                        }
                        if (Session["gt"] != null)
                        {
                            str2 = Session["gt"].ToString();
                        }
                        status = ipo_gateway.UpdateTransaction(str, str2, "1");
                        status = "1";
                        if (status == "1")
                        {
                            ack_status = "1";
                        }
                    }
                }
            }
        }
        catch (Exception exception)
        {
            
        }
    }

  
}

