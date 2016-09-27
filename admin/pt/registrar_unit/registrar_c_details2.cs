using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class  admin_pt_registrar_unit_registrar_c_details2 : Page
{
    public string admin = "";
    public string admin_status;
    public List<pt.Address> lt_addy = new List<pt.Address>();
    public List<pt.AddressService> lt_addy_service = new List<pt.AddressService>();
    public List<pt.Applicant> lt_app = new List<pt.Applicant>();
    public List<pt.PtInfo> lt_mi = new List<pt.PtInfo>();
    public List<pt.Stage> lt_p = new List<pt.Stage>();
    public List<pt.Representative> lt_rep = new List<pt.Representative>();
    public List<pt.Stage> lt_stage = new List<pt.Stage>();
    public List<zues.Adminz> lt_tm_admin_details = new List<zues.Adminz>();
    public List<zues.PtOffice> lt_tm_office = new List<zues.PtOffice>();
    public List<zues.Adminz> lt_x_admin_details = new List<zues.Adminz>();
    public string pID;
    public string rbval_text = "";
    public string search_doc_succ1 = "";
    public string search_doc_succ2 = "";
    public string search_doc_succ3 = "";
    public string succ = "";
    public pt t = new pt();
    public string xcomments = "";
    public string xofficer;
    public zues z = new zues();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["x"] != null)
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
            pID = Request.QueryString["x"].ToString();
            lt_mi = t.getPtInfoByUserID(pID);
            lt_p = t.getPwalletDetailsByID(lt_mi[0].log_staff);
            lt_app = t.getApplicantByUserID(lt_mi[0].log_staff);
            lt_addy = t.getAddressByLog_staffID(lt_mi[0].log_staff);
            lt_addy_service = t.getAddressServiceByID(lt_mi[0].log_staff);
            lt_rep = t.getRepListByUserID(lt_mi[0].log_staff);
            lt_tm_office = z.getPtOfficeDetailsByID(lt_mi[0].log_staff);
            lt_stage = t.getStageByUserID(lt_mi[0].log_staff);
        }
        else
        {
            Response.Redirect("./registrar_c.aspx");
        }
    }

  
}

