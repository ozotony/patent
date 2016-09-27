using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class  admin_pt_registrar_unit_registrar_c_details : Page
{
    public string admin = "";
    public string admin_status;
    public List<pt.Address> lt_addy = new List<pt.Address>();
    public List<pt.AddressService> lt_addy_service = new List<pt.AddressService>();
    public List<pt.Applicant> lt_app = new List<pt.Applicant>();
    public List<pt.PtInfo> lt_mi = new List<pt.PtInfo>();
    public List<pt.Stage> lt_p = new List<pt.Stage>();
    public List<pt.Priority_info> lt_pri = new List<pt.Priority_info>();
    public List<pt.Representative> lt_rep = new List<pt.Representative>();
    public List<pt.Stage> lt_stage = new List<pt.Stage>();
    public List<zues.Adminz> lt_tm_admin_details = new List<zues.Adminz>();
    public List<zues.PtOffice> lt_tm_office = new List<zues.PtOffice>();
    public List<zues.Adminz> lt_x_admin_details = new List<zues.Adminz>();
    public string pID;
    public string rbval_text = "";
    public string registrar_date = "";
    public string sealing_date = "";
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
            lt_pri = t.getPriority_infoByvalidationID(lt_mi[0].log_staff);
            if (lt_tm_office.Count > 0)
            {
                for (int i = 0; i < lt_tm_office.Count; i++)
                {
                    sealing_date = lt_tm_office[lt_tm_office.Count - 1].reg_date;
                    if (lt_tm_office[i].data_status == "Grant Patent")
                    {
                        registrar_date = lt_tm_office[i].reg_date;
                        DateTime time = new DateTime(Convert.ToInt32(registrar_date.Substring(0, 4)), Convert.ToInt32(registrar_date.Substring(5, 2)), Convert.ToInt32(registrar_date.Substring(8, 2)));
                        string str = time.ToString("dd");
                        string str2 = time.ToString("MMMM");
                        string str3 = time.ToString("yyyy");
                        if (str.Substring(0, 1) == "0")
                        {
                            str = str.Substring(1, 1);
                        }
                        if (str.EndsWith("1") && (str != "11"))
                        {
                            str = str + "st";
                        }
                        else if (str.EndsWith("2") && (str != "12"))
                        {
                            str = str + "nd";
                        }
                        else if (str.EndsWith("3") && (str != "13"))
                        {
                            str = str + "rd";
                        }
                        else
                        {
                            str = str + "th";
                        }
                        registrar_date = str + " day of" + str2 + ", " + str3;
                    }
                }
            }
        }
        else
        {
            Response.Redirect("./registrar_c.aspx");
        }
    }

  
}

