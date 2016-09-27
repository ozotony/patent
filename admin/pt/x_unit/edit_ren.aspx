<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_ren.aspx.cs" Inherits="admin_pt_x_unit_edit_ren" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../../../css/style.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="../../../css/jquery.ui.all.css" type="text/css"/>
<link rel="stylesheet" href="../../../css/jquery.ui.theme.css" type="text/css"/>

<script src="../../../js/aj.js" type="text/javascript"></script>
<script src="../../../js/jquery.js" type="text/javascript"></script>
<script src="../../../js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="../../../js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>

<script src="../../../js/ui/jquery.cookie.js" type="text/javascript"></script>
<script src="../../../js/ui/jquery.ui.core.js" type="text/javascript"></script>
<script src="../../../js/ui/jquery.ui.widget.js" type="text/javascript"></script>
<script src="../../../js/ui/jquery.ui.datepicker.js" type="text/javascript"></script>
<script src="../../../js/jquery.blockUI.js" type="text/javascript"></script>

<script  type="text/javascript">
    function doEdit() {
       

        $("#RenewalListView_aa").hide();
    }

  
    $(function () {

        $(".xdate").datepicker({
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'yy-mm-dd',
            yearRange: 'c-100:c+0'
        });

    });
</script>
    <style type="text/css">
        .form table a {
            color: #0094ff;
        }


    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<table style="width:80%;font-family:Calibri;" id="applicantForm" align="center" class="form">
    <tr align="center">
                <td>
                    <img alt="Coat Of Arms" height="79" src="../../../images/coat_of_arms.png" 
                        width="85" />
               </td>
            </tr>
            <tr style="text-align:center; background-color:#666; color:#fff; font-size:24px;" >
                <td>
                    <br />
                    --- PATENT RENEWAL EDIT SECTION ---
                      <br />
                     <br />
                </td>
            </tr>
   


     <tr style="font-size:11pt;" >
                <td >
             <asp:TextBox ID="TextBox6" Width="300px" placeholder="Filter By Validation Id" runat="server"></asp:TextBox>     
           <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />       
</td>
            </tr>




    <tr>
<td>
             <asp:ListView runat="server" 
        ID="RenewalListView"
         OnItemEditing="RenewalListView_ItemEditing"  
        OnItemCommand="EmployeesListView_OnItemCommand"
        OnItemCanceling="RenewalListView_ItemCanceling" 
       OnItemDataBound="lvAZSubjectSeriesLinks_ItemDataBound"
        
        DataKeyNames="log_staff" 
        >
        <LayoutTemplate >
        <div > 
          <table runat="server" id="tblEmployees"  
                 cellspacing="0" cellpadding="1"  border="1" style="width:100%;">
                 <tr id="aa">
                
                      <th style="text-align:left; background-color:#666; color:#fff;">
              Transaction ID
                 </th>


                 <th style="text-align:left; background-color:#666; color:#fff;">
             TITLE OF INVENTION
                 </th>
                 <th style="text-align:left; background-color:#666; color:#fff;">
              PATENT TYPE
                 </th>
                      <th style="text-align:left; background-color:#666; color:#fff;">
              ITEM CODE
                 </th>

                        <th style="text-align:left; background-color:#666; color:#fff;">
              APPLICATION NO
                 </th>

                      <th style="text-align:left; background-color:#666; color:#fff;">
              APPLICANT NAME
                 </th>                

                      <th style="text-align:left; background-color:#666; color:#fff;">
              AGENT NAME
                 </th>
                   

                      <th style="text-align:left; background-color:#666; color:#fff;">
              APPLICATION DATE
                 </th>
                 <th>
                 
                 </th>
                 </tr>
            <tr id="itemPlaceholder" runat="server"></tr>
          </table>

          </div>
           
          
         
        </LayoutTemplate>
    <ItemTemplate>
          <tr id="Tr1" onmouseover="this.style.backgroundColor='#FFFAAA' " onmouseout="this.style.backgroundColor='white' " runat="server">

                <td >
              <asp:Label runat="server" ID="Label7" 
                Text='<%#Eval("visible")  %>' />
            </td>

            <td >
              <asp:Label runat="server" ID="NameLabel" 
                Text='<%#Eval("title")  %>' />
            </td>
            <td >
              <asp:Label runat="server" ID="Label1" 
                Text='<%#Eval("type")  %>' />
            </td>

              <td >
              <asp:Label runat="server" ID="Label2" 
                Text='<%#Eval("reg_no")  %>' />
            </td>

               <td >
              <asp:Label runat="server" ID="Label3" 
                Text='<%#Eval("app_no")  %>' />
            </td>
             

              <td >
              <asp:Label runat="server" ID="Label6" 
                Text='<%#Eval("xname")  %>' />
            </td>
             

              <td >
              <asp:Label runat="server" ID="Label11" 
                Text='<%#Eval("agt_name")  %>' />
            </td>
                <td >
              <asp:Label runat="server" ID="Label5" 
                Text='<%#Eval("app_date")  %>' />
            </td>
           
            
          
            <td>
             
             
             
                           
            <asp:Label  Visible="false" runat="server" ID="Label4" 
                Text='<%#Eval("log_staff")  %>' />
                <asp:LinkButton ID="UpdateButton" CommandName="Edit" runat="server" commandargument='<%#Eval("log_staff")  %>' Text="Edit"  ></asp:LinkButton>
                 <asp:LinkButton ID="LinkButton2"  runat="server" Text="Delete" onclientclick="javascript:return confirm('Are you sure to delete record?')"  commandname="Del" commandargument='<%#Eval("log_staff")  %>'  >
                            </asp:LinkButton>
            </td>
          </tr>
        </ItemTemplate>

        <EditItemTemplate>
             <tr>
                        <th style="text-align:left;width:250px; background-color:#666; color:#fff;">
                       Transaction ID :
                        </th>
                        <td>
                            <asp:TextBox ID="visible"  Enabled="false" runat="server" Width="500px"  Text='<% #Bind("visible")%>' ></asp:TextBox>
                          
                        </td>
                    </tr>
      

          <tr>
                        <th style="text-align:left;width:250px; background-color:#666; color:#fff;">
                        TITLE OF INVENTION :
                        </th>
                        <td>
                            <asp:TextBox ID="title"  Width="500px" runat="server"  Text='<% #Bind("title")%>' ></asp:TextBox>
                            
                        </td>
                    </tr>

             <tr>
                        <th style="text-align:left;width:250px; background-color:#666; color:#fff;">
                         PATENT TYPE:
                        </th>
                        <td>
                             <select id="type" name="type"  class="textbox" runat="server">
                        <option value="Convention">Convention</option>
                        <option value="Non-Conventional">Non-Conventional</option>
                        <option value="PCT">PCT</option>
                    </select>
                            <asp:TextBox ID="TextBox1" Visible="false" runat="server" Width="500px"  Text='<% #Bind("type")%>' ></asp:TextBox>
                            
                        </td>
                    </tr>
                    <tr>
                        <th style="text-align:left;width:250px; background-color:#666; color:#fff;">
                         ITEM CODE:
                        </th>
                        <td>
                            <asp:TextBox ID="regno" runat="server" Width="500px"  Text='<% #Bind("reg_no")%>' ></asp:TextBox>
                          
                        </td>
                    </tr>

             <tr>
                        <th style="text-align:left;width:250px; background-color:#666; color:#fff;">
                         Application No:
                        </th>
                        <td>
                            <asp:TextBox ID="appno" runat="server" Width="500px" Text='<% #Bind("app_no")%>' ></asp:TextBox>
                          
                        </td>
                    </tr>

            <tr>
                        <th style="text-align:left;width:250px; background-color:#666; color:#fff;">
                        Application Date:
                        </th>
                        <td>
                            <asp:TextBox ID="appdate" runat="server" CssClass="xdate" Width="500px"  Text='<% #Bind("app_date")%>' ></asp:TextBox>
                          
                        </td>
                    </tr>

             <tr>
                        <th style="text-align:left;width:250px; background-color:#666; color:#fff;">
                          Applicant Name:
                        </th>
                        <td>
                            <asp:TextBox ID="xname" runat="server" Width="500px"  Text='<% #Bind("xname")%>' ></asp:TextBox>
                          
                        </td>
                    </tr>

            

            
             <tr>
                        <th style="text-align:left;width:250px; background-color:#666; color:#fff;">
                        Applicant Mobile No.:
                        </th>
                        <td>
                            <asp:TextBox ID="xmobile" runat="server" Width="500px"  Text='<% #Bind("xmobile")%>' ></asp:TextBox>
                          
                        </td>
                    </tr>

             <tr>
                        <th style="text-align:left;width:250px; background-color:#666; color:#fff;">
                        Applicant E-mail:
                        </th>
                        <td>
                            <asp:TextBox ID="xemail" runat="server" Width="500px"  Text='<% #Bind("xemail")%>' ></asp:TextBox>
                          
                        </td>
                    </tr>

             <tr>
                        <th style="text-align:left;width:250px; background-color:#666; color:#fff;">
                        Applicant Address:
                        </th>
                        <td>
                            <asp:TextBox ID="xaddy" runat="server" Width="500px"  Text='<% #Bind("xaddy")%>'  TextMode="MultiLine" Columns="5"></asp:TextBox>
                          
                        </td>
                    </tr

             <tr>
                        <th style="text-align:left;width:250px; background-color:#666; color:#fff;">
                         Agent Code:
                        </th>
                        <td>
                            <asp:TextBox ID="agt_code" runat="server" Width="500px"  Text='<% #Bind("agt_code")%>' Enabled="false" ></asp:TextBox>
                          
                        </td>
                    </tr>

             <tr>
                        <th style="text-align:left;width:250px; background-color:#666; color:#fff;">
                          Agent Name:
                        </th>
                        <td>
                            <asp:TextBox ID="agt_name" runat="server" Width="500px"  Text='<% #Bind("agt_name")%>' ></asp:TextBox>
                          
                        </td>
                    </tr>

             <tr>
                        <th style="text-align:left;width:250px; background-color:#666; color:#fff;">
                         Agent Address:
                        </th>
                        <td>
                            <asp:TextBox ID="agt_addy" runat="server" Width="500px"  Text='<% #Bind("agt_addy")%>' TextMode="MultiLine" Columns="5"></asp:TextBox>
                          
                        </td>
                    </tr>

              <tr>
                        <th style="text-align:left;width:250px; background-color:#666; color:#fff;">
                         Agent Mobile No.:
                        </th>
                        <td>
                            <asp:TextBox ID="agt_mobile" runat="server" Width="500px"  Text='<% #Bind("agt_mobile")%>' ></asp:TextBox>
                          
                        </td>
                    </tr>

             <tr>
                        <th style="text-align:left;width:250px; background-color:#666; color:#fff;">
                         Agent E-mail:
                        </th>
                        <td>
                            <asp:TextBox ID="agt_email" runat="server" Width="500px"  Text='<% #Bind("agt_email")%>' ></asp:TextBox>
                          
                        </td>
                    </tr>

             <tr>
                        <th style="text-align:left;width:250px; background-color:#666; color:#fff;">
                        Last Renewal Date:
                        </th>
                        <td>
                            <asp:TextBox ID="last_rwl_date" runat="server" CssClass="xdate" Width="500px"  Text='<% #Bind("last_rwl_date")%>' ></asp:TextBox>
                          
                        </td>
                    </tr>
                    
 <tr>
                        <th style="text-align:left;width:250px; background-color:#666; color:#fff;">
                         Registration Date:
                        </th>
                        <td>
                            <asp:TextBox ID="reg_date" runat="server" CssClass="xdate" Width="500px"  Text='<% #Bind("reg_date")%>' ></asp:TextBox>
                          
                        </td>
                    </tr>

           
                     

                    <tr id="Tr5" runat="server">
                    <td colspan="2">
                
                       
                     
                     <asp:LinkButton ID="UpdateButton" CommandName="Save" runat="server" Text="Update"  ></asp:LinkButton>

                            <asp:LinkButton ID="CancelButton" CommandName="Cancel" runat="server" Text="Cancel" CausesValidation="false"></asp:LinkButton>
                             <asp:Label Visible="false"  runat="server" ID="Label4" 
                Text='<%#Eval("log_staff")  %>' />
                
                    
                    </td>
                    
                    
                    </tr>


                   





        </EditItemTemplate>
        
      </asp:ListView>


</td>


    </tr>
    
    </table>


    </div>
    </form>
</body>
</html>
