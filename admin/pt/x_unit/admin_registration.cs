using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class admin_pt_x_unit_admin_registration : Page
{
    public zues.Adminz ad = new zues.Adminz();
    public string admin = "";
    public string edit_email_text = "";
    public string edit_name_text = "";
    public string edit_telephone1_text = "";
    public string edit_telephone2_text = "";
    public string edit_xcode_text = "";
    public string email_text = "";
    public string enable_Captcha = "1";
    public string enable_Confirm = "0";
    public string enable_EditTbl = "1";
    public string enable_Save = "1";
    public int file_len = 0x400;
    public string file_string = "Xavier";
    public string name_text = "";
    public int newState;
    public Odyssey ody = new Odyssey();
    public string pwalletID = "1";
    public string regID = "0";
    public string serverpath = "";
    public string telephone1_text = "";
    public string telephone2_text = "";
    public string vID = "";
    public int x_add_succ;
    public int x_add_tbl = 1;
    public int x_del_succ;
    public int x_del_tbl = 1;
    public int x_edit_succ;
    public int x_edit_tbl = 1;
    public string xcode_text = "";
    public string xType = "0";
    public zues z = new zues();

    protected void btn_menu_Click(object sender, EventArgs e)
    {
        x_add_tbl = 1;
        x_add_succ = 0;
    }

    protected void ConfirmDetails_Click(object sender, EventArgs e)
    {
        int num = 0;
        if (xemail.Text == "")
        {
            email_text = "1";
            num++;
        }
        if (xname.Text == "")
        {
            name_text = "1";
            num++;
        }
        if (num != 0)
        {
            Response.Write("<script language=JavaScript>alert('Please fill in the marked fileds')</script>");
        }
        else
        {
            doCaptcha();
        }
    }

    protected void doCaptcha()
    {
        string str = "";
        if (Session["Captcha"] != null)
        {
            str = Session["Captcha"].ToString();
        }
        if (str == xcode.Text.ToUpper())
        {
            newState = 0;
            enable_Save = "0";
            enable_Confirm = "1";
            enable_Captcha = "0";
        }
        else
        {
            newState = 1;
            xcode.Text = "";
        }
    }

    protected void EditBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("./admin_registration.aspx");
    }

    protected void EditRefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect("./admin_registration.aspx");
    }

    protected void EditSave_Click(object sender, EventArgs e)
    {
        string path = serverpath + @"\Handlers\bf.pke";
        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path, true);
            file_string = reader.ReadToEnd();
            reader.Close();
            if (file_string != null)
            {
                string oldValue = file_string.Substring(0, file_string.IndexOf("</BitStrength>") + 14);
                file_string = file_string.Replace(oldValue, "");
            }
        }
        if (z.e_regadmin(edit_xname.Text, ody.EncryptString(edit_xpass.Text, file_len, file_string), edit_xrole.SelectedValue, ody.EncryptString(edit_xemail.Text, file_len, file_string), edit_telephone1.Text, edit_telephone2.Text, "pt", pwalletID, getAdmins.SelectedValue, edit_status.SelectedValue) > 0)
        {
            x_edit_tbl = 0;
            x_edit_succ = 1;
        }
    }

    protected void getAdmins_SelectedIndexChanged(object sender, EventArgs e)
    {
        ad = z.getAdminDetails(getAdmins.SelectedValue);
        edit_xname.Text = ad.xname;
        edit_xpass.Text = ody.DecryptString(ad.xpass, file_len, file_string);
        edit_xemail.Text = ody.DecryptString(ad.xemail, file_len, file_string);
        edit_telephone1.Text = ad.xtelephone1;
        edit_telephone2.Text = ad.xtelephone2;
        edit_xrole.SelectedIndex = Convert.ToInt16(z.getAdmiPriv(ad.xroleID)) - 1;
        edit_status.SelectedIndex = Convert.ToInt16(ad.xvisible);
        enable_EditTbl = "1";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        serverpath = Server.MapPath("~/");
        string path = serverpath + @"Handlers\bf.kez";
        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path, true);
            file_string = reader.ReadToEnd();
            reader.Close();
            if (file_string != null)
            {
                string oldValue = file_string.Substring(0, file_string.IndexOf("</BitStrength>") + 14);
                file_string = file_string.Replace(oldValue, "");
            }
        }
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
        if (!IsPostBack)
        {
            ad = z.getTopAdminDetails();
            edit_xname.Text = ad.xname;
            edit_xpass.Text = ody.DecryptString(ad.xpass, file_len, file_string);
            edit_xemail.Text = ody.DecryptString(ad.xemail, file_len, file_string);
            edit_telephone1.Text = ad.xtelephone1;
            edit_telephone2.Text = ad.xtelephone2;
            edit_xrole.SelectedIndex = Convert.ToInt16(z.getAdmiPriv(ad.xroleID)) - 1;
            edit_status.SelectedIndex = Convert.ToInt16(ad.xvisible);
        }
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        string path = serverpath + @"\Handlers\bf.pke";
        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path, true);
            file_string = reader.ReadToEnd();
            reader.Close();
            if (file_string != null)
            {
                string oldValue = file_string.Substring(0, file_string.IndexOf("</BitStrength>") + 14);
                file_string = file_string.Replace(oldValue, "");
            }
        }
        int length = xtelephone1.Text.Length;
        string inputString = xtelephone1.Text.Remove(0, length - 4);
        regID = z.a_regadmin(xname.Text, xrole.SelectedValue, ody.EncryptString(xemail.Text, file_len, file_string), xtelephone1.Text, xtelephone2.Text, "pt", pwalletID, ody.EncryptString(inputString, file_len, file_string));
        if (regID != "0")
        {
            x_add_tbl = 0;
            x_add_succ = 1;
        }
    }

    
}

