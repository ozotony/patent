    using System;
    using System.IO;
    using System.Net;
    using System.Text;

public class Messenger
{
    public string getSessionID()
    {
        string str = "login";
        string str2 = "aidigbe@mynovasys.com";
        string str3 = "UNS";
        string str4 = "ba2xai";
        string str5 = "";
        try
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            string s = "cmd=" + str + "&owneremail=" + str2 + "&subacct=" + str3 + "&subacctpwd=" + str4;
            byte[] bytes = encoding.GetBytes(s);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.smslive247.com/http/index.aspx/");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            WebResponse response = request.GetResponse();
            requestStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(requestStream);
            str5 = reader.ReadToEnd();
            str5 = str5.Replace("OK: ", "");
            reader.Close();
            requestStream.Close();
            response.Close();
        }
        catch (WebException exception)
        {
            exception.ToString();
        }
        return str5;
    }

    public string send_sms(string message, string sender, string sendto)
    {
        string str = "sendmsg";
        string str2 = getSessionID();
        string str3 = "0";
        string str4 = "";
        ASCIIEncoding encoding = new ASCIIEncoding();
        string s = "cmd=" + str + "&sessionid=" + str2 + "&message=" + message + "&sender=" + sender + "&sendto=" + sendto + "&msgtype=" + str3;
        try
        {
            byte[] bytes = encoding.GetBytes(s);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.smslive247.com/http/index.aspx/");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            WebResponse response = request.GetResponse();
            requestStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(requestStream);
            str4 = reader.ReadToEnd();
            reader.Close();
            requestStream.Close();
            response.Close();
            return str4.Replace("OK: ", "");
        }
        catch (WebException exception)
        {
            exception.ToString();
            return "No net";
        }
    }
}
