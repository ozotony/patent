using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class cp : Page
{
    public string adminID = "0";
    public string code_text;
    public string enable_Captcha = "1";
    public string enable_Confirm = "0";
    public string enable_Save = "1";
    public int file_len = 0x400;
    public string file_string = "Xavier";
    public string newp = "0";
    public string newState = "0";
    public Odyssey ody = new Odyssey();
    public string serverpath = "";
    public string xnewpass1_text;
    public string xnewpass2_text = "";
    public zues z = new zues();

    protected void ConfirmDetails_Click(object sender, EventArgs e)
    {
        int num = 0;
        if (xnewpass1.Text == "")
        {
            xnewpass1_text = "1";
            num++;
        }
        if (xnewpass2.Text == "")
        {
            xnewpass2_text = "1";
            num++;
        }
        if (xcode.Text == "")
        {
            code_text = "1";
            num++;
        }
        if (xnewpass1.Text != xnewpass2.Text)
        {
            num++;
        }
        if (num != 0)
        {
            Response.Write("<script language=JavaScript>alert('Please fill in the marked fileds or make sure the passwords match!!')</script>");
        }
        else
        {
            Session["Newpass"] = xnewpass1.Text;
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

    protected void Page_Load(object sender, EventArgs e)
    {
        serverpath = Server.MapPath("~/");
        adminID = Request.QueryString["x"];
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
        if (xnewpass1.Text != "")
        {
            xnewpass1_text = xnewpass1.Text;
        }
        if (xnewpass2.Text != "")
        {
            xnewpass2_text = xnewpass2.Text;
        }
        if (Session["Newpass"] != null)
        {
            xnewpass1_text = Session["Newpass"].ToString();
        }
        if (z.e_xadminz(adminID, ody.EncryptString(xnewpass1_text, file_len, file_string)) != "0")
        {
            Response.Redirect("./login.aspx");
        }
        else
        {
            Response.Redirect("./cp.aspx");
        }
    }

    protected void xnewpass1_Unload(object sender, EventArgs e)
    {
        xnewpass1_text = xnewpass1.Text;
    }

    protected void xnewpass2_Unload(object sender, EventArgs e)
    {
        xnewpass2_text = xnewpass2.Text;
    }

   
}

