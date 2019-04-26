using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_pt_search_unit_admin_cert_status : System.Web.UI.Page
{
    public pt.XPwallet c_p = new pt.XPwallet();
    public pt.Renewal c_ren = new pt.Renewal();
    public string current_date;
    public string msg = "";
    public pt t = new pt();
   public  zues.Adminz ad = new zues.Adminz();
    public zues z = new zues();

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((((Session["transID"] != null) && (Session["transID"].ToString() != "")) && (Session["x_code"] != null)) && (Session["x_code"].ToString() != ""))
        {
            c_p = t.getXPwalletDetailsByCode(Session["transID"].ToString(), Session["x_code"].ToString());
            string admin = Session["pwalletID"].ToString();
            ad = z.getAdminDetails(admin);
           // vame2.Text = z.getRoleName(ad.xroleID).ToUpper();
           try
            {
              //  vame2.Text = z.getRoleName(ad.xroleID).ToUpper();
                vame2.Text = ad.Designation.ToUpper();
            }

            catch(Exception ee)
            {

            }

            try
            {
              //  vame.Text = ad.Designation.ToUpper();
               vame.Text = ad.xname.ToUpper();
            }

            catch (Exception ee)
            {

            }

           
            if (string.IsNullOrEmpty(ad.FilePath))
            {
                img.Visible = false;
            }
            else
            {
                img.Visible = true;
                img.ImageUrl = ".." + ad.FilePath;
            }
            
            if (c_p.ID != null)
            {
                c_ren = t.getRenewalByLogstaffID(c_p.ID);
                if (c_ren.xID != null)
                {
                    transID.Text = c_p.validationID;
                    payment_date.Text = c_p.reg_date;
                    p_title.Text = c_ren.title;
                    p_app_no.Text = c_ren.app_no;
                    p_type.Text = c_ren.type;
                    p_app_date.Text = c_ren.app_date;
                    p_xname.Text = c_ren.xname;
                    p_xaddy.Text = c_ren.xaddy;
                    p_xmobile.Text = c_ren.xmobile;
                    p_xemail.Text = c_ren.xemail;
                    p_agt_code.Text = c_ren.agt_code;
                    p_agt_name.Text = c_ren.agt_name;
                    p_agt_addy.Text = c_ren.agt_addy;
                    p_agt_mobile.Text = c_ren.agt_mobile;
                    p_agt_email.Text = c_ren.agt_email;
                    p_due_date.Text = Convert.ToDateTime(c_ren.last_rwl_date).AddYears(1).ToString("yyyy-MM-dd");
                    p_next_due_date.Text = Convert.ToDateTime(c_ren.last_rwl_date).AddYears(2).ToString("yyyy-MM-dd");
                }
            }
            else
            {
                msg = "NO ENTRY EXISTS WITH THE DETAILS ABOVE,PLEASE CHECK THE DETAILS AND TRY AGAIN!!";
            }
        }
        else
        {
            Response.Write("<script language=JavaScript>alert('PLEASE ENTER A VALID REFERENCE NUMBER')</script>");
        }
    }
}