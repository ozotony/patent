﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tm_acknowledgement_Recordal.aspx.cs" Inherits="tm_acknowledgement_Recordal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ACKNOWLEDGEMENT SLIP</title>
   
<link href="css/print_style.css" rel="stylesheet" type="text/css" />

<script src="js/jquery.js" type="text/javascript"></script>

<script src="js/funk.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       
            <div id="searchform">

    <table align="center" width="1000px" class="form" >    
        <tr>
            <td colspan="2" align="center" >
             <img alt="Coat Of Arms" height="79" src="images/coat_of_arms.png" 
                        width="85" /><br />
              FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY<br />
                    PATENTS AND DESIGNS DECREE NO 60 OF 1970<br />
                   <div style="font-size:20px;"><strong>ACKNOWLEDGMENT FORM</strong></div> 
            </td>
        </tr>       
        
        <%if (lt_mi.Count > 0)
          { %>
        <tr>
            <td width="100%" align="right" colspan="2" class="sub_header">
                </td>
        </tr>
        
        <tr>
            <td width="50%" align="right">
                &nbsp;FILING/APPLICATION DATE :             </td>
            <td>
               
                <asp:Label ID="Label1" runat="server" Text="Label"><% Response.Write(lt_mi[0].reg_date); %></asp:Label>&nbsp;</td>
        </tr>
        
        <tr>
            <td align="right">
                REGISTRATION NUMBER :
            </td>
                <td>
                  <asp:Label ID="Label2" runat="server" Text="Label"><% Response.Write(lt_mi[0].reg_number); %></asp:Label>
                    </td>
        </tr>
         <tr>
            <td align="right"> 
                                &nbsp;
                                ONLINE APPLICATION ID : </td>
            <td>
                 
                <asp:Label ID="Label6" runat="server" Text="Label"><% Response.Write("OAI/PT/"+t.ValidationIDByPwalletID(lt_mi[0].log_staff) ); %></asp:Label></td>
        </tr>
         <tr>
            <td colspan="2" class="tbbg">
                --- 
                PATENT INFORMATION --- </td>
        </tr>
        
        <tr>
            <td align="right">
                &nbsp;PATENT TYPE :</td>
                <td>
                 
                  <asp:Label ID="Label3" runat="server" Text="Label"><% Response.Write(lt_mi[0].xtype); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;TITLE OF INVENTION :
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Label"><% Response.Write(lt_mi[0].title_of_invention); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                TRANSACTION ID :
                </td>
            <td>
                <% Response.Write(lt_stage[0].validationID); %></td>
        </tr>
        
        <tr>
            <td align="right">
                TRANSACTION AMOUNT :
                </td>
            <td>
                <% Response.Write(lt_stage[0].amt); %>  NGN
                </td>
        </tr>  
        <%}%>      
       <%if (lt_app.Count > 0)
         {
            %>
        <tr>
            <td class="tbbg" colspan="2">
                --- APPLICANT INFORMATION ---</td>
        </tr>
         <%             for (int app = 0; app < lt_app.Count; app++)
             {%>
        <tr>
            <td align="left" colspan="2" style="background-color:#999999;">
                <strong>APPLICANT <%=app + 1%>>></strong></td>
        </tr>
        
        <tr>
            <td align="right">
                NAME :</td>
                <td>
                    <% Response.Write(lt_app[app].xname); %></td>
        </tr>
        
        <tr>
            <td align="right">
                ADDRESS :</td>
                <td>
                    <% Response.Write(lt_app[app].address); %></td>
        </tr>
        
        <tr>
            <td align="right">
                PHONE NUMBER :
            </td>
                <td>
                    <% Response.Write(lt_app[app].xmobile); %></td>
        </tr>
        
        <tr>
            <td align="right">
                E-MAILS :</td>
                <td>
                    <% Response.Write(lt_app[app].xemail); %></td>
        </tr>
        <tr>
            <td align="right">
                NATIONALITY :</td>
                <td>
                   <% Response.Write(t.getCountryName(lt_app[app].nationality)); %></td>
        </tr>
       
         <%
             }
         }%>
         <%if (lt_inv.Count > 0)
           {
              %>  
        
       
        <tr>
            <td class="tbbg" colspan="2">
                --- TRUE INVENTOR INFORMATION ---</td>
        </tr>
        <%   for (int inv = 0; inv < lt_inv.Count; inv++)
               {%>
        <tr>
            <td align="left" colspan="2" style="background-color:#999999;">
                <strong>INVENTOR <%=inv+1%>>></strong></td>
        </tr>
        
        <tr>
            <td align="right">
                NAME :</td>
                <td>
                    <% Response.Write(lt_inv[inv].xname); %></td>
        </tr>
        
        <tr>
            <td align="right">
                ADDRESS :</td>
                <td>
                    <% Response.Write(lt_inv[inv].address); %></td>
        </tr>
        
        <tr>
            <td align="right">
                PHONE NUMBER :
            </td>
                <td>
                    <% Response.Write(lt_inv[inv].xmobile); %></td>
        </tr>
        
        <tr>
            <td align="right">
                E-MAILS :</td>
                <td>
                    <% Response.Write(lt_inv[inv].xemail); %></td>
        </tr>
        <tr>
            <td align="right">
                NATIONALITY :</td>
                <td>
                   <% Response.Write(t.getCountryName(lt_inv[inv].nationality)); %></td>
        </tr>
        <%
               }
           }%>
        <%if(lt_assinfo.Count>0){ %>
        <tr>
            <td class="tbbg" colspan="2">
                --- ASSIGNMENT INFORMATION ---</td>
        </tr>
          <tr>
            <td align="right">
                DATE OF ASSIGNMENT :</td>
                <td>
                    <% Response.Write(lt_assinfo[0].date_of_assignment); %></td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="background-color:#999999;">
                <strong>ASSIGNEE >></strong></td>
        </tr>
       
        <tr>
            <td align="right">
                NAME :</td>
                <td>
                    <% Response.Write(lt_assinfo[0].assignee_name); %></td>
        </tr>
        
        <tr>
            <td align="right">
                ADDRESS :</td>
                <td>
                    <% Response.Write(lt_assinfo[0].assignee_address); %></td>
        </tr>
         <tr>
            <td align="right">
                NATIONALITY :</td>
                <td>
                   <% Response.Write(t.getCountryName(lt_assinfo[0].assignee_nationality)); %></td>
        </tr>
       <tr>
            <td align="left" colspan="2" style="background-color:#999999;">
                <strong>ASSIGNOR >></strong></td>
        </tr>
        
        <tr>
            <td align="right">
                NAME :</td>
                <td>
                    <% Response.Write(lt_assinfo[0].assignor_name); %></td>
        </tr>
        
       
       
        <tr>
            <td align="right">
                ADDRESS&nbsp; :</td>
                <td>
                     <% Response.Write(lt_assinfo[0].assignor_address); %></td>
        </tr>
        <tr>
            <td align="right">
                NATIONALITY :</td>
                <td>
                   <% Response.Write(t.getCountryName(lt_assinfo[0].assignor_nationality)); %></td>
        </tr>
        <%} %>
        <%if(lt_xpri.Count>0){%>
        <tr>
            <td colspan="2" class="tbbg">
                --- PRIORITY INFORMATION ---</td>
        </tr>
        <tr>
            <td colspan="2" style="border:0px outset silver; padding: 0px;">
                <table width="100%">
                <tr style="background-color:#999999;">
                <td style="width:10%;">
                    <strong>S/N</strong></td>
                <td style="width:30%;">
                    <strong>COUNTRY</strong></td>
                <td style="width:30%;">
                    <strong>APPLICATION NUMBER</strong></td>
                <td style="width:30%;">
                    <strong>DATE</strong></td>
                </tr>

                 <%
                     for (int pri = 0; pri <lt_xpri.Count; pri++)
              {%>
                <tr >
                <td>
                <%=pri + 1%>
                </td>
                <td>
                    
                    <% Response.Write(t.getCountryName(lt_xpri[pri].countryID)); %></td>
                <td>
                    <% Response.Write(lt_xpri[pri].app_no); %></td>
                <td>
                    <% Response.Write(lt_xpri[pri].xdate); %></td>
                </tr>
                 <%
              }
          %>
                </table></td>
        </tr>
        <%
          }%>
        <%if (lt_rep.Count > 0)
          { %>
        <tr>
            <td colspan="2" class="tbbg">
                --- ADDRESS OF SERVICE IN NIGERIA ---
            </td>
        </tr>
        <tr>
            <td align="right">
                                ATTORNEY CODE :
                </td>
            <td>
                 <asp:Label ID="Label9" runat="server" Text="Label"><% Response.Write(lt_rep[0].agent_code); %></asp:Label>
                     </td>
        </tr>        
        
        
        <tr>
            <td align="right">
                                ATTORNEY NAME :</td>
            <td>
                <% Response.Write(lt_rep[0].xname); %></td>
        </tr>
        
        
        <tr>
            <td align="right">
                NATIONALITY :</td>
            <td>
                <% Response.Write(t.getCountryName(lt_rep[0].nationality)); %></td>
        </tr>
        
        
        <tr>
            <td align="right">
                COUNTRY :</td>
            <td>
               <% Response.Write(t.getCountryName(lt_rep[0].country)); %></td>
        </tr>
        
        
        <tr>
            <td align="right">
                STATE :</td>
            <td>
               <% Response.Write(t.getStateName(lt_rep[0].state)); %></td>
        </tr>
        
        
        <tr>
            <td align="right">
                &nbsp;ADDRESS :
                </td>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Label"><% Response.Write(lt_rep[0].address); %></asp:Label></td>
        </tr>
        
        
        <tr>
            <td align="right">
                PHONE NUMBER : </td>
            <td>
                <% Response.Write(lt_rep[0].xmobile); %></td>
        </tr>
        
        
        <tr>
            <td align="right">
                E-MAIL : </td>
            <td>
                <% Response.Write(lt_rep[0].xemail); %></td>
        </tr>
        <tr>
            <td colspan="2" class="tbbg">
                --- DOCUMENTS ATTACHED ---
            </td>
        </tr>
        <tr>
            <td align="right">
               LETTER OF AUTHORIZATION OF AGENT(FORM 2) :
            </td>
            <td >
            <%if ((lt_mi[0].loa_doc == "")||(lt_mi[0].loa_doc == "0"))
              { %> NOT ATTACHED<%}
              else
              { %> ATTACHED<%} %></td>
        </tr>
        
        <tr>
            <td align="right">
                CLAIM(S) :</td>
            <td >
                <%if ((lt_mi[0].claim_doc == "") || (lt_mi[0].claim_doc == "0"))
                  { %> NOT ATTACHED<%}
                  else
                  { %> ATTACHED<%} %></td>
        </tr>
        
        <tr>
            <td align="right">
                PCT DOCUMENT:</td>
            <td >
                  <%if ((lt_mi[0].pct_doc == "") || (lt_mi[0].pct_doc == "0"))
                    { %> NOT ATTACHED<%}
                    else
                    { %> ATTACHED<%} %></td>
        </tr>
        
        <tr>
            <td align="right">
                DEED OF ASSIGNMENT:</td>
            <td >
                  <%if ((lt_mi[0].doa_doc == "") || (lt_mi[0].doa_doc == "0"))
                    { %> NOT ATTACHED<%}
                    else
                    { %> ATTACHED<%} %></td>
        </tr>
        
        <tr>
            <td align="right">
                COMPLETE SPECIFICATION (FORM 3):</td>
            <td >
                  <%if ((lt_mi[0].spec_doc == "") || (lt_mi[0].spec_doc == "0"))
                    { %> NOT ATTACHED<%}
                    else
                    { %> ATTACHED<%} %></td>
        </tr>
        <%}%>

          <tr>
            <td colspan="2" class="tbbg">
                --- RECORDAL ---
            </td>
        </tr>

        <tr>
            <td >
                Old Applicant 
            </td>

            <td><%= applicant_recordal.old_applicant %>  </td>
        </tr>

         <tr>
            <td >
                New Applicant 
            </td>

            <td><%= applicant_recordal.new_applicant %>  </td>
        </tr>
        <tr>
            <td class="tbbg" colspan="2" style="color: #fff; background-color: #006600; text-align: center; font-weight: bold;">
              
                &nbsp;</td>
        </tr>
        <tr>
            <td  align="center" colspan="2">
              
             <strong>YOUR APPLICATION HAS BEEN RECEIVED AND IS RECEIVING DUE ATTENTION</strong><br />
             <strong>TRADEMARKS, PATENTS AND DESIGNS REGISTRY 
                <br />
                COMMERCIAL LAW DEPARTMENT
                <br />
                FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT
                </strong>
                </td>
        </tr>        
         
    </table>
        </div>
  <table style="float:left;width:100%;">
        <tr>
        <td align="left" width="100%">       
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printPtCert(searchform);" class="button" />&nbsp;
                <asp:Button ID="btnDashboard" runat="server" Visible="false" Text="Back to Dashboard" 
                    class="button" onclick="btnDashboard_Click"/>
                
                </td>
        </tr>
        </table>
</div>
    </form>
</body>
</html>