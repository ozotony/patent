<%@ page language="C#" autoeventwireup="true" CodeFile="appstatus.cs"  inherits="appstatus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<script src="js/jquery.js" type="text/javascript"></script>
<script src="js/funk.js" type="text/javascript"></script>


</head>
<body>
    <form id="form1" runat="server">
    <div>

    <div class="container">
    <div class="sidebar"></div>
       
        <div class="content">                
                     <div class="xmenu">
                         <div class="menu">
                             <ul>
                                 <li><a href="login.aspx">
                                     <img alt="" src="./images/logon.png" width="16" height="16" />Login</a></li>
                                
                             </ul>
                         </div>
                     </div>
                 
            <% if(showt==0) {%>
            <table align="center" width="100%">
             <tr align="center">
                <td colspan="2">
                    <img alt="Coat Of Arms" height="79" src="images/coat_of_arms.png" 
                        width="85" />
               </td>
            </tr>
            <tr align="center" style=" font-size:11pt;" >
                <td colspan="2">
                    FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY<br />
                    PATENTS AND DESIGNS DECREE NO 60 OF 1970
</td>
            </tr>
        <tr>
            <td colspan="2" align="left" class="tbbg">
                &nbsp;PLEASE ENTER YOUR TRANSACTION OR APPLICATION NUMBER TO CHECK YOUR STATUS</td>
        </tr>
       
        
        <tr>
            <td align="right">
                &nbsp;
                REFERENCE /APPLICATION NUMBER: &nbsp;
                  </td>
                
            <td style="width: 50%;">
            <asp:TextBox ID="xref" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                </td>
        </tr>
        
        <tr>
            <td class="tbbg" colspan="2">               
            </td>
        </tr>
        <tr>
            <td  colspan="2" align="center">               
                <asp:Button ID="Save" runat="server" Text="Check Status" OnClick="Save_Click" class="button" />               
            </td>
        </tr>

    </table>
            <% }%>
            <% if (showt == 1)
               {%>
               <div id="searchform">
                <table align="center" width="100%" class="form" 
                     id="table1">
                    <tr align="center">
                <td colspan="2">
                    <img alt="Coat Of Arms" height="79" src="images/coat_of_arms.png" 
                        width="85" />
               </td>
            </tr>
            <tr align="center" style=" font-size:11pt;" >
                <td colspan="2">
                    FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY<br />
                    PATENTS AND DESIGNS DECREE NO 60 OF 1970
</td>
            </tr>
                   
                    <tr>
                        <td width="100%" colspan="2" class="tbbg">
                            <strong>---STATUS INFORMATION---</strong>
                        </td>
                    </tr>
                     <% if (refill == 0)
                       { %>
                    <tr>
                        <td width="100%" align="justify" colspan="2">
                         Dear 
                            <% if (lt_rep.xname != null) { Response.Write(lt_rep.xname); } else { Response.Write(lt_pw[0].validationID); }%>, 
                            <br /> We will like to inform you of the current position of your application ("/OAI/TM/<% Response.Write(lt_pw[0].validationID); %>") below: <br /><br />
                            Current Office: <strong>  "<% Response.Write(status); %>"</strong><br />
                            Current Status: <strong>"<% Response.Write(data_status); %>"</strong><br />
                            Regards,
                        </td>
                    </tr>
                     <% }
                       else if(refill==1){ %>
                        <tr>
                        <td width="100%" align="justify" colspan="2">
                         Dear 
                            <% if (lt_rep.xname != null) { Response.Write(lt_rep.xname); } else { Response.Write(lt_pw[0].validationID); }%>, 
                            <br /> We will like to inform you that your application ("OAI/TM/<% Response.Write(r); %>&quot;) 
                            has not been completed successfully!!!<br /> Please click 
                            on the &quot;COMPLETE PATENT APPLICATION&quot; button below to update the patent 
                            details<br />
                            Regards,
                        </td>
                    </tr>
                    <% } %>
                    <tr>
                        <td class="tbbg" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width:50%">
                            <strong>&nbsp;THE TRADEMARK REGISTRY,<br />
                                &nbsp;COMMERCIAL LAW DEPARTMENT NIGERIA,<br />
                                &nbsp;FEDERAL MINISTRY OF TRADE AND INVESTMENT,<br />
                                &nbsp;FEDERAL CAPITAL TERRITORY,<br />
                                &nbsp;ABUJA,NIGERIA </strong>
                        </td>
                        <td align="right">
                            <strong>REGISTRAR OF TRADEMARKS&nbsp;&nbsp; </strong>
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="tbbg" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                           
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printAssessment(document.getElementById('searchform'));return false" class="button" />
                <% if (refill == 0)
                   { %>
                        <input type="button" name="btnReprint" id="btnReprint" value="Reprint Acknowledgment Slip"  onclick="doView('./tm_ackrep.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=<% Response.Write(r); %>&94384238SKFGKSDKGFSDKFSKFDKFD=<% Response.Write(agt); %>');" class="button" />
                        <% } else if (refill == 1)
                   { %>
                            <input id="btnCompletePatent" class="button" name="btnCompletePatent" 
                                onclick="doView('./pt_refill.aspx?XXX1234445=<% Response.Write(r); %>&amp;XXX94384238=<% Response.Write(agt); %>');" 
                                type="button" value="Complete Patent Application" />
 <% }%>
                        <asp:Button ID="BtnCheckStatus" runat="server" Text="Refresh Search"  
                                CssClass="button" Width="154px" onclick="BtnCheckStatus_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" class="tbbg">
                           
                            &nbsp;</td>
                    </tr>
                </table>
               </div>
            <% }%>
        </div>
     </div>   
    
    
</div>
    </form>
</body>
</html>
