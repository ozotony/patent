using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class patent : Page
{
  
    public string abstract_doc_text = "";
    public string address_text = "";
    public string agentemail;
    public string agentpnumber;
    public string aid = "";
    public string amt = "";
    public string aos_address_text = "";
    public string aos_addressID = "1";
    public string aos_city_text = "";
    public string aos_email_text = "";
    public string aos_name_text = "";
    public string aos_state_row = "0";
    public string aos_state_text = "";
    public string aos_telephone_text = "";
    public string applicantname;
    public pt.AddressService c_aos = new pt.AddressService();
    public pt.Applicant c_app = new pt.Applicant();
    public pt.Address c_app_addy = new pt.Address();
    public pt.PtInfo c_pt = new pt.PtInfo();
    public pt.Representative c_rep = new pt.Representative();
    public pt.Address c_rep_addy = new pt.Address();
    public string city_text = "";
    public string claim_doc_text = "";
    public string cname;
    public string description_doc_text = "";
    public string drawing_doc_text = "";
    public string email_text = "";
    public string enable_AosConfirm = "0";
    public string enable_AosSave = "1";
    public string enable_AppConfirm = "0";
    public string enable_AppSave = "1";
    public string enable_MarkConfirm = "0";
    public string enable_PtSave = "1";
    public string enable_RepConfirm = "0";
    public string enable_RepSave = "1";
    public string enable_Save_Doc = "1";
    public string gt = "";
    public string log_staffID = "0";
    public List<pt.State> lt_aos_state;
    public List<pt.NClass> lt_nclass;
    public List<pt.State> lt_rep_state;
    public List<pt.State> lt_state;
    public string name_text = "";
    public int newState;
    public string pc = "";
    public string pt_infoID = "0";
    public string pwalletID = "0";
    public string rbInventors_text = "";
    public string rbOtherInventors_text = "";
    public string rbPriorityClaim_text = "";
    public string rep_address_text = "";
    public string rep_city_text = "";
    public string rep_code_text = "";
    public string rep_email_text = "";
    public string rep_name_text = "";
    public string rep_residence_text = "";
    public string rep_state_row = "0";
    public string rep_state_text = "";
    public string rep_state_visible = "0";
    public string rep_telephone_text = "";
    public string residence_text = "";
    public string serverpath;
    public string show_image_section = "0";
    public string show_imageMsg = "";
    public int showItems;
    public string state_row = "0";
    public string state_text = "";
    public string state_visible = "0";
    public string status = "";
    public pt t = new pt();
    public string telephone_text = "";
    public string title_of_invention_text = "";
    public string tm_type_text = "";
    public string transID = "";
    public string vid = "";
    public string xapplication = "";
    public string xcode_text = "";

    protected void ConfirmRepresentativeDetails_Click(object sender, EventArgs e)
    {
        if (Session["aid"] != null)
        {
            xaid.Value = Session["aid"].ToString();
        }
        if (Session["vid"] != null)
        {
            xvid.Value = Session["vid"].ToString();
        }
        if (Session["amt"] != null)
        {
            xamt.Value = Session["amt"].ToString();
        }
        if (Session["gt"] != null)
        {
            xgt.Value = Session["gt"].ToString();
        }
        if (Session["pc"] != null)
        {
            xpc.Value = Session["pc"].ToString();
        }
        if (Session["pwalletID"] != null)
        {
            xpwalletID.Value = Session["pwalletID"].ToString();
        }
        if (Session["agentemail"] != null)
        {
            xagentemail.Value = Session["agentemail"].ToString();
        }
        if (Session["cname"] != null)
        {
            xcname.Value = Session["cname"].ToString();
        }
        if (Session["agentpnumber"] != null)
        {
            xagentpnumber.Value = Session["agentpnumber"].ToString();
        }
        if (Session["applicantname"] != null)
        {
            xapplicantname.Value = Session["applicantname"].ToString();
        }
        if (Session["product_title"] != null)
        {
            xproduct_title.Value = Session["product_title"].ToString();
        }
        int num = 0;
        if (xemail.Text == "")
        {
            email_text = "1";
            num++;
        }
        if (xtelephone.Text == "")
        {
            telephone_text = "1";
            num++;
        }
        if ((state_visible == "0") && (xselectState.Text == ""))
        {
            state_text = "1";
            num++;
        }
        if (xcity.Text == "")
        {
            city_text = "1";
            num++;
        }
        if (xaddress.Text == "")
        {
            address_text = "1";
            num++;
        }
        if (title_of_invention.Text == "")
        {
            title_of_invention_text = "1";
            num++;
        }
        if (num != 0)
        {
            Response.Write("<script language=JavaScript>alert('Please fill in the marked fileds')</script>");
            show_image_section = "0";
        }
        else
        {
            enable_AppSave = "0";
            enable_AppConfirm = "1";
            enable_PtSave = "0";
            enable_MarkConfirm = "1";
            enable_Save_Doc = "0";
            enable_RepConfirm = "1";
            enable_RepSave = "0";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        serverpath = Server.MapPath("~/");
        if (Session["aid"] != null)
        {
            xaid.Value = Session["aid"].ToString();
        }
        if (Session["vid"] != null)
        {
            xvid.Value = Session["vid"].ToString();
        }
        else
        {
            Response.Redirect("http://www.iponigeria.com/userarea/dashboard");
        }
        if (Session["amt"] != null)
        {
            xamt.Value = Session["amt"].ToString();
        }
        if (Session["gt"] != null)
        {
            xgt.Value = Session["gt"].ToString();
        }
        if (Session["pc"] != null)
        {
            pc = xpc.Value = Session["pc"].ToString();
        }
        if (Session["pwalletID"] != null)
        {
            xpwalletID.Value = Session["pwalletID"].ToString();
        }
        if (Session["agentemail"] != null)
        {
            xagentemail.Value = Session["agentemail"].ToString();
        }
        if (Session["cname"] != null)
        {
            xcname.Value = Session["cname"].ToString();
        }
        if (Session["agentpnumber"] != null)
        {
            xagentpnumber.Value = Session["agentpnumber"].ToString();
        }
        if (Session["applicantname"] != null)
        {
            xapplicantname.Value = Session["applicantname"].ToString();
        }
        if (Session["product_title"] != null)
        {
            xproduct_title.Value = Session["product_title"].ToString();
        }
        if (Session["log_staffID"] != null)
        {
            log_staffID = Session["log_staffID"].ToString();
        }
        xcode.Text = xaid.Value.ToUpper();
        xname.Text = xapplicantname.Value.ToUpper();
        if (selectDay.Text == "")
        {
            selectDay.Text = DateTime.Now.Day.ToString();
        }
        if (selectMonth.Text == "")
        {
            selectMonth.Text = DateTime.Now.Month.ToString();
        }
        if (selectYear.Text == "")
        {
            selectYear.Text = DateTime.Now.Year.ToString();
        }
        description_no.Text = "1";
        claim_no.Text = "1";
        abstract_no.Text = "1";
        drawing_no.Text = "1";
        if (rbPriorityClaim.SelectedValue == "Yes")
        {
            rbPriorityClaim_text = "1";
        }
        if (rbInventors.SelectedValue == "Yes")
        {
            rbInventors_text = "1";
        }
        if (rbOtherInventors.SelectedValue == "Yes")
        {
            rbInventors_text = "1";
            rbOtherInventors_text = "1";
        }
        if (IsPostBack)
        {
            lt_state = t.getState(residence.SelectedValue);
            if (lt_state.Count == 0)
            {
                state_row = "1";
                state_visible = "1";
            }
            lt_rep_state = t.getState(rep_residence.SelectedValue);
            if (lt_rep_state.Count == 0)
            {
                rep_state_row = "1";
                state_visible = "1";
            }
            if (Session["aid"] != null)
            {
                xaid.Value = Session["aid"].ToString();
            }
            if (Session["vid"] != null)
            {
                xvid.Value = Session["vid"].ToString();
            }
            if (Session["amt"] != null)
            {
                xamt.Value = Session["amt"].ToString();
            }
            if (Session["gt"] != null)
            {
                xgt.Value = Session["gt"].ToString();
            }
            if (Session["pc"] != null)
            {
                pc = xpc.Value = Session["pc"].ToString();
                if (pc == "T002")
                {
                    pc = "1";
                }
                else
                {
                    pc = "2";
                }
            }
            if (Session["pwalletID"] != null)
            {
                xpwalletID.Value = Session["pwalletID"].ToString();
            }
            if (Session["agentemail"] != null)
            {
                xagentemail.Value = Session["agentemail"].ToString();
            }
            if (Session["cname"] != null)
            {
                xcname.Value = Session["cname"].ToString();
            }
            if (Session["agentpnumber"] != null)
            {
                xagentpnumber.Value = Session["agentpnumber"].ToString();
            }
            if (Session["applicantname"] != null)
            {
                xapplicantname.Value = Session["applicantname"].ToString();
            }
            if (Session["product_title"] != null)
            {
                xproduct_title.Value = Session["product_title"].ToString();
            }
        }
        else
        {
            transID = Session["vid"].ToString();
            Session["xref"] = Convert.ToInt32(Session["xref"]) + 1;
            if (Session["xref"].ToString() != "1")
            {
                Response.Redirect("./violation.aspx");
            }
            if (((Session["xapplication"] != null) && (Session["xapplication"].ToString() != "")) && (transID != Session["xapplication"].ToString()))
            {
                Response.Redirect("./violation.aspx");
            }
            nationality.SelectedIndex = 0x9f;
            rep_nationality.SelectedIndex = 0x9f;
            residence.SelectedIndex = 0x9f;
            rep_residence.SelectedIndex = 0x9f;
            rep_xname.Text = xcname.Value.ToUpper();
            rep_xemail.Text = xagentemail.Value.ToUpper();
            rep_xtelephone.Text = xagentpnumber.Value.ToUpper();
            title_of_invention.Text = xproduct_title.Value.ToUpper();
        }
        if ((Session["description_doc"] == null) && description_doc.HasFile)
        {
            Session["description_doc"] = description_doc;
            lblDescription_doc.Text = description_doc.FileName;
        }
        else if (!((Session["description_doc"] == null) || description_doc.HasFile))
        {
            description_doc = (FileUpload) Session["description_doc"];
            lblDescription_doc.Text = description_doc.FileName;
        }
        else if (description_doc.HasFile)
        {
            Session["description_doc"] = description_doc;
            lblDescription_doc.Text = description_doc.FileName;
        }
        if ((Session["claim_doc"] == null) && claim_doc.HasFile)
        {
            Session["claim_doc"] = claim_doc;
            lblClaim_doc.Text = claim_doc.FileName;
        }
        else if (!((Session["claim_doc"] == null) || claim_doc.HasFile))
        {
            claim_doc = (FileUpload) Session["claim_doc"];
            lblClaim_doc.Text = claim_doc.FileName;
        }
        else if (claim_doc.HasFile)
        {
            Session["claim_doc"] = claim_doc;
            lblClaim_doc.Text = claim_doc.FileName;
        }
        if ((Session["abstract_doc"] == null) && abstract_doc.HasFile)
        {
            Session["abstract_doc"] = abstract_doc;
            lblAbstract_doc.Text = abstract_doc.FileName;
        }
        else if (!((Session["abstract_doc"] == null) || abstract_doc.HasFile))
        {
            abstract_doc = (FileUpload) Session["abstract_doc"];
            lblAbstract_doc.Text = abstract_doc.FileName;
        }
        else if (abstract_doc.HasFile)
        {
            Session["abstract_doc"] = abstract_doc;
            lblAbstract_doc.Text = abstract_doc.FileName;
        }
        if ((Session["drawing_doc"] == null) && drawing_doc.HasFile)
        {
            Session["drawing_doc"] = drawing_doc;
            lblDrawing_doc.Text = drawing_doc.FileName;
        }
        else if (!((Session["drawing_doc"] == null) || drawing_doc.HasFile))
        {
            drawing_doc = (FileUpload) Session["drawing_doc"];
            lblDrawing_doc.Text = drawing_doc.FileName;
        }
        else if (drawing_doc.HasFile)
        {
            Session["drawing_doc"] = drawing_doc;
            lblDrawing_doc.Text = drawing_doc.FileName;
        }
    }

    protected void rbInventors_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbInventors.SelectedValue == "Yes")
        {
            rbInventors_text = "1";
        }
    }

    protected void rbOtherInventors_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbOtherInventors.SelectedValue == "Yes")
        {
            rbInventors_text = "1";
            rbOtherInventors_text = "1";
        }
    }

    protected void rbPriorityClaim_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbPriorityClaim.SelectedValue == "Yes")
        {
            rbPriorityClaim_text = "1";
        }
    }

    protected void SaveAll_Click(object sender, EventArgs e)
    {
        SaveAll.Visible = false;
        c_app.xname = xapplicantname.Value;
        c_app_addy.countryID = residence.Text;
        c_app_addy.stateID = xselectState.Text;
        c_app_addy.city = xcity.Text;
        c_app_addy.street = xaddress.Text;
        c_app_addy.telephone1 = xtelephone.Text;
        c_app_addy.email1 = xemail.Text;
        c_pt.title_of_invention = title_of_invention.Text;
        c_aos.stateID = aos_xselectState.Text;
        c_aos.city = aos_xcity.Text;
        c_aos.street = aos_xaddress.Text;
        c_aos.telephone1 = aos_xtelephone.Text;
        c_aos.email1 = aos_xemail.Text;
        c_rep.agent_code = xaid.Value;
        c_rep.xname = rep_xname.Text;
        c_rep.nationality = rep_nationality.SelectedValue;
        c_rep_addy.countryID = rep_residence.SelectedValue;
        c_rep_addy.stateID = xselectRepState.SelectedValue;
        c_rep_addy.city = rep_xcity.Text;
        c_rep_addy.street = rep_address.Text;
        c_rep_addy.telephone1 = rep_xtelephone.Text;
        c_rep_addy.email1 = rep_xemail.Text;
        pwalletID = xpwalletID.Value;
        if (xmarkID.Value != "0")
        {
            show_image_section = "1";
        }
    }

    protected void SaveDocs_Click(object sender, EventArgs e)
    {
        SaveDocs.Visible = false;
        string str = "";
        string str2 = "";
        string str3 = "";
        string str4 = "";
        string str5 = "";
        int num = 0;
        if (num != 0)
        {
            Response.Write("<script language=JavaScript>alert('Please fill in the marked fileds')</script>");
            show_image_section = "1";
        }
        else
        {
            if (description_doc.HasFile)
            {
                str = t.doUploadDoc(xmarkID.Value, Server.MapPath("~/") + "admin/pt/docz/", description_doc);
            }
            if (claim_doc.HasFile)
            {
                str2 = t.doUploadDoc(xmarkID.Value, Server.MapPath("~/") + "admin/pt/docz/", claim_doc);
            }
            if (abstract_doc.HasFile)
            {
                str3 = t.doUploadDoc(xmarkID.Value, Server.MapPath("~/") + "admin/pt/docz/", abstract_doc);
            }
            if (drawing_doc.HasFile)
            {
                str4 = t.doUploadDoc(xmarkID.Value, Server.MapPath("~/") + "admin/pt/docz/", drawing_doc);
            }
            str5 = str5.Replace(Server.MapPath("~/") + "admin/pt/", "");
            str = str.Replace(Server.MapPath("~/") + "admin/pt/", "");
            str2 = str2.Replace(Server.MapPath("~/") + "admin/pt/", "");
            str3 = str3.Replace(Server.MapPath("~/") + "admin/pt/", "");
            str4 = str4.Replace(Server.MapPath("~/") + "admin/pt/", "");
        }
    }

  
}

