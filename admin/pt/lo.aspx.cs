using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_pt_lo : Page
{
    public string adminID = "0";
    public string xadminID = "0";
    public string code_text = "";
    public string email_text = "";
    public string enable_Captcha = "1";
    public string enable_Confirm = "0";
    public string enable_Save = "1";
    public string newp = "0";
    public string newState = "0";
    public Odyssey ody = new Odyssey();
    public static string OriginalIP = "";
    public string password_text = "";
    public static string remote_host = "";
    public static string remote_user = "";
    public static string RemoteIP = "";
    public static string server_name = "";
    public static string server_url = "";
    public string serverpath = "";
    public zues z = new zues();

    protected void ConfirmDetails_Click(object sender, EventArgs e)
    {
        int num = 0;
        if (xemail.Text == "")
        {
            email_text = "1";
            num++;
        }
        if (xcode.Text == "")
        {
            code_text = "1";
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
            newState = "0";
            enable_Save = "0";
            enable_Confirm = "1";
            enable_Captcha = "0";
            newp = "1";
        }
        else
        {
            newState = "1";
            xcode.Text = "";
        }
    }

    public static string GetClientIPAddress(HttpRequest httpRequest)
    {
        OriginalIP = "Proxy IP: " + httpRequest.ServerVariables["HTTP_X_FORWARDED_FOR"];
        RemoteIP = "Remote IP: " + httpRequest.ServerVariables["LOCAL_ADDR"];
        remote_host = "Remote Host: " + httpRequest.ServerVariables["REMOTE_HOST"];
        remote_user = "User Agent: " + httpRequest.UserAgent;
        server_name = "UserHostName: " + httpRequest.UserHostName;
        server_url = "UserHostAddress: " + httpRequest.UserHostAddress;
        if ((OriginalIP != null) && (OriginalIP.Trim().Length > 0))
        {
            return (OriginalIP + "(" + RemoteIP + ")");
        }
        return RemoteIP;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        serverpath = Server.MapPath("~/");
        string clientIPAddress = GetClientIPAddress(Context.Request);
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        if (xpassword.Text != "")
        {
            password_text = xpassword.Text;
        }
        Odyssey odyssey = new Odyssey();
        adminID = z.a_xadminz(xemail.Text, xpassword.Text, serverpath);
       xadminID = z.getRoleByID(adminID);
        if (adminID != "0")
        {
            if (!(z.addAdminLog(adminID, RemoteIP, remote_host, remote_user, server_name, server_url) != ""))
            {
                Response.Redirect("../../login.aspx");
            }
            else
            {
                Session["pwalletID"] = adminID;
                string str3 = xadminID;
                if (str3 != null)
                {
                    if (!(str3 == "1"))
                    {
                        if (str3 == "2")
                        {
                            Response.Redirect("./verification_unit/profile.aspx");
                        }
                        else if (str3 == "3")
                        {
                            Response.Redirect("./search_unit/profile.aspx");
                        }
                        else if (str3 == "4")
                        {
                            Response.Redirect("./examiners_unit/profile.aspx");
                        }
                        else if (str3 == "5")
                        {
                            Response.Redirect("./acceptance_unit/profile.aspx");
                        }
                        else if (str3 == "6")
                        {
                            Response.Redirect("./registrar_unit/profile_index.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("./x_unit/profile.aspx");
                    }
                }
            }
        }
    }

    protected void xpassword_Unload(object sender, EventArgs e)
    {
        password_text = xpassword.Text;
    }

   
  
}