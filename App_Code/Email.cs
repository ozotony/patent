    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Text;

public class Email
{
    private string hostname = "88.150.164.30";
    private MailMessage mail = new MailMessage();
    private string passwd = "Zues.4102.Hector";
    private int port = 0x24b;
    private string username = "paymentsupport@einaosolutions.com";

    public string sendMail(string userdisplayname, string to, string from, string subject, string msg, string path)
    {
        string str = "";
        SmtpClient client = new SmtpClient
        {
            Credentials = new NetworkCredential(username, passwd),
            Port = port,
            Host = hostname,
            EnableSsl = false,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Timeout = 0x4e20
        };
     mail = new MailMessage();
        string[] strArray = to.Split(new char[] { ',' });
        try
        {
         mail.From = new MailAddress(from, userdisplayname, Encoding.UTF8);
            for (byte i = 0; i < strArray.Length; i = (byte)(i + 1))
            {
             mail.To.Add(strArray[i]);
            }
         mail.Priority = MailPriority.High;
         mail.Subject = subject;
         mail.Body = msg;
            if (path != "")
            {
                LinkedResource item = new LinkedResource(path)
                {
                    ContentId = "Logo"
                };
                AlternateView view = AlternateView.CreateAlternateViewFromString("<html><body><table border=2><tr width=100%><td><img src=cid:Logo alt=companyname /></td><td>FROM CLD</td></tr></table><hr/></body></html>" + msg, null, "text/html");
                view.LinkedResources.Add(item);
             mail.AlternateViews.Add(view);
             mail.IsBodyHtml = true;
             mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
             mail.ReplyTo = new MailAddress(from);
                client.Send(mail);
                return "sent";
            }
            if (path == "")
            {
             mail.IsBodyHtml = true;
             mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
             mail.ReplyTo = new MailAddress(from);
                client.Send(mail);
                str = "sent";
            }
        }
        catch (Exception exception)
        {
            if (exception.ToString() == "The operation has timed out")
            {
                client.Send(mail);
                str = "bad";
            }
        }
        return str;
    }
}

