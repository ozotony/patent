<%@ page language="C#" autoeventwireup="true" CodeFile="patent.cs" inherits="patent" maintainscrollpositiononpostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PATENT FILING</title>

<link href="css/style.css" rel="stylesheet" type="text/css" />
<script src="js/funk.js" type="text/javascript"></script>


</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="container">
        <div class="sidebar">
            </div>
        <div class="content">
            <div class="adminheader">
                <div class="xmenu">
                    <div class="menu">
                    <ul>
                                           
                    </ul>
                </div>
                </div>
                <div class="xlogo">
                    <div class="xlogo_l">
                    </div>
                    <div class="xlogo_r">                      

                    </div>
                </div>
            </div>
            
    <table  id="applicantForm" align="center" width="100%" class="form" >
           
    <% if (show_image_section=="0" ) {%>
        <tr>
            <td colspan="2" align="left" class="tbbg">
                FORM 1 : PLEASE FILL IN THE APPLICANT/PROPRIETOR 
                INFORMATION DETAILS BELOW  
            </td>
        </tr>
        
        <tr>
            <td width="30%">
                &nbsp;&nbsp;NAME:
            </td>
            <td>
                <asp:TextBox ID="xname" runat="server" Width="400px" CssClass="textbox" ReadOnly="True"></asp:TextBox>
                <% if (name_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AppSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>               
                                   
                </td>
        </tr>
        
        <tr>
            <td align="left">
                &nbsp;&nbsp;NATIONALITY :
            </td>
            <td align="left">
                <asp:DropDownList ID="nationality" runat="server" CssClass="textbox" DataSourceID="ds_Nationality" DataTextField="name" 
                    DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_Nationality" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT * FROM [country]"></asp:SqlDataSource>
           </td>
        </tr>        
        <tr>
            <td width="22%" colspan="2" class="tbbg">
                APPLICANT/PROPRIETOR
                ADDRESS INFORMATION DETAILS</td>
        </tr>
        <tr>
            <td width="22%">
                &nbsp;COUNTRY :
            </td>
            <td>
                <asp:DropDownList ID="residence" runat="server" CssClass="textbox" 
                    DataSourceID="ds_DefaultCountry" DataTextField="name" 
                    DataValueField="ID" AutoPostBack="true">
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_DefaultCountry" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT * FROM [country]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="ID" Type="Int64" />
                    </SelectParameters>
                </asp:SqlDataSource>
                </td>
        </tr>
         <% if (state_row == "0")
                    { %>
        <tr>
            <td width="22%">
                &nbsp;STATE:             </td>
            <td>
                 
                <asp:DropDownList ID="xselectState" runat="server" CssClass="textbox" 
                    DataSourceID="ds_State" DataTextField="name" DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_State" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT DISTINCT * FROM [state] WHERE ([countryID] = @countryID)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="residence" DefaultValue="" Name="countryID" 
                            PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                                             
                
                <% if (state_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px"   />
                <% } if (enable_AppSave == "0")
                   { %>
                <img src="images/checkmark.gif" alt="" width="16px" height="16px" />  
                             <% }  %>
            </td>
        </tr>
        <% } %>
        <tr>
            <td width="22%">
                &nbsp;CITY :
            </td>
            <td>
            <asp:TextBox ID="xcity" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                <% if (city_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AppSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        <tr>
            <td width="22%">
                &nbsp;STREET 
                No.:
            </td>
            <td>
                <asp:TextBox ID="xaddress" runat="server" Width="400px" CssClass="textbox" 
                    Height="50px" TextMode="MultiLine"></asp:TextBox>
                <% if (address_text == "1")
                   { %>&nbsp;&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AppSave == "0")
                   { %>
                <img src="images/checkmark.gif" alt="" width="16px" height="16px"  />
                <% }%>
            </td>
        </tr>          
       
        <tr>
            <td>
                                &nbsp;
                                TELEPHONE: &nbsp;</td>
            <td>
            <asp:TextBox ID="xtelephone" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                <% if (telephone_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AppSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        
        <tr>
            <td>
                &nbsp;
                E-MAIL:
                </td>
            <td>
            <asp:TextBox ID="xemail" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                <% if (email_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AppSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        
        <tr>
            <td colspan="2">
            
            </td>
        </tr>
    </table>
    
    <table align="center" width="100%" class="form">
                <tr>
                    <td colspan="3" align="left" class="tbbg">
                        STEP 2 : PLEASE FILL IN THE &quot;PATENT&quot; DETAILS BELOW
                    </td>
                </tr>
                <tr>
                    <td width="30%">
                        &nbsp;&nbsp;PATENT TYPE :
                    </td>
                    <td colspan="2">     <% if ((pc == "T002")||(pc == "1"))
                   { %>                    
                        <asp:Label ID="Label1" runat="server" Text="CONVENTIONAL"></asp:Label>
                        <% }%>
                        
                         <% else if ((pc == "T001") || (pc == "2"))
                   { %>                    
                        <asp:Label ID="Label2" runat="server" Text="NON-CONVENTIONAL"></asp:Label>
                        <% }%>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;TITLE OF 
                        INVENTION :
                    </td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="title_of_invention" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>
                        <% if (title_of_invention_text == "1")
                   { %>
                        &nbsp;&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
                        <% } if (enable_PtSave == "0")
                   { %>
                        <img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                         <% }%>
                    </td>
                </tr>
                <tr>
                    <td class="tbbg" colspan="3">
                       --- PRIORITY SECTION ---</td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <strong>ARE YOU CLAIMING PRIORITY FROM ONE OR MORE EARLIER-FILED PATENT APPLICATIONS? </strong></td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                      <asp:RadioButtonList ID="rbPriorityClaim" runat="server" 
                            RepeatDirection="Horizontal" AutoPostBack="True" 
                            onselectedindexchanged="rbPriorityClaim_SelectedIndexChanged">
                    <asp:ListItem Value="Yes" >YES</asp:ListItem>
                    <asp:ListItem Value="No" Selected="True">NO</asp:ListItem>
                </asp:RadioButtonList>
                       
                    </td>
                </tr>
                <% if (rbPriorityClaim_text == "1")
                   { %>
                <tr>
                    <td align="center" colspan="3">
                        <strong>IF SO, PLEASE GIVE DETAILS OF THE APPLICATION(S)</strong></td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;DETAILS OF THE APPLICATION :
                    </td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="priority_details" runat="server" Height="50px" TextMode="MultiLine" Width="90%" CssClass="textbox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;PRIORITY 
                        / FILING DATE :
                    </td>
                    <td align="left" colspan="2">
                        &nbsp; Day
                        
                        <asp:TextBox ID="selectDay" runat="server" Width="20px" CssClass="textbox"></asp:TextBox>
                        
                    &nbsp;Month
                       <asp:TextBox ID="selectMonth" runat="server" Width="20px" CssClass="textbox"></asp:TextBox>
                    &nbsp;Year:
                       <asp:TextBox ID="selectYear" runat="server" Width="40px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
               
                <tr>
                    <td align="left">
                        &nbsp; COUNTRY :
                    </td>
                    <td align="left" colspan="2">
                        <asp:DropDownList ID="ptCountry" runat="server"  CssClass="textbox" 
                            DataSourceID="countryDS" DataTextField="name" DataValueField="ID" 
                            AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="countryDS" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:cldConnectionString.ProviderName %>" 
                            SelectCommand="SELECT DISTINCT * FROM [country]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td width="22%">
                        &nbsp;&nbsp;STATE:
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ptState" runat="server"  CssClass="textbox" 
                            DataSourceID="stateDS" DataTextField="name" DataValueField="ID">
                        </asp:DropDownList>
                       
                        <asp:SqlDataSource ID="stateDS" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                            SelectCommand="SELECT DISTINCT * FROM [state] WHERE ([countryID] = @countryID)">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="ptCountry" Name="countryID" 
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>                        
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;&nbsp;PRIORITY 
                        /FILING NUMBER :
                    </td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="priority_no" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                        
                        &nbsp;</td>
                </tr>
                <% }%>
                <tr>
                    <td class="tbbg" colspan="3">
                       --- INVENTORSHIP 
                        SECTION ---</td>
                </tr>
                <tr>
                    <td  colspan="3">
                      </td>
                </tr>
                <tr>
                    <td class="tbbg" colspan="3">
                        &nbsp;
                        &nbsp;ARE ALL THE APPLICANTS LISTED BEFORE ALSO INVENTORS?</td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:RadioButtonList ID="rbInventors" runat="server" 
                            RepeatDirection="Horizontal" 
                            onselectedindexchanged="rbInventors_SelectedIndexChanged" 
                            AutoPostBack="True">
                    <asp:ListItem Value="Yes" >YES</asp:ListItem>
                    <asp:ListItem Value="No" Selected="True">NO</asp:ListItem>
                </asp:RadioButtonList>
                    </td>
                </tr>
                 <% if (rbInventors_text == "1")
                   { %>
                <tr>
                    <td class="tbbg" colspan="3">
                        ARE THEY ANY OTHER INVENTORS?</td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:RadioButtonList ID="rbOtherInventors" runat="server" 
                            RepeatDirection="Horizontal" 
                            onselectedindexchanged="rbOtherInventors_SelectedIndexChanged" 
                            AutoPostBack="True">
                    <asp:ListItem Value="Yes" >YES</asp:ListItem>
                    <asp:ListItem Value="No" Selected="True">NO</asp:ListItem>
                </asp:RadioButtonList>
                    </td>
                </tr>
                <% if (rbOtherInventors_text == "1")
                   { %>
                <tr>
                    <td class="tbbg" colspan="3">
                        PLEASE ENTER 
                        THE NAMES OF THE INVENTOR(S) SEPERATED BY A COMMA (,)</td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                                        <asp:TextBox ID="inventors" runat="server" Width="95%" CssClass="textbox" 
                    Height="50px" TextMode="MultiLine"></asp:TextBox>
                
                        </td>
                </tr>
                 <% } %>
                <% }%>              
              
                <tr>
                    <td class="tbbg" colspan="3">                   
                        &nbsp;</td>
                </tr>
                
            </table>
       
               <table align="center" width="100%" class="form">
        <tr>
            <td colspan="2" align="left" class="tbbg">
                FORM 3: PLEASE FILL IN THE &quot;ADDRESS OF SERVICE&quot; DETAILS BELOW
            </td>
        </tr>
       
         <% if (aos_state_row == "0")
            { %>
        <tr>
            <td width="22%">
                &nbsp;STATE:             </td>
            <td>
                <asp:DropDownList ID="aos_xselectState" runat="server" CssClass="textbox" 
                    DataSourceID="ds_AosState" DataTextField="name" DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_AosState" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT * FROM [state]">
                </asp:SqlDataSource>
                <% if (aos_state_text == "1")
                   { %>                
                <asp:TextBox ID="aos_xstate" runat="server" Width="100px" CssClass="textbox"></asp:TextBox>
                &nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px"   />
                <% } if (enable_AosSave == "0")
                   { %>
                <img src="images/checkmark.gif" alt="" width="16px" height="16px" />  
                             <% }  %>
            </td>
        </tr>
                   <% } %>
        <tr>
            <td width="22%">
                &nbsp;CITY :
            </td>
            <td>
            <asp:TextBox ID="aos_xcity" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                <% if (aos_city_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AosSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        <tr>
            <td width="22%" class="style1">
                &nbsp;STREET 
                No.:
            </td>
            <td class="style1">
                <asp:TextBox ID="aos_xaddress" runat="server" Width="400px" CssClass="textbox" 
                    Height="50px" TextMode="MultiLine"></asp:TextBox>
                <% if (aos_address_text == "1")
                   { %>&nbsp;&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AosSave == "0")
                   { %>
                <img src="images/checkmark.gif" alt="" width="16px" height="16px"  />
                <% }%>
            </td>
        </tr>       
      
        <tr>
            <td>
                                &nbsp;
                                TELEPHONE: &nbsp;</td>
            <td>
            <asp:TextBox ID="aos_xtelephone" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                <% if (aos_telephone_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AosSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        
        <tr>
            <td>
                &nbsp;
                E-MAIL:
                </td>
            <td>
            <asp:TextBox ID="aos_xemail" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                <% if (aos_email_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_AosSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        
        <tr>
            <td  colspan="2">               
               
            </td>
        </tr>
    </table>
         
       <table align="center" width="100%" class="form">
        <tr>
            <td colspan="2" align="left" class="tbbg">
                FORM 4 : PLEASE FILL IN THE &quot;REPRESENTATIVE/ATTORNEY&quot; DETAILS BELOW
            </td>
        </tr>
          
        <tr>
            <td width="30%">
                &nbsp;&nbsp;AGENT CODE:             </td>
            <td class="style1">
                <asp:TextBox ID="xcode" runat="server" Width="400px" 
                    CssClass="textbox" ReadOnly="True"></asp:TextBox>
                                
                                   
                </td>
        </tr>
        <tr>
            <td align="left">
                &nbsp;&nbsp;NAME :
            </td>
            <td align="left" class="style1">
                <asp:TextBox ID="rep_xname" runat="server" Width="400px" CssClass="textbox" ></asp:TextBox>
                <% if (rep_name_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_RepSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>    
            </td>
        </tr>
       
        <tr>
            <td align="left">
                &nbsp;&nbsp;NATIONALITY :
            </td>
            <td align="left" class="style1">
                <asp:DropDownList ID="rep_nationality" runat="server" CssClass="textbox" DataSourceID="ds_Nationality" DataTextField="name" 
                    DataValueField="ID" >
                </asp:DropDownList>
                     </td>
        </tr>        
        <tr>
            <td colspan="2" class="tbbg">
                ADDRESS INFORMATION</td>
        </tr>
        <tr>
            <td width="22%">
                &nbsp;COUNTRY :
            </td>
            <td class="style1">
                <asp:DropDownList ID="rep_residence" runat="server" CssClass="textbox" 
                    DataSourceID="ds_RepCountry" DataTextField="name" 
                    DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_RepCountry" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT * FROM [country] WHERE ([ID] = @ID)">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="160" Name="ID" Type="Int64" />
                    </SelectParameters>
                </asp:SqlDataSource>
           </td>
        </tr>
       
        <tr>
            <td width="22%">
                &nbsp;STATE:             </td>
                  
            <td class="style1">
                <% if (rep_state_row == "0")
                    { %>  
                <asp:DropDownList ID="xselectRepState" runat="server" CssClass="textbox" 
                    DataSourceID="ds_RepState" DataTextField="name" DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_RepState" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    
                    SelectCommand="SELECT DISTINCT ID, name, countryID FROM state WHERE (countryID = 160)">
                    
                </asp:SqlDataSource>
                 
                   <% } else
            { %>                
                <asp:TextBox ID="rep_xstate" runat="server" Width="100px" CssClass="textbox"></asp:TextBox>
                <% } if (rep_state_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px"   />
                <% } if (enable_RepSave == "0")
                   { %>
                <img src="images/checkmark.gif" alt="" width="16px" height="16px" />  
                            
            </td>
        </tr>
           <% } %>
        <tr>
            <td width="22%">
                &nbsp;CITY :
            </td>
            <td class="style1">
            <asp:TextBox ID="rep_xcity" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                <% if (rep_city_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_RepSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        <tr>
            <td width="22%">
                &nbsp;STREET :
            </td>
            <td class="style1">
                <asp:TextBox ID="rep_address" runat="server" Width="400px" CssClass="textbox" 
                    Height="50px" TextMode="MultiLine"></asp:TextBox>
                <% if (rep_address_text == "1")
                   { %>&nbsp;&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_RepSave == "0")
                   { %>
                <img src="images/checkmark.gif" alt="" width="16px" height="16px"  />
                <% }%>
            </td>
        </tr>
        
        <tr>
            <td>
                                &nbsp;
                                TELEPHONE: &nbsp;</td>
            <td class="style1">
            <asp:TextBox ID="rep_xtelephone" runat="server" Width="200px" CssClass="textbox" ></asp:TextBox>
                <% if (rep_telephone_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_RepSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        
        <tr>
            <td>
                &nbsp;
                E-MAIL:
                </td>
            <td class="style1">
            <asp:TextBox ID="rep_xemail" runat="server" Width="200px" CssClass="textbox" ></asp:TextBox>
                <% if (rep_email_text == "1")
                   { %>&nbsp;<img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_RepSave == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     </td>
        </tr>
        
        <tr>
            <td class="tbbg" colspan="2">
            
                <% if (enable_RepConfirm == "0")
                   { %>
                <asp:Button ID="ConfirmRepresentativeDetails" runat="server" 
                    Text="Confirm Details" class="button" 
                    onclick="ConfirmRepresentativeDetails_Click" />
               
                <% } if (enable_RepSave == "0")
                   { %>
                <asp:Button ID="SaveAll" runat="server" Text="Submit Application"  class="button" 
                    onclick="SaveAll_Click" />
                <% }
           
           %>
            </td>
        </tr>     
        
        <% 
            }
            if (show_image_section == "1")
            {%>
             <tr>
            <td  colspan="2">
            <table width="100%">
            <tr>
                    <td class="tbbg" colspan="3">
                       
                        PLEASE ENTER THE NUMBER OF PAGES OF EACH ITEM ACCOMPANYING THIS FORM AND ATTACH 
                        DOCUMENTS BELOW :</td>
                </tr>
              
                <tr>
                    <td align="center" colspan="3" style="color:Red;">
                       <strong>(NOTE: DOCUMENTS ATTACHED SHOULD BE &quot;JPEG&quot; OR &quot;PDF&quot; ONLY!!)</strong> </td>
                </tr>
                <tr>
                    <td align="center" class="tbbg2" style="width:40%;">
                        ITEMS</td>
                    <td align="center" class="tbbg2" style="width:10%;">
                        NUMBER</td>
                    <td align="left" class="tbbg2" style="width:50%;">
                        ATTACH DOCUMENT</td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;FORM 2 (LETTER OF AUTHORIZATION OF AGENT) :
                    </td>
                    <td align="center">
                       <asp:TextBox ID="description_no" runat="server" Width="40px" 
                            CssClass="textbox"></asp:TextBox>
                        </td>
                    <td align="left">
                        <asp:FileUpload ID="description_doc" runat="server" />
                        &nbsp;
                         <% if (description_doc_text == "1")
                   { %>
                        &nbsp;<asp:Label ID="lblDescription_doc" runat="server"></asp:Label>
&nbsp;&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
                        <% } if (enable_PtSave == "0")
                   { %>
                        <img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                         <% }%>
                         </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                
                <tr>
                    <td align="center">
                        &nbsp; CLAIM(S) : &nbsp;
                    </td>
                    <td align="center">
                        <asp:TextBox ID="claim_no" runat="server" Width="40px" 
                            CssClass="textbox"></asp:TextBox>
                        </td>
                    <td align="left">
                        <asp:FileUpload ID="claim_doc" runat="server" />
                         &nbsp;
                         <% if (claim_doc_text == "1")
                   { %>
                        &nbsp;&nbsp;<asp:Label ID="lblClaim_doc" runat="server"></asp:Label>
&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
                        <% } if (enable_PtSave == "0")
                   { %>
                        <img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                         <% }%>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;&nbsp;ABSTRACT :
                    </td>
                    <td align="center">
                        <asp:TextBox ID="abstract_no" 
                            runat="server" Width="40px" 
                            CssClass="textbox"></asp:TextBox>
                        </td>
                    <td align="left">
                        <asp:FileUpload ID="abstract_doc" runat="server" />
                         &nbsp;
                         <% if (abstract_doc_text == "1")
                   { %>
                        &nbsp;&nbsp;<asp:Label ID="lblAbstract_doc" runat="server"></asp:Label>
&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
                        <% } if (enable_PtSave == "0")
                   { %>
                        <img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                         <% }%>
                    </td>
                </tr>
                 <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        &nbsp;&nbsp;DRAWINGS:
                    </td>
                    <td align="center">
                        <asp:TextBox ID="drawing_no" runat="server" Width="40px" 
                            CssClass="textbox"></asp:TextBox>
                        </td>
                    <td align="left">
                        <asp:FileUpload ID="drawing_doc" runat="server" />
                         &nbsp;
                         <% if (drawing_doc_text == "1")
                   { %>
                        &nbsp;&nbsp;<asp:Label ID="lblDrawing_doc" runat="server"></asp:Label>
&nbsp;<img src="images/arrow-left.gif" alt="" width="16px" height="16px" />
                        <% } if (enable_PtSave == "0")
                   { %>
                        <img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                         <% }%>
                    </td>
                </tr>
                </table>
                </td>
                </tr>
                <tr>
                    <td colspan="2">
                <asp:HiddenField ID="xaid" runat="server" />
                <asp:HiddenField ID="xvid" runat="server" />
                <asp:HiddenField ID="xamt" runat="server" />
                <asp:HiddenField ID="xgt" runat="server" />
                <asp:HiddenField ID="xpc" runat="server" />
                <asp:HiddenField ID="xpwalletID" runat="server" />
                <asp:HiddenField ID="xmarkID" runat="server" />
                <asp:HiddenField ID="xagentemail" runat="server" />
                <asp:HiddenField ID="xcname" runat="server" />
                <asp:HiddenField ID="xagentpnumber" runat="server" />
                <asp:HiddenField ID="xapplicantname" runat="server" />
                <asp:HiddenField ID="xproduct_title" runat="server" />
                 <asp:HiddenField ID="xref" runat="server" />
                    </td>
                </tr> 
                

                <tr>
            <td  colspan="2"><% Response.Write(show_imageMsg); %></td>
        </tr>
        
        <tr>
            <td class="tbbg" colspan="2">
            
                <asp:Button ID="SaveDocs" runat="server" Text="Submit Documents"  
                    class="button" onclick="SaveDocs_Click"  />
                </td>
        </tr>       
         <% }%>
    </table>

        </div>
    </div>
    </div>
    </form>
</body>
</html>
