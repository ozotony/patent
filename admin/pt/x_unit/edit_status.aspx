<%@ page language="C#" autoeventwireup="true" CodeFile="edit_status.cs" inherits="admin_pt_x_unit_edit_status" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link href="../../../css/style.css" rel="stylesheet" type="text/css" />
<script src="../../../js/jquery.js" type="text/javascript"></script>
<script src="../../../js/funk.js" type="text/javascript"></script>

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
                                     <img alt="" src="../../../images/logon.png" width="16" height="16" />Login</a></li>
                                
                             </ul>
                         </div>
                     </div>
                 
            <% if(showt==0) {%>
            <table align="center" width="100%">
             <tr align="center">
                <td colspan="2">
                    <img alt="Coat Of Arms" height="79" src="../../../images/coat_of_arms.png" 
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
                &nbsp;ENTER REFERENCE / APPLICATION NUMBER BELOW</td>
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
                <asp:Button ID="Save" runat="server" Text="Search For Patent" OnClick="Save_Click" class="button" />               
            </td>
        </tr>

    </table>
            <% }%>
            <% if (showt == 1)
               {%>
               <div id="searchform">
                <table align="center" width="100%" class="form">
        <tr>
            <td colspan="2" align="left" class="tbbg">
                PLEASE UPDATE THE &quot;STATUS&quot; DETAILS BELOW
            </td>
        </tr>
       
        <tr>
            <td width="22%" colspan="2" align="center">
                 <% Response.Write(trans_status); %></td>
        </tr>
       
        <tr>
            <td width="22%">
                &nbsp;OFFICE/STATUS&nbsp; : </td>
            <td>
                <asp:DropDownList ID="select_xoffice" runat="server" CssClass="textbox">
                <asp:ListItem Value="Fresh|1" Text="Verification-New Application"></asp:ListItem>
                <asp:ListItem Value="Invalid|1" Text="Verification-Invalid Application"></asp:ListItem>
                <asp:ListItem Value="V_Contact|1" Text="Verification-Contact Form"></asp:ListItem>
                <asp:ListItem Value="Valid|2" Text="Search-New Application"></asp:ListItem>
                <asp:ListItem Value="S_Contact|2" Text="Search-Contact Form"></asp:ListItem>
                <asp:ListItem Value="Search Conducted|3" Text="Examiner-New Application"></asp:ListItem>
                <asp:ListItem Value="E_Contact|3" Text="Examiner-Contact Form"></asp:ListItem>
                <asp:ListItem Value="Futher Review|4" Text="Acceptance-New Application"></asp:ListItem>
                <asp:ListItem Value="A_Contact|4" Text="Acceptance-Contact Form"></asp:ListItem>
                <asp:ListItem Value="Patentable|5" Text="Registrar-New Application"></asp:ListItem>
                <asp:ListItem Value="R_Contact|5" Text="Registrar-Contact Form"></asp:ListItem>
                </asp:DropDownList>               
            </td>
        </tr>
        <tr>
            <td width="22%" class="style1">
                &nbsp;COMMENT:
            </td>
            <td class="style1">
                <asp:TextBox ID="txt_comment" runat="server" Width="400px" CssClass="textbox" 
                    Height="50px" TextMode="MultiLine"></asp:TextBox>              
            </td>
        </tr>
       
       <tr>
            <td>
                 <asp:Label ID="appID" runat="server" ForeColor="White"></asp:Label>
                  <asp:Label ID="addressID" runat="server" ForeColor="White"></asp:Label>
                  </td>
            <td>
                <asp:Button ID="UpdateApplicant" runat="server" Text="Update Status" 
                    class="button" onclick="UpdateApplicant_Click"  />
                                   
            </td>
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
