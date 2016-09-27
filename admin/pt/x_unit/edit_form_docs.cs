using Brettle.Web.NeatUpload;
using Ipo;
using log4net;
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class admin_pt_x_unit_edit_form_docs : Page
{
    public string ack_status = "0";
    public string claim_doc = "";
    public string claim_newfilename = "0";
    public string doa_doc = "";
    public string doa_newfilename = "0";
    public string doc_path = "";
    public GatewayService ipo_gateway = new GatewayService();
    public string loa_doc = "";
    public string loa_newfilename = "0";
    public string pc = "";
    public string pct_doc = "";
    public string pct_newfilename = "0";
    public string spec_doc = "";
    public string spec_newfilename = "0";
    public string status = "0";
    public pt t = new pt();
    public string vid = "0";

    protected void btnDashBoard_Click(object sender, EventArgs e)
    {
        Response.Redirect("./profile.aspx");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["pc"] != null)
        {
            pc = Session["pc"].ToString();
        }
        if (Session["loa_doc"] != null)
        {
            loa_doc = Session["loa_doc"].ToString();
        }
        if (Session["claim_doc"] != null)
        {
            claim_doc = Session["claim_doc"].ToString();
        }
        if (Session["pct_doc"] != null)
        {
            pct_doc = Session["pct_doc"].ToString();
        }
        if (Session["doa_doc"] != null)
        {
            doa_doc = Session["doa_doc"].ToString();
        }
        if (Session["spec_doc"] != null)
        {
            spec_doc = Session["spec_doc"].ToString();
        }
        if (Session["loa_doc_no"] != null)
        {
            txt_loa_no.Text = Session["loa_doc_no"].ToString();
        }
        else
        {
            txt_loa_no.Text = "1";
        }
        if (Session["claim_doc_no"] != null)
        {
            txt_claim_no.Text = Session["claim_doc_no"].ToString();
        }
        else
        {
            txt_claim_no.Text = "1";
        }
        if (Session["pct_doc_no"] != null)
        {
            txt_pct_no.Text = Session["pct_doc_no"].ToString();
        }
        else
        {
            txt_pct_no.Text = "1";
        }
        if (Session["doa_doc_no"] != null)
        {
            txt_doa_no.Text = Session["doa_doc_no"].ToString();
        }
        else
        {
            txt_doa_no.Text = "1";
        }
        if (Session["vid"] != null)
        {
            vid = Session["vid"].ToString();
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
    }

    private void upload_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (Session["mix_updateID"] != null)
            {
                doc_path = Server.MapPath("~/") + "admin/pt/docz/" + Session["mix_updateID"].ToString() + "/";
                if (!Directory.Exists(doc_path))
                {
                    Directory.CreateDirectory(doc_path);
                }
                if (IsValid && fu_loa_doc.HasFile)
                {
                    loa_newfilename = Path.Combine(doc_path, fu_loa_doc.FileName.Replace(" ", "_"));
                    fu_loa_doc.MoveTo(Path.Combine(doc_path, fu_loa_doc.FileName.Replace(" ", "_")), MoveToOptions.Overwrite);
                    loa_newfilename = loa_newfilename.Replace(Server.MapPath("~/") + "admin/pt/", "");
                    Session["loa_newfilename"] = loa_newfilename;
                    t.updateLoaDocz(loa_newfilename, txt_loa_no.Text, Session["mix_updateID"].ToString());
                    Session["txt_loa_no"] = txt_loa_no.Text;
                }
                if (IsValid && fu_claim_doc.HasFile)
                {
                    claim_newfilename = Path.Combine(doc_path, fu_claim_doc.FileName.Replace(" ", "_"));
                    fu_claim_doc.MoveTo(claim_newfilename, MoveToOptions.Overwrite);
                    claim_newfilename = claim_newfilename.Replace(Server.MapPath("~/") + "admin/pt/", "");
                    Session["claim_newfilename"] = claim_newfilename;
                    t.updateClaimDocz(claim_newfilename, txt_claim_no.Text, Session["mix_updateID"].ToString());
                    Session["txt_claim_no"] = txt_claim_no.Text;
                }
                if (IsValid && fu_pct_doc.HasFile)
                {
                    pct_newfilename = Path.Combine(doc_path, fu_pct_doc.FileName.Replace(" ", "_"));
                    fu_pct_doc.MoveTo(pct_newfilename, MoveToOptions.Overwrite);
                    pct_newfilename = pct_newfilename.Replace(Server.MapPath("~/") + "admin/pt/", "");
                    Session["pct_newfilename"] = pct_newfilename;
                    t.updatePctDocz(pct_newfilename, txt_pct_no.Text, Session["mix_updateID"].ToString());
                    Session["txt_pct_no"] = txt_pct_no.Text;
                }
                if (IsValid && fu_doa_doc.HasFile)
                {
                    doa_newfilename = Path.Combine(doc_path, fu_doa_doc.FileName.Replace(" ", "_"));
                    fu_doa_doc.MoveTo(doa_newfilename, MoveToOptions.Overwrite);
                    doa_newfilename = doa_newfilename.Replace(Server.MapPath("~/") + "admin/pt/", "");
                    Session["doa_newfilename"] = doa_newfilename;
                    t.updateDoaDocz(doa_newfilename, txt_doa_no.Text, Session["mix_updateID"].ToString());
                    Session["txt_doa_no"] = txt_doa_no.Text;
                }
                if (IsValid && fu_spec_doc.HasFile)
                {
                    spec_newfilename = Path.Combine(doc_path, fu_spec_doc.FileName.Replace(" ", "_"));
                    fu_spec_doc.MoveTo(spec_newfilename, MoveToOptions.Overwrite);
                    spec_newfilename = spec_newfilename.Replace(Server.MapPath("~/") + "admin/pt/", "");
                    Session["spec_newfilename"] = spec_newfilename;
                    t.updateSpecDocz(spec_newfilename, Session["mix_updateID"].ToString());
                }
                string transactionID = "";
                string gateway = "";
                if (Session["vid"] != null)
                {
                    transactionID = Session["vid"].ToString();
                }
                if (Session["gt"] != null)
                {
                    gateway = Session["gt"].ToString();
                }
                try
                {
                    status = ipo_gateway.UpdateTransaction(transactionID, gateway, "1");
                }
                catch (Exception)
                {
                    if (pc == "P001")
                    {
                        if ((((loa_newfilename != "0") && (claim_newfilename != "0")) && ((pct_newfilename != "0") && (doa_newfilename != "0"))) && (spec_newfilename != "0"))
                        {
                            ack_status = "1";
                        }
                    }
                    else if (((loa_newfilename != "0") && (claim_newfilename != "0")) && (spec_newfilename != "0"))
                    {
                        ack_status = "1";
                    }
                }
                if (pc == "P001")
                {
                    if ((((loa_newfilename != "0") && (claim_newfilename != "0")) && ((pct_newfilename != "0") && (doa_newfilename != "0"))) && (spec_newfilename != "0"))
                    {
                        ack_status = "1";
                    }
                }
                else if (((loa_newfilename != "0") && (claim_newfilename != "0")) && (spec_newfilename != "0"))
                {
                    ack_status = "1";
                }
            }
        }
        catch (Exception exception2)
        {
            
        }
    }

    
}

