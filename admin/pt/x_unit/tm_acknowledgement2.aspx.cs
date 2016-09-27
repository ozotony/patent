using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_pt_x_unit_tm_acknowledgement2 : System.Web.UI.Page
{
    public string aid = "";
    public string amt = "";
    public string gt = "";
    public List<pt.Applicant> lt_app = new List<pt.Applicant>();
    public List<pt.Assignment_info> lt_assinfo = new List<pt.Assignment_info>();
    public List<pt.Inventor> lt_inv = new List<pt.Inventor>();
    public List<pt.PtInfo> lt_mi = new List<pt.PtInfo>();
    public List<pt.Representative> lt_rep = new List<pt.Representative>();
    public List<pt.Stage> lt_stage = new List<pt.Stage>();
    public List<pt.Priority_info> lt_xpri = new List<pt.Priority_info>();
    public string pwalletID = "";
    public pt t = new pt();
    public string validationID = "";
    public string vid = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"] != null) && (Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"].ToString() != ""))
        {
            vid = Request.QueryString["0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD"].ToString();
            if (vid.Contains("OAI/PT/"))
            {
                vid = vid.Replace("OAI/PT/", "");
            }
            pwalletID = t.getPwalletID(vid);
            if (pwalletID != "")
            {
                lt_mi = t.getPtInfoByPwalletID(pwalletID);
                lt_rep = t.getRepListByUserID(pwalletID);
                lt_stage = t.getStageByUserID(pwalletID);
                lt_app = t.getApplicantByvalidationID(pwalletID);
                lt_inv = t.getInventorByvalidationID(pwalletID);
                lt_assinfo = t.getAssignment_infoByvalidationID(pwalletID);
                lt_xpri = t.getPriority_infoByvalidationID(pwalletID);
                Session["xserviceaddress"] = null;
                Session["xrepresentative"] = null;
                Session["xmarkinfo"] = null;
                Session["xapplication"] = null;
                Session["vid"] = null;
                Session["amt"] = null;
                Session["aid"] = null;
                Session["g"] = null;
                Session["pc"] = null;
                Session["new_ptID"] = null;
                Session["loa_newfilename"] = null;
                Session["claim_newfilename"] = null;
                Session["pct_newfilename"] = null;
                Session["doa_newfilename"] = null;
                Session["spec_newfilename"] = null;
                Session["txt_loa_no"] = null;
                Session["txt_claim_no"] = null;
                Session["txt_pct_no"] = null;
                Session["txt_doa_no"] = null;
            }
        }
    }

}