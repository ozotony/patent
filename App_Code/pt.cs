  using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;
using System.Transactions;
using System.Web;
using System.Threading;

public class pt
{
    public string getRegNumber(Int32 ID)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT reg_number FROM pt_info WHERE xID=" + ID, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["reg_number"].ToString();
        }
        reader.Close();
        return str;
    }

    public string addAddress(Address c_app_addy, string pwalletID)
    {
        string str = DateTime.Today.Date.ToString("yyyy-MM-dd");
        string str2 = "1";
        if (c_app_addy.countryID == null)
        {
            c_app_addy.countryID = "";
        }
        if (c_app_addy.stateID == null)
        {
            c_app_addy.stateID = "";
        }
        if (c_app_addy.city == null)
        {
            c_app_addy.city = "";
        }
        if (c_app_addy.street == null)
        {
            c_app_addy.street = "";
        }
        if (c_app_addy.telephone1 == null)
        {
            c_app_addy.telephone1 = "";
        }
        if (c_app_addy.email1 == null)
        {
            c_app_addy.email1 = "";
        }
        string connectionString = Connect();
        string str4 = "0";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO address (countryID,stateID,city,street,telephone1,email1,log_staff,reg_date,visible) VALUES (@countryID,@stateID,@city,@street,@telephone1,@email1,@log_staff,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@countryID", SqlDbType.VarChar, 10);
        command.Parameters.Add("@stateID", SqlDbType.NVarChar, 10);
        command.Parameters.Add("@city", SqlDbType.VarChar, 40);
        command.Parameters.Add("@street", SqlDbType.Text);
        command.Parameters.Add("@telephone1", SqlDbType.NVarChar, 40);
        command.Parameters.Add("@email1", SqlDbType.VarChar, 40);
        command.Parameters.Add("@log_staff", SqlDbType.VarChar, 40);
        command.Parameters.Add("@reg_date", SqlDbType.VarChar, 40);
        command.Parameters.Add("@visible", SqlDbType.VarChar, 1);
        command.Parameters["@countryID"].Value = c_app_addy.countryID;
        command.Parameters["@stateID"].Value = c_app_addy.stateID;
        command.Parameters["@city"].Value = c_app_addy.city;
        command.Parameters["@street"].Value = ConvertApos2Tab(c_app_addy.street);
        command.Parameters["@telephone1"].Value = c_app_addy.telephone1;
        command.Parameters["@email1"].Value = ConvertApos2Tab(c_app_addy.email1);
        command.Parameters["@log_staff"].Value = pwalletID;
        command.Parameters["@reg_date"].Value = str;
        command.Parameters["@visible"].Value = str2;
        str4 = command.ExecuteScalar().ToString();
        connection.Close();
        return str4;
    }

    public string addAos(AddressService c_aos, string pwalletID)
    {
        string str = DateTime.Today.Date.ToString("yyyy-MM-dd");
        string str2 = "1";
        if (c_aos.countryID == null)
        {
            c_aos.countryID = "";
        }
        if (c_aos.stateID == null)
        {
            c_aos.stateID = "";
        }
        if (c_aos.city == null)
        {
            c_aos.city = "";
        }
        if (c_aos.street == null)
        {
            c_aos.street = "";
        }
        if (c_aos.telephone1 == null)
        {
            c_aos.telephone1 = "";
        }
        if (c_aos.email1 == null)
        {
            c_aos.email1 = "";
        }
        string connectionString = Connect();
        string str4 = "0";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO address_service (countryID,stateID,city,street,telephone1,email1,log_staff,reg_date,visible) VALUES (@countryID,@stateID,@city,@street,@telephone1,@email1,@log_staff,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@countryID", SqlDbType.VarChar, 10);
        command.Parameters.Add("@stateID", SqlDbType.NVarChar, 10);
        command.Parameters.Add("@city", SqlDbType.VarChar, 40);
        command.Parameters.Add("@street", SqlDbType.Text);
        command.Parameters.Add("@telephone1", SqlDbType.NVarChar, 40);
        command.Parameters.Add("@email1", SqlDbType.VarChar, 40);
        command.Parameters.Add("@log_staff", SqlDbType.VarChar, 40);
        command.Parameters.Add("@reg_date", SqlDbType.VarChar, 40);
        command.Parameters.Add("@visible", SqlDbType.VarChar, 1);
        command.Parameters["@countryID"].Value = c_aos.countryID;
        command.Parameters["@stateID"].Value = c_aos.stateID;
        command.Parameters["@city"].Value = c_aos.city;
        command.Parameters["@street"].Value = ConvertApos2Tab(c_aos.street);
        command.Parameters["@telephone1"].Value = c_aos.telephone1;
        command.Parameters["@email1"].Value = ConvertApos2Tab(c_aos.email1);
        command.Parameters["@log_staff"].Value = pwalletID;
        command.Parameters["@reg_date"].Value = str;
        command.Parameters["@visible"].Value = str2;
        str4 = command.ExecuteScalar().ToString();
        connection.Close();
        return str4;
    }

    public string addApplicant(Applicant c_app)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO applicant (xname,address,xemail,xmobile,nationality,log_staff,visible) VALUES (@xname,@address,@xemail,@xmobile,@nationality,@log_staff,@visible) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@xname", SqlDbType.VarChar);
        command.Parameters.Add("@address", SqlDbType.Text);
        command.Parameters.Add("@xemail", SqlDbType.VarChar);
        command.Parameters.Add("@xmobile", SqlDbType.VarChar);
        command.Parameters.Add("@nationality", SqlDbType.VarChar, 50);
        command.Parameters.Add("@log_staff", SqlDbType.VarChar, 20);
        command.Parameters.Add("@visible", SqlDbType.VarChar, 10);
        command.Parameters["@xname"].Value = ConvertApos2Tab(c_app.xname);
        command.Parameters["@address"].Value = ConvertApos2Tab(c_app.address);
        command.Parameters["@xemail"].Value = ConvertApos2Tab(c_app.xemail);
        command.Parameters["@xmobile"].Value = c_app.xmobile;
        command.Parameters["@nationality"].Value = c_app.nationality;
        command.Parameters["@log_staff"].Value = c_app.log_staff;
        command.Parameters["@visible"].Value = c_app.visible;
        str2 = command.ExecuteScalar().ToString();
        connection.Close();
        return str2;
    }

    public string addAssignment_info(Assignment_info c_ass)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO assignment_info (date_of_assignment,assignee_name,assignee_address,assignee_nationality,assignor_name,assignor_address,assignor_nationality,log_staff,xvisible) VALUES (@date_of_assignment,@assignee_name,@assignee_address,@assignee_nationality,@assignor_name,@assignor_address,@assignor_nationality,@log_staff,@xvisible) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@date_of_assignment", SqlDbType.VarChar, 50);
        command.Parameters.Add("@assignee_name", SqlDbType.VarChar);
        command.Parameters.Add("@assignee_address", SqlDbType.Text);
        command.Parameters.Add("@assignee_nationality", SqlDbType.VarChar, 50);
        command.Parameters.Add("@assignor_name", SqlDbType.VarChar);
        command.Parameters.Add("@assignor_address", SqlDbType.Text);
        command.Parameters.Add("@assignor_nationality", SqlDbType.VarChar, 50);
        command.Parameters.Add("@log_staff", SqlDbType.VarChar, 50);
        command.Parameters.Add("@xvisible", SqlDbType.VarChar, 10);
        command.Parameters["@date_of_assignment"].Value = c_ass.date_of_assignment;
        command.Parameters["@assignee_name"].Value = ConvertApos2Tab(c_ass.assignee_name);
        command.Parameters["@assignee_address"].Value = ConvertApos2Tab(c_ass.assignee_address);
        command.Parameters["@assignee_nationality"].Value = c_ass.assignee_nationality;
        command.Parameters["@assignor_name"].Value = ConvertApos2Tab(c_ass.assignor_name);
        command.Parameters["@assignor_address"].Value = ConvertApos2Tab(c_ass.assignor_address);
        command.Parameters["@assignor_nationality"].Value = c_ass.assignor_nationality;
        command.Parameters["@log_staff"].Value = c_ass.log_staff;
        command.Parameters["@xvisible"].Value = c_ass.visible;
        str2 = command.ExecuteScalar().ToString();
        connection.Close();
        return str2;
    }

    public string addInventor(Inventor c_inv)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO inventor (xname,address,xemail,xmobile,nationality,log_staff,visible) VALUES (@xname,@address,@xemail,@xmobile,@nationality,@log_staff,@visible) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@xname", SqlDbType.VarChar);
        command.Parameters.Add("@address", SqlDbType.Text);
        command.Parameters.Add("@xemail", SqlDbType.VarChar);
        command.Parameters.Add("@xmobile", SqlDbType.VarChar);
        command.Parameters.Add("@nationality", SqlDbType.VarChar, 50);
        command.Parameters.Add("@log_staff", SqlDbType.VarChar, 20);
        command.Parameters.Add("@visible", SqlDbType.VarChar, 10);
        command.Parameters["@xname"].Value = ConvertApos2Tab(c_inv.xname);
        command.Parameters["@address"].Value = ConvertApos2Tab(c_inv.address);
        command.Parameters["@xemail"].Value = ConvertApos2Tab(c_inv.xemail);
        command.Parameters["@xmobile"].Value = c_inv.xmobile;
        command.Parameters["@nationality"].Value = c_inv.nationality;
        command.Parameters["@log_staff"].Value = c_inv.log_staff;
        command.Parameters["@visible"].Value = c_inv.visible;
        str2 = command.ExecuteScalar().ToString();
        connection.Close();
        return str2;
    }

    public string addNewPatent(List<Applicant> lt_app, List<Priority_info> lt_pri, List<Inventor> lt_inv, PtInfo c_pt, Assignment_info c_assinfo, Representative c_rep)
    {
        string xID = "";
        foreach (Applicant applicant in lt_app)
        {
            if ((applicant.xname != null) && (applicant.xname != ""))
            {
             addApplicant(applicant);
            }
        }
        foreach (Priority_info _info in lt_pri)
        {
            if ((_info.app_no != null) && (_info.app_no != ""))
            {
             addPriority_info(_info);
            }
        }
        foreach (Inventor inventor in lt_inv)
        {
            if ((inventor.xname != null) && (inventor.xname != ""))
            {
             addInventor(inventor);
            }
        }
        if ((((c_assinfo.assignee_name != null) && (c_assinfo.assignee_name != "")) && (c_assinfo.date_of_assignment != null)) && (c_assinfo.date_of_assignment != ""))
        {
         addAssignment_info(c_assinfo);
        }
        xID = addPt(c_pt);
     updatePtReg(xID, c_pt.xtype);
     addRepresentative(c_rep);
     updatePwalletStatus(c_pt.log_staff, "0");
        return xID;
    }

    public int addNewPatentX(List<Applicant> lt_app, List<Priority_info> lt_pri, List<Inventor> lt_inv, PtInfo c_pt, Assignment_info c_assinfo, Representative c_rep, string transID, string agent, string amt, string hwalletID)
    {
        //try
        //{
            SqlConnection connection;
            SqlCommand command;
            string commandText;
            object obj2;
            string connectionString = Connect();
            string str2 = ConnectXpay();
            string reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
            string data_status = "Fresh";
            string stage = "5";
            string visible = "1";
            string status = "1";
            int num = 0;
            int num2 = 0;
            using (connection = new SqlConnection(connectionString))
            {
                using (command = connection.CreateCommand())
                {
                    //command.CommandText = "INSERT INTO pwallet (validationID,applicantID,log_officer,amt,stage,status,data_status,reg_date,visible ) ";
                    //command.CommandTimeout = 300;
                    //commandText = command.CommandText;
                    //command.CommandText = commandText + " VALUES ('" + transID + "','" + agent + "','0','" + amt + "','" + stage + "','" + status + "','" + data_status + "','" + reg_date + "','" + visible + "' ) ";
                    //command.CommandText = command.CommandText + " SELECT SCOPE_IDENTITY()";

                    command.CommandText = "INSERT INTO pwallet (validationID,applicantID,log_officer,amt,stage,status,data_status,reg_date,visible ) ";
                 //   command.CommandTimeout = 300;
                    commandText = command.CommandText;
                    command.CommandText = commandText + " VALUES (@transID ,@agent ,'0',@amt ,@stage ,@status ,@data_status ,@reg_date ,@visible ) ";
                    command.CommandText = command.CommandText + " SELECT SCOPE_IDENTITY()";



                    command.Connection.Open();

                    command.Parameters.Add("@transID", SqlDbType.NVarChar);
                    command.Parameters.Add("@agent", SqlDbType.NVarChar);
                    command.Parameters.Add("@amt", SqlDbType.NVarChar);
                    command.Parameters.Add("@stage", SqlDbType.NVarChar);
                    command.Parameters.Add("@status", SqlDbType.NVarChar);
                    command.Parameters.Add("@data_status", SqlDbType.NVarChar);
                    command.Parameters.Add("@reg_date", SqlDbType.NVarChar);
                    command.Parameters.Add("@visible", SqlDbType.NVarChar);

                    command.Parameters["@transID"].Value = transID;
                    command.Parameters["@agent"].Value = agent;
                    command.Parameters["@amt"].Value = amt;
                    command.Parameters["@stage"].Value = stage;
                    command.Parameters["@status"].Value = status;
                    command.Parameters["@data_status"].Value = data_status;
                    command.Parameters["@reg_date"].Value = reg_date;
                    command.Parameters["@visible"].Value = visible;

                    foreach (SqlParameter Parameter in command.Parameters)
                    {
                        if (Parameter.Value == null)
                        {
                            Parameter.Value = DBNull.Value;
                        }
                    }

                    num = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            using (connection = new SqlConnection(connectionString))
            {
                using (command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO representative (agent_code,xname,nationality,country,state,address,xemail,xmobile,log_staff,visible) ";
                 //   command.CommandTimeout = 300; 
                    obj2 = command.CommandText;
                    //command.CommandText = string.Concat(new object[] { 
                    //obj2, " VALUES ('", c_rep.agent_code, "','", c_rep.xname, "','", c_rep.nationality, "','", c_rep.country, "','", c_rep.state, "','", c_rep.address, "','", c_rep.xemail, "','", 
                    //c_rep.xmobile, "','", num, "','", visible, "' ) "

                    command.CommandText = string.Concat(new object[] { 
                    obj2, " VALUES (@agent_code, @xname, @nationality,@country, @state, @address,@xemail, @xmobile, @num,@visible) "
                 });
                    command.CommandText = command.CommandText + " SELECT SCOPE_IDENTITY()";


                    command.Connection.Open();

                    command.Parameters.Add("@agent_code", SqlDbType.NVarChar);
                    command.Parameters.Add("@xname", SqlDbType.NVarChar);
                    command.Parameters.Add("@nationality", SqlDbType.NVarChar);
                    command.Parameters.Add("@country", SqlDbType.NVarChar);
                    command.Parameters.Add("@state", SqlDbType.NVarChar);
                    command.Parameters.Add("@address", SqlDbType.NVarChar);
                    command.Parameters.Add("@xemail", SqlDbType.NVarChar);
                    command.Parameters.Add("@xmobile", SqlDbType.NVarChar);
                    command.Parameters.Add("@num", SqlDbType.NVarChar);
                    command.Parameters.Add("@visible", SqlDbType.NVarChar);

                    command.Parameters["@agent_code"].Value = c_rep.agent_code;
                    command.Parameters["@xname"].Value = c_rep.xname;
                    command.Parameters["@nationality"].Value = c_rep.nationality;
                    command.Parameters["@country"].Value = c_rep.country;
                    command.Parameters["@state"].Value = c_rep.state;
                    command.Parameters["@address"].Value = c_rep.address;
                    command.Parameters["@xemail"].Value = c_rep.xemail;
                    command.Parameters["@xmobile"].Value = c_rep.xmobile;
                    command.Parameters["@num"].Value = num;
                    command.Parameters["@visible"].Value = visible;

                    foreach (SqlParameter Parameter in command.Parameters)
                    {
                        if (Parameter.Value == null)
                        {
                            Parameter.Value = DBNull.Value;
                        }
                    }

                    Convert.ToInt32(command.ExecuteScalar());
                }
            }
            using (connection = new SqlConnection(connectionString))
            {
                using (command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO pt_Info (reg_number,xtype,title_of_invention,pt_desc,spec_doc,loa_no,loa_doc,claim_no,claim_doc,pct_no,pct_doc,doa_no,doa_doc,log_staff,reg_date,xvisible) ";
                   // command.CommandTimeout = 300; 
                    commandText = command.CommandText;
                    //command.CommandText = commandText + " VALUES ('" + c_pt.reg_number + "','" + c_pt.xtype + "','" + c_pt.title_of_invention + "','" + c_pt.pt_desc + "','','','','','','', ";
                    //obj2 = command.CommandText;
                    //command.CommandText = string.Concat(new object[] { obj2, "  '','','','", num, "','", reg_date, "','", visible, "' ) " });

                    command.CommandText = commandText + " VALUES (@reg_number ,@xtype,@title_of_invention ,@pt_desc ,'','','','','','', ";
                    obj2 = command.CommandText;
                    command.CommandText = string.Concat(new object[] { obj2, "  '','','','", num, "','", reg_date, "','", visible, "' ) " });
                    command.CommandText = command.CommandText + " SELECT SCOPE_IDENTITY()";
                    command.Connection.Open();

                    command.Parameters.Add("@reg_number", SqlDbType.NVarChar);
                    command.Parameters.Add("@xtype", SqlDbType.NVarChar);
                    command.Parameters.Add("@title_of_invention", SqlDbType.NVarChar);
                    command.Parameters.Add("@pt_desc", SqlDbType.NVarChar);

                    command.Parameters["@reg_number"].Value = c_pt.reg_number;
                    command.Parameters["@xtype"].Value = c_pt.xtype;
                    command.Parameters["@title_of_invention"].Value = c_pt.title_of_invention;
                    command.Parameters["@pt_desc"].Value = c_pt.pt_desc;

                    foreach (SqlParameter Parameter in command.Parameters)
                    {
                        if (Parameter.Value == null)
                        {
                            Parameter.Value = DBNull.Value;
                        }
                    }


                    num2 = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            if ((((c_assinfo.assignee_name != null) && (c_assinfo.assignee_name != "")) && (c_assinfo.date_of_assignment != null)) && (c_assinfo.date_of_assignment != ""))
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO assignment_info (date_of_assignment,assignee_name,assignee_address,assignee_nationality,assignor_name,assignor_address,assignor_nationality,log_staff,xvisible) ";
                    //    command.CommandTimeout = 300; 
                        commandText = command.CommandText;
                        command.CommandText = commandText + " VALUES ('" + c_assinfo.date_of_assignment + "','" + c_assinfo.assignee_name + "','" + c_assinfo.assignee_address + "','" + c_assinfo.assignee_nationality + "', ";
                        obj2 = command.CommandText;
                        command.CommandText = string.Concat(new object[] { obj2, " '", c_assinfo.assignor_name, "','", c_assinfo.assignor_address, "','", c_assinfo.assignor_nationality, "','", num, "','", visible, "' ) " });
                        command.CommandText = command.CommandText + " SELECT SCOPE_IDENTITY()";
                        command.Connection.Open();
                        Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            foreach (Priority_info _info in lt_pri)
            {
                if ((_info.app_no != null) && (_info.app_no != ""))
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO priority_info (countryID,app_no,xdate,log_staff,xvisible) ";
                            command.CommandTimeout = 300; 
                            obj2 = command.CommandText;
                            command.CommandText = string.Concat(new object[] { obj2, " VALUES ('", _info.countryID, "','", _info.app_no, "','", _info.xdate, "','", num, "','", visible, "' ) " });
                            command.CommandText = command.CommandText + " SELECT SCOPE_IDENTITY()";
                            command.Connection.Open();
                            Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                }
            }
            foreach (Inventor inventor in lt_inv)
            {
                if ((inventor.xname != null) && (inventor.xname != ""))
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO inventor (xname,address,xemail,xmobile,nationality,log_staff,visible) ";
                            command.CommandTimeout = 300; 
                            obj2 = command.CommandText;
                            //command.CommandText = string.Concat(new object[] { obj2, " VALUES ('", inventor.xname, "','", inventor.address, "','", inventor.xemail, "','", inventor.xmobile, "','", inventor.nationality, "','", num, "','", visible, "') " });
                            command.CommandText = string.Concat(new object[] { obj2, " VALUES (@xname,@address, @xemail,@xmobile,@nationality, @num, @visible) " });
                            command.CommandText = command.CommandText + " SELECT SCOPE_IDENTITY()";
                            command.Connection.Open();
                            command.Parameters.Add("@xname", SqlDbType.NVarChar);
                            command.Parameters.Add("@address", SqlDbType.NVarChar);
                            command.Parameters.Add("@xemail", SqlDbType.NVarChar);
                            command.Parameters.Add("@xmobile", SqlDbType.NVarChar);
                            command.Parameters.Add("@nationality", SqlDbType.NVarChar);
                            command.Parameters.Add("@num", SqlDbType.NVarChar);
                            command.Parameters.Add("@visible", SqlDbType.NVarChar);

                            command.Parameters["@xname"].Value = inventor.xname;
                            command.Parameters["@address"].Value = inventor.address;
                            command.Parameters["@xemail"].Value = inventor.xemail;
                            command.Parameters["@xmobile"].Value = inventor.xmobile;
                            command.Parameters["@nationality"].Value = inventor.nationality;
                            command.Parameters["@num"].Value = num;
                            command.Parameters["@visible"].Value = visible;
                            foreach (SqlParameter Parameter in command.Parameters)
                            {
                                if (Parameter.Value == null)
                                {
                                    Parameter.Value = DBNull.Value;
                                }
                            }

                            Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                }
            }
            foreach (Applicant applicant in lt_app)
            {
                if ((applicant.xname != null) && (applicant.xname != ""))
                {
                    using (connection = new SqlConnection(connectionString))
                    {
                        using (command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO applicant (xname,address,xemail,xmobile,nationality,log_staff,visible) ";
                          //  command.CommandTimeout = 300; 
                            obj2 = command.CommandText;
                            //command.CommandText = string.Concat(new object[] { obj2, " VALUES ('", applicant.xname, "','", applicant.address, "','", applicant.xemail, "','", applicant.xmobile, "','", applicant.nationality, "','", num, "','", visible, "' ) " });
                            command.CommandText = string.Concat(new object[] { obj2, " VALUES (@xname,@address, @xemail, @xmobile, @nationality,@num,@visible) " });
                            command.CommandText = command.CommandText + " SELECT SCOPE_IDENTITY()";
                            command.Connection.Open();

                            command.Parameters.Add("@xname", SqlDbType.NVarChar);
                            command.Parameters.Add("@address", SqlDbType.NVarChar);
                            command.Parameters.Add("@xemail", SqlDbType.NVarChar);
                            command.Parameters.Add("@xmobile", SqlDbType.NVarChar);
                            command.Parameters.Add("@nationality", SqlDbType.NVarChar);
                            command.Parameters.Add("@num", SqlDbType.NVarChar);
                            command.Parameters.Add("@visible", SqlDbType.NVarChar);

                            command.Parameters["@xname"].Value = applicant.xname;
                            command.Parameters["@address"].Value = applicant.address;
                            command.Parameters["@xemail"].Value = applicant.xemail;
                            command.Parameters["@xmobile"].Value = applicant.xmobile;
                            command.Parameters["@nationality"].Value = applicant.nationality;
                            command.Parameters["@num"].Value = num;
                            command.Parameters["@visible"].Value = visible;

                            foreach (SqlParameter Parameter in command.Parameters)
                            {
                                if (Parameter.Value == null)
                                {
                                    Parameter.Value = DBNull.Value;
                                }
                            }

                            Convert.ToInt32(command.ExecuteScalar());
                        }
                    }
                }
            }
            using (connection = new SqlConnection(connectionString))
            {
                using (command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE pwallet SET stage=5,log_officer='0' WHERE ID='" + num + "' ";
                    command.CommandTimeout = 300; 
                    command.Connection.Open();
                    Convert.ToInt32(command.ExecuteNonQuery());
                }
            }
            string str8 = "";
            if (c_pt.xtype.ToUpper() == "NON-CONVENTIONAL")
            {
                str8 = string.Concat(new object[] { "NG/PT/NC/", DateTime.Today.Date.ToString("yyyy"), "/", num2 });
          //  str8 = string.Concat(new object[] { "F/PT/C/", DateTime.Today.Date.ToString("yyyy"), "/", num2 });

        }
            else
            {
         //   str8 = string.Concat(new object[] { "F/PT/C/", DateTime.Today.Date.ToString("yyyy"), "/", num2 });
            str8 = string.Concat(new object[] { "NG/PT/C/", DateTime.Today.Date.ToString("yyyy"), "/", num2 });
            }
            using (connection = new SqlConnection(connectionString))
            {
                using (command = connection.CreateCommand())
                {
                    command.CommandText = string.Concat(new object[] { "UPDATE pt_info SET reg_number='", str8, "'  WHERE xID='", num2, "' " });
                    command.CommandTimeout = 300; 
                    command.Connection.Open();
                    Convert.ToInt32(command.ExecuteNonQuery());
                }
            }
            return num2;
        //}
        //catch (Exception ee)
        //{
        //    XWriter2 pp = new XWriter2();
        //    string message = transID + " " + DateTime.Now;

        //    string vpath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Patent/" + transID + ".txt";

        //    pp.WriteToFile(message, vpath);
        //  //  num2 = 0;
        //    return 0;

        //}
    }

    public string addPriority_info(Priority_info c_pri)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO priority_info (countryID,app_no,xdate,log_staff,xvisible) VALUES (@countryID,@app_no,@xdate,@log_staff,@xvisible) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@countryID", SqlDbType.VarChar, 50);
        command.Parameters.Add("@app_no", SqlDbType.VarChar);
        command.Parameters.Add("@xdate", SqlDbType.VarChar, 50);
        command.Parameters.Add("@log_staff", SqlDbType.VarChar, 20);
        command.Parameters.Add("@xvisible", SqlDbType.VarChar, 10);
        command.Parameters["@countryID"].Value = c_pri.countryID;
        command.Parameters["@app_no"].Value = c_pri.app_no;
        command.Parameters["@xdate"].Value = c_pri.xdate;
        command.Parameters["@log_staff"].Value = c_pri.log_staff;
        command.Parameters["@xvisible"].Value = c_pri.xvisible;
        str2 = command.ExecuteScalar().ToString();
        connection.Close();
        return str2;
    }

    public string addPt(PtInfo c_pt)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO pt_Info (reg_number,xtype,title_of_invention,pt_desc,spec_doc,loa_no,loa_doc,claim_no,claim_doc,pct_no,pct_doc,doa_no,doa_doc,log_staff,reg_date,xvisible) VALUES (@reg_number,@xtype,@title_of_invention,@pt_desc,@spec_doc,@loa_no,@loa_doc,@claim_no,@claim_doc,@pct_no,@pct_doc,@doa_no,@doa_doc,@log_staff,@reg_date,@xvisible) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@reg_number", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@xtype", SqlDbType.NVarChar);
        command.Parameters.Add("@title_of_invention", SqlDbType.NVarChar);
        command.Parameters.Add("@pt_desc", SqlDbType.Text);
        command.Parameters.Add("@spec_doc", SqlDbType.Text);
        command.Parameters.Add("@loa_no", SqlDbType.NVarChar, 20);
        command.Parameters.Add("@loa_doc", SqlDbType.Text);
        command.Parameters.Add("@claim_no", SqlDbType.NVarChar, 20);
        command.Parameters.Add("@claim_doc", SqlDbType.Text);
        command.Parameters.Add("@pct_no", SqlDbType.NVarChar, 20);
        command.Parameters.Add("@pct_doc", SqlDbType.Text);
        command.Parameters.Add("@doa_no", SqlDbType.NVarChar, 20);
        command.Parameters.Add("@doa_doc", SqlDbType.Text);
        command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@xvisible", SqlDbType.NVarChar, 10);
        command.Parameters["@reg_number"].Value = c_pt.reg_number;
        command.Parameters["@xtype"].Value = c_pt.xtype;
        command.Parameters["@title_of_invention"].Value = ConvertApos2Tab(c_pt.title_of_invention);
        command.Parameters["@pt_desc"].Value = ConvertApos2Tab(c_pt.pt_desc);
        command.Parameters["@spec_doc"].Value = "";
        command.Parameters["@loa_no"].Value = c_pt.loa_no;
        command.Parameters["@loa_doc"].Value = "";
        command.Parameters["@claim_no"].Value = c_pt.claim_no;
        command.Parameters["@claim_doc"].Value = "";
        command.Parameters["@pct_no"].Value = c_pt.pct_no;
        command.Parameters["@pct_doc"].Value = "";
        command.Parameters["@doa_no"].Value = c_pt.doa_no;
        command.Parameters["@doa_doc"].Value = "";
        command.Parameters["@log_staff"].Value = c_pt.log_staff;
        command.Parameters["@reg_date"].Value = c_pt.reg_date;
        command.Parameters["@xvisible"].Value = c_pt.xvisible;
        str = command.ExecuteScalar().ToString();
        connection.Close();
        return str;
    }

    public string addPwallet(string serverpath, string validationID, string agent_code, string amt, string log_officer)
    {
        string connectionString = Connect();
        string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
        string str3 = "1";
        string str4 = "5";
        string str5 = "1";
        string str6 = "Fresh";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO pwallet (validationID,applicantID,log_officer,amt,stage,status,data_status,reg_date,visible )  VALUES ( @validationID,@applicantID,@log_officer,@amt,@stage,@status,@data_status,@regdate,@visible ) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@validationID", SqlDbType.VarChar, 50);
        command.Parameters.Add("@applicantID", SqlDbType.VarChar, 50);
        command.Parameters.Add("@log_officer", SqlDbType.VarChar, 50);
        command.Parameters.Add("@amt", SqlDbType.VarChar, 50);
        command.Parameters.Add("@stage", SqlDbType.NChar, 10);
        command.Parameters.Add("@status", SqlDbType.VarChar, 20);
        command.Parameters.Add("@data_status", SqlDbType.VarChar, 50);
        command.Parameters.Add("@regdate", SqlDbType.VarChar, 50);
        command.Parameters.Add("@visible", SqlDbType.VarChar, 1);
        command.Parameters["@validationID"].Value = validationID;
        command.Parameters["@applicantID"].Value = agent_code;
        command.Parameters["@log_officer"].Value = log_officer;
        command.Parameters["@amt"].Value = amt;
        command.Parameters["@stage"].Value = str4;
        command.Parameters["@status"].Value = str3;
        command.Parameters["@data_status"].Value = str6;
        command.Parameters["@regdate"].Value = str2;
        command.Parameters["@visible"].Value = str5;
        return command.ExecuteScalar().ToString();
    }

    public int addRenewal(Renewal x)
    {
        int num = 0;
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO renewal (title,type,app_no,app_date,xname,xaddy,xemail,xmobile,agt_code,agt_name,agt_addy,agt_mobile,agt_email,last_rwl_date,reg_date,reg_time,log_staff,visible,sync) VALUES (@title,@type,@app_no,@app_date,@xname,@xaddy,@xemail,@xmobile,@agt_code,@agt_name,@agt_addy,@agt_mobile,@agt_email,@last_rwl_date,@reg_date,@reg_time,@log_staff,@visible,@sync) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@title", SqlDbType.NVarChar);
        command.Parameters.Add("@type", SqlDbType.NVarChar);
        command.Parameters.Add("@app_no", SqlDbType.NVarChar);
        command.Parameters.Add("@app_date", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@xname", SqlDbType.NVarChar);
        command.Parameters.Add("@xaddy", SqlDbType.Text);
        command.Parameters.Add("@xemail", SqlDbType.NVarChar);
        command.Parameters.Add("@xmobile", SqlDbType.NVarChar);
        command.Parameters.Add("@agt_code", SqlDbType.NVarChar);
        command.Parameters.Add("@agt_name", SqlDbType.NVarChar);
        command.Parameters.Add("@agt_addy", SqlDbType.Text);
        command.Parameters.Add("@agt_mobile", SqlDbType.NVarChar);
        command.Parameters.Add("@agt_email", SqlDbType.NVarChar);
        command.Parameters.Add("@last_rwl_date", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@reg_time", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@log_staff", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@visible", SqlDbType.NVarChar, 10);
        command.Parameters.Add("@sync", SqlDbType.NVarChar, 10);
        command.Parameters["@title"].Value = x.title;
        command.Parameters["@type"].Value = x.type;
        command.Parameters["@app_no"].Value = x.app_no;
        command.Parameters["@app_date"].Value = x.app_date;
        command.Parameters["@xname"].Value = x.xname;
        command.Parameters["@xaddy"].Value = x.xaddy;
        command.Parameters["@xemail"].Value = x.xemail;
        command.Parameters["@xmobile"].Value = x.xmobile;
        command.Parameters["@agt_code"].Value = x.agt_code;
        command.Parameters["@agt_name"].Value = x.agt_name;
        command.Parameters["@agt_addy"].Value = x.agt_addy;
        command.Parameters["@agt_mobile"].Value = x.agt_mobile;
        command.Parameters["@agt_email"].Value = x.agt_email;
        command.Parameters["@last_rwl_date"].Value = x.last_rwl_date;
        command.Parameters["@reg_date"].Value = x.reg_date;
        command.Parameters["@reg_time"].Value = x.reg_time;
        command.Parameters["@log_staff"].Value = x.log_staff;
        command.Parameters["@visible"].Value = x.visible;
        command.Parameters["@sync"].Value = x.sync;
        num = Convert.ToInt32(command.ExecuteScalar());
        connection.Close();
        string str2 = string.Concat(new object[] { "PT/GF/P003/", DateTime.Today.Year.ToString(), "/", num });
     updateRenewalReg(str2, num.ToString());
        return num;
    }

    public string addRepresentative(Representative c_rep)
    {
        string str = "0";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO representative (agent_code,xname,nationality,country,state,address,xemail,xmobile,log_staff,visible) VALUES (@agent_code,@xname,@nationality,@country,@state,@address,@xemail,@xmobile,@log_staff,@visible) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@agent_code", SqlDbType.VarChar);
        command.Parameters.Add("@xname", SqlDbType.NVarChar);
        command.Parameters.Add("@nationality", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@country", SqlDbType.VarChar, 50);
        command.Parameters.Add("@state", SqlDbType.VarChar, 50);
        command.Parameters.Add("@address", SqlDbType.Text);
        command.Parameters.Add("@xemail", SqlDbType.NVarChar);
        command.Parameters.Add("@xmobile", SqlDbType.VarChar);
        command.Parameters.Add("@log_staff", SqlDbType.VarChar, 50);
        command.Parameters.Add("@visible", SqlDbType.VarChar, 10);
        command.Parameters["@agent_code"].Value = c_rep.agent_code;
        command.Parameters["@xname"].Value = ConvertApos2Tab(c_rep.xname);
        command.Parameters["@nationality"].Value = c_rep.nationality;
        command.Parameters["@country"].Value = c_rep.country;
        command.Parameters["@state"].Value = c_rep.state;
        command.Parameters["@address"].Value = ConvertApos2Tab(c_rep.address);
        command.Parameters["@xemail"].Value = ConvertApos2Tab(c_rep.xemail);
        command.Parameters["@xmobile"].Value = c_rep.xmobile;
        command.Parameters["@log_staff"].Value = c_rep.log_staff;
        command.Parameters["@visible"].Value = c_rep.visible;
        str = command.ExecuteScalar().ToString();
        connection.Close();
        return str;
    }

    public string addSwallet(SWallet s)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO search_wallet (mark_infoID,search_str,search_cri,xclass,log_officer,reg_date,visible) VALUES (@mark_infoID,@search_str,@search_cri,@xclass,@log_officer,@reg_date,@visible) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@mark_infoID", SqlDbType.NVarChar);
        command.Parameters.Add("@search_str", SqlDbType.Text);
        command.Parameters.Add("@search_cri", SqlDbType.Text);
        command.Parameters.Add("@xclass", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@log_officer", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
        command.Parameters["@mark_infoID"].Value = s.mark_infoID;
        command.Parameters["@search_str"].Value = s.search_str;
        command.Parameters["@search_cri"].Value = s.search_cri;
        command.Parameters["@xclass"].Value = s.xclass;
        command.Parameters["@log_officer"].Value = s.log_officer;
        command.Parameters["@reg_date"].Value = s.reg_date;
        command.Parameters["@visible"].Value = s.visible;
        str2 = command.ExecuteScalar().ToString();
        connection.Close();
        return str2;
    }

    public string addXPwallet(string serverpath, string validationID, string agent_code, string amt, string log_officer, string item_code)
    {
        string connectionString = Connect();
        string str2 = DateTime.Today.Date.ToString("yyyy-MM-dd");
        string str3 = "1";
        string str4 = "5";
        string str5 = "1";
        string str6 = "Fresh";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO x_pwallet (validationID,applicantID,log_officer,amt,item_code,stage,status,data_status,reg_date,visible )  VALUES ( @validationID,@applicantID,@log_officer,@amt,@item_code,@stage,@status,@data_status,@regdate,@visible ) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@validationID", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@applicantID", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@log_officer", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@amt", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@item_code", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@stage", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@status", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@data_status", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@regdate", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@visible", SqlDbType.NVarChar, 1);
        command.Parameters["@validationID"].Value = validationID;
        command.Parameters["@applicantID"].Value = agent_code;
        command.Parameters["@log_officer"].Value = log_officer;
        command.Parameters["@amt"].Value = amt;
        command.Parameters["@item_code"].Value = item_code;
        command.Parameters["@stage"].Value = str4;
        command.Parameters["@status"].Value = str3;
        command.Parameters["@data_status"].Value = str6;
        command.Parameters["@regdate"].Value = str2;
        command.Parameters["@visible"].Value = str5;
        return command.ExecuteScalar().ToString();
    }

    public string Connect()
    {
        return ConfigurationManager.ConnectionStrings["cldConnectionString"].ConnectionString;
    }

    public string Connect2()
    {
        return ConfigurationManager.ConnectionStrings["xhomeConnectionString"].ConnectionString;
    }

    public string ConnectXpay()
    {
        return ConfigurationManager.ConnectionStrings["xpayConnectionString"].ConnectionString;
    }

    public string ConvertApos2Tab(string x)
    {
        string str = x;
        if (((x != null) || (x != "")) && x.Contains("'"))
        {
            str = x.Replace("'", "|");
        }
        return str;
    }

    public string ConvertTab2Apos(string x)
    {
        string str = x;
        if (((x != null) || (x != "")) && x.Contains("|"))
        {
            str = x.Replace("|", "'");
        }
        return str;
    }

    public string deleteApplicant(string id)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "DELETE FROM applicant WHERE [log_staff] ='" + id + "'";
        connection.Open();
        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str2;
    }

    public string deleteInventor(string id)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "DELETE FROM inventor WHERE [log_staff] ='" + id + "'";
        connection.Open();
        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str2;
    }

    public void doDeleteCurrentDir(string path)
    {
        try
        {
            if (Directory.Exists(path))
            {
                foreach (string str in Directory.GetFiles(path))
                {
                    File.Delete(str);
                }
            }
        }
        catch (Exception)
        {
        }
        finally
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path);
            }
        }
    }

    public void doDeleteDir(string serverpath, long markID)
    {
        if (markID > 0L)
        {
            string path = serverpath + "admin/tm/docz/" + markID.ToString() + "/";
            string str2 = serverpath + "admin/tm/Picz/" + markID.ToString() + "/";
            try
            {
                if (Directory.Exists(path))
                {
                    foreach (string str3 in Directory.GetFiles(path))
                    {
                        File.Delete(str3);
                    }
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (Directory.Exists(str2))
                {
                    foreach (string str4 in Directory.GetFiles(str2))
                    {
                        File.Delete(str4);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }

    public string doUploadDoc(string ID, string path, FileUpload fu)
    {
        string str = "";
        try
        {
            if (!Directory.Exists(path + ID + "/"))
            {
                Directory.CreateDirectory(path + ID + "/");
            }
            string str2 = Path.GetFileName(fu.FileName).Replace(" ", "_");
            fu.SaveAs(path + ID + "/" + str2);
            return (str = path + ID + "/" + str2);
        }
        catch (Exception)
        {
            return "";
        }
    }

    public string doUploadDocNoLimit(string ID, string path, FileUpload fu)
    {
        string str = "";
        try
        {
            if (!Directory.Exists(path + ID + "/"))
            {
                Directory.CreateDirectory(path + ID + "/");
            }
            string str2 = Path.GetFileName(fu.FileName).Replace(" ", "_");
            fu.SaveAs(path + ID + "/" + str2);
            return (str = path + ID + "/" + str2);
        }
        catch (Exception exception)
        {
            return ("The file could not be uploaded. The following error occured: " + exception.Message);
        }
    }

    public string doUploadPic(string ID, string newfilename, string path, FileUpload fu)
    {
        try
        {
            if (!Directory.Exists(path + ID + "/"))
            {
                Directory.CreateDirectory(path + ID + "/");
            }
            newfilename = newfilename.Replace(" ", "_");
            fu.SaveAs(path + ID + "/" + newfilename);
            return (path + ID + "/" + newfilename);
        }
        catch (Exception exception)
        {
            return ("The file could not be uploaded. The following error occured: " + exception.Message);
        }
    }

    public void flushAddress(string id)
    {
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("DELETE from address where log_staff='" + id + "'", connection);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void flushAddress_service(string id)
    {
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("DELETE from address_service where log_staff='" + id + "'", connection);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void flushAddress_serviceByID(string id)
    {
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("DELETE from address_service where ID='" + id + "'", connection);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void flushAddressByID(string id)
    {
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("DELETE from address where ID='" + id + "'", connection);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void flushApplicant(string id)
    {
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("DELETE from applicant where log_staff='" + id + "'", connection);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void flushApplicantByID(string id)
    {
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("DELETE from applicant where ID='" + id + "'", connection);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void flushMark_infoByID(string serverpath, string id)
    {
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("DELETE from pt_info where xID='" + id + "'", connection);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
        if (Convert.ToInt64(id) > 0L)
        {
         doDeleteDir(serverpath, Convert.ToInt64(id));
        }
    }

    public void flushPt_info(string serverpath, string id)
    {
        long markID = 0L;
        string connectionString = Connect();
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand("SELECT xID from pt_info where log_staff='" + id + "'", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            markID = Convert.ToInt64(reader["xID"]);
        }
        reader.Close();
        SqlConnection connection2 = new SqlConnection(connectionString);
        SqlCommand command2 = new SqlCommand("DELETE from pt_info where log_staff='" + id + "'", connection2);
        connection2.Open();
        command2.ExecuteNonQuery();
        connection2.Close();
        if (markID > 0L)
        {
         doDeleteDir(serverpath, markID);
        }
    }

    public void flushPwalletByID(string id)
    {
        string connectionString = Connect();
        if ((id != "0") && (id != ""))
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("DELETE from pwallet where ID='" + id + "'", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void flushRepresentative(string id)
    {
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("DELETE from representative where log_staff='" + id + "'", connection);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void flushRepresentativeByID(string id)
    {
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("DELETE from representative where ID='" + id + "'", connection);
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
    }

    public List<Address> getAddressByID(string ID)
    {
        List<Address> list = new List<Address>();
        new Address();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM address WHERE ID='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Address item = new Address
            {
                ID = reader["ID"].ToString(),
                countryID = reader["countryID"].ToString(),
                stateID = reader["stateID"].ToString(),
                lgaID = reader["lgaID"].ToString(),
                city = ConvertTab2Apos(reader["city"].ToString()),
                street = ConvertTab2Apos(reader["street"].ToString()),
                zip = reader["zip"].ToString(),
                telephone1 = reader["telephone1"].ToString(),
                telephone2 = reader["telephone2"].ToString(),
                email1 = ConvertTab2Apos(reader["email1"].ToString()),
                email2 = ConvertTab2Apos(reader["email2"].ToString()),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                visible = reader["visible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<Address> getAddressByLog_staffID(string validationID)
    {
        List<Address> list = new List<Address>();
        new Address();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM address WHERE ID='" + validationID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Address item = new Address
            {
                ID = reader["ID"].ToString(),
                countryID = reader["countryID"].ToString(),
                stateID = reader["stateID"].ToString(),
                lgaID = reader["lgaID"].ToString(),
                city = ConvertTab2Apos(reader["city"].ToString()),
                street = ConvertTab2Apos(reader["street"].ToString()),
                zip = reader["zip"].ToString(),
                telephone1 = reader["telephone1"].ToString(),
                telephone2 = reader["telephone2"].ToString(),
                email1 = ConvertTab2Apos(reader["email1"].ToString()),
                email2 = ConvertTab2Apos(reader["email2"].ToString()),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                visible = reader["visible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<AddressService> getAddressServiceByID(string ID)
    {
        List<AddressService> list = new List<AddressService>();
        new AddressService();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM address_service WHERE log_staff='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            AddressService item = new AddressService
            {
                ID = Convert.ToInt64(reader["ID"]).ToString(),
                countryID = reader["countryID"].ToString(),
                stateID = reader["stateID"].ToString(),
                lgaID = reader["lgaID"].ToString(),
                city = ConvertTab2Apos(reader["city"].ToString()),
                street = ConvertTab2Apos(reader["street"].ToString()),
                zip = reader["zip"].ToString(),
                telephone1 = reader["telephone1"].ToString(),
                telephone2 = reader["telephone2"].ToString(),
                email1 = ConvertTab2Apos(reader["email1"].ToString()),
                email2 = ConvertTab2Apos(reader["email2"].ToString()),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                visible = reader["visible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public bool getAdminExtension(string filename)
    {
        string str = "";
        bool flag = false;
        int num = filename.LastIndexOf(".");
        str = filename.Substring(num + 1);
        if ((((str != "pdf") && (str != "jpg")) && ((str != "jpeg") && (str != "PDF"))) && ((str != "JPG") && (str != "JPEG")))
        {
            return flag;
        }
        return true;
    }

    public string getAgentEmail1ByID(string ID)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT email1 FROM address WHERE ID='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["email1"].ToString();
        }
        reader.Close();
        return str;
    }

    public string getAgentTelephone1ByID(string ID)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT telephone1 FROM address WHERE ID='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["telephone1"].ToString();
        }
        reader.Close();
        return str;
    }

    public List<Renewal> getAllRenewal()
    {
        List<Renewal> list = new List<Renewal>();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM renewal ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Renewal item = new Renewal
            {
                xID = reader["ID"].ToString(),
                title = ConvertTab2Apos(reader["title"].ToString()),
                type = ConvertTab2Apos(reader["type"].ToString()),
                reg_no = ConvertTab2Apos(reader["reg_no"].ToString()),
                app_no = reader["app_no"].ToString(),
                app_date = reader["app_date"].ToString(),
                xname = reader["xname"].ToString(),
                xaddy = reader["xaddy"].ToString(),
                xmobile = ConvertTab2Apos(reader["xmobile"].ToString()),
                xemail = ConvertTab2Apos(reader["xemail"].ToString()),
                agt_name = ConvertTab2Apos(reader["agt_name"].ToString()),
                agt_code = reader["agt_code"].ToString(),
                agt_addy = reader["agt_addy"].ToString(),
                agt_mobile = reader["agt_mobile"].ToString(),
                agt_email = reader["agt_email"].ToString(),
                last_rwl_date = ConvertTab2Apos(reader["last_rwl_date"].ToString()),
                reg_date = ConvertTab2Apos(reader["reg_date"].ToString()),
                reg_time = ConvertTab2Apos(reader["reg_time"].ToString()),
                log_staff = reader["log_staff"].ToString(),
                visible = reader["visible"].ToString(),
                sync = reader["sync"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<Applicant> getApplicantByUserID(string ID)
    {
        List<Applicant> list = new List<Applicant>();
        new Applicant();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM applicant WHERE log_staff='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Applicant item = new Applicant
            {
                ID = reader["ID"].ToString(),
                xname = ConvertTab2Apos(reader["xname"].ToString()),
                address = ConvertTab2Apos(reader["address"].ToString()),
                xemail = ConvertTab2Apos(reader["xemail"].ToString()),
                xmobile = reader["xmobile"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                visible = reader["visible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<Applicant> getApplicantByvalidationID(string validationID)
    {
        List<Applicant> list = new List<Applicant>();
        new Applicant();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM applicant WHERE log_staff='" + validationID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Applicant item = new Applicant
            {
                ID = reader["ID"].ToString(),
                xname = ConvertTab2Apos(reader["xname"].ToString()),
                address = ConvertTab2Apos(reader["address"].ToString()),
                xemail = ConvertTab2Apos(reader["xemail"].ToString()),
                xmobile = reader["xmobile"].ToString(),
                nationality = reader["nationality"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                visible = reader["visible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<Assignment_info> getAssignment_infoByvalidationID(string validationID)
    {
        List<Assignment_info> list = new List<Assignment_info>();
        new Assignment_info();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM assignment_info WHERE log_staff='" + validationID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Assignment_info item = new Assignment_info
            {
                ID = reader["xID"].ToString(),
                date_of_assignment = reader["date_of_assignment"].ToString(),
                assignee_name = ConvertTab2Apos(reader["assignee_name"].ToString()),
                assignee_address = ConvertTab2Apos(reader["assignee_address"].ToString()),
                assignee_nationality = reader["assignee_nationality"].ToString(),
                assignor_name = ConvertTab2Apos(reader["assignor_name"].ToString()),
                assignor_nationality = reader["assignor_nationality"].ToString(),
                assignor_address = ConvertTab2Apos(reader["assignor_address"].ToString()),
                log_staff = reader["log_staff"].ToString(),
                visible = reader["xvisible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public string getClientNumber()
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        string cmdText = "SELECT TOP 1 ID,pin FROM xscard where usedstatus='0'";
        SqlCommand command = new SqlCommand(cmdText, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["ID"].ToString() + "_" + reader["pin"].ToString();
        }
        reader.Close();
        return str;
    }

    public List<Contact_form> getContact_formByOfficerID(string xofficerID, string sent_status)
    {
        List<Contact_form> list = new List<Contact_form>();
        new Contact_form();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM contact_form WHERE xofficerID='" + xofficerID + "' AND sent_status='" + sent_status + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Contact_form item = new Contact_form
            {
                xID = reader["xID"].ToString(),
                response_deadline = reader["response_deadline"].ToString(),
                xofficerID = reader["xofficerID"].ToString(),
                xmsg = ConvertTab2Apos(reader["xmsg"].ToString()),
                sent_status = reader["sent_status"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                xvisible = reader["xvisible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<Country> getCountry()
    {
        List<Country> list = new List<Country>();
        new Country();
        SqlConnection connection = new SqlConnection(Connect());
        string cmdText = "SELECT * FROM country";
        SqlCommand command = new SqlCommand(cmdText, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Country item = new Country
            {
                ID = Convert.ToInt64(reader["ID"]).ToString(),
                name = reader["name"].ToString(),
                code = reader["code"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public string getCountryName(string ID)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT name FROM country WHERE ID='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["name"].ToString();
        }
        reader.Close();
        return str;
    }

    public string getExtension(string filename)
    {
        int num = filename.LastIndexOf(".");
        return filename.Substring(num + 1);
    }

    public string getFormattedAddressByID(string ID)
    {
        string str = "";
        List<Address> list = new List<Address>();
        new Address();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM address WHERE ID='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Address item = new Address
            {
                ID = reader["ID"].ToString(),
                countryID = reader["countryID"].ToString(),
                stateID = reader["stateID"].ToString(),
                lgaID = reader["lgaID"].ToString(),
                city = reader["city"].ToString(),
                street = ConvertTab2Apos(reader["street"].ToString()),
                zip = reader["zip"].ToString(),
                telephone1 = reader["telephone1"].ToString(),
                telephone2 = reader["telephone2"].ToString(),
                email1 = ConvertTab2Apos(reader["email1"].ToString()),
                email2 = ConvertTab2Apos(reader["email2"].ToString()),
                log_staff = reader["log_staff"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                visible = reader["visible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        string str2 = str;
        return (str2 + list[0].street.ToUpper() + "," + list[0].city.ToUpper() + "," + getStateName(list[0].stateID).ToUpper());
    }

    public List<Inventor> getInventorByvalidationID(string validationID)
    {
        List<Inventor> list = new List<Inventor>();
        new Inventor();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM inventor WHERE log_staff='" + validationID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Inventor item = new Inventor
            {
                ID = reader["ID"].ToString(),
                xname = ConvertTab2Apos(reader["xname"].ToString()),
                address = ConvertTab2Apos(reader["address"].ToString()),
                xemail = ConvertTab2Apos(reader["xemail"].ToString()),
                xmobile = reader["xmobile"].ToString(),
                nationality = reader["nationality"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                visible = reader["visible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<Lga> getLga()
    {
        List<Lga> list = new List<Lga>();
        new Lga();
        SqlConnection connection = new SqlConnection(Connect());
        string cmdText = "SELECT * FROM lga";
        SqlCommand command = new SqlCommand(cmdText, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Lga item = new Lga
            {
                ID = Convert.ToInt64(reader["ID"]).ToString(),
                name = reader["name"].ToString(),
                stateID = reader["stateID"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public string getLogoDescriptionName(string id)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT type from logo_description where xID='" + id + "'", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["type"].ToString();
        }
        reader.Close();
        return str;
    }

    public string getNationalClassDesc(string id)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT description from national_classes where xID='" + id + "'", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["description"].ToString();
        }
        reader.Close();
        return str;
    }

    public List<Priority_info> getPriority_infoByvalidationID(string validationID)
    {
        List<Priority_info> list = new List<Priority_info>();
        new Priority_info();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM priority_info WHERE log_staff='" + validationID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Priority_info item = new Priority_info
            {
                xID = reader["xID"].ToString(),
                countryID = reader["countryID"].ToString(),
                app_no = reader["app_no"].ToString(),
                xdate = reader["xdate"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                xvisible = reader["xvisible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<PtInfo> getPtInfoByPwalletID(string ID)
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
                title_of_invention = ConvertTab2Apos(reader["title_of_invention"].ToString()),
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

    public PtInfo getPtInfoByPwalletID2(string ID)
    {
        List<PtInfo> list = new List<PtInfo>();
        PtInfo item = null;
        new PtInfo();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM pt_info WHERE log_staff=(select cast(ID as varchar) from pwallet where validationID ='" + ID + "' )  ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
             item = new PtInfo
            {
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = ConvertTab2Apos(reader["title_of_invention"].ToString()),
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
             return item;
           // list.Add(item);
        }
        reader.Close();
        return item;
    }


    public PtInfo getPtInfoByPwalletID4(string ID, string APPID)
    {
        List<PtInfo> list = new List<PtInfo>();
        PtInfo item = null;
        new PtInfo();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM pt_info WHERE log_staff=(select cast(ID as varchar) from pwallet where validationID ='" + ID + "' and applicantID ='" + APPID + "' and pwallet.data_status !='Grant Patent')  ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            item = new PtInfo
            {
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = ConvertTab2Apos(reader["title_of_invention"].ToString()),
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
            return item;
            // list.Add(item);
        }
        reader.Close();
        return item;
    }

    public PtInfo getPtInfoByPwalletID3(string ID)
    {
        List<PtInfo> list = new List<PtInfo>();
        PtInfo item = null;
        new PtInfo();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM pt_info WHERE reg_number='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            item = new PtInfo
            {
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = ConvertTab2Apos(reader["title_of_invention"].ToString()),
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
            return item;
            // list.Add(item);
        }
        reader.Close();
        return item;
    }

    public PtInfo getPtInfoByPwalletID5(string ID, string APPID)
    {

        PtInfo xd = getPtInfoByPwalletID3(ID);
        List<PtInfo> list = new List<PtInfo>();
        PtInfo item = null;
        new PtInfo();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM pt_info WHERE reg_number='" + ID + "' and log_staff=(select ID from pwallet where  applicantID ='" + APPID + "' and id= '" + xd.log_staff + "' and pwallet.data_status !='Grant Patent')  ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            item = new PtInfo
            {
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = ConvertTab2Apos(reader["title_of_invention"].ToString()),
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
            return item;
            // list.Add(item);
        }
        reader.Close();
        return item;
    }

    public List<PtInfo> getPtInfoByUserID(string ID)
    {
        List<PtInfo> list = new List<PtInfo>();
        new PtInfo();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM pt_info WHERE xID='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            PtInfo item = new PtInfo
            {
                xID = reader["xID"].ToString(),
                reg_number = reader["reg_number"].ToString(),
                xtype = reader["xtype"].ToString(),
                title_of_invention = ConvertTab2Apos(reader["title_of_invention"].ToString()),
                pt_desc = ConvertTab2Apos(reader["pt_desc"].ToString()),
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

    public string doUploadDoc(string ID, string path, HttpPostedFile fu)
    {
        try
        {
            if (!Directory.Exists(path + ID + "/"))
            {
                Directory.CreateDirectory(path + ID + "/");
            }
            string str = Path.GetFileName(fu.FileName).Replace(" ", "_");
            fu.SaveAs(path + ID + "/" + str);
            return (path + ID + "/" + str);
        }
        catch (Exception)
        {
            return "";
        }
    }

    public string UpdateTrademarkTx(string dd, HttpPostedFile loa_doc, HttpPostedFile claim_doc, HttpPostedFile pct_doc, HttpPostedFile doa_doc, HttpPostedFile spec_doc, string serverpath)
    {
        List<Agent_FileUpload> ts = new List<Agent_FileUpload>();
        PtInfo xxk = getPtInfoByPwalletID2(dd);
        ptinfobackup(dd);
        updateUploadDate2(dd);

       
      //  cld.Classes.tm.MarkInfo xxk = vtm.getMarkInfoClassByUserID2(dd);

        //  Retriever ret = new Retriever();
        string xID = null; int pID = 0;
        string xloa_doc = ""; string xclaim_doc = ""; string xpct_doc = ""; string xdoa_doc = ""; string xspec_doc = "";
        string reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
        string xtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
        string xvisible = "1"; string xsync = "0";

        SqlConnection connection; SqlCommand command;
        string connectionString = Connect();
        //c_pwall.reg_date = reg_date;
        //c_pwall.xtime = c_pwall.log_officer + ": " + xtime;
        //c_pwall.visible = xvisible; c_pwall.status = "1"; c_pwall.stage = "5"; c_pwall.data_status = "Fresh";
        //c_pwall.acc_p = "0"; c_pwall.rtm = "0"; 
        int app_addyID = 0;

        int rep_addyID = 0;
        int cert_infoID = 0;



        try
        {



            xID = dd;
            try
            {
                if (loa_doc != null) { xloa_doc = doUploadDoc(xID, serverpath + "admin/pt/docz/", loa_doc); }
            }

            catch (Exception ee)
            {

            }
            try
            {
                if (claim_doc != null) { xclaim_doc = doUploadDoc(xID, serverpath + "admin/pt/docz/", claim_doc); }

            }
            catch (Exception ee)
            {

            }
            try
            {
                if (pct_doc != null) { xpct_doc = doUploadDoc(xID, serverpath + "admin/pt/docz/", pct_doc); }
            }

            catch (Exception ee)
            {

            }
            try
            {
                if (doa_doc != null) { xdoa_doc = doUploadDoc(xID, serverpath + "admin/pt/docz/", doa_doc); }

            }
            catch (Exception ee)
            {

            }


            try
            {
                if (spec_doc != null) { xspec_doc = doUploadDoc(xID, serverpath + "admin/pt/docz/", spec_doc); }

            }
            catch (Exception ee)
            {

            }
            try
            {
                if (loa_doc != null)
                {
                    xloa_doc = xloa_doc.Replace(serverpath + "admin/pt/", "");
                    Agent_FileUpload dd3 = new  Agent_FileUpload();
                    dd3.new_file = xloa_doc;
                    dd3.old_file = xxk.loa_doc;
                    ts.Add(dd3);


                }
                else
                {
                    xloa_doc = xxk.loa_doc;

                }
            }
            catch (Exception ee)
            {

            }
            try
            {
                if (claim_doc != null)
                {
                    xclaim_doc = xclaim_doc.Replace(serverpath + "admin/pt/", "");

                    Agent_FileUpload dd3 = new Agent_FileUpload();
                    dd3.new_file = xclaim_doc;
                    dd3.old_file = xxk.claim_doc;
                    ts.Add(dd3);
                }
                else
                {
                    xclaim_doc = xxk.claim_doc;
                }
            }
            catch (Exception ee)
            {

            }
            try
            {
                if (pct_doc != null)
                {
                    xpct_doc = xpct_doc.Replace(serverpath + "admin/pt/", "");

                    Agent_FileUpload dd3 = new Agent_FileUpload();
                    dd3.new_file = xpct_doc;
                    dd3.old_file = xxk.pct_doc;
                    ts.Add(dd3);
                }
                else
                {
                    xpct_doc = xxk.pct_doc;
                }
            }
            catch (Exception ee)
            {

            }
            try
            {
                if (doa_doc != null)
                {
                    xdoa_doc = xdoa_doc.Replace(serverpath + "admin/pt/", "");

                    Agent_FileUpload dd3 = new Agent_FileUpload();
                    dd3.new_file = xdoa_doc;
                    dd3.old_file = xxk.doa_doc;
                    ts.Add(dd3);
                }
                else
                {
                    xdoa_doc = xxk.doa_doc;
                }
            }
            catch (Exception ee)
            {

            }

            try
            {
                if (spec_doc != null)
                {
                    xspec_doc = xspec_doc.Replace(serverpath + "admin/pt/", "");

                    Agent_FileUpload dd3 = new Agent_FileUpload();
                    dd3.new_file = xspec_doc;
                    dd3.old_file = xxk.spec_doc;
                    ts.Add(dd3);
                }
                else
                {
                    xspec_doc = xxk.spec_doc;
                }
            }
            catch (Exception ee)
            {

            }


            using (connection = new SqlConnection(connectionString))
            {
                using (command = connection.CreateCommand())
                {
                    //  command.CommandTimeout = 300;
                    command.CommandText = "UPDATE pt_info SET loa_doc=@loa_doc,claim_doc=@claim_doc,pct_doc=@pct_doc,doa_doc=@doa_doc ,spec_doc=@spec_doc WHERE log_staff=(select cast(ID as varchar) from pwallet where validationid= @log_staff)  ";

                    command.Connection.Open();
                    command.Parameters.Add("@loa_doc", SqlDbType.Text);
                    command.Parameters.Add("@claim_doc", SqlDbType.Text);
                    command.Parameters.Add("@pct_doc", SqlDbType.Text);
                    command.Parameters.Add("@doa_doc", SqlDbType.Text);
                    command.Parameters.Add("@spec_doc", SqlDbType.Text);
                    command.Parameters.Add("@log_staff", SqlDbType.NChar, 50);

                    command.Parameters["@loa_doc"].Value = xloa_doc;
                    command.Parameters["@claim_doc"].Value = xclaim_doc;
                    command.Parameters["@pct_doc"].Value = xpct_doc;
                    command.Parameters["@doa_doc"].Value = xdoa_doc;
                    command.Parameters["@spec_doc"].Value = xspec_doc;
                    command.Parameters["@log_staff"].Value = dd;
                    int h = Convert.ToInt32(command.ExecuteNonQuery());
                    command.Connection.Close();
                }
            }


            if (command.Connection.State == ConnectionState.Open) { command.Connection.Close(); }
        }
        catch (Exception exception)
        {
          
        }
        finally
        {

            //  xID = "0";
            // command.Connection.Close(); 
        }
        updateUploadDate(xxk.log_staff);
      //  updateUploadDate(dd);
        List<Stage> xxl = getStageByUserID(xxk.log_staff);
        String xsubject ="upload from Patent  application  with number "  + xxk.reg_number;
        DateTime xxs = DateTime.Now;
        foreach (Agent_FileUpload Agent_FileUpload in ts)
        {

            Agent_FileUpload.agent_code = xxl[0].applicantID;
            Agent_FileUpload.Date_Uploaded = xxs;

            Agent_FileUpload.Status = xxl[0].data_status;
            Agent_FileUpload.pt_id = xxl[0].validationID;

            AddAgentUpload_Log(Agent_FileUpload);

        }

        AddAdminMail(xxl[0].applicantID, "upload from Patent  application ", xsubject, xxk.reg_number, xxk.xID);

        return xID;
    }
    static object locker = new object();
    static string Generate15UniqueDigits()
    {
        lock (locker)
        {
            Thread.Sleep(100);
            return DateTime.Now.ToString("yyyyMMddHHmmssf");
        }
    }
    public string UpdateTrademarkTx2(string dd, HttpPostedFile loa_doc, HttpPostedFile claim_doc, HttpPostedFile pct_doc, HttpPostedFile doa_doc, HttpPostedFile spec_doc, string serverpath)
    {

        List<Agent_FileUpload> ts = new List<Agent_FileUpload>();
        PtInfo xxk = getPtInfoByPwalletID3(dd);
        ptinfobackup(dd);
        updateUploadDate2(dd);

        //  cld.Classes.tm.MarkInfo xxk = vtm.getMarkInfoClassByUserID2(dd);

        //  Retriever ret = new Retriever();
        string xID = null; int pID = 0;
        string xloa_doc = ""; string xclaim_doc = ""; string xpct_doc = ""; string xdoa_doc = ""; string xspec_doc = "";
        string reg_date = DateTime.Today.Date.ToString("yyyy-MM-dd");
        string xtime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt");
        string xvisible = "1"; string xsync = "0";

        SqlConnection connection; SqlCommand command;
        string connectionString = Connect();
        //c_pwall.reg_date = reg_date;
        //c_pwall.xtime = c_pwall.log_officer + ": " + xtime;
        //c_pwall.visible = xvisible; c_pwall.status = "1"; c_pwall.stage = "5"; c_pwall.data_status = "Fresh";
        //c_pwall.acc_p = "0"; c_pwall.rtm = "0"; 
        int app_addyID = 0;

        int rep_addyID = 0;
        int cert_infoID = 0;



        try
        {



            xID = dd;
            try
            {
                if (loa_doc != null) { xloa_doc = doUploadDoc(xID, serverpath + "admin/pt/docz/", loa_doc); }
            }

            catch (Exception ee)
            {

            }
            try
            {
                if (claim_doc != null) { xclaim_doc = doUploadDoc(xID, serverpath + "admin/pt/docz/", claim_doc); }

            }
            catch (Exception ee)
            {

            }
            try
            {
                if (pct_doc != null) { xpct_doc = doUploadDoc(xID, serverpath + "admin/pt/docz/", pct_doc); }
            }

            catch (Exception ee)
            {

            }
            try
            {
                if (doa_doc != null) { xdoa_doc = doUploadDoc(xID, serverpath + "admin/pt/docz/", doa_doc); }

            }
            catch (Exception ee)
            {

            }


            try
            {
                if (spec_doc != null) { xspec_doc = doUploadDoc(xID, serverpath + "admin/pt/docz/", spec_doc); }

            }
            catch (Exception ee)
            {

            }
            try
            {
                if (loa_doc != null)
                {
                    xloa_doc = xloa_doc.Replace(serverpath + "admin/pt/", "");
                    Agent_FileUpload dd3 = new Agent_FileUpload();
                    dd3.new_file = xloa_doc;
                    dd3.old_file = xxk.loa_doc;
                    ts.Add(dd3);


                }
                else
                {
                    xloa_doc = xxk.loa_doc;

                }
            }
            catch (Exception ee)
            {

            }
            try
            {
                if (claim_doc != null)
                {
                    xclaim_doc = xclaim_doc.Replace(serverpath + "admin/pt/", "");

                    Agent_FileUpload dd3 = new Agent_FileUpload();
                    dd3.new_file = xclaim_doc;
                    dd3.old_file = xxk.claim_doc;
                    ts.Add(dd3);
                }
                else
                {
                    xclaim_doc = xxk.claim_doc;
                }
            }
            catch (Exception ee)
            {

            }
            try
            {
                if (pct_doc != null)
                {
                    xpct_doc = xpct_doc.Replace(serverpath + "admin/pt/", "");

                    Agent_FileUpload dd3 = new Agent_FileUpload();
                    dd3.new_file = xpct_doc;
                    dd3.old_file = xxk.pct_doc;
                    ts.Add(dd3);
                }
                else
                {
                    xpct_doc = xxk.pct_doc;
                }
            }
            catch (Exception ee)
            {

            }
            try
            {
                if (doa_doc != null)
                {
                    xdoa_doc = xdoa_doc.Replace(serverpath + "admin/pt/", "");

                    Agent_FileUpload dd3 = new Agent_FileUpload();
                    dd3.new_file = xdoa_doc;
                    dd3.old_file = xxk.doa_doc;
                    ts.Add(dd3);
                }
                else
                {
                    xdoa_doc = xxk.doa_doc;
                }
            }
            catch (Exception ee)
            {

            }

            try
            {
                if (spec_doc != null)
                {
                    xspec_doc = xspec_doc.Replace(serverpath + "admin/pt/", "");

                    Agent_FileUpload dd3 = new Agent_FileUpload();
                    dd3.new_file = xspec_doc;
                    dd3.old_file = xxk.spec_doc;
                    ts.Add(dd3);
                }
                else
                {
                    xspec_doc = xxk.spec_doc;
                }
            }
            catch (Exception ee)
            {

            }


            using (connection = new SqlConnection(connectionString))
            {
                using (command = connection.CreateCommand())
                {
                    //  command.CommandTimeout = 300;
                    command.CommandText = "UPDATE pt_info SET loa_doc=@loa_doc,claim_doc=@claim_doc,pct_doc=@pct_doc,doa_doc=@doa_doc ,spec_doc=@spec_doc WHERE reg_number =@log_staff  ";

                    command.Connection.Open();
                    command.Parameters.Add("@loa_doc", SqlDbType.Text);
                    command.Parameters.Add("@claim_doc", SqlDbType.Text);
                    command.Parameters.Add("@pct_doc", SqlDbType.Text);
                    command.Parameters.Add("@doa_doc", SqlDbType.Text);
                    command.Parameters.Add("@spec_doc", SqlDbType.Text);
                    command.Parameters.Add("@log_staff", SqlDbType.NChar, 50);

                    command.Parameters["@loa_doc"].Value = xloa_doc;
                    command.Parameters["@claim_doc"].Value = xclaim_doc;
                    command.Parameters["@pct_doc"].Value = xpct_doc;
                    command.Parameters["@doa_doc"].Value = xdoa_doc;
                    command.Parameters["@spec_doc"].Value = xspec_doc;
                    command.Parameters["@log_staff"].Value = dd;
                    int h = Convert.ToInt32(command.ExecuteNonQuery());
                    command.Connection.Close();
                }
            }


            if (command.Connection.State == ConnectionState.Open) { command.Connection.Close(); }
        }
        catch (Exception exception)
        {
            //xID = "0";
            //XWriters pp = new XWriters();

            //string message = c_pwall.validationID + " " + DateTime.Now;

            //string vpath = System.Web.HttpContext.Current.Server.MapPath("~/") + "TradeMarkLog/NonGeneric/" + dd. c_pwall.validationID + ".txt";

            //pp.WriteToFile(message, vpath);
            //exception.ToString(); xID = "0";
            //   command.Connection.Close();
        }
        finally
        {

            //  xID = "0";
            // command.Connection.Close(); 
        }

      
        List<Stage> xxl = getStageByUserID(xxk.log_staff);

        updateUploadDate(xxk.log_staff);
        String xsubject = "upload from Patent  application  with number " + xxk.reg_number ;

        DateTime xxs = DateTime.Now;
        foreach (Agent_FileUpload Agent_FileUpload in ts)
        {

            Agent_FileUpload.agent_code = xxl[0].applicantID;
            Agent_FileUpload.Date_Uploaded = xxs;

            Agent_FileUpload.Status = xxl[0].data_status;
            Agent_FileUpload.pt_id = xxl[0].validationID;

            AddAgentUpload_Log(Agent_FileUpload);

        }


        AddAdminMail(xxl[0].applicantID, "upload from Patent  application ", xsubject, xxk.reg_number, xxk.xID);
        return xID;
    }

    public int updateEmail(string xid)
    {
        SqlConnection connection = new SqlConnection(this.Connect());
        Boolean bb = true;
        SqlCommand command = new SqlCommand("UPDATE Admin_Mail  SET Status= '" + bb + "'   WHERE id='" + xid + "'  ", connection);
        connection.Open();
        int num = command.ExecuteNonQuery();
        connection.Close();
        return num;
    }


    public int updateUploadDate(string xid)
    {
        DateTime dd = DateTime.Now;
        SqlConnection connection = new SqlConnection(this.Connect());
        Boolean bb = true;
        SqlCommand command = new SqlCommand("UPDATE pt_info   SET upload_date= '" +dd + "'   WHERE log_staff='" + xid + "'  ", connection);
        connection.Open();
        int num = command.ExecuteNonQuery();
        connection.Close();
        return num;
    }


    public int updateUploadDate2(string xid)
    {
        DateTime dd = DateTime.Now;
        SqlConnection connection = new SqlConnection(this.Connect());
        Boolean bb = true;
        SqlCommand command = new SqlCommand("UPDATE pt_info_backup   SET upload_date= '" + dd + "'   WHERE log_staff='" + xid + "'  ", connection);
        connection.Open();
        int num = command.ExecuteNonQuery();
        connection.Close();
        return num;
    }



    public void  ptinfobackup(string xid)
    {
        DateTime dd = DateTime.Now;
        SqlConnection connection = new SqlConnection(this.Connect());
        Boolean bb = true;
        SqlCommand command = new SqlCommand("INSERT INTO pt_info_backup (spec_doc,loa_doc,claim_doc,pct_doc,doa_doc,log_staff) SELECT spec_doc,loa_doc,claim_doc,pct_doc,doa_doc,log_staff FROM pt_info_backup where log_staff='" + xid + "'  "  , connection);
        connection.Open();
        int num = command.ExecuteNonQuery();
        connection.Close();
       // return num;
    }
    public Email4 getEmail2(string xid)
    {

        SqlConnection connection = new SqlConnection(this.Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM Admin_Mail WHERE id='" + xid + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        List<Email4> dd = new List<Email4>();
        Email4 x = new Email4();
        while (reader.Read())
        {

            x.id = Convert.ToInt32(reader["id"]);
            x.Subject = reader["Subject"].ToString();
            x.Message = reader["Message"].ToString();
            try
            {
                x.Sent_Date = (reader["Date_Sent"]).ToString();

            }

            catch (Exception ee)
            {

            }

            x.Agent_Code = reader["Agent_Code"].ToString();

            x.pt_id = reader["pt_id"].ToString();
            x.reg_number = reader["reg_number"].ToString();
            x.Data_Status = getStageByUserID2(x.pt_id)[0].data_status;
            //  dd.Add(x);

        }
        reader.Close();
        updateEmail(xid);
        return x;
    }


    public Email4 getOutboxEmail2(string xid)
    {

        SqlConnection connection = new SqlConnection(this.Connect2());
        SqlCommand command = new SqlCommand("SELECT * FROM Agent_Mail WHERE id='" + xid + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        List<Email4> dd = new List<Email4>();
        Email4 x = new Email4();
        while (reader.Read())
        {

            x.id = Convert.ToInt32(reader["id"]);
            x.Subject = reader["Subject"].ToString();
            x.Message = reader["Message"].ToString();
            try
            {
                x.Sent_Date = (reader["Date_Sent"]).ToString();

            }

            catch (Exception ee)
            {

            }

            x.Agent_Code = reader["Agent_Code"].ToString();

         
            //  dd.Add(x);

        }
        reader.Close();
      //  updateEmail(xid);
        return x;
    }


    public int getEmailCount2(string status, string data_status)
    {
        int succ = 0;
        SqlConnection connection = new SqlConnection(this.Connect());
        Boolean bb = false;
        SqlCommand command = new SqlCommand("select count(Admin_Mail.id) AS cnt from Admin_Mail inner join pt_info on Admin_Mail.pt_id = pt_info.xid inner join  pwallet on pt_info.log_staff = pwallet.id where  pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' and   Admin_Mail.Status ='" + bb + "'   ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            try
            {
                succ = Convert.ToInt32(reader["cnt"]);
            }
            catch (Exception ex)
            {
                succ = 0;
            }
        }
        reader.Close();
        return succ;
    }


    public List<String> getEmailCount4(string status, string data_status)
    {
        String  succ = "";
        SqlConnection connection = new SqlConnection(this.Connect());
        Boolean bb = false;
        List<String> jj = new List<string>();
        SqlCommand command = new SqlCommand("select pwallet.validationid  AS cnt from Admin_Mail inner join pt_info on Admin_Mail.pt_id = pt_info.xid inner join  pwallet on pt_info.log_staff = pwallet.id where  pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "'  and   Admin_Mail.Status ='" + bb + "'   ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            try
            {
                succ = Convert.ToString(reader["cnt"]);
                jj.Add(succ);
            }
            catch (Exception ex)
            {
                succ = "";
            }
        }
        reader.Close();
        return jj;
    }

   

    public String getEmailCount3(string status, string data_status)
    {
        int succ = 0;
        String succ2 = null;
        SqlConnection connection = new SqlConnection(this.Connect());
        Boolean bb = false;
        SqlCommand command = new SqlCommand("select count(Admin_Mail.id) AS cnt from Admin_Mail inner join pt_info on Admin_Mail.pt_id = pt_info.xid inner join  pwallet on pt_info.log_staff = pwallet.id  where  pwallet.status='" + status + "' AND pwallet.data_status='" + data_status + "' and Admin_Mail.Status ='" + bb + "'   ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            try
            {
                succ = Convert.ToInt32(reader["cnt"]);
            }
            catch (Exception ex)
            {
                succ = 0;
            }
        }
        reader.Close();
        if (succ > 0)
        {

            succ2 = succ + " UNREAD NOTIFICATIONS";
        }

        else
        {
            succ2 = null;
        }

        return succ2;
    }
    public List<Email4> getEmails()
    {

        SqlConnection connection = new SqlConnection(this.Connect());
        SqlCommand command = new SqlCommand("SELECT Admin_Mail.id,Admin_Mail.Subject,Admin_Mail.Message,Admin_Mail.Date_Sent,pwallet.validationid,pwallet.data_status,Admin_Mail.Agent_Code,Admin_Mail.Status,pt_info.title_of_invention,pt_id,pt_info.reg_number FROM Admin_Mail inner join pt_info on Admin_Mail.pt_id = pt_info.xid inner join  pwallet on pt_info.log_staff = pwallet.id order by Date_Sent desc  ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        List<Email4> dd = new List<Email4>();
        while (reader.Read())
        {
            Email4 x = new Email4();
            x.id = Convert.ToInt32(reader["id"]);
            x.Subject = reader["Subject"].ToString();
            x.Message = reader["Message"].ToString();
            try
            {
                x.Sent_Date = (reader["Date_Sent"]).ToString();

            }

            catch (Exception ee)
            {

            }

            x.Agent_Code = reader["Agent_Code"].ToString();
            x.Status = Convert.ToBoolean(reader["Status"]);
            x.pt_id = reader["pt_id"].ToString();
            x.reg_number = reader["reg_number"].ToString();
            x.Data_Status = reader["data_status"].ToString();
            x.Title= reader["title_of_invention"].ToString(); 
            x.Online_Id= reader["validationid"].ToString();
            dd.Add(x);

        }
        reader.Close();
        return dd;
    }

    public List<Email4> getOutboxEmails()
    {

        SqlConnection connection = new SqlConnection(this.Connect2());
        SqlCommand command = new SqlCommand("SELECT id,Subject,Message,Date_Sent,agent_code,pt_id   FROM Agent_Mail where subject in ('Patent Examiner  Information','Patent Search  Information') order by Date_Sent desc  ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        List<Email4> dd = new List<Email4>();
        while (reader.Read())
        {
            Email4 x = new Email4();
            x.id = Convert.ToInt32(reader["id"]);
            x.Subject = reader["Subject"].ToString();
            x.Message = reader["Message"].ToString();
            try
            {
                x.Sent_Date = (reader["Date_Sent"]).ToString();

            }

            catch (Exception ee)
            {

            }
            x.Agent_Code= reader["agent_code"].ToString();
            String vpt_id= reader["pt_id"].ToString();

            List<PtInfo> dx = getPtInfoByPwalletID(vpt_id);

            List<Stage> dx2 = getStageByUserID2(dx[0].xID);

            x.Title = dx[0].title_of_invention;
            x.Online_Id = dx2[0].validationID;

            dd.Add(x);

        }
        reader.Close();
        return dd;
    }

    public void AddAdminMail(string agent_code, String Subject, String Message, String reg_number, String pt_id)
    {
        string str = DateTime.Today.Date.ToString("yyyy-MM-dd");
        string str2 = DateTime.Now.ToLongTimeString();
        string connectionString = Connect();
        string str4 = "0";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Admin_Mail (Message,Subject,Date_Sent,Agent_Code,Status,pt_id,reg_number) VALUES (@Message,@Subject,@Date_Sent,@Agent_Code,@Status,@pt_id,@reg_number) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@Message", SqlDbType.NVarChar, 500);
        command.Parameters.Add("@Subject", SqlDbType.NVarChar, 500);
        command.Parameters.Add("@Date_Sent", SqlDbType.DateTime);
        command.Parameters.Add("@Agent_Code", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@pt_id", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@reg_number", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@Status", SqlDbType.Bit);

        command.Parameters["@Message"].Value = Message;
        command.Parameters["@Subject"].Value = Subject;
        command.Parameters["@Date_Sent"].Value = DateTime.Now;
        command.Parameters["@Agent_Code"].Value = agent_code;
        command.Parameters["@pt_id"].Value = pt_id;
        command.Parameters["@reg_number"].Value = reg_number;
        command.Parameters["@Status"].Value = 0;

        str4 = command.ExecuteScalar().ToString();
        connection.Close();

    }


    public void AddAgentUpload_Log(Agent_FileUpload dd)
    {
        string str = DateTime.Today.Date.ToString("yyyy-MM-dd");
        string str2 = DateTime.Now.ToLongTimeString();
        string connectionString = Connect();
        string str4 = "0";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Agent_FileUpload (agent_code,old_file,new_file,Date_Uploaded,Status,pt_id) VALUES (@agent_code,@old_file,@new_file,@Date_Uploaded,@Status,@pt_id) SELECT SCOPE_IDENTITY()";
        connection.Open();
        command.Parameters.Add("@agent_code", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@old_file", SqlDbType.NVarChar, 500);
        command.Parameters.Add("@new_file", SqlDbType.NVarChar, 500);
        command.Parameters.Add("@Date_Uploaded", SqlDbType.DateTime);
        command.Parameters.Add("@Status", SqlDbType.NVarChar, 50);
        command.Parameters.Add("@pt_id", SqlDbType.NVarChar, 50);


        command.Parameters["@agent_code"].Value = dd.agent_code;
        command.Parameters["@old_file"].Value =dd.old_file;
        command.Parameters["@new_file"].Value =dd.new_file;
        command.Parameters["@Date_Uploaded"].Value = dd.Date_Uploaded;
        command.Parameters["@Status"].Value = dd.Status;
        command.Parameters["@pt_id"].Value = dd.pt_id;
      

        str4 = command.ExecuteScalar().ToString();
        connection.Close();

    }
    public string getPtTypeName(string id)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT type from pt_type where xID='" + id + "'", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["type"].ToString();
        }
        reader.Close();
        return str;
    }

    public List<Stage> getPwalletDetailsByID(string ID)
    {
        List<Stage> list = new List<Stage>();
        new Stage();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE ID='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Stage item = new Stage
            {
                ID = reader["ID"].ToString(),
                applicantID = reader["applicantID"].ToString(),
                validationID = reader["validationID"].ToString(),
                stage = reader["stage"].ToString(),
                amt = reader["amt"].ToString(),
                reg_date = reader["reg_date"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }


    public List<Recordal> getG_PwalletByID3(Int32 ValidationID)
    {
        List<Recordal> pp2 = new List<Recordal>();
        SqlConnection connection = new SqlConnection(this.Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM Recordal WHERE ID='" + ValidationID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        foreach (SqlParameter Parameter in command.Parameters)
        {
            if (Parameter.Value == null)
            {
                Parameter.Value = DBNull.Value;
            }
        }
        while (reader.Read())
        {
            Recordal pp = new Recordal();
           
           
           
              
      
           
            
            try
            {
                pp.RECORDAL_REQUEST_DATE = Convert.ToDateTime(reader["RECORDAL_REQUEST_DATE"]);
            }
            catch (Exception ee)
            {

            }
            try
            {


                pp.RECORDAL_APPROVE_DATE = Convert.ToDateTime(reader["RECORDAL_APPROVE_DATE"]);
            }

            catch (Exception ee)
            {

            }
            try
            {
                pp.AMOUNT = reader["AMOUNT"].ToString();
            }
            catch (Exception ee)
            {

            }

            try
            {
                pp.TRANSACTIONID = reader["TRANSACTIONID"].ToString();
            }
            catch (Exception ee)
            {

            }
            try
            {
                pp.OFFICER = reader["XOFFICER"].ToString();
            }
            catch (Exception ee)
            {
                pp.OFFICER = null;
            }
            try
            {
                pp.VSTATUS = reader["STATUS"].ToString();
            }
            catch (Exception ee)
            {

            }


           


           

            try
            {
                pp.RECORDAL_TYPE = reader["RECORDAL_TYPE"].ToString();
            }
            catch (Exception ee)
            {

            }

            try
            {
                pp.Xcomment = reader["Xcomment"].ToString();
            }
            catch (Exception ee)
            {

            }

           

           

           

           

          


         



            

            

            try
            {
                pp.data_status2 = reader["data_status2"].ToString();
            }
            catch (Exception ee)
            {

            }

        



           



            pp2.Add(pp);

        }
        reader.Close();
        connection.Close();
        return pp2;
    }

    public string getPwalletID(string validationID)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT ID FROM pwallet WHERE validationID='" + validationID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = Convert.ToInt64(reader["ID"]).ToString();
        }
        reader.Close();
        return str;
    }

    public string getPwalletID22(string validationID)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT ID FROM pwallet WHERE ID='" + validationID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = Convert.ToInt64(reader["ID"]).ToString();
        }
        reader.Close();
        return str;
    }

    public string getPwalletIDByMID(string pt_infoID)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT log_staff from pt_info where xID='" + pt_infoID + "'", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["log_staff"].ToString();
        }
        reader.Close();
        return str;
    }

    public Renewal getRenewalByID(string xID)
    {
        Renewal renewal = new Renewal();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM renewal WHERE xID='" + xID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            renewal = new Renewal
            {
                xID = reader["xID"].ToString(),
                title = ConvertTab2Apos(reader["title"].ToString()),
                type = ConvertTab2Apos(reader["type"].ToString()),
                reg_no = ConvertTab2Apos(reader["reg_no"].ToString()),
                app_no = reader["app_no"].ToString(),
                app_date = reader["app_date"].ToString(),
                xname = reader["xname"].ToString(),
                xaddy = reader["xaddy"].ToString(),
                xmobile = ConvertTab2Apos(reader["xmobile"].ToString()),
                xemail = ConvertTab2Apos(reader["xemail"].ToString()),
                agt_name = ConvertTab2Apos(reader["agt_name"].ToString()),
                agt_code = reader["agt_code"].ToString(),
                agt_addy = reader["agt_addy"].ToString(),
                agt_mobile = reader["agt_mobile"].ToString(),
                agt_email = reader["agt_email"].ToString(),
                last_rwl_date = ConvertTab2Apos(reader["last_rwl_date"].ToString()),
                reg_date = ConvertTab2Apos(reader["reg_date"].ToString()),
                reg_time = ConvertTab2Apos(reader["reg_time"].ToString()),
                log_staff = reader["log_staff"].ToString(),
                visible = reader["visible"].ToString(),
                sync = reader["sync"].ToString()
            };
        }
        reader.Close();
        return renewal;
    }


    public Applicant_Recordal getApplicantRecordal(string xID)
    {
        Applicant_Recordal renewal = new Applicant_Recordal();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM APPLICANT_RECORDAL  WHERE Recordal_Id='" + xID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            renewal = new Applicant_Recordal
            {
                old_applicant = reader["OLD_APPLICANT"].ToString(),
                new_applicant = reader["NEW_APPLICANT"].ToString()
               
               
            };
        }
        reader.Close();
        return renewal;
    }

    public Renewal getRenewalByLogstaffID(string log_staff)
    {
        Renewal renewal = new Renewal();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM renewal WHERE log_staff='" + log_staff + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            renewal = new Renewal
            {
                xID = reader["xID"].ToString(),
                title = ConvertTab2Apos(reader["title"].ToString()),
                type = ConvertTab2Apos(reader["type"].ToString()),
                reg_no = ConvertTab2Apos(reader["reg_no"].ToString()),
                app_no = reader["app_no"].ToString(),
                app_date = reader["app_date"].ToString(),
                xname = reader["xname"].ToString(),
                xaddy = reader["xaddy"].ToString(),
                xmobile = ConvertTab2Apos(reader["xmobile"].ToString()),
                xemail = ConvertTab2Apos(reader["xemail"].ToString()),
                agt_name = ConvertTab2Apos(reader["agt_name"].ToString()),
                agt_code = reader["agt_code"].ToString(),
                agt_addy = reader["agt_addy"].ToString(),
                agt_mobile = reader["agt_mobile"].ToString(),
                agt_email = reader["agt_email"].ToString(),
                last_rwl_date = ConvertTab2Apos(reader["last_rwl_date"].ToString()),
                reg_date = ConvertTab2Apos(reader["reg_date"].ToString()),
                reg_time = ConvertTab2Apos(reader["reg_time"].ToString()),
                log_staff = reader["log_staff"].ToString(),
                visible = reader["visible"].ToString(),
                sync = reader["sync"].ToString()
            };
        }
        reader.Close();
        return renewal;
    }

    public int getRenStageIDByvalidationID(string validationID)
    {
        int num = 0;
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT ID FROM x_pwallet WHERE validationID='" + validationID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            num = Convert.ToInt32(reader["ID"]);
        }
        reader.Close();
        return num;
    }

    public Representative getRepByUserID(string ID)
    {
        Representative representative = new Representative
        {
            ID = "",
            agent_code = "",
            xname = "",
            nationality = "",
            country = "",
            state = "",
            address = "",
            xemail = "",
            xmobile = "",
            log_staff = "",
            visible = ""
        };
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM representative WHERE log_staff='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            representative.ID = reader["ID"].ToString();
            representative.agent_code = reader["agent_code"].ToString();
            representative.xname = ConvertTab2Apos(reader["xname"].ToString());
            representative.nationality = reader["nationality"].ToString();
            representative.country = reader["country"].ToString();
            representative.nationality = reader["nationality"].ToString();
            representative.state = reader["state"].ToString();
            representative.address = ConvertTab2Apos(reader["address"].ToString());
            representative.xemail = ConvertTab2Apos(reader["xemail"].ToString());
            representative.xmobile = reader["xmobile"].ToString();
            representative.log_staff = reader["log_staff"].ToString();
            representative.visible = reader["visible"].ToString();
        }
        reader.Close();
        return representative;
    }

    public List<Representative> getRepListByUserID(string validationID)
    {
        List<Representative> list = new List<Representative>();
        new Representative();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM representative WHERE log_staff='" + validationID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Representative item = new Representative
            {
                ID = reader["ID"].ToString(),
                agent_code = reader["agent_code"].ToString(),
                xname = ConvertTab2Apos(reader["xname"].ToString()),
                nationality = reader["nationality"].ToString(),
                country = reader["country"].ToString(),
                state = reader["state"].ToString(),
                address = ConvertTab2Apos(reader["address"].ToString()),
                xemail = ConvertTab2Apos(reader["xemail"].ToString()),
                xmobile = reader["xmobile"].ToString(),
                log_staff = reader["log_staff"].ToString(),
                visible = reader["visible"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }
    public pt.Stage getPwalletByID2(string xid)
    {
        pt.Stage pwallet = new pt.Stage();
        SqlConnection connection = new SqlConnection(this.Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE id='" + xid + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {


            pwallet.data_status = reader["data_status"].ToString();

            pwallet.status = reader["status"].ToString();
        }
        reader.Close();
        connection.Close();
        return pwallet;
    }
    public Recordal_Result InsertRecordal( string logstaff, string vamount, string vtransid, string description)
    {
       pt.Stage pw = getPwalletByID2(logstaff);

        string str = "";
        SqlConnection connection = new SqlConnection(this.Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Recordal (RECORDAL_REQUEST_DATE,LOG_STAFF,STATUS,AMOUNT,TRANSACTIONID,RECORDAL_TYPE,data_status,data_status2,Description) VALUES (@RECORDAL_REQUEST_DATE,@LOG_STAFF,@STATUS,@AMOUNT,@TRANSACTIONID,@RECORDAL_TYPE,@data_status,@data_status2,@Description) SELECT SCOPE_IDENTITY()";
        connection.Open();
      
        command.Parameters.Add("@RECORDAL_REQUEST_DATE", SqlDbType.DateTime);
       
        command.Parameters.Add("@LOG_STAFF", SqlDbType.VarChar, 50);
        command.Parameters.Add("@STATUS", SqlDbType.VarChar, 50);
        command.Parameters.Add("@AMOUNT", SqlDbType.VarChar, 50);
        command.Parameters.Add("@TRANSACTIONID", SqlDbType.VarChar, 50);
        command.Parameters.Add("@RECORDAL_TYPE", SqlDbType.VarChar, 50);
        command.Parameters.Add("@data_status", SqlDbType.VarChar, 50);
        command.Parameters.Add("@data_status2", SqlDbType.VarChar, 50);
        command.Parameters.Add("@Description", SqlDbType.VarChar, 500);

       
        command.Parameters["@Description"].Value = description;
        
        command.Parameters["@RECORDAL_REQUEST_DATE"].Value = DateTime.Now;
        command.Parameters["@LOG_STAFF"].Value = logstaff;
        command.Parameters["@STATUS"].Value = "Pending";
        command.Parameters["@AMOUNT"].Value = vamount;
        command.Parameters["@TRANSACTIONID"].Value = vtransid;
        command.Parameters["@RECORDAL_TYPE"].Value = "p007";

        command.Parameters["@data_status"].Value = pw.data_status;
        command.Parameters["@data_status2"].Value = pw.status;
        foreach (SqlParameter Parameter in command.Parameters)
        {
            if (Parameter.Value == null)
            {
                Parameter.Value = DBNull.Value;
            }
        }
        str = command.ExecuteScalar().ToString();
        connection.Close();
        update_RecordalStatus3(str, "1", "Recordal");
        //  g_pwalletStatus(logstaff, "1", "Recordal");
        string vf = getG_PwalletTransID(logstaff);

        Recordal_Result ks = new Recordal_Result();
        ks.Recordal_Id = str;
        ks.TransactionId = vf;
        return ks;
    }

    public void  InsertRecordalApplicant(string RecordalId, string oldApplicant, string NewApplicant)
    {
        
        string str = "";
        SqlConnection connection = new SqlConnection(this.Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO APPLICANT_RECORDAL (OLD_APPLICANT,NEW_APPLICANT,Recordal_Id) VALUES (@OLD_APPLICANT,@NEW_APPLICANT,@Recordal_Id) SELECT SCOPE_IDENTITY()";
        connection.Open();

       

        command.Parameters.Add("@Recordal_Id", SqlDbType.VarChar, 50);
        command.Parameters.Add("@OLD_APPLICANT", SqlDbType.VarChar, 200);
        command.Parameters.Add("@NEW_APPLICANT", SqlDbType.VarChar, 200);
        

       
        command.Parameters["@Recordal_Id"].Value = RecordalId;
        command.Parameters["@OLD_APPLICANT"].Value = oldApplicant;
        command.Parameters["@NEW_APPLICANT"].Value = NewApplicant;
       
      
        foreach (SqlParameter Parameter in command.Parameters)
        {
            if (Parameter.Value == null)
            {
                Parameter.Value = DBNull.Value;
            }
        }
        str = command.ExecuteScalar().ToString();
        connection.Close();
      
    }

    public void InsertRecordalPtInfo(string RecordalId, string oldPtInfo, string NewPtInfo)
    {

        string str = "";
        SqlConnection connection = new SqlConnection(this.Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO PATENTINFO_RECORDAL (OLD_PATENTINFO,NEW_PATENTINFO,Recordal_Id) VALUES (@OLD_APPLICANT,@NEW_APPLICANT,@Recordal_Id) SELECT SCOPE_IDENTITY()";
        connection.Open();



        command.Parameters.Add("@Recordal_Id", SqlDbType.VarChar, 50);
        command.Parameters.Add("@OLD_APPLICANT", SqlDbType.VarChar, 200);
        command.Parameters.Add("@NEW_APPLICANT", SqlDbType.VarChar, 200);



        command.Parameters["@Recordal_Id"].Value = RecordalId;
        command.Parameters["@OLD_APPLICANT"].Value = oldPtInfo;
        command.Parameters["@NEW_APPLICANT"].Value = NewPtInfo;


        foreach (SqlParameter Parameter in command.Parameters)
        {
            if (Parameter.Value == null)
            {
                Parameter.Value = DBNull.Value;
            }
        }
        str = command.ExecuteScalar().ToString();
        connection.Close();

    }

    public void InsertRecordalAssignment_info(string RecordalId, string oldAssignment_info, string NewAssignment_info)
    {

        string str = "";
        SqlConnection connection = new SqlConnection(this.Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO ASSIGNMENTINFO_RECORDAL (OLD_ASSIGNMENTINFO,NEW_ASSIGNMENTINFO,Recordal_Id) VALUES (@OLD_APPLICANT,@NEW_APPLICANT,@Recordal_Id) SELECT SCOPE_IDENTITY()";
        connection.Open();



        command.Parameters.Add("@Recordal_Id", SqlDbType.VarChar, 50);
        command.Parameters.Add("@OLD_APPLICANT", SqlDbType.VarChar, 200);
        command.Parameters.Add("@NEW_APPLICANT", SqlDbType.VarChar, 200);



        command.Parameters["@Recordal_Id"].Value = RecordalId;
        command.Parameters["@OLD_APPLICANT"].Value = oldAssignment_info;
        command.Parameters["@NEW_APPLICANT"].Value = NewAssignment_info;


        foreach (SqlParameter Parameter in command.Parameters)
        {
            if (Parameter.Value == null)
            {
                Parameter.Value = DBNull.Value;
            }
        }
        str = command.ExecuteScalar().ToString();
        connection.Close();

    }

    public void InsertRecordalInventor_info(string RecordalId, string oldInventor_info, string NewInventor_info)
    {

        string str = "";
        SqlConnection connection = new SqlConnection(this.Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO INVENTORINFO_RECORDAL (OLD_INVENTORINFO,NEW_INVENTORINFO,Recordal_Id) VALUES (@OLD_APPLICANT,@NEW_APPLICANT,@Recordal_Id) SELECT SCOPE_IDENTITY()";
        connection.Open();



        command.Parameters.Add("@Recordal_Id", SqlDbType.VarChar, 50);
        command.Parameters.Add("@OLD_APPLICANT", SqlDbType.VarChar, 200);
        command.Parameters.Add("@NEW_APPLICANT", SqlDbType.VarChar, 200);



        command.Parameters["@Recordal_Id"].Value = RecordalId;
        command.Parameters["@OLD_APPLICANT"].Value = oldInventor_info;
        command.Parameters["@NEW_APPLICANT"].Value = NewInventor_info;


        foreach (SqlParameter Parameter in command.Parameters)
        {
            if (Parameter.Value == null)
            {
                Parameter.Value = DBNull.Value;
            }
        }
        str = command.ExecuteScalar().ToString();
        connection.Close();

    }

    public void InsertRecordalPriority_info(string RecordalId, string oldPriority_info, string NewPriority_info)
    {

        string str = "";
        SqlConnection connection = new SqlConnection(this.Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO INVENTORINFO_RECORDAL (OLD_PriorityINFO,NEW_PriorityINFO,Recordal_Id) VALUES (@OLD_APPLICANT,@NEW_APPLICANT,@Recordal_Id) SELECT SCOPE_IDENTITY()";
        connection.Open();



        command.Parameters.Add("@Recordal_Id", SqlDbType.VarChar, 50);
        command.Parameters.Add("@OLD_APPLICANT", SqlDbType.VarChar, 200);
        command.Parameters.Add("@NEW_APPLICANT", SqlDbType.VarChar, 200);



        command.Parameters["@Recordal_Id"].Value = RecordalId;
        command.Parameters["@OLD_APPLICANT"].Value = oldPriority_info;
        command.Parameters["@NEW_APPLICANT"].Value = NewPriority_info;


        foreach (SqlParameter Parameter in command.Parameters)
        {
            if (Parameter.Value == null)
            {
                Parameter.Value = DBNull.Value;
            }
        }
        str = command.ExecuteScalar().ToString();
        connection.Close();

    }
    public string getG_PwalletTransID(string id)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(this.Connect());
        SqlCommand command = new SqlCommand("SELECT validationID from pwallet where ID='" + id + "'", connection)
        {
            CommandTimeout = 0
        };
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
    public int update_RecordalStatus3(string xID, string sent_status, string sent_status2)
    {
        //Int32 vint = getMaxId(xID);
        //String AddressId = getApplicantAddressId(xID);
        //Int64 AddressId2 = Convert.ToInt64(AddressId);
        SqlConnection connection = new SqlConnection(this.Connect());
        SqlCommand command = connection.CreateCommand();
        DateTime vv = DateTime.Now;

        command.CommandText = "UPDATE Recordal   SET data_status3=@sent_status,data_status4 =@sent_status2  WHERE id=@xID ";
        connection.Open();
        command.Parameters.Add("@xID", SqlDbType.NVarChar, 500);
        command.Parameters.Add("@sent_status", SqlDbType.NVarChar, 500);

        command.Parameters.Add("@sent_status2", SqlDbType.NVarChar, 500);


        command.Parameters["@xID"].Value = xID;
        command.Parameters["@sent_status"].Value = sent_status;
        command.Parameters["@sent_status2"].Value = sent_status2;


        int num = command.ExecuteNonQuery();
        connection.Close();
        return num;
    }
    public List<PtInfo> getSearchPtInfoRS(string kword, List<string> fulltext, string cri)
    {
        List<PtInfo> list = new List<PtInfo>();
        new PtInfo();
        string cmdText = "";
        string str2 = "";
        string str3 = "";
        string str4 = "";
        int num = 0;
        SqlConnection connection = new SqlConnection(Connect());
        if (fulltext == null)
        {
            if (cri == "0")
            {
                cmdText = "select * from pt_info LEFT OUTER JOIN pwallet ON pt_info.log_staff=pwallet.ID WHERE (pwallet.status >'3') AND (title_of_invention like '%" + kword + "%') ORDER BY xID ASC";
            }
            else
            {
                cmdText = "select * from pt_info LEFT OUTER JOIN pwallet ON pt_info.log_staff=pwallet.ID WHERE  (pwallet.status >'3') AND (title_of_invention like '%" + kword + "%') ORDER BY xID ASC";
            }
        }
        else
        {
            num = fulltext.Count - 1;
            if (cri == "0")
            {
                str2 = "select * from pt_info LEFT OUTER JOIN pwallet ON pt_info.log_staff=pwallet.ID WHERE (pwallet.status >'3') AND ";
            }
            else
            {
                str2 = "select * from pt_info LEFT OUTER JOIN pwallet ON pt_info.log_staff=pwallet.ID WHERE (pwallet.status >'3') AND ";
            }
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
            str4 = " ORDER BY xID ASC";
            cmdText = str2 + str3 + str4;
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

    public List<Stage> getStageByUserID(string ID)
    {
        List<Stage> list = new List<Stage>();
        new Stage();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE ID='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Stage item = new Stage
            {
                ID = reader["ID"].ToString(),
                applicantID = reader["applicantID"].ToString(),
                validationID = reader["validationID"].ToString(),
                stage = reader["stage"].ToString(),
                status = reader["status"].ToString(),
                amt = reader["amt"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                data_status = reader["data_status"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<Stage> getStageByUserID2(string ID)
    {
        List<Stage> list = new List<Stage>();
        new Stage();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE ID= (select log_staff from pt_info where xid='" + ID + "') ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Stage item = new Stage
            {
                ID = reader["ID"].ToString(),
                applicantID = reader["applicantID"].ToString(),
                validationID = reader["validationID"].ToString(),
                stage = reader["stage"].ToString(),
                status = reader["status"].ToString(),
                amt = reader["amt"].ToString(),
                reg_date = reader["reg_date"].ToString(),
                data_status = reader["data_status"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public List<Stage> getStageByUserID3(string validationID)
    {
        List<Stage> list = new List<Stage>();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE validationID='" + validationID + "'    AND data_status <>'' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Stage item = new Stage
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

    public List<Stage> getStageByUserIDAcc(string validationID, string agentID)
    {
        List<Stage> list = new List<Stage>();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE validationID='" + validationID + "'  AND applicantID='" + agentID + "'  AND data_status <>'' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Stage item = new Stage
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

    public List<Stage> getStageByUserIDAdmin(string validationID)
    {
        List<Stage> list = new List<Stage>();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE validationID='" + validationID + "'  AND data_status <>'' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            Stage item = new Stage
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

    public int getStageIDByvalidationID(string validationID)
    {
        int num = 0;
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT ID FROM pwallet WHERE validationID='" + validationID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            num = Convert.ToInt32(reader["ID"]);
        }
        reader.Close();
        return num;
    }

    public List<State> getState(string countryID)
    {
        List<State> list = new List<State>();
        new State();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM state WHERE countryID='" + countryID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            State item = new State
            {
                ID = Convert.ToInt64(reader["ID"]).ToString(),
                name = reader["name"].ToString(),
                countryID = reader["countryID"].ToString()
            };
            list.Add(item);
        }
        reader.Close();
        return list;
    }

    public string getStateName(string ID)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT name FROM state WHERE ID='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["name"].ToString();
        }
        reader.Close();
        return str;
    }

    public Stage getStatusIDByvalidationID(string validationID)
    {
        Stage stage = new Stage();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM pwallet WHERE validationID='" + validationID + "'", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            stage.status = reader["status"].ToString();
            stage.stage = reader["stage"].ToString();
            stage.applicantID = reader["applicantID"].ToString();
        }
        reader.Close();
        return stage;
    }

    public SWallet getSwalletByID(string ID)
    {
        SWallet wallet = new SWallet();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM search_wallet WHERE mark_infoID='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            wallet.ID = Convert.ToInt64(reader["ID"]).ToString();
            wallet.mark_infoID = reader["mark_infoID"].ToString();
            wallet.search_cri = reader["search_cri"].ToString();
            wallet.search_str = reader["search_str"].ToString();
            wallet.xclass = reader["xclass"].ToString();
            wallet.log_officer = reader["log_officer"].ToString();
            wallet.reg_date = reader["reg_date"].ToString();
            wallet.visible = reader["visible"].ToString();
        }
        reader.Close();
        return wallet;
    }

    public XPwallet getXPwalletDetailsByCode(string validationID, string xcode)
    {
        XPwallet pwallet = new XPwallet();
        new Stage();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM x_pwallet WHERE validationID='" + validationID + "' AND log_officer='" + xcode + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            pwallet = new XPwallet
            {
                ID = reader["ID"].ToString(),
                applicantID = reader["applicantID"].ToString(),
                validationID = reader["validationID"].ToString(),
                item_code = reader["item_code"].ToString(),
                stage = reader["stage"].ToString(),
                status = reader["status"].ToString(),
                data_status = reader["data_status"].ToString(),
                amt = reader["amt"].ToString(),
                reg_date = reader["reg_date"].ToString()
            };
        }
        reader.Close();
        return pwallet;
    }

    public XPwallet getXPwalletDetailsByID(string ID)
    {
        XPwallet pwallet = new XPwallet();
        new Stage();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM x_pwallet WHERE ID='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            pwallet = new XPwallet
            {
                ID = reader["ID"].ToString(),
                applicantID = reader["applicantID"].ToString(),
                validationID = reader["validationID"].ToString(),
                log_officer = reader["log_officer"].ToString(),
                item_code = reader["item_code"].ToString(),
                stage = reader["stage"].ToString(),
                status = reader["status"].ToString(),
                data_status = reader["data_status"].ToString(),
                amt = reader["amt"].ToString(),
                reg_date = reader["reg_date"].ToString()
            };
        }
        reader.Close();
        return pwallet;
    }

    public XPwallet getXPwalletDetailsByID2(string ID)
    {
        XPwallet pwallet = new XPwallet();
        new Stage();
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT * FROM x_pwallet WHERE validationid='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            pwallet = new XPwallet
            {
                ID = reader["ID"].ToString(),
                applicantID = reader["applicantID"].ToString(),
                validationID = reader["validationID"].ToString(),
                log_officer = reader["log_officer"].ToString(),
                item_code = reader["item_code"].ToString(),
                stage = reader["stage"].ToString(),
                status = reader["status"].ToString(),
                data_status = reader["data_status"].ToString(),
                amt = reader["amt"].ToString(),
                reg_date = reader["reg_date"].ToString()
            };
        }
        reader.Close();
        return pwallet;
    }

    public string updateApplicant(Applicant x)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE [dbo].[applicant] SET [xname] ='" + ConvertApos2Tab(x.xname) + "',[address] = '" + ConvertApos2Tab(x.address) + "',[xemail] = '" + ConvertApos2Tab(x.xemail) + "',[xmobile] = '" + x.xmobile + "',  ";
        string commandText = command.CommandText;
        command.CommandText = commandText + " [nationality] = '" + x.nationality + "',[log_staff] = '" + x.log_staff + "',[visible] = '" + x.visible + "' WHERE ID ='" + x.ID + "' ";
        connection.Open();
        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str2;
    }

    public string updateAssignment_info(Assignment_info x)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE [dbo].[assignment_info] SET [date_of_assignment] ='" + x.date_of_assignment + "',[assignee_name] = '" + ConvertApos2Tab(x.assignee_name) + "',[assignee_address] = '" + ConvertApos2Tab(x.assignee_address) + "', ";
        string commandText = command.CommandText;
        command.CommandText = commandText + "  [assignee_nationality] = '" + x.assignee_nationality + "',[assignor_name] = '" + ConvertApos2Tab(x.assignor_name) + "',[assignor_address] = '" + ConvertApos2Tab(x.assignor_address) + "' , ";
        commandText = command.CommandText;
        command.CommandText = commandText + "  [assignor_nationality] = '" + x.assignor_nationality + "',[log_staff] = '" + x.log_staff + "',[xvisible] = '" + x.visible + "' WHERE xID ='" + x.ID + "' ";
        connection.Open();
        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str2;
    }

    public string updateClaimDocz(string claim_doc, string claim_no, string pwalletID)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE pt_info SET claim_doc=@claim_doc,claim_no=@claim_no WHERE xID=@pwalletID ";
        connection.Open();
        command.Parameters.Add("@claim_doc", SqlDbType.Text);
        command.Parameters.Add("@claim_no", SqlDbType.NVarChar, 20);
        command.Parameters.Add("@pwalletID", SqlDbType.NVarChar);
        command.Parameters["@claim_doc"].Value = claim_doc;
        command.Parameters["@claim_no"].Value = claim_no;
        command.Parameters["@pwalletID"].Value = pwalletID;
        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str2;
    }

    public string updateDoaDocz(string doa_doc, string doa_no, string pwalletID)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE pt_info SET doa_doc=@doa_doc,doa_no=@doa_no WHERE xID=@pwalletID ";
        connection.Open();
        command.Parameters.Add("@doa_doc", SqlDbType.Text);
        command.Parameters.Add("@doa_no", SqlDbType.NVarChar, 20);
        command.Parameters.Add("@pwalletID", SqlDbType.NVarChar);
        command.Parameters["@doa_doc"].Value = doa_doc;
        command.Parameters["@doa_no"].Value = doa_no;
        command.Parameters["@pwalletID"].Value = pwalletID;
        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str2;
    }

    public int updateHwallet(string xid, string used_status, string used_date, string product_title)
    {
        int num = 0;
        string connectionString = ConnectXpay();
        using (TransactionScope scope = new TransactionScope())
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE hwallet SET used_status='" + used_status + "',product_title='" + product_title + "',used_date='" + used_date + "'  WHERE xid='" + xid + "' ";
                    command.Connection.Open();
                    num = Convert.ToInt32(command.ExecuteNonQuery());
                }
            }
            scope.Complete();
        }
        return num;
    }

    public string updateInventor(Inventor x)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE [dbo].[inventor] SET [xname] ='" + ConvertApos2Tab(x.xname) + "',[address] = '" + ConvertApos2Tab(x.address) + "',[xemail] = '" + ConvertApos2Tab(x.xemail) + "', ";
        string commandText = command.CommandText;
        command.CommandText = commandText + "  [xmobile] = '" + x.xmobile + "',[nationality] = '" + x.nationality + "',[log_staff] = '" + x.log_staff + "' , ";
        commandText = command.CommandText;
        command.CommandText = commandText + "  [visible] = '" + x.visible + "' WHERE ID ='" + x.ID + "' ";
        connection.Open();
        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str2;
    }

    public string updateLoaDocz(string loa_doc, string loa_no, string pwalletID)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE pt_info SET loa_doc=@loa_doc,loa_no=@loa_no WHERE xID=@pwalletID ";
        connection.Open();
        command.Parameters.Add("@loa_doc", SqlDbType.Text);
        command.Parameters.Add("@loa_no", SqlDbType.NVarChar, 20);
        command.Parameters.Add("@pwalletID", SqlDbType.NVarChar);
        command.Parameters["@loa_doc"].Value = loa_doc;
        command.Parameters["@loa_no"].Value = loa_no;
        command.Parameters["@pwalletID"].Value = pwalletID;
        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str2;
    }

    public string updatePctDocz(string pct_doc, string pct_no, string pwalletID)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE pt_info SET pct_doc=@pct_doc,pct_no=@pct_no WHERE xID=@pwalletID ";
        connection.Open();
        command.Parameters.Add("@pct_doc", SqlDbType.Text);
        command.Parameters.Add("@pct_no", SqlDbType.NVarChar, 20);
        command.Parameters.Add("@pwalletID", SqlDbType.NVarChar);
        command.Parameters["@pct_doc"].Value = pct_doc;
        command.Parameters["@pct_no"].Value = pct_no;
        command.Parameters["@pwalletID"].Value = pwalletID;
        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str2;
    }

    public string updatePriority_info(Priority_info x)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE [dbo].[priority_info] SET [countryID] ='" + x.countryID + "',[app_no] = '" + x.app_no + "',[xdate] = '" + x.xdate + "' ";
        string commandText = command.CommandText;
        command.CommandText = commandText + "   WHERE xID ='" + x.xID + "' ";
        connection.Open();
        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str2;
    }

    public string updatePtDocz(string spec_doc, string loa_doc, string loa_no, string claim_doc, string claim_no, string pct_doc, string pct_no, string doa_doc, string doa_no, string pwalletID)
    {

        if (claim_doc == null || claim_doc =="" )
        {
            claim_no = "0";

        }

        if (loa_doc == null || loa_doc=="")
        {
            loa_no = "0";

        }
            string connectionString = Connect();
            string str2 = "";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE pt_info SET spec_doc=@spec_doc,loa_doc=@loa_doc,claim_doc=@claim_doc,pct_doc=@pct_doc,doa_doc=@doa_doc,loa_no=@loa_no,claim_no=@claim_no,pct_no=@pct_no,doa_no=@doa_no WHERE xID=@pwalletID ";
            //try
            //{
                connection.Open();
                command.Parameters.Add("@spec_doc", SqlDbType.Text);
                command.Parameters.Add("@loa_doc", SqlDbType.Text);
                command.Parameters.Add("@claim_doc", SqlDbType.Text);
                command.Parameters.Add("@pct_doc", SqlDbType.Text);
                command.Parameters.Add("@doa_doc", SqlDbType.Text);
                command.Parameters.Add("@loa_no", SqlDbType.NVarChar, 20);
                command.Parameters.Add("@claim_no", SqlDbType.NVarChar, 20);
                command.Parameters.Add("@pct_no", SqlDbType.NVarChar, 20);
                command.Parameters.Add("@doa_no", SqlDbType.NVarChar, 20);
                command.Parameters.Add("@pwalletID", SqlDbType.NVarChar);
                command.Parameters["@spec_doc"].Value = spec_doc;
                command.Parameters["@loa_doc"].Value = loa_doc;
                command.Parameters["@claim_doc"].Value = claim_doc;
                command.Parameters["@pct_doc"].Value = pct_doc;
                command.Parameters["@doa_doc"].Value = doa_doc;
                command.Parameters["@loa_no"].Value = loa_no;
                command.Parameters["@claim_no"].Value = claim_no;
                command.Parameters["@pct_no"].Value = pct_no;
                command.Parameters["@doa_no"].Value = doa_no;
                command.Parameters["@pwalletID"].Value = pwalletID;
                str2 = command.ExecuteNonQuery().ToString();
                connection.Close();
            //}
            //catch (Exception ee)
            //{

            //    XWriter2 pp = new XWriter2();
            //    string message = pwalletID + " " + DateTime.Now;

            //    string vpath = System.Web.HttpContext.Current.Server.MapPath("~/") + "PatentLog/Patent/" + pwalletID + ".txt";
                
            //    pp.WriteToFile(message, vpath);

            //}
            return str2;
       
        
    }


    public string activity_log(string userID, string Module, string Operation, string documentid, string status, string oldtitle, string newtitle, string oldapplicantname, string newapplicantname, string oldclass, string newclass)
    {
        //  ba2xai_cldx_backupEntities xp = new ba2xai_cldx_backupEntities();
     //   ba2xai_cldx_backupEntities1 app = new ba2xai_cldx_backupEntities1();
        //  activity_lg dd = new activity_lg();
        string str = "";
        string connectionString = Connect();
        //  SqlConnection connection = new SqlConnection(this.Connect());
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand cmd = connection.CreateCommand();
        DateTime currentDate2 = DateTime.UtcNow;
        TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("W. Central Africa Standard Time");
        currentDate2 = TimeZoneInfo.ConvertTimeFromUtc(currentDate2, pstZone);
        //  currentDate2 = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentDate2, TimeZoneInfo.Local.Id, "GMT Standard Time");
        //  TimeSpan currentTime2 = currentDate2.TimeOfDay;



        cmd.CommandText = "INSERT INTO activity_lg (userID,act_date,module,DocumentId,Operation,status,old_title,new_title,old_class,new_class,old_applicantname,new_applicantname) VALUES (@userID,@act_date,@module,@DocumentId,@Operation,@status,@old_title,@new_title,@old_class,@new_class,@old_applicantname,@new_applicantname)";
        connection.Open();
        cmd.Parameters.Add("@userID", SqlDbType.VarChar, 200);
        cmd.Parameters.Add("@DocumentId", SqlDbType.VarChar, 200);
        cmd.Parameters.Add("@Operation", SqlDbType.VarChar, 200);
        cmd.Parameters.Add("@act_date", SqlDbType.DateTime);
        cmd.Parameters.Add("@status", SqlDbType.VarChar, 200);
        cmd.Parameters.Add("@old_title", SqlDbType.VarChar, 400);
        cmd.Parameters.Add("@new_title", SqlDbType.VarChar, 400);
        cmd.Parameters.Add("@old_class", SqlDbType.VarChar, 200);
        cmd.Parameters.Add("@new_class", SqlDbType.VarChar, 200);
        cmd.Parameters.Add("@old_applicantname", SqlDbType.VarChar, 400);
        cmd.Parameters.Add("@new_applicantname", SqlDbType.VarChar, 400);
        //  cmd.Parameters.Add("@act_time", SqlDbType.Timestamp);
        cmd.Parameters.Add("@module", SqlDbType.Text);
        cmd.Parameters["@userID"].Value = userID;
        cmd.Parameters["@act_date"].Value = currentDate2;

        cmd.Parameters["@DocumentId"].Value = documentid;
        cmd.Parameters["@Operation"].Value = Operation;
        cmd.Parameters["@status"].Value = status;
        //  cmd.Parameters["@act_time"].Value = currentTime2;
        cmd.Parameters["@module"].Value = Module;
        cmd.Parameters["@old_title"].Value = oldtitle;
        cmd.Parameters["@new_title"].Value = newtitle;
        cmd.Parameters["@old_class"].Value = oldclass;
        cmd.Parameters["@new_class"].Value = newclass;

        cmd.Parameters["@old_applicantname"].Value = oldapplicantname;
        cmd.Parameters["@new_applicantname"].Value = newapplicantname;

        foreach (SqlParameter Parameter in cmd.Parameters)
        {
            if (Parameter.Value == null)
            {
                Parameter.Value = DBNull.Value;
            }
        }
        try
        {
            str = cmd.ExecuteScalar().ToString();

        }

        catch (Exception ee)
        {

        }
        connection.Close();
        return str;
    }
    //public string activity_log(string userID, string Module, string Operation, string documentid, string status)
    //{
    //    //  ba2xai_cldx_backupEntities xp = new ba2xai_cldx_backupEntities();
    //  //  ba2xai_cldx_backupEntities1 app = new ba2xai_cldx_backupEntities1();
    //    //  activity_lg dd = new activity_lg();
    //    string str = "";
    //    string connectionString = Connect();
    //    //  SqlConnection connection = new SqlConnection(this.Connect());
    //    SqlConnection connection = new SqlConnection(connectionString);
    //    SqlCommand cmd = connection.CreateCommand();
    //    DateTime currentDate2 = DateTime.UtcNow;
    //    TimeZoneInfo pstZone = TimeZoneInfo.FindSystemTimeZoneById("W. Central Africa Standard Time");
    //    currentDate2 = TimeZoneInfo.ConvertTimeFromUtc(currentDate2, pstZone);
    //    //  currentDate2 = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentDate2, TimeZoneInfo.Local.Id, "GMT Standard Time");
    //    //  TimeSpan currentTime2 = currentDate2.TimeOfDay;



    //    cmd.CommandText = "INSERT INTO activity_lg (userID,act_date,module,DocumentId,Operation,status) VALUES (@userID,@act_date,@module,@DocumentId,@Operation,@status)";
    //    connection.Open();
    //    cmd.Parameters.Add("@userID", SqlDbType.VarChar, 200);
    //    cmd.Parameters.Add("@DocumentId", SqlDbType.VarChar, 200);
    //    cmd.Parameters.Add("@Operation", SqlDbType.VarChar, 200);
    //    cmd.Parameters.Add("@act_date", SqlDbType.DateTime);
    //    cmd.Parameters.Add("@status", SqlDbType.VarChar, 200);
    //    //  cmd.Parameters.Add("@act_time", SqlDbType.Timestamp);
    //    cmd.Parameters.Add("@module", SqlDbType.Text);
    //    cmd.Parameters["@userID"].Value = userID;
    //    cmd.Parameters["@act_date"].Value = currentDate2;

    //    cmd.Parameters["@DocumentId"].Value = documentid;
    //    cmd.Parameters["@Operation"].Value = Operation;
    //    cmd.Parameters["@status"].Value = status;
    //    //  cmd.Parameters["@act_time"].Value = currentTime2;
    //    cmd.Parameters["@module"].Value = Module;

    //    foreach (SqlParameter Parameter in cmd.Parameters)
    //    {
    //        if (Parameter.Value == null)
    //        {
    //            Parameter.Value = DBNull.Value;
    //        }
    //    }
    //    try
    //    {
    //        str = cmd.ExecuteScalar().ToString();

    //    }

    //    catch (Exception ee)
    //    {

    //    }
    //    connection.Close();
    //    return str;
    //}

    public string updatePtInfo(PtInfo x)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE [dbo].[pt_info] SET [xtype] = '" + x.xtype + "',[title_of_invention] = '" + ConvertApos2Tab(x.title_of_invention) + "', ";
        string commandText = command.CommandText;
        command.CommandText = commandText + "  [pt_desc] = '" + ConvertApos2Tab(x.pt_desc) + "',[reg_date] = '" + x.reg_date + "', ";
        commandText = command.CommandText;
        command.CommandText = commandText + "  [log_staff] = '" + x.log_staff + "',[xvisible] = '" + x.xvisible + "'  WHERE xID ='" + x.xID + "' ";
        connection.Open();
        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str2;
    }

    public string updatePtInfo2(PtInfo x)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE [dbo].[pt_info] SET [xtype] = '" + x.xtype + "',[title_of_invention] = '" + ConvertApos2Tab(x.title_of_invention) + "', ";
        string commandText = command.CommandText;
        command.CommandText = commandText + "  [pt_desc] = '" + ConvertApos2Tab(x.pt_desc) + "',[reg_date] = '" + x.reg_date + "', ";
        commandText = command.CommandText;
        command.CommandText = commandText + "  [log_staff] = '" + x.log_staff + "',[xvisible] = '" + x.xvisible + "',[reg_number] = '" + x.reg_number + "' WHERE xID ='" + x.xID + "' ";
        connection.Open();
        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str2;
    }

    public string updatePtReg(string xID, string typ)
    {
        string str = "0";
        string str2 = "";
        if (typ.ToUpper() == "NON-CONVENTIONAL")
        {
            str2 = "NG/PT/NC/" + DateTime.Today.Date.ToString("yyyy") + "/" + xID;
        }
        else
        {
            str2 = "NG/PT/C/" + DateTime.Today.Date.ToString("yyyy") + "/" + xID;
        }
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE pt_info SET reg_number=@reg_number WHERE xID=@xID ";
        connection.Open();
        command.Parameters.Add("@xID", SqlDbType.BigInt);
        command.Parameters.Add("@reg_number", SqlDbType.NVarChar, 50);
        command.Parameters["@xID"].Value = Convert.ToInt64(xID);
        command.Parameters["@reg_number"].Value = str2;
        str = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str;
    }

    public string updatePwalletStatus(string pwalletID, string log_officer)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE pwallet SET stage=5,log_officer=@log_officer WHERE ID=@ID ";
        connection.Open();
        command.Parameters.Add("@ID", SqlDbType.BigInt);
        command.Parameters.Add("@log_officer", SqlDbType.NVarChar, 50);
        command.Parameters["@ID"].Value = Convert.ToInt64(pwalletID);
        command.Parameters["@log_officer"].Value = log_officer;
        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str2;
    }


    public string updatePwalletDate(string pwalletID, string reg_date)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE pwallet SET reg_date=@reg_date WHERE ID=@ID ";
        connection.Open();
        command.Parameters.Add("@ID", SqlDbType.BigInt);
        command.Parameters.Add("@reg_date", SqlDbType.NVarChar, 50);
        command.Parameters["@ID"].Value = Convert.ToInt64(pwalletID);
        command.Parameters["@reg_date"].Value = reg_date;
        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str2;
    }

    public string updateRenewalReg(string reg_no, string xid)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE renewal SET reg_no ='" + reg_no + "' WHERE xid ='" + xid + "' ";
        connection.Open();
        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str2;
    }

    public string updateRepresentative(Representative x)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE [dbo].[representative] SET [agent_code] ='" + x.agent_code + "',[xname] = '" + ConvertApos2Tab(x.xname) + "',[nationality] = '" + x.nationality + "', ";
        string commandText = command.CommandText;
        command.CommandText = commandText + "  [country] = '" + x.country + "',[state] = '" + x.state + "',[address] = '" + ConvertApos2Tab(x.address) + "' , ";
        commandText = command.CommandText;
        command.CommandText = commandText + "  [xemail] = '" + ConvertApos2Tab(x.xemail) + "',[xmobile] = '" + x.xmobile + "',[log_staff] = '" + x.log_staff + "' , ";
        commandText = command.CommandText;
        command.CommandText = commandText + "  [visible] = '" + x.visible + "' WHERE ID ='" + x.ID + "' ";
        connection.Open();
        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str2;
    }

    public string updateSpecDocz(string spec_doc, string pwalletID)
    {
        string connectionString = Connect();
        string str2 = "";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "UPDATE pt_info SET spec_doc=@spec_doc WHERE xID=@pwalletID ";
        connection.Open();
        command.Parameters.Add("@spec_doc", SqlDbType.Text);
        command.Parameters.Add("@pwalletID", SqlDbType.NVarChar);
        command.Parameters["@spec_doc"].Value = spec_doc;
        command.Parameters["@pwalletID"].Value = pwalletID;
        str2 = command.ExecuteNonQuery().ToString();
        connection.Close();
        return str2;
    }

    public string ValidationIDByPwalletID(string ID)
    {
        string str = "";
        SqlConnection connection = new SqlConnection(Connect());
        SqlCommand command = new SqlCommand("SELECT validationID FROM pwallet WHERE ID='" + ID + "' ", connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
        while (reader.Read())
        {
            str = reader["validationID"].ToString();
        }
        reader.Close();
        return str;
    }

    public class Address
    {
        public string city { get; set; }

        public string countryID { get; set; }

        public string email1 { get; set; }

        public string email2 { get; set; }

        public string ID { get; set; }

        public string lgaID { get; set; }

        public string log_staff { get; set; }

        public string reg_date { get; set; }

        public string stateID { get; set; }

        public string street { get; set; }

        public string telephone1 { get; set; }

        public string telephone2 { get; set; }

        public string visible { get; set; }

        public string zip { get; set; }
    }

    public class AddressService
    {
        public string city { get; set; }

        public string countryID { get; set; }

        public string email1 { get; set; }

        public string email2 { get; set; }

        public string ID { get; set; }

        public string lgaID { get; set; }

        public string log_staff { get; set; }

        public string reg_date { get; set; }

        public string stateID { get; set; }

        public string street { get; set; }

        public string telephone1 { get; set; }

        public string telephone2 { get; set; }

        public string visible { get; set; }

        public string zip { get; set; }
    }

    public class Applicant
    {
        public string address { get; set; }

        public string ID { get; set; }

        public string log_staff { get; set; }

        public string nationality { get; set; }

        public string visible { get; set; }

        public string xemail { get; set; }

        public string xmobile { get; set; }

        public string xname { get; set; }
    }

    public class Assignment_info
    {
        public string assignee_address { get; set; }

        public string assignee_name { get; set; }

        public string assignee_nationality { get; set; }

        public string assignor_address { get; set; }

        public string assignor_name { get; set; }

        public string assignor_nationality { get; set; }

        public string date_of_assignment { get; set; }

        public string ID { get; set; }

        public string log_staff { get; set; }

        public string visible { get; set; }
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

    public class Country
    {
        public string code { get; set; }

        public string ID { get; set; }

        public string name { get; set; }
    }

    public class Inventor
    {
        public string address { get; set; }

        public string ID { get; set; }

        public string log_staff { get; set; }

        public string nationality { get; set; }

        public string visible { get; set; }

        public string xemail { get; set; }

        public string xmobile { get; set; }

        public string xname { get; set; }
    }

    public class Lga
    {
        public string ID { get; set; }

        public string name { get; set; }

        public string stateID { get; set; }
    }

    public class NClass
    {
        public string xdescription { get; set; }

        public string xID { get; set; }

        public string xtype { get; set; }
    }

    public class Priority_info
    {
        public string app_no { get; set; }

        public string countryID { get; set; }

        public string log_staff { get; set; }

        public string xdate { get; set; }

        public string xID { get; set; }

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

    public class Renewal
    {
        public string agt_addy { get; set; }

        public string agt_code { get; set; }

        public string agt_email { get; set; }

        public string agt_mobile { get; set; }

        public string agt_name { get; set; }

        public string app_date { get; set; }

        public string app_no { get; set; }

        public string last_rwl_date { get; set; }

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
    }

    public class Representative
    {
        public string address { get; set; }

        public string agent_code { get; set; }

        public string country { get; set; }

        public string ID { get; set; }

        public string log_staff { get; set; }

        public string nationality { get; set; }

        public string reg_date { get; set; }

        public string state { get; set; }

        public string visible { get; set; }

        public string xemail { get; set; }

        public string xmobile { get; set; }

        public string xname { get; set; }
    }

    public class Stage
    {
        public string amt { get; set; }

        public string applicantID { get; set; }

        public string data_status { get; set; }

        public string ID { get; set; }

        public string reg_date { get; set; }

        public string stage { get; set; }

        public string status { get; set; }

        public string validationID { get; set; }
    }

    public class State
    {
        public string countryID { get; set; }

        public string ID { get; set; }

        public string name { get; set; }
    }

    public class Recordal
    {
        public string ID { get; set; }
        public string OLD_APPLICANTNAME { get; set; }
        public string NEW_APPLICANTNAME { get; set; }
        public DateTime RECORDAL_REQUEST_DATE { get; set; }

        public String RECORDAL_REQUEST_DATE2 { get; set; }
        public DateTime RECORDAL_APPROVE_DATE { get; set; }

        public string AMOUNT { get; set; }
        public string TRANSACTIONID { get; set; }

        public string OFFICER { get; set; }

        public string VSTATUS { get; set; }

        public string RECORDAL_TYPE { get; set; }

        public string OLD_APPLICANTADDRESS { get; set; }
        public string RECORDAL_TYPE3 { get; set; }


        public string NEW_APPLICANTADDRESS { get; set; }

        public string Xcomment { get; set; }

        public string OLD_PRODUCT_TITLE { get; set; }

        public string NEW_PRODUCT_TITLE { get; set; }

        public string OLD_PRODUCT_LOGO { get; set; }

        public string OLD_AGENTNAME { get; set; }
        public string NEW_AGENTNAME { get; set; }
        public string OLD_AGENTCODE { get; set; }
        public string NEW_AGENTCODE { get; set; }
        public string OLD_AGENTEMAIL { get; set; }
        public string NEW_AGENTEMAIL { get; set; }
        public string OLD_AGENTPHONE { get; set; }
        public string NEW_AGENTPHONE { get; set; }
        public string OLDAGENT_ADDRESS { get; set; }
        public string NEWAGENT_ADDRESS { get; set; }
        public string NEW_PRODUCT_LOGO { get; set; }

        public string LOGO_DESC { get; set; }

        public string Detail_Id { get; set; }

        public string data_status { get; set; }

        public string data_status2 { get; set; }

        public string data_status3 { get; set; }

        public string data_status4 { get; set; }

        public string description { get; set; }

        public string UPLOADPATH { get; set; }


        public string UPLOADPATH2 { get; set; }

        public string UPLOADPATH3 { get; set; }




    }
    public class SWallet
    {
        public string ID { get; set; }

        public string log_officer { get; set; }

        public string mark_infoID { get; set; }

        public string reg_date { get; set; }

        public string search_cri { get; set; }

        public string search_str { get; set; }

        public string visible { get; set; }

        public string xclass { get; set; }
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

        public string log_officer { get; set; }

        public string reg_date { get; set; }

        public string stage { get; set; }

        public string status { get; set; }

        public string validationID { get; set; }
    }
}

