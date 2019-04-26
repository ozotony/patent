<%@ Page Language="C#" AutoEventWireup="true" CodeFile="examination_details.aspx.cs" Inherits="admin_pt_examiners_unit2_examination_details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" data-ng-app="formApp">
<head runat="server">
    <title></title>
    <link href="../../../css/style.css" rel="stylesheet" type="text/css" />

<script src="../../../js/funk.js" type="text/javascript"></script>
    <script src="../../../Scripts/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/angular.js"  type="text/javascript"></script>

  
   <%-- <script src="../../../js/angular-sanitize.min.js" type="text/javascript"></script>--%>
    <script src="../../../Scripts/angular-sanitize.min.js" type="text/javascript"></script>
    <script src="../../../Scripts/App3.js" type="text/javascript"></script>
    <script src="../../../Scripts/ng-wig.min.js" type="text/javascript"></script>
    <script src="../../../js/sweet-alert.min.js" type="text/javascript"></script>
    <link href="../../../css/sweet-alert.css" rel="stylesheet" />
    <link href="../../../css/ng-wig.css" rel="stylesheet" />
    <script src="../../../js/ng-modal.min.js" type="text/javascript"></script>
    <link href="../../../css/ng-modal.css" rel="stylesheet" />

     <style type="text/css">

        .form table a {
            color: black;
        }
    </style>
</head>
<body  ng-controller="formController">
    <form id="form1" runat="server">
    <div>
    <div class="container">
        <div class="sidebar">
            <a href="./profile.aspx">PROFILE</a> 
            <a href="../../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a> 
            <a href="./eed.aspx">VIEW STATISTICS</a>
        </div>
        <div class="content">
            <div class="adminheader">
                <div class="xmenu">
                    <div class="menu">
                        <ul>
                            <li><a href="../lo.aspx">
                                <img alt="" src="../../../images/logoff.png" width="16" height="16" />Log off</a></li>
                        </ul>
                    </div>
                </div>
                
            </div>
            <div id="searchform">
    
     <table align="center"  style="width:100%;" class="form" >
            <tr id="xdets">
            <td>
            <table align="center" width="100%"  class="form">
         <tr>
            <td colspan="2" align="center" >
             <img alt="Coat Of Arms" height="79" src="../../../images/coat_of_arms.png" 
                        width="85" /><br />
              FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY<br />
                    PATENTS AND DESIGNS DECREE NO 60 OF 1970
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
            <% if (lt_mi[0].loa_doc != "")
               {
                   Response.Write("<a href=../" + lt_mi[0].loa_doc + " target='_blank' style='color:#000;'>View</a>");        
         }  else { Response.Write("NONE"); 
               } %></td>
        </tr>
        
        <tr>
            <td align="right">
                CLAIM(S) :</td>
            <td >
                 <% if (lt_mi[0].claim_doc != "")
               {
                   Response.Write("<a href=../" + lt_mi[0].claim_doc + " target='_blank' style='color:#000;' >View</a>");        
         }  else { Response.Write("NONE"); 
               } %></td>
        </tr>
        
        <tr>
            <td align="right">
                PCT DOCUMENT:</td>
            <td >
                    <% if (lt_mi[0].pct_doc != "")
               {
                   Response.Write("<a href=../" + lt_mi[0].pct_doc + " target='_blank' style='color:#000;'>View</a>");        
         }  else { Response.Write("NONE"); 
               } %></td>
        </tr>
        
        <tr>
            <td align="right">
                DEED OF ASSIGNMENT:</td>
            <td >
                  <% if (lt_mi[0].doa_doc != "")
               {
                   Response.Write("<a href=../" + lt_mi[0].doa_doc + " target='_blank' style='color:#000;'>View</a>");        
         }  else { Response.Write("NONE"); 
               } %></td>
        </tr>
        
        <tr>
            <td align="right">
                COMPLETE SPECIFICATION (FORM 3):</td>
            <td >
                  <% if (lt_mi[0].spec_doc != "")
               {
                   Response.Write("<a href=../" + lt_mi[0].spec_doc + " target='_blank' style='color:#000;'>View</a>");        
         }  else { Response.Write("NONE"); 
               } %></td>
        </tr>
        <%}%>
        <tr>
            <td  colspan="2" style="color: #fff; text-align: center; font-weight: bold;">
              
                &nbsp;</td>
        </tr>
         <tr>
            <td class="tbbg" colspan="2" align="center">
                &nbsp;
                -- PREVIOUS ADMINISTRATOR'S COMMENT --</td>
        </tr>
        <% Response.Write(xcomments); %>      
        
        <tr>
            <td class="tbbg" colspan="2">--- ACTION ---</td>
        </tr>
        <tr>
            <td align="center"  colspan="2"> <asp:RadioButtonList ID="rbValid" runat="server" RepeatDirection="Horizontal" onselectedindexchanged="rbValid_SelectedIndexChanged" AutoPostBack="True">
                      <asp:ListItem Value="Futher Review" >Examined For Futher Review</asp:ListItem>
                      <asp:ListItem Value="Further Search">For Further Search</asp:ListItem>
                      <asp:ListItem Value="E_Contact">KIV</asp:ListItem>
                       <asp:ListItem Value="Refused">Refuse </asp:ListItem>
                       <asp:ListItem Value="Patentable">Accept</asp:ListItem>
                       <asp:ListItem Value="Ping" >Ping Agent</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="tbbg" colspan="2" align="center">  --- ADD COMMENT --- </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:TextBox ID="comment" runat="server" Height="50px" TextMode="MultiLine" Width="98%"></asp:TextBox>
                 <table class="table tt2" id="rich" Width="98%"> 
              <tr>
                  <td> <textarea ng-wig="model.content"    ></textarea>  </td>

              </tr>

        <tr>
                  <td>
                      
                      
                      <input id="Button1" type="button" ng-click="add3(model.content)" value="Update" />  </td>

              </tr>


              </table>
            </td>

              
        </tr>
        
        <tr>
            <td class="tbbg" colspan="2">
                &nbsp;</td>
        </tr>
     
    </table>
            </td>
            </tr>
			
			 <tr>
            <td align="center">
                 <asp:Button ID="Refuse" runat="server" Text="Refuse" OnClick="Refuse_Click" class="button" />
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printAssessment('xdets');return false" class="button" />
                <asp:Button ID="Verify" runat="server" Text="Update" OnClick="Verify_Click" class="button" />
            </td>
        </tr>
            </table>
        </div>
    </div>
</div>
</div>
         <input id="xname" name="xname" type="hidden" runat="server" />
                  <input id="xname2" name="xname2" type="hidden" runat="server" />
                <input id="xname3" name="xname3" type="hidden" runat="server" />
                 <input id="xname4" name="xname3" type="hidden" runat="server" />
             <input id="xname5" name="xname5" type="hidden" runat="server" />

    </form>
</body>
</html>