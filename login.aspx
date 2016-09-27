<%@ page language="C#" autoeventwireup="true"  CodeFile="login.cs" inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
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
                 <%--<div class="alert alert-info fade in">
                   
                                            <img src="images/einao_logo.png" /> <br/>
                                            Dear User, <br />

                                            This site is currently unavailable due to some operational maintenance. We apologize for any inconveniences caused.<br />

                                            For any queries, please send us an email: info@einaosolutions.com <br />

                                            Thanks.

                                        </div>   --%>  
 
            <table align="center" width="100%" >
              <tr>
            <td align="center" colspan="2">
               <img alt="Coat Of Arms" height="79" src="images/coat_of_arms.png" 
                        width="85" /><br />
              FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY<br />
                    PATENTS AND DESIGNS DECREE NO 60 OF 1970   
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left" class="tbbg">
                &nbsp;PLEASE LOGIN IN USING YOUE E-MAIL ADDRESS AND PASSWORD</td>
        </tr>
       
        
        <tr>
            <td align="right">
                &nbsp;
                E-MAIL: &nbsp;</td>
                
            <td rowspan="5" style="width: 50%;">
                <img alt="login" src="images/login.png" style="width: 128px; height: 128px" /></td>
        </tr>
        <tr>
            <td align="right">
            <asp:TextBox ID="xemail" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                <% if (email_text == "1")
                   { %>
                <img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <%  } if (enable_Save == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%></td>
        </tr>
        
        <tr class="green_bg_l">
            <td align="right" > Please note that the letters below are not case sensitive!!!
                </td>
        </tr>
        
        <tr>
            <td align="right"> <img alt="captcha" src="Handler.ashx" /><br />
                </td>
        </tr>
        
        <tr>
            <td align="right">
                ENTER CODE : 
            <asp:TextBox ID="xcode" runat="server" Width="90px" CssClass="textbox"></asp:TextBox>
            <% if (code_text == "1")
                   { %>
                <img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% } if (enable_Save == "0")
                   { %><img src="images/checkmark.gif" alt="" width="16px" height="16px" />
                <% }%>     
                </td>
        </tr>
        
        <% if (newState!= "0")
           { %>
        <tr>
            <td colspan="2" align="center">
                <strong>SORRY BUT THE CODE YOU ENTERED IS INVALID.</strong>
            </td>
        </tr>
        <% } %>
        <% if (newp != "0")
           { %>
        <tr>
            <td class="tbbg" colspan="2">
                &nbsp;</td>
        </tr>
        
        
        <tr>
            <td align="right">
                PASSWORD: </td>
            <td>
            <asp:TextBox ID="xpassword" runat="server" Width="200px" CssClass="textbox" TextMode="Password" onunload="xpassword_Unload" ></asp:TextBox>
                 </td>
        </tr>        
        <% } %>
        <tr>
            <td class="tbbg" colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
             <% if (enable_Confirm == "0")
                   { %>
               <asp:Button ID="ConfirmDetails" runat="server" Text="Confirm Details" 
                    OnClick="ConfirmDetails_Click" class="button"/>
                <% }if (enable_Save == "0")
                   { %>
                    <asp:Button ID="Save" runat="server" Text="Login" OnClick="Save_Click" 
                    class="button" />
                <% }%>
               
                </td>
        </tr>
    </table>
        </div>
     </div>   
    
    
</div>
    </form>
</body>
</html>
