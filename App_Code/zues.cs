using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public class zues
{
    public string a_contact_form(Contact_form cf)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO contact_form (pwalletID,response_deadline,xofficerID,xmsg,sent_status,reg_date,xvisible) VALUES (@pwalletID,@response_deadline,@xofficerID,@xmsg,@sent_status,@reg_date,@xvisible) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@pwalletID", SqlDbType.VarChar, 50);
        command.Parameters.Add("@response_deadline", SqlDbType.VarChar, 50);
        command.Parameters.Add("@xofficerID", SqlDbType.VarChar);
        command.Parameters.Add("@xmsg", SqlDbType.Text);
        command.Parameters.Add("@sent_status", SqlDbType.VarChar, 1);
        command.Parameters.Add("@reg_date", SqlDbType.VarChar, 50);
        command.Parameters.Add("@xvisible", SqlDbType.VarChar, 1);
        command.Parameters["@pwalletID"].Value = cf.pwalletID;
        command.Parameters["@response_deadline"].Value = cf.response_deadline;
        command.Parameters["@xofficerID"].Value = cf.xofficerID;
        command.Parameters["@xmsg"].Value = cf.xmsg;
        command.Parameters["@sent_status"].Value = cf.sent_status;
        command.Parameters["@reg_date"].Value = cf.reg_date;
        command.Parameters["@xvisible"].Value = cf.xvisible;
        str = command.ExecuteScalar().ToString();
        connection.Close();
        return str;
    }

    public string a_regadmin(string xname, string xrole, string xemail, string telephone1, string telephone2, string xsection, string pwalletID, string pass)
    {
        string connectionString = Connect();
        string str2 = "";
        string str3 = DateTime.Now.ToString("yyyy-MM-dd");
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT into xadminz_pt (xroleID ,xname,xemail,xpass,xtelephone1,xtelephone2,xsection,xlog_officer,xreg_date,xvisible) VALUES (@xrole,@xname,@xemail,@xpass,@xtelephone1,@xtelephone2,@xsection,@xlog_officer,@xreg_date,@xvisible) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@xname", SqlDbType.VarChar);
        command.Parameters.Add("@xrole", SqlDbType.VarChar, 50);
        command.Parameters.Add("@xemail", SqlDbType.Text);
        command.Parameters.Add("@xpass", SqlDbType.Text);
        command.Parameters.Add("@xtelephone1", SqlDbType.VarChar, 50);
        command.Parameters.Add("@xtelephone2", SqlDbType.VarChar, 50);
        command.Parameters.Add("@xsection", SqlDbType.VarChar, 50);
        command.Parameters.Add("@xlog_officer", SqlDbType.VarChar, 50);
        command.Parameters.Add("@xreg_date", SqlDbType.VarChar, 50);
        command.Parameters.Add("@xvisible", SqlDbType.VarChar, 10);
        command.Parameters["@xname"].Value = xname;
        command.Parameters["@xrole"].Value = xrole;
        command.Parameters["@xemail"].Value = xemail;
        command.Parameters["@xpass"].Value = pass;
        command.Parameters["@xtelephone1"].Value = telephone1;
        command.Parameters["@xtelephone2"].Value = telephone2;
        command.Parameters["@xsection"].Value = xsection;
        command.Parameters["@xlog_officer"].Value = pwalletID;
        command.Parameters["@xreg_date"].Value = str3;
        command.Parameters["@xvisible"].Value = "1";
        str2 = command.ExecuteScalar().ToString();
        connection.Close();
        return str2;
    }

    public string a_tm_office(string pwalletID, string admin_status, string data_status, string xcomment, string xdoc1, string xdoc2, string xdoc3, string xofficer)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO pt_office (pwalletID,admin_status,data_status,xcomment,xdoc1,xdoc2,xdoc3,xofficer,reg_date,xvisible) VALUES (@pwalletID,@admin_status,@data_status,@xcomment,@xdoc1,@xdoc2,@xdoc3,@xofficer,@reg_date,@xvisible) SELECT SCOPE_IDENTITY()";
        connection.Open();
        string str3 = DateTime.Now.ToString("yyyy-MM-dd");
        xdoc1 = xdoc1.Replace(" ", "_");
        xdoc2 = xdoc2.Replace(" ", "_");
        xdoc3 = xdoc3.Replace(" ", "_");
        command.Parameters.Add("@pwalletID", SqlDbType.VarChar, 50);
        command.Parameters.Add("@admin_status", SqlDbType.VarChar, 50);
        command.Parameters.Add("@data_status", SqlDbType.VarChar, 50);
        command.Parameters.Add("@xcomment", SqlDbType.Text);
        command.Parameters.Add("@xdoc1", SqlDbType.Text);
        command.Parameters.Add("@xdoc2", SqlDbType.Text);
        command.Parameters.Add("@xdoc3", SqlDbType.Text);
        command.Parameters.Add("@xofficer", SqlDbType.VarChar, 50);
        command.Parameters.Add("@reg_date", SqlDbType.VarChar, 50);
        command.Parameters.Add("@xvisible", SqlDbType.VarChar, 10);
        command.Parameters["@pwalletID"].Value = pwalletID;
        command.Parameters["@admin_status"].Value = admin_status;
        command.Parameters["@data_status"].Value = data_status;
        command.Parameters["@xcomment"].Value = xcomment;
        command.Parameters["@xdoc1"].Value = xdoc1;
        command.Parameters["@xdoc2"].Value = xdoc2;
        command.Parameters["@xdoc3"].Value = xdoc3;
        command.Parameters["@xofficer"].Value = xofficer;
        command.Parameters["@reg_date"].Value = str3;
        command.Parameters["@xvisible"].Value = "1";
        str = command.ExecuteScalar().ToString();
        connection.Close();
        if (str == "0")
        {
            return "0";
        }
        if (!(Convert.ToInt32(e_PwalletStatus(pwalletID, admin_status, data_status)).ToString() != "0"))
        {
            str = "0";
        }
        return str;
    }

    public string a_x_pt_office(string pwalletID, string admin_status, string data_status, string xcomment, string xdoc1, string xdoc2, string xdoc3, string xofficer)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO x_pt_office (pwalletID,admin_status,data_status,xcomment,xdoc1,xdoc2,xdoc3,xofficer,reg_date,xvisible) VALUES (@pwalletID,@admin_status,@data_status,@xcomment,@xdoc1,@xdoc2,@xdoc3,@xofficer,@reg_date,@xvisible) SELECT SCOPE_IDENTITY()";
        connection.Open();
        string str3 = DateTime.Now.ToString("yyyy-MM-dd");
        xdoc1 = xdoc1.Replace(" ", "_");
        xdoc2 = xdoc2.Replace(" ", "_");
        xdoc3 = xdoc3.Replace(" ", "_");
        command.Parameters.Add("@pwalletID", SqlDbType.VarChar, 50);
        command.Parameters.Add("@admin_status", SqlDbType.VarChar, 50);
        command.Parameters.Add("@data_status", SqlDbType.VarChar, 50);
        command.Parameters.Add("@xcomment", SqlDbType.Text);
        command.Parameters.Add("@xdoc1", SqlDbType.Text);
        command.Parameters.Add("@xdoc2", SqlDbType.Text);
        command.Parameters.Add("@xdoc3", SqlDbType.Text);
        command.Parameters.Add("@xofficer", SqlDbType.VarChar, 50);
        command.Parameters.Add("@reg_date", SqlDbType.VarChar, 50);
        command.Parameters.Add("@xvisible", SqlDbType.VarChar, 10);
        command.Parameters["@pwalletID"].Value = pwalletID;
        command.Parameters["@admin_status"].Value = admin_status;
        command.Parameters["@data_status"].Value = data_status;
        command.Parameters["@xcomment"].Value = xcomment;
        command.Parameters["@xdoc1"].Value = xdoc1;
        command.Parameters["@xdoc2"].Value = xdoc2;
        command.Parameters["@xdoc3"].Value = xdoc3;
        command.Parameters["@xofficer"].Value = xofficer;
        command.Parameters["@reg_date"].Value = str3;
        command.Parameters["@xvisible"].Value = "1";
        str = command.ExecuteScalar().ToString();
        connection.Close();
        if (str == "0")
        {
            return "0";
        }
        if (!(Convert.ToInt32(e_X_PwalletStatus(pwalletID, admin_status, data_status)).ToString() != "0"))
        {
            str = "0";
        }
        return str;
    }

    public List<ApplicationOfficer2> ApplicationOff(string startdate, string enddate)
    {
        string str = "";
        int sn = 1;

        SqlConnection connection = new SqlConnection(this.Connect());
        string format = "yyyy-MM-dd";
        var kk = Convert.ToDateTime(startdate).Date.ToString(format);
        var kk2 = Convert.ToDateTime(enddate).Date.ToString(format);
        SqlCommand command = new SqlCommand("select pt_office.data_status,pt_office.reg_date,validationid,pwalletid ,xname  from pt_office inner JOIN xadminz_pt ON xadminz_pt.xID=pt_office.xofficer inner JOIN pwallet on pwallet.id =pt_office.pwalletID where  pt_office.reg_date BETWEEN  '" + kk + "' AND '" + kk2 + "' union  select pt_office.data_status,pt_office.reg_date,validationid,pwalletid ,xname  from pt_office inner JOIN xadminz_pt ON xadminz_pt.xID=pt_office.xofficer inner JOIN x_pwallet on x_pwallet.id =pt_office.pwalletID where  pt_office.reg_date BETWEEN  '" + kk + "' AND '" + kk2 + "'    ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        List<ApplicationOfficer2> xk = new List<ApplicationOfficer2>();
        while (reader.Read())
        {
            ApplicationOfficer2 pp = new ApplicationOfficer2();
            pp.data_status = reader["data_status"].ToString();
            pp.sn = sn;
            pp.reg_date = reader["reg_date"].ToString();

            pp.Validationid = reader["validationid"].ToString();

            pp.pwalletid = reader["pwalletid"].ToString();
            pp.xname = reader["xname"].ToString();

            sn++;

            xk.Add(pp);
        }
        reader.Close();
        connection.Close();
        return xk;
    }

    public string a_xadminz(string uname, string xpass, string serverpath)
    {
        string path = serverpath + @"\Handlers\bf.kez";
        string xmlString = "";
        int dwKeySize = 0x400;
        if (File.Exists(path))
        {
            StreamReader reader = new StreamReader(path, true);
            xmlString = reader.ReadToEnd();
            reader.Close();
            if (xmlString != null)
            {
                string oldValue = xmlString.Substring(0, xmlString.IndexOf("</BitStrength>") + 14);
                xmlString = xmlString.Replace(oldValue, "");
            }
        }
        List<Adminz> list = new List<Adminz>();
        string str4 = Connect();
        string str5 = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("select xID,xemail,xpass from xadminz_pt where xvisible='1' ", connection);
        connection.Open();
        SqlDataReader reader2 = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader2.Read())
        {
            Adminz item = new Adminz
            {
                xID = reader2["xID"].ToString(),
                xemail = reader2["xemail"].ToString(),
                xpass = reader2["xpass"].ToString()
            };
            list.Add(item);
        }
        reader2.Close();
        string str6 = "";
        string str7 = "";
        Odyssey odyssey = new Odyssey();
        for (int i = 0; i < list.Count; i++)
        {
            str7 = odyssey.DecryptString(list[i].xemail, dwKeySize, xmlString);
            str6 = odyssey.DecryptString(list[i].xpass, dwKeySize, xmlString);
            if ((uname == str7) && (xpass == str6))
            {
                str5 = list[i].xID.ToString();
            }
        }
        return str5;
    }

    public string addAdminLog(string adminID, string ip_addy, string remote_host, string remote_user, string server_name, string server_url)
    {
        string str = DateTime.Today.Date.ToString("yyyy-MM-dd");
        string str2 = DateTime.Now.ToLongTimeString();
        string connectionString = Connect();
        string str4 = "0";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO admin_lg (adminID,ip_addy,remote_host,remote_user,server_name,server_url,log_date,log_time) VALUES (@adminID,@ip_addy,@remote_host,@remote_user,@server_name,@server_url,@log_date,@log_time) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@adminID", SqlDbType.VarChar, 200);
        command.Parameters.Add("@ip_addy", SqlDbType.Text);
        command.Parameters.Add("@remote_host", SqlDbType.Text);
        command.Parameters.Add("@remote_user", SqlDbType.Text);
        command.Parameters.Add("@server_name", SqlDbType.Text);
        command.Parameters.Add("@server_url", SqlDbType.Text);
        command.Parameters.Add("@log_date", SqlDbType.VarChar, 200);
        command.Parameters.Add("@log_time", SqlDbType.VarChar, 200);
        command.Parameters["@adminID"].Value = adminID;
        command.Parameters["@ip_addy"].Value = ip_addy;
        command.Parameters["@remote_host"].Value = remote_host;
        command.Parameters["@remote_user"].Value = remote_user;
        command.Parameters["@server_name"].Value = server_name;
        command.Parameters["@server_url"].Value = server_url;
        command.Parameters["@log_date"].Value = str;
        command.Parameters["@log_time"].Value = str2;
        str4 = command.ExecuteScalar().ToString();
        connection.Close();
        return str4;
    }

    public int addReversal(PtOffice c_tm_office)
    {
        string connectionString = Connect();
        int num = 0;
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO pt_office (pwalletID,admin_status,data_status,xcomment,xdoc1,xdoc2,xdoc3,xofficer,reg_date,xvisible) VALUES ('" + c_tm_office.pwalletID + "','" + c_tm_office.admin_status + "','" + c_tm_office.data_status + "','" + c_tm_office.xcomment + "','" + c_tm_office.xdoc1 + "','" + c_tm_office.xdoc2 + "','" + c_tm_office.xdoc3 + "','" + c_tm_office.xofficer + "','" + c_tm_office.reg_date + "','" + c_tm_office.xvisible + "') SELECT SCOPE_IDENTITY()";
        connection.Open();
        num = Convert.ToInt32(command.ExecuteScalar());
        if (num > 0)
        {
            SqlCommand command2 = connection.CreateCommand();
            command2.CommandText = "update pwallet set  status='" + c_tm_office.admin_status + "' ,data_status='" + c_tm_office.data_status + "' where ID='" + c_tm_office.pwalletID + "' ";
            num += command2.ExecuteNonQuery();
        }
        connection.Close();
        return num;
    }

    public string Connect()
    {
        return ConfigurationManager.ConnectionStrings["cldConnectionString"].ConnectionString;
    }

    public int e_Contact_formStatus(string xID, string sent_status)
    {
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE contact_form SET sent_status=@sent_status WHERE xID=@xID ";
        connection.Open();
        command.Parameters.Add("@xID", SqlDbType.BigInt);
        command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 1);
        command.Parameters["@xID"].Value = Convert.ToInt64(xID);
        command.Parameters["@sent_status"].Value = sent_status;
        int num = command.ExecuteNonQuery();
        connection.Close();
        return num;
    }

    public int e_PwalletStatus(string xID, string status, string data_status)
    {
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE pwallet SET status=@status,data_status=@data_status WHERE ID=@ID ";
        connection.Open();
        command.Parameters.Add("@ID", SqlDbType.BigInt);
        command.Parameters.Add("@status", SqlDbType.NVarChar, 20);
        command.Parameters.Add("@data_status", SqlDbType.NVarChar, 50);
        command.Parameters["@ID"].Value = Convert.ToInt64(xID);
        command.Parameters["@status"].Value = status;
        command.Parameters["@data_status"].Value = data_status;
        int num = command.ExecuteNonQuery();
        connection.Close();
        return num;
    }

    public int e_regadmin(string xname, string xpass, string xrole, string xemail, string telephone1, string telephone2, string xsection, string pwalletID, string xID, string visible)
    {
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE xadminz_pt SET xname=@xname,xpass=@xpass,xroleID=@xroleID,xemail=@xemail,xtelephone1=@xtelephone1,xtelephone2=@xtelephone2,xsection=@xsection,xlog_officer=@pwalletID,xvisible=@xvisible WHERE xID=@xID ";
        connection.Open();
        command.Parameters.Add("@xID", SqlDbType.BigInt);
        command.Parameters.Add("@xname", SqlDbType.NVarChar);
        command.Parameters.Add("@xpass", SqlDbType.Text);
        command.Parameters.Add("@xroleID", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@xemail", SqlDbType.Text);
        command.Parameters.Add("@xtelephone1", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@xtelephone2", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@xsection", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@pwalletID", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@xvisible", SqlDbType.NVarChar, 1);
        command.Parameters["@xID"].Value = xID;
        command.Parameters["@xname"].Value = xname;
        command.Parameters["@xpass"].Value = xpass;
        command.Parameters["@xroleID"].Value = xrole;
        command.Parameters["@xemail"].Value = xemail;
        command.Parameters["@xtelephone1"].Value = telephone1;
        command.Parameters["@xtelephone2"].Value = telephone2;
        command.Parameters["@xsection"].Value = xsection;
        command.Parameters["@pwalletID"].Value = pwalletID;
        command.Parameters["@xvisible"].Value = visible;
        int num = command.ExecuteNonQuery();
        connection.Close();
        if (num > 0)
        {
            num = Convert.ToInt32(xID);
        }
        return num;
    }

    public int e_X_PwalletLogStatus(string xID, string xcode)
    {
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE x_pwallet SET log_officer=@log_officer WHERE ID=@ID ";
        connection.Open();
        command.Parameters.Add("@ID", SqlDbType.BigInt);
        command.Parameters.Add("@log_officer", SqlDbType.NVarChar, 50);
        command.Parameters["@ID"].Value = Convert.ToInt64(xID);
        command.Parameters["@log_officer"].Value = xcode;
        int num = command.ExecuteNonQuery();
        connection.Close();
        return num;
    }

    public int e_X_PwalletStatus(string xID, string status, string data_status)
    {
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE x_pwallet SET status=@status,data_status=@data_status WHERE ID=@ID ";
        connection.Open();
        command.Parameters.Add("@ID", SqlDbType.BigInt);
        command.Parameters.Add("@status", SqlDbType.NVarChar, 20);
        command.Parameters.Add("@data_status", SqlDbType.NVarChar, 50);
        command.Parameters["@ID"].Value = Convert.ToInt64(xID);
        command.Parameters["@status"].Value = status;
        command.Parameters["@data_status"].Value = data_status;
        int num = command.ExecuteNonQuery();
        connection.Close();
        return num;
    }

    public string e_xadminz(string xID, string xpass)
    {
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE xadminz_pt SET xpass=@xpass WHERE xID=@xID ";
        connection.Open();
        command.Parameters.Add("@xID", SqlDbType.BigInt);
        command.Parameters.Add("@xpass", SqlDbType.Text);
        command.Parameters["@xID"].Value = Convert.ToInt64(xID);
        command.Parameters["@xpass"].Value = xpass;
        string str = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str;
    }

    public string formatDate(string date)
    {
        if ((date == "") || (date == null))
        {
            date = DateTime.Today.Date.ToString("MM/dd/yyyy");
        }
        string str = "";
        string str2 = date.Substring(0, 2);
        string str3 = date.Substring(3, 2);
        str = date.Substring(6, 4);
        return (str + "-" + str2 + "-" + str3);
    }

    public string formatSearchDate(string date)
    {
        string str = "";
        string str2 = "";
        string str3 = "";
        string str4 = "";
        if (date != "")
        {
            str = "";
            str2 = date.Substring(0, 2);
            str3 = date.Substring(3, 2);
            str = date.Substring(6, 4);
            str4 = str + "-" + str2 + "-" + str3;
        }
        return str4;
    }

    public List<PtInfo> getAcceptedRS(string stage)
    {
        List<PtInfo> list = new List<PtInfo>();
        new PtInfo();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("select * from pt_info LEFT OUTER JOIN pwallet ON pt_info.log_staff=pwallet.ID WHERE pwallet.status >='" + stage + "' ORDER BY xID DESC", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            PtInfo item = new PtInfo
            {
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = reader["title_of_invention"].ToString(),
                pt_desc = reader["pt_desc"].ToString(),
                spec_doc = reader["spec_doc"].ToString(),
                loa_no = reader["loa_no"].ToString(),
                loa_doc = reader["loa_doc"].ToString(),
                claim_no = reader["claim_no"].ToString(),
                claim_doc = reader["claim_doc"].ToString(),
                pct_no = reader["pct_no"].ToString(),
                pct_doc = reader["pct_doc"].ToString(),
                doa_no = reader["doa_no"].ToString(),
                doa_doc = reader["doa_doc"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                xvisible = reader["xvisible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public long getAcceptedRSCnt(string status)
    {
        long num = 0L;
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("select Count(*) AS cnt from pt_info LEFT OUTER JOIN pwallet ON pt_info.log_staff=cast (pwallet.ID as  Varchar) WHERE pwallet.stage='5' AND pwallet.status>='" + status + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            num = Convert.ToInt64(reader["cnt"]);
        }
        reader.Close();
        return num;
    }

    public List<PtInfo> getAcceptedRSX(string status, string start, string limit)
    {
        List<PtInfo> list = new List<PtInfo>();
        new PtInfo();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("WITH RSTbl AS (select pt_info.xID,pt_info.reg_number,pt_info.title_of_invention,pt_info.xtype,pt_info.reg_date,pt_info.log_staff, ROW_NUMBER() OVER (ORDER BY pt_info.xID) AS 'RowRank' from pt_info LEFT OUTER JOIN pwallet ON pt_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status >='" + status + "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            PtInfo item = new PtInfo
            {
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = reader["title_of_invention"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<PtInfo> getAcceptedRSX2(string status, string start, string limit)
    {
        List<PtInfo> list = new List<PtInfo>();
        new PtInfo();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("select pt_info.xID,pt_info.reg_number,applicant.xname,pt_info.title_of_invention,pt_info.xtype,pt_info.reg_date,pt_info.log_staff  from pt_info LEFT OUTER JOIN pwallet ON pt_info.log_staff=cast (pwallet.ID as  Varchar)  LEFT OUTER JOIN  applicant ON pt_info.log_staff=applicant.log_staff WHERE pwallet.stage='5' AND pwallet.status >='" + status + "' order by pwallet.ID  ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        Int32 vsn = 0;
        zues z = new zues();
        while (reader.Read())
        {
            vsn=vsn+1;
            String voffice = z.getPtOfficeByMID(reader["log_staff"].ToString());
            PtInfo item = new PtInfo
            {
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = reader["title_of_invention"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                Office = voffice,
                Sn=Convert.ToString(vsn) ,
                xname = reader["xname"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public string GetAddressTags(string select_search)
    {
        return "";
    }

    public Adminz getAdminDetails(string ID)
    {
        Adminz adminz = new Adminz();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * from xadminz_pt where xID='" + ID + "'", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            adminz.xID = reader["xID"].ToString();
            adminz.xroleID = reader["xroleID"].ToString();
            adminz.xname = reader["xname"].ToString();
            adminz.xemail = reader["xemail"].ToString();
            adminz.xpass = reader["xpass"].ToString();
            adminz.xtelephone1 = reader["xtelephone1"].ToString();
            adminz.xtelephone2 = reader["xtelephone2"].ToString();
            adminz.xsection = reader["xsection"].ToString();
            adminz.xlog_officer = reader["xlog_officer"].ToString();
            adminz.xreg_date = reader["xreg_date"].ToString();
            adminz.xvisible = reader["xvisible"].ToString();
        }
        reader.Close();
        return adminz;
    }

    public List<PtInfo> getAdminSearchAcceptedRS(string status, string criteria, List<string> fulltext, string dateFrom, string dateTo)
    {
        List<PtInfo> list = new List<PtInfo>();
        new PtInfo();
        string cmdText = "";
        string str2 = "";
        string str3 = "";
        string str4 = "";
        int num = 0;
        SqlConnection connection = new SqlConnection(Connect());
        if (criteria == "product_title")
        {
            num = fulltext.Count - 1;
            str2 = "select * from pt_info LEFT OUTER JOIN pwallet ON pt_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status >='" + status + "'  AND ";
            for (int i = 0; i < fulltext.Count; i++)
            {
                if (fulltext.Count == 1)
                {
                    str3 = str3 + " ( title_of_invention like '%" + fulltext[i] + "%' ) ";
                }
                else if (num == i)
                {
                    str3 = str3 + " ( title_of_invention like '%" + fulltext[i] + "%' ) ";
                }
                else
                {
                    str3 = str3 + " ( title_of_invention like '%" + fulltext[i] + "%' ) OR";
                }
            }
            str4 = "AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC";
            cmdText = str2 + str3 + str4;
        }
        else if (criteria == "app_number")
        {
            cmdText = "select * from pt_info LEFT OUTER JOIN pwallet ON pt_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status >='" + status + "' AND pt_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
        }
        SqlCommand command = new SqlCommand(cmdText, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            PtInfo item = new PtInfo
            {
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = reader["title_of_invention"].ToString(),
                pt_desc = reader["pt_desc"].ToString(),
                spec_doc = reader["spec_doc"].ToString(),
                loa_no = reader["loa_no"].ToString(),
                loa_doc = reader["loa_doc"].ToString(),
                claim_no = reader["claim_no"].ToString(),
                claim_doc = reader["claim_doc"].ToString(),
                pct_no = reader["pct_no"].ToString(),
                pct_doc = reader["pct_doc"].ToString(),
                doa_no = reader["doa_no"].ToString(),
                doa_doc = reader["doa_doc"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                xvisible = reader["xvisible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<PtInfo> getAdminSearchPtInfoRS(string status, string data_status, string criteria, List<string> fulltext, string dateFrom, string dateTo)
    {
        List<PtInfo> list = new List<PtInfo>();
        new PtInfo();
        string cmdText = "";
        string str2 = "";
        string str3 = "";
        string str4 = "";
        int num = 0;
        SqlConnection connection = new SqlConnection(Connect());
        if (criteria == "product_title")
        {
            num = fulltext.Count - 1;
            str2 = "select * from pt_info LEFT OUTER JOIN pwallet ON pt_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' AND ";
            for (int i = 0; i < fulltext.Count; i++)
            {
                if (fulltext.Count == 1)
                {
                    str3 = str3 + " ( title_of_invention like '%" + fulltext[i] + "%' ) ";
                }
                else if (num == i)
                {
                    str3 = str3 + " ( title_of_invention like '%" + fulltext[i] + "%' ) ";
                }
                else
                {
                    str3 = str3 + " ( title_of_invention like '%" + fulltext[i] + "%' ) OR";
                }
            }
            str4 = "AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC";
            cmdText = str2 + str3 + str4;
        }
        else if (criteria == "app_number")
        {
            cmdText = "select * from pt_info LEFT OUTER JOIN pwallet ON pt_info.log_staff=pwallet.ID WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' AND pt_info.reg_number like  '%" + fulltext[0] + "%' AND pwallet.reg_date between '" + dateFrom + "' AND '" + dateTo + "'  ORDER BY xID ASC ";
        }
        SqlCommand command = new SqlCommand(cmdText, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            PtInfo item = new PtInfo
            {
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = reader["title_of_invention"].ToString(),
                pt_desc = reader["pt_desc"].ToString(),
                spec_doc = reader["spec_doc"].ToString(),
                loa_no = reader["loa_no"].ToString(),
                loa_doc = reader["loa_doc"].ToString(),
                claim_no = reader["claim_no"].ToString(),
                claim_doc = reader["claim_doc"].ToString(),
                pct_no = reader["pct_no"].ToString(),
                pct_doc = reader["pct_doc"].ToString(),
                doa_no = reader["doa_no"].ToString(),
                doa_doc = reader["doa_doc"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                xvisible = reader["xvisible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public string getAdmiPriv(string ID)
    {
        string str = "0";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT priv from roles where priv='" + ID + "'", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["priv"].ToString();
        }
        reader.Close();
        return str;
    }

    public List<PtInfo> getPtInfoByDataStatusRS(string stage, string data_status)
    {
        List<PtInfo> list = new List<PtInfo>();
        new PtInfo();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("select * from pt_info LEFT OUTER JOIN pt_office ON pt_info.log_staff=pt_office.pwalletID WHERE pt_office.admin_status='" + stage + "' AND pt_office.data_status='" + data_status + "' ORDER BY xID DESC", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            PtInfo item = new PtInfo
            {
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = reader["title_of_invention"].ToString(),
                pt_desc = reader["pt_desc"].ToString(),
                spec_doc = reader["spec_doc"].ToString(),
                loa_no = reader["loa_no"].ToString(),
                loa_doc = reader["loa_doc"].ToString(),
                claim_no = reader["claim_no"].ToString(),
                claim_doc = reader["claim_doc"].ToString(),
                pct_no = reader["pct_no"].ToString(),
                pct_doc = reader["pct_doc"].ToString(),
                doa_no = reader["doa_no"].ToString(),
                doa_doc = reader["doa_doc"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                xvisible = reader["xvisible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<PtInfo> getPtInfoByUserID(string ID)
    {
        List<PtInfo> list = new List<PtInfo>();
        new PtInfo();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM pt_info WHERE log_staff='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            PtInfo item = new PtInfo
            {
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = reader["title_of_invention"].ToString(),
                pt_desc = reader["pt_desc"].ToString(),
                spec_doc = reader["spec_doc"].ToString(),
                loa_no = reader["loa_no"].ToString(),
                loa_doc = reader["loa_doc"].ToString(),
                claim_no = reader["claim_no"].ToString(),
                claim_doc = reader["claim_doc"].ToString(),
                pct_no = reader["pct_no"].ToString(),
                pct_doc = reader["pct_doc"].ToString(),
                doa_no = reader["doa_no"].ToString(),
                doa_doc = reader["doa_doc"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                xvisible = reader["xvisible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<PtInfo> getPtInfoRS(string stage)
    {
        List<PtInfo> list = new List<PtInfo>();
        new PtInfo();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("select * from pt_info LEFT OUTER JOIN pwallet ON pt_info.log_staff=pwallet.ID WHERE pwallet.status='" + stage + "' ORDER BY xID DESC", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            PtInfo item = new PtInfo
            {
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = reader["title_of_invention"].ToString(),
                pt_desc = reader["pt_desc"].ToString(),
                spec_doc = reader["spec_doc"].ToString(),
                loa_no = reader["loa_no"].ToString(),
                loa_doc = reader["loa_doc"].ToString(),
                claim_no = reader["claim_no"].ToString(),
                claim_doc = reader["claim_doc"].ToString(),
                pct_no = reader["pct_no"].ToString(),
                pct_doc = reader["pct_doc"].ToString(),
                doa_no = reader["doa_no"].ToString(),
                doa_doc = reader["doa_doc"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                xvisible = reader["xvisible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public long getPtInfoRSCnt(string status, string data_status)
    {
        long num = 0L;
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("select Count(*) AS cnt from pt_info LEFT OUTER JOIN pwallet ON pt_info.log_staff=cast (pwallet.ID as  Varchar) WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            num = Convert.ToInt64(reader["cnt"]);
        }
        reader.Close();
        return num;
    }

    public List<PtInfo> getPtInfoRSX(string status, string data_status, string start, string limit)
    {
        List<PtInfo> list = new List<PtInfo>();
        new PtInfo();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("WITH RSTbl AS (select pt_info.xID,pt_info.reg_number,pt_info.title_of_invention,pt_info.xtype,pt_info.reg_date,pt_info.log_staff, ROW_NUMBER() OVER (ORDER BY pt_info.reg_number) AS 'RowRank' from pt_info LEFT OUTER JOIN pwallet ON pt_info.log_staff=cast (pwallet.ID as  Varchar) WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '" + start + "' AND '" + limit + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            PtInfo item = new PtInfo
            {
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = reader["title_of_invention"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<PtInfo> getPtInfoRSX2(string status, string data_status, string start, string limit)
    {
        List<PtInfo> list = new List<PtInfo>();
        new PtInfo();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("select '' as  description, pt_info.xID,pt_info.reg_number,pt_info.title_of_invention,applicant.xname ,pt_info.xtype,pt_info.reg_date,pt_info.log_staff from pt_info inner  JOIN pwallet ON pt_info.log_staff=cast (pwallet.ID as  Varchar)  inner join  applicant ON pt_info.log_staff=applicant.log_staff WHERE pwallet.stage='5' AND pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "'  order by pt_info.upload_date desc ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        zues z = new zues();
        int sn = 0;
        while (reader.Read())
        {
            sn = sn + 1;
            String pvalidation = z.getValidationIDFromPtInfo(reader["xID"].ToString());
            String voffice = z.getPtOfficeByMID(reader["log_staff"].ToString());
            if (voffice == "")
            {
                voffice = "None";
            }
            PtInfo item = new PtInfo
            {
               
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = reader["title_of_invention"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                Validation = pvalidation,
                Office = voffice,
                Sn=Convert.ToString(sn),
                moveapp = reader["description"].ToString(),
                xname = reader["xname"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }
    public int g_pwalletStatus2(string xID, string sent_status, string sent_status2)
    {
        SqlConnection connection = new SqlConnection(this.Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE pwallet SET status=@sent_status,data_status=@sent_status2 WHERE validationid=@xID ";
        connection.Open();
        command.Parameters.Add("@xID", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 50);
        command.Parameters["@xID"].Value = xID;
        command.Parameters["@sent_status"].Value = sent_status;
        command.Parameters["@sent_status2"].Value = sent_status2;
        int num = command.ExecuteNonQuery();
        connection.Close();
        return num;
    }


    public String CheckLogin(Login pp)
    {
        SqlConnection connection = new SqlConnection(this.Connect());

        string str = "0";
        string cmdText = "";
        string xadmin = "";


        cmdText = "SELECT count(*) as count FROM xadminz_pt  where CONVERT(VARCHAR, xemail)='" + pp.Email + "'  and CONVERT(VARCHAR, xpass) ='' ";

        SqlCommand command = new SqlCommand(cmdText, connection)
        {
            CommandTimeout = 0
        };
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["count"].ToString();
        }
        int vcount = Convert.ToInt32(str);
        if (vcount > 0)
        {
            xadmin = CheckLogin2(pp.Email);
        }

        else
        {
            xadmin = CheckLogin3(pp);
        }

        reader.Close();
        connection.Close();

        return xadmin;

    }

    public string CheckLogin2(string email)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(this.Connect());
        SqlCommand command = new SqlCommand("SELECT xID from xadminz_pt where CONVERT(VARCHAR, xemail)='" + email + "'  and CONVERT(VARCHAR, xpass) =''", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["xID"].ToString();
        }
        reader.Close();
        connection.Close();
        return str;
    }

    public string CheckLogin3(Login cf)
    {
        string str = "";

        SqlConnection connection = new SqlConnection(this.Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO xadminz_pt (xroleID,xname,xemail,xpass) VALUES (@pwalletID,@response_deadline,@xofficerID,@xmsg) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@pwalletID", SqlDbType.VarChar, 50);
        command.Parameters.Add("@response_deadline", SqlDbType.VarChar, 50);
        command.Parameters.Add("@xofficerID", SqlDbType.VarChar);
        command.Parameters.Add("@xmsg", SqlDbType.VarChar);


        command.Parameters["@pwalletID"].Value = "1";
        command.Parameters["@response_deadline"].Value = cf.name;
        command.Parameters["@xofficerID"].Value = cf.Email;
        command.Parameters["@xmsg"].Value = "";

        str = command.ExecuteScalar().ToString();
        connection.Close();
        return str;
    }

    public int g_pwalletStatus3(string xID, string sent_status, string sent_status2)
    {
        SqlConnection connection = new SqlConnection(this.Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE x_pwallet  SET status=@sent_status,data_status=@sent_status2 WHERE validationid=@xID ";
        connection.Open();
        command.Parameters.Add("@xID", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 50);
        command.Parameters["@xID"].Value = xID;
        command.Parameters["@sent_status"].Value = sent_status;
        command.Parameters["@sent_status2"].Value = sent_status2;
        int num = command.ExecuteNonQuery();
        connection.Close();
        return num;
    }


    public List<PtInfo> getPtInfoSlipPlusRS(string stage)
    {
        List<PtInfo> list = new List<PtInfo>();
        new PtInfo();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT pt_info.*  FROM pwallet LEFT OUTER JOIN pt_info ON cast (pwallet.ID as  Varchar)=pt_info.log_staff WHERE pwallet.status >= '" + stage + "' AND pt_info.log_staff IN (Select ID  FROM pwallet) ORDER BY ID DESC", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            PtInfo item = new PtInfo
            {
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = reader["title_of_invention"].ToString(),
                pt_desc = reader["pt_desc"].ToString(),
                spec_doc = reader["spec_doc"].ToString(),
                loa_no = reader["loa_no"].ToString(),
                loa_doc = reader["loa_doc"].ToString(),
                claim_no = reader["claim_no"].ToString(),
                claim_doc = reader["claim_doc"].ToString(),
                pct_no = reader["pct_no"].ToString(),
                pct_doc = reader["pct_doc"].ToString(),
                doa_no = reader["doa_no"].ToString(),
                doa_doc = reader["doa_doc"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                xvisible = reader["xvisible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<PtInfo> getPtInfoSlipRS(string stage, string status)
    {
        List<PtInfo> list = new List<PtInfo>();
        new PtInfo();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT pt_info.*  FROM pt_info LEFT OUTER JOIN pwallet ON pt_info.log_staff=cast (pwallet.ID as  Varchar) LEFT OUTER JOIN pt_office ON pwallet.ID=pt_office.pwalletID  WHERE pt_office.admin_status = '" + stage + "' AND pt_office.data_status='" + status + "' AND pt_info.log_staff IN (Select pwallet.ID  FROM pwallet) ORDER BY pwallet.ID DESC", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            PtInfo item = new PtInfo
            {
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = reader["title_of_invention"].ToString(),
                pt_desc = reader["pt_desc"].ToString(),
                spec_doc = reader["spec_doc"].ToString(),
                loa_no = reader["loa_no"].ToString(),
                loa_doc = reader["loa_doc"].ToString(),
                claim_no = reader["claim_no"].ToString(),
                claim_doc = reader["claim_doc"].ToString(),
                pct_no = reader["pct_no"].ToString(),
                pct_doc = reader["pct_doc"].ToString(),
                doa_no = reader["doa_no"].ToString(),
                doa_doc = reader["doa_doc"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                xvisible = reader["xvisible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<PtInfo> getPtInfoXRS(string stage, string status)
    {
        List<PtInfo> list = new List<PtInfo>();
        new PtInfo();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT pt_info.*  FROM pwallet LEFT OUTER JOIN pt_info ON cast (pwallet.ID as  Varchar)=pt_info.log_staff LEFT OUTER JOIN pt_office ON pt_office.pwalletID=pt_info.log_staff WHERE pwallet.status = '" + stage + "'  AND pt_office.data_status='" + status + "' AND pt_info.log_staff IN (Select pwallet.ID  FROM pwallet) ORDER BY pwallet.ID DESC", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            PtInfo item = new PtInfo
            {
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = reader["title_of_invention"].ToString(),
                pt_desc = reader["pt_desc"].ToString(),
                spec_doc = reader["spec_doc"].ToString(),
                loa_no = reader["loa_no"].ToString(),
                loa_doc = reader["loa_doc"].ToString(),
                claim_no = reader["claim_no"].ToString(),
                claim_doc = reader["claim_doc"].ToString(),
                pct_no = reader["pct_no"].ToString(),
                pct_doc = reader["pct_doc"].ToString(),
                doa_no = reader["doa_no"].ToString(),
                doa_doc = reader["doa_doc"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                xvisible = reader["xvisible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public string getPtOfficeByMID(string pwalletID)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT data_status from pt_office where pwalletID='" + pwalletID + "'", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["data_status"].ToString();
        }
        reader.Close();
        return str;
    }

    public List<PtOffice> getPtOfficeDetailsByID(string ID)
    {
        List<PtOffice> list = new List<PtOffice>();
        new Pwallet();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM pt_office WHERE pwalletID='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            PtOffice item = new PtOffice
            {
                ID = reader["ID"].ToString(),
                pwalletID = reader["pwalletID"].ToString(),
                admin_status = reader["admin_status"].ToString(),
                data_status = reader["data_status"].ToString(),
                xcomment = reader["xcomment"].ToString(),
                xdoc1 = reader["xdoc1"].ToString(),
                xdoc2 = reader["xdoc2"].ToString(),
                xdoc3 = reader["xdoc3"].ToString(),
                xofficer = reader["xofficer"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                xvisible = reader["xvisible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }


    public List<PtOffice> getPtOfficeDetailsByID3(string ID)
    {
        List<PtOffice> list = new List<PtOffice>();
        new Pwallet();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT pt_office.xcomment,xadminz_pt.xname FROM pt_office inner join xadminz_pt on pt_office.xofficer = xadminz_pt.xid   WHERE pt_office.pwalletid='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            PtOffice item = new PtOffice
            {
                //ID = reader["ID"].ToString(),
                //pwalletID = reader["pwalletID"].ToString(),
                //admin_status = reader["admin_status"].ToString(),
                //data_status = reader["data_status"].ToString(),
                xcomment = reader["xcomment"].ToString(),
                //xdoc1 = reader["xdoc1"].ToString(),
                //xdoc2 = reader["xdoc2"].ToString(),
                //xdoc3 = reader["xdoc3"].ToString(),
                xofficer = reader["xname"].ToString()
                //reg_date = reader["reg_date"].ToString(),
                //xvisible = reader["xvisible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }
    public long getPublishPtInfoRSCnt(string status, string data_status)
    {
        long num = 0L;
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("select Count(*) AS cnt from pt_info LEFT OUTER JOIN pwallet ON pt_info.log_staff=cast (pwallet.ID as  Varchar) WHERE (pwallet.stage='5' AND pwallet.status = '" + status + "' AND pwallet.data_status = '" + data_status + "') OR (pwallet.stage='5' AND pwallet.status ='6') OR (pwallet.stage='5' AND pwallet.status ='7') OR (pwallet.stage='5' AND pwallet.status ='8') OR (pwallet.stage='5' AND pwallet.status ='9') OR (pwallet.stage='5' AND pwallet.status ='10') ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            num = Convert.ToInt64(reader["cnt"]);
        }
        reader.Close();
        return num;
    }

    public List<Pwallet> getPwalletDetailsByID(string ID)
    {
        List<Pwallet> list = new List<Pwallet>();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE ID='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Pwallet item = new Pwallet
            {
                ID = reader["ID"].ToString(),
                applicantID = reader["applicantID"].ToString(),
                validationID = reader["validationID"].ToString(),
                stage = reader["stage"].ToString(),
                status = reader["status"].ToString(),
                data_status = reader["data_status"].ToString(),
                amt = reader["amt"].ToString(),
                reg_date = reader["reg_date"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public int getRenPtInfoRSCnt(string status, string data_status)
    {
        int num = 0;
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("select Count(*) AS cnt from renewal LEFT OUTER JOIN x_pwallet ON renewal.log_staff=x_pwallet.ID WHERE x_pwallet.stage='5' AND x_pwallet.status='" + status + "' AND x_pwallet.data_status='" + data_status + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            num = Convert.ToInt32(reader["cnt"]);
        }
        reader.Close();
        return num;
    }

   

    public List<Renewal> getRenPtInfoRSX(string status, string data_status, string item_code, int start, int limit)
    {
        List<Renewal> list = new List<Renewal>();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select renewal.xID,renewal.reg_no,renewal.app_no,renewal.title,renewal.type,renewal.reg_date,renewal.log_staff, ROW_NUMBER() OVER (ORDER BY renewal.reg_no) AS 'RowRank' from renewal LEFT OUTER JOIN x_pwallet ON renewal.log_staff=x_pwallet.ID WHERE x_pwallet.stage='5' AND x_pwallet.status='", status, "' AND x_pwallet.data_status='", data_status, "' AND x_pwallet.item_code='", item_code, "' )SELECT * FROM RSTbl  WHERE RowRank BETWEEN '", start, "' AND '", limit, "' " }), connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Renewal item = new Renewal
            {
                xID = reader["xID"].ToString(),
                reg_no = reader["reg_no"].ToString(),
                app_no = reader["app_no"].ToString(),
                type = reader["type"].ToString(),
                title = reader["title"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<Renewal> getRenPtInfoRSX4(string status, string data_status, string item_code, int start, int limit)
    {
        List<Renewal> list = new List<Renewal>();
        SqlConnection connection = new SqlConnection(Connect());
       // SqlCommand command = new SqlCommand(string.Concat(new object[] { "select renewal.last_rwl_date as 'cnt',renewal.agt_code , renewal.xID,renewal.reg_no,renewal.app_no,renewal.title,renewal.type,renewal.reg_date,renewal.log_staff,renewal.app_date  from renewal LEFT OUTER JOIN x_pwallet ON renewal.log_staff=x_pwallet.ID WHERE x_pwallet.stage='5' AND x_pwallet.status='", status, "' AND x_pwallet.data_status='", data_status, "' AND x_pwallet.item_code='", item_code, "'  order by  x_pwallet.ID " }), connection);

        SqlCommand command = new SqlCommand(string.Concat(new object[] { "select '' as  description,x_pwallet.validationID, renewal.last_rwl_date as 'cnt',renewal.agt_code , renewal.xID,renewal.reg_no,renewal.app_no,renewal.title,renewal.type,renewal.reg_date,renewal.log_staff,renewal.app_date  from renewal LEFT OUTER JOIN x_pwallet ON renewal.log_staff=x_pwallet.ID WHERE x_pwallet.stage='5' AND x_pwallet.status='", status, "' AND x_pwallet.data_status='", data_status, "'   order by  x_pwallet.ID " }), connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        Int32 vsn = 0;
        DateTime  dd =DateTime.Now;
        while (reader.Read())
        {
            vsn = vsn + 1;
            try
            {
                dd = Convert.ToDateTime(reader["cnt"].ToString()).AddYears(1);
            }
            catch (Exception ee)
            {
              //  dd = null;
            }

            string format = "yyyy-MM-dd"; 

            Renewal item = new Renewal
            {
                

                
                xID = reader["xID"].ToString(),
                reg_no = reader["reg_no"].ToString(),
                app_no = reader["app_no"].ToString(),
                type = reader["type"].ToString(),
                title = reader["title"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                last_rwl_date = reader["cnt"].ToString(),
                app_date = getApproval(reader["log_staff"].ToString()) ,
                

                Sn =Convert.ToString(vsn),
                agt_code = reader["agt_code"].ToString() ,
                Due_Date = dd.ToString(format),
                moveapp = reader["description"].ToString(),
                validationID = reader["validationID"].ToString()


            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }


    public String  getApproval(string log_staff)
    {
       
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand(string.Concat(new object[] { "select reg_date  from x_pt_office  WHERE data_status='Approved' AND pwalletid='", log_staff, "'  " }), connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        Int32 vsn = 0;
       String dd = "";
        while (reader.Read())
        {
            vsn = vsn + 1;
            try
            {
                dd = reader["reg_date"].ToString();
            }
            catch (Exception ee)
            {
                //  dd = null;
            }

           
        }
        reader.Close();
        return dd;
    }

    public List<Renewal2> getRenPtInfoRSX4b(string status, string data_status, string item_code, int start, int limit)
    {
        List<Renewal2> list = new List<Renewal2>();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand(string.Concat(new object[] { "select renewal.last_rwl_date as 'cnt',renewal.agt_code , renewal.xID,renewal.reg_no,renewal.app_no,renewal.title,renewal.type,renewal.reg_date,renewal.log_staff,renewal.xname ,renewal.app_date,x_pwallet.validationid from renewal LEFT OUTER JOIN x_pwallet ON renewal.log_staff=x_pwallet.ID WHERE x_pwallet.stage='5' AND x_pwallet.status='", status, "' AND x_pwallet.data_status='", data_status, "' AND x_pwallet.item_code='", item_code, "'  order by  x_pwallet.ID " }), connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        Int32 vsn = 0;
        DateTime dd = DateTime.Now;
        while (reader.Read())
        {
            vsn = vsn + 1;
            try
            {
                dd = Convert.ToDateTime(reader["cnt"].ToString()).AddYears(1);
            }
            catch (Exception ee)
            {
                //  dd = null;
            }

            string format = "yyyy-MM-dd";

            Renewal2 item = new Renewal2
            {



               Applicant_name = reader["xname"].ToString(),
                last_renewal_date = reader["cnt"].ToString(),
                due_date = dd.ToString(format),
                registration_date= reader["reg_date"].ToString(),
              title_of_patent  = reader["title"].ToString(),
               patent_type = reader["type"].ToString(),
               app_date = getApproval(reader["log_staff"].ToString()) ,
               TransactionId = reader["ValidationId"].ToString()

            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<Renewal> getRenPtInfoRSX2(string status, string data_status, string item_code, string title)
    {
        List<Renewal> list = new List<Renewal>();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select renewal.xID,renewal.reg_no,renewal.app_no,renewal.title,renewal.type,renewal.reg_date,renewal.log_staff  from renewal LEFT OUTER JOIN x_pwallet ON renewal.log_staff=x_pwallet.ID WHERE x_pwallet.stage='5' AND x_pwallet.status='", status, "' AND x_pwallet.data_status='", data_status, "' AND x_pwallet.item_code='", item_code, "' )SELECT * FROM RSTbl  WHERE   title like '%" + title + "%'  " }), connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Renewal item = new Renewal
            {
                xID = reader["xID"].ToString(),
                reg_no = reader["reg_no"].ToString(),
                app_no = reader["app_no"].ToString(),
                type = reader["type"].ToString(),
                title = reader["title"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<Renewal> getRenPtInfoRSX3(string status, string data_status, string item_code, string title)
    {
        List<Renewal> list = new List<Renewal>();
        SqlConnection connection = new SqlConnection(Connect());

        SqlCommand command = new SqlCommand(string.Concat(new object[] { "WITH RSTbl AS (select renewal.xID,renewal.reg_no,renewal.app_no,renewal.title,renewal.type,renewal.reg_date,renewal.log_staff  from renewal LEFT OUTER JOIN x_pwallet ON renewal.log_staff=x_pwallet.ID WHERE x_pwallet.stage='5' AND x_pwallet.status='", status, "' AND x_pwallet.data_status='", data_status, "' AND x_pwallet.item_code='", item_code, "' )SELECT * FROM RSTbl  WHERE   reg_no='", title, "'  " }), connection);
        
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Renewal item = new Renewal
            {
                xID = reader["xID"].ToString(),
                reg_no = reader["reg_no"].ToString(),
                app_no = reader["app_no"].ToString(),
                type = reader["type"].ToString(),
                title = reader["title"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }



    public string getRoleByID(string id)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT xroleID from xadminz_pt where xID='" + id + "'", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["xroleID"].ToString();
        }
        reader.Close();
        return str;
    }

    public string getRoleNameByID(string ID)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT name FROM roles WHERE priv='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["name"].ToString();
        }
        reader.Close();
        return str;
    }

    public List<Adminz> getTmAdminDetailsByID(string ID)
    {
        List<Adminz> list = new List<Adminz>();
        new Pwallet();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM xadminz_pt WHERE xID='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Adminz item = new Adminz
            {
                xID = reader["xID"].ToString(),
                xroleID = reader["xroleID"].ToString(),
                xname = reader["xname"].ToString(),
                xemail = reader["xemail"].ToString(),
                xpass = reader["xpass"].ToString(),
                xtelephone1 = reader["xtelephone1"].ToString(),
                xtelephone2 = reader["xtelephone2"].ToString(),
                xsection = reader["xsection"].ToString(),
                xlog_officer = reader["xlog_officer"].ToString(),
                xreg_date = reader["xreg_date"].ToString(),
                xvisible = reader["xvisible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public Adminz getTopAdminDetails()
    {
        Adminz adminz = new Adminz();
        SqlConnection connection = new SqlConnection(Connect());
        string cmdText = "SELECT top 1 * from xadminz_pt";
        SqlCommand command = new SqlCommand(cmdText, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            adminz.xID = reader["xID"].ToString();
            adminz.xroleID = reader["xroleID"].ToString();
            adminz.xname = reader["xname"].ToString();
            adminz.xemail = reader["xemail"].ToString();
            adminz.xpass = reader["xpass"].ToString();
            adminz.xtelephone1 = reader["xtelephone1"].ToString();
            adminz.xtelephone2 = reader["xtelephone2"].ToString();
            adminz.xsection = reader["xsection"].ToString();
            adminz.xlog_officer = reader["xlog_officer"].ToString();
            adminz.xreg_date = reader["xreg_date"].ToString();
            adminz.xvisible = reader["xvisible"].ToString();
        }
        reader.Close();
        return adminz;
    }

    public string getTotalEntries(string unit)
    {
        string str = "0";
        string cmdText = "";
        SqlConnection connection = new SqlConnection(Connect());
        if (unit != "")
        {
            cmdText = "SELECT count(*) as count FROM pwallet  where status='" + unit + "'";
        }
        else
        {
            cmdText = "SELECT count(*) as count FROM pwallet ";
        }
        SqlCommand command = new SqlCommand(cmdText, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["count"].ToString();
        }
        reader.Close();
        return str;
    }

    public string getTotalEntriesByDate(string unit, string xfrom, string xto)
    {
        string str = "0";
        string cmdText = "";
        SqlConnection connection = new SqlConnection(Connect());
        if (unit != "")
        {
            cmdText = "SELECT count(*) as count FROM pwallet  where (status='" + unit + "') AND (reg_date BETWEEN '" + xfrom + "' AND '" + xto + "') ";
        }
        else
        {
            cmdText = "SELECT count(*) as count FROM pwallet WHERE reg_date BETWEEN '" + xfrom + "' AND '" + xto + "' ";
        }
        SqlCommand command = new SqlCommand(cmdText, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["count"].ToString();
        }
        reader.Close();
        return str;
    }

    public string getTotalEntryCountByStage(string stage, string status)
    {
        string str = "0";
        string cmdText = "";
        SqlConnection connection = new SqlConnection(Connect());
        if (status == "")
        {
            cmdText = "SELECT count(*) as count FROM pwallet  where status > '" + stage + "' ";
        }
        else
        {
            cmdText = "SELECT count(*) as count FROM pwallet  where status='" + stage + "' AND data_status='" + status + "' ";
        }
        SqlCommand command = new SqlCommand(cmdText, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["count"].ToString();
        }
        reader.Close();
        return str;
    }

    public string getTotalEntryCountStageByDate(string stage, string status, string xfrom, string xto)
    {
        string str = "0";
        string cmdText = "";
        SqlConnection connection = new SqlConnection(Connect());
        if (status == "")
        {
            cmdText = "SELECT count(*) as count FROM pwallet  where (status >'" + stage + "')  AND (reg_date BETWEEN '" + xfrom + "' AND '" + xto + "' ) ";
        }
        else
        {
            cmdText = "SELECT count(*) as count FROM pwallet  where (status='" + stage + "') AND (data_status='" + status + "') AND (reg_date BETWEEN '" + xfrom + "' AND '" + xto + "' ) ";
        }
        SqlCommand command = new SqlCommand(cmdText, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["count"].ToString();
        }
        reader.Close();
        return str;
    }

    public string getValidationIDFromPtInfo(string ID)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("select validationID from pwallet where ID IN ( select log_staff from pt_info where xID='" + ID + "' ) ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["validationID"].ToString();
        }
        reader.Close();
        connection.Close();
        return str;
    }

    public List<XPtOffice> getXPtOfficeDetailsByID(string ID)
    {
        List<XPtOffice> list = new List<XPtOffice>();
        new Pwallet();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM x_pt_office WHERE pwalletID='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            XPtOffice item = new XPtOffice
            {
                ID = reader["ID"].ToString(),
                pwalletID = reader["pwalletID"].ToString(),
                admin_status = reader["admin_status"].ToString(),
                data_status = reader["data_status"].ToString(),
                xcomment = reader["xcomment"].ToString(),
                xdoc1 = reader["xdoc1"].ToString(),
                xdoc2 = reader["xdoc2"].ToString(),
                xdoc3 = reader["xdoc3"].ToString(),
                xofficer = reader["xofficer"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                xvisible = reader["xvisible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public class Adminz
    {
        public string xemail { get; set; }

        public string xID { get; set; }

        public string xlog_officer { get; set; }

        public string xname { get; set; }

        public string xpass { get; set; }

        public string xreg_date { get; set; }

        public string xroleID { get; set; }

        public string xsection { get; set; }

        public string xtelephone1 { get; set; }

        public string xtelephone2 { get; set; }

        public string xvisible { get; set; }
    }

    public class Contact_form
    {
        public string pwalletID { get; set; }

        public string reg_date { get; set; }

        public string response_deadline { get; set; }

        public string sent_status { get; set; }

        public string xID { get; set; }

        public string xmsg { get; set; }

        public string xofficerID { get; set; }

        public string xvisible { get; set; }
    }

    public class PtInfo
    {
        public string claim_doc { get; set; }

        public string claim_no { get; set; }

        public string doa_doc { get; set; }

        public string doa_no { get; set; }

        public string loa_doc { get; set; }

        public string loa_no { get; set; }

        public string log_staff { get; set; }

        public string pct_doc { get; set; }

        public string pct_no { get; set; }

        public string pt_desc { get; set; }

        public string reg_date { get; set; }

        public string reg_number { get; set; }

        public string spec_doc { get; set; }

        public string title_of_invention { get; set; }

        public string xID { get; set; }

        public string xstat { get; set; }

        public string xtype { get; set; }

        public string xvisible { get; set; }

        public string Validation { get; set; }

        public string Office { get; set; }

        public string Sn { get; set; }

        public string xname { get; set; }

        public string description { get; set; }

        public string moveapp { get; set; }


    }

    public class PtOffice
    {
        public string admin_status { get; set; }

        public string data_status { get; set; }

        public string ID { get; set; }

        public string pwalletID { get; set; }

        public string reg_date { get; set; }

        public string xcomment { get; set; }

        public string xdoc1 { get; set; }

        public string xdoc2 { get; set; }

        public string xdoc3 { get; set; }

        public string xofficer { get; set; }

        public string xvisible { get; set; }
    }

    public class Pwallet
    {
        public string amt { get; set; }

        public string applicantID { get; set; }

        public string data_status { get; set; }

        public string ID { get; set; }

        public string reg_date { get; set; }

        public string stage { get; set; }

        public string status { get; set; }

        public string validationID { get; set; }

        public string visible { get; set; }
    }

    public class Renewal
    {
       
          public string validationID { get; set; }
        public string agt_addy { get; set; }

        public string agt_code { get; set; }

        public string agt_email { get; set; }

        public string agt_mobile { get; set; }

        public string agt_name { get; set; }

        public string app_date { get; set; }

        public string app_no { get; set; }

        public string last_rwl_date { get; set; }
        public string Due_Date { get; set; }

        public string log_staff { get; set; }

        public string reg_date { get; set; }

        public string reg_no { get; set; }

        public string reg_time { get; set; }

        public string sync { get; set; }

        public string title { get; set; }

        public string type { get; set; }

        public string visible { get; set; }

        public string xaddy { get; set; }

        public string xemail { get; set; }

        public string xID { get; set; }

        public string xmobile { get; set; }

        public string xname { get; set; }

        public string xstat { get; set; }

        //  public string Last_Renewal_Date { get; set; }

       
        public string Sn { get; set; }

        public string description { get; set; }

        public string moveapp { get; set; }
    }

    public class Renewal2
    {
        public string Applicant_name { get; set; }

        public string TransactionId { get; set; }


        public string last_renewal_date { get; set; }

        public string due_date { get; set; }

        public string registration_date { get; set; }

        public string title_of_patent { get; set; }

        public string patent_type { get; set; }

        public string app_date { get; set; }

    }


    public class XPtOffice
    {
        public string admin_status { get; set; }

        public string data_status { get; set; }

        public string ID { get; set; }

        public string pwalletID { get; set; }

        public string reg_date { get; set; }

        public string xcomment { get; set; }

        public string xdoc1 { get; set; }

        public string xdoc2 { get; set; }

        public string xdoc3 { get; set; }

        public string xofficer { get; set; }

        public string xvisible { get; set; }
    }

    public class XPwallet
    {
        public string amt { get; set; }

        public string applicantID { get; set; }

        public string data_status { get; set; }

        public string ID { get; set; }

        public string item_code { get; set; }

        public string reg_date { get; set; }

        public string stage { get; set; }

        public string status { get; set; }

        public string validationID { get; set; }
    }
}

