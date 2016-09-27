<%@ page language="C#" autoeventwireup="true" CodeFile="xreturn.cs" inherits="xreturn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">

    <title>
TRADEMARK APPLICATION NOTICE
</title>
  <link href="css/style.css" rel="stylesheet" type="text/css" />

<script src="js/jquery.js" type="text/javascript"></script>

<script src="js/funk.js" type="text/javascript"></script>
    
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function Proceed_onclick() {
            window.location.href = "./XPay/login.aspx";
        }

// ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">
  

<div>
    <div class="container">
        <div class="sidebar">
        </div>
        <div class="content_tm_ack">
            
            <div id="searchform">

    <table align="center" width="100%" class="form">
        <tr>
            <td align="center" >
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
            <td width="22%" align="center" bgcolor="#006699">&nbsp;</td>
        </tr>
        
        
        <tr>
            <td width="22%" align="center">
                <strong>&nbsp;APPLICATION VIOLATION NOTICE</strong> </td>
        </tr>
        
        
        <tr>
            <td width="50%" align="left">
               
                <div align="center">AN APPLICATION WITH THE TRANSACTION ID <strong>"<%=validationID.ToUpper() %>"</strong> HAS ALREADY BEEN FILED!!!<br />
                    <br />
                    PLEASE 
                    CONSULT CUSTOMER CARE TO MAKE ANY COMPLAINTS</div>
                <br />
                <br />
                <div align="center"><strong>THANK YOU FOR YOUR UNDERSTANDING AND SERVICE</strong></div> </td>
        </tr>
        
        <tr>
            <td class="tbbg">               
                &nbsp;</td>
        </tr>
        
       
        <tr>
            <td  align="center">
                &nbsp;<asp:Button ID="Agreed" runat="server" Text="BACK TO DASHBOARD" class="button" onclick="Agreed_Click" />
                </td>
        </tr>
         
    </table>
        </div>
    </div>
</div>
</div>

    </form>
</body>
</html>
