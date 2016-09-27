<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rej_renewal_details.aspx.cs" Inherits="admin_pt_search_unit_rej_renewal_details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" data-ng-app="formApp">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../../css/style.css" rel="stylesheet" type="text/css" />

<script src="../../../js/funk.js" type="text/javascript"></script>

    <script src="../../../js/jquery-2.1.1.min.js"></script>

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
</head>
<body ng-controller="form2Controller">
    <form id="form1" runat="server">
   <div>
    <div class="container">
        <div class="sidebar">
            <a href="./profile.aspx">PROFILE</a>
             <a href="../../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a> 
             <a href="./ved.aspx">VIEW STATISTICS</a>
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
            <table align="center" width="100%" class="form">
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
        
        <%if ((c_p.ID!=null)&&(c_x.xID!=null))
          { %>
        <tr>
            <td width="100%" align="right" colspan="2" class="sub_header">
                </td>
        </tr>
        
                <tr>
            <td width="100%" align="right" colspan="2" class="tbbg">
                --- PAYMENT INFORMATION ---</td>
                </tr>
                <tr>
            <td width="50%" align="right">
                &nbsp;PAYMENT DATE :             </td>
            <td>
               
                <asp:Label ID="payment_date" runat="server" Text="None"></asp:Label>&nbsp;</td>
                </tr>
                <tr>
            <td align="right">
                TRANSACTION ID :
            </td>
                <td>
                  <asp:Label ID="transID" runat="server" Text="None"></asp:Label>
                    </td>
                </tr>
                <tr>
            <td colspan="2" class="tbbg">
                --- 
                PATENT APPLICATION INFORMATION --- </td>
                </tr>
                <tr>
            <td align="right">
                &nbsp;PATENT TYPE :</td>
                <td>
                 
                  <asp:Label ID="p_type" runat="server" Text="None"></asp:Label></td>
                </tr>
                <tr>
            <td align="right">
                ITEM CODE: </td>
                <td>
                  <asp:Label ID="p_item_code" runat="server" Text="None"></asp:Label>
                  </td>
                </tr>
                <tr>
            <td align="right">
                &nbsp;PATENT APPLICATION NUMBER :
            </td>
            <td>
                <asp:Label ID="p_app_no" runat="server" Text="None"></asp:Label></td>
                </tr>
                <tr>
            <td align="right">
                TITLE OF INVENTION :
                </td>
            <td>
               
                <asp:Label ID="p_title" runat="server" Text="None"></asp:Label>
                </td>
                </tr>
                <tr>
            <td align="right">
                FILING DATE :
                </td>
            <td>
               
                <asp:Label ID="p_app_date" runat="server" Text="None"></asp:Label>&nbsp;
                </td>
                </tr>
                <tr>
            <td class="tbbg" colspan="2">
                --- APPLICANT INFORMATION ---</td>
                </tr>
                <tr>
            <td align="right">
                NAME :</td>
                <td>
               
                <asp:Label ID="p_xname" runat="server" Text="None"></asp:Label>
                   </td>
                </tr>
                <tr>
            <td align="right">
                ADDRESS :</td>
                <td>
               
                <asp:Label ID="p_xaddy" runat="server" Text="None"></asp:Label>
                    </td>
                </tr>
                <tr>
            <td align="right">
                PHONE NUMBER :
            </td>
                <td>
               
                <asp:Label ID="p_xmobile" runat="server" Text="None"></asp:Label>
                  </td>
                </tr>
                <tr>
            <td align="right">
                E-MAIL :</td>
                <td>
               
                <asp:Label ID="p_xemail" runat="server" Text="None"></asp:Label>
                   </td>
                </tr>
                <tr>
            <td class="tbbg" colspan="2">
                --- AGENT INFORMATION ---</td>
                </tr>
                <tr>
            <td align="right">
                NAME :</td>
                <td>
               
                <asp:Label ID="p_agt_name" runat="server" Text="None"></asp:Label>
                   </td>
                </tr>
                <tr>
            <td align="right">
                CODE: </td>
                <td>
                <asp:Label ID="p_agt_code" runat="server" Text="None"></asp:Label>
                </td>
                </tr>
                <tr>
            <td align="right">
                ADDRESS :</td>
                <td>
               
                <asp:Label ID="p_agt_addy" runat="server" Text="None"></asp:Label>
                    </td>
                </tr>
                <tr>
            <td align="right">
                PHONE NUMBER :
            </td>
                <td>
               
                <asp:Label ID="p_agt_mobile" runat="server" Text="None"></asp:Label>
                  </td>
                </tr>
                <tr>
            <td align="right">
                E-MAIL :</td>
                <td>
               
                <asp:Label ID="p_agt_email" runat="server" Text="None"></asp:Label>
                   </td>
                </tr>
                <tr>
            <td class="tbbg" colspan="2">
                --- RENEWAL INFORMATION ---</td>
                </tr>
                <tr>
            <td align="right">
                LAST RENEWAL DATE :</td>
                <td>
               
                <asp:Label ID="p_last_rwl_date" runat="server" Text="None"></asp:Label>
                   </td>
                </tr>
                <tr>
            <td align="right">
                DUE DATE :</td>
                <td>
               
                <asp:Label ID="p_due_date" runat="server" Text="None"></asp:Label>
                   </td>
                </tr>
                  <tr>
            <td class="tbbg" colspan="2" align="center">
                &nbsp;
                -- PREVIOUS ADMINISTRATOR'S COMMENT --</td>
        </tr>
        <% Response.Write(xcomments); %>  
        <tr>
            <td class="tbbg" colspan="2" style="color: #fff; text-align: center; font-weight: bold;">
              
                --- ACTION ---</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
               
                <asp:RadioButtonList ID="rbValid" runat="server" RepeatDirection="Horizontal" onselectedindexchanged="rbValid_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Value="Approved">Approve</asp:ListItem>
                    <asp:ListItem Value="Refused">Refuse</asp:ListItem>
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
            <%
               }
           %>      
    </table>
            </td>
            </tr>
			
			 <tr>
            <td align="center">
                <input type="button" name="Printform" id="Button1" value="Print" onclick="printAssessment('xdets');return false" class="button" />
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