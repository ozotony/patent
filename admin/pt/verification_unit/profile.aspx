<%@ page language="C#" autoeventwireup="true"  CodeFile="profile.cs" inherits="admin_pt_verification_unit_profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" ng-app="formApp" >
<head id="Head1" runat="server">
    <title></title>
    <link href="../../../css/bootstrap.min.css" rel="stylesheet" />
<link href="../../../css/style.css" rel="stylesheet" type="text/css" />   
    <script src="../../../Scripts/jquery-2.1.1.min.js"></script>
    <script src="../../../Scripts/angular.js"></script>
    <script src="../../../Scripts/App2.js"></script>
</head>
<body ng-controller="formController">
      <script type="text/javascript">
<!--
         spe = 500;
         var na = document.getElementsByTagName("blink")
 // var   na = document.all.tags("blink");
    swi = 1;
    bringBackBlinky();

    function bringBackBlinky() {

        if (swi == 1) {
            sho = "visible";
            swi = 0;
        }
        else {
            sho = "hidden";
            swi = 1;
        }

        for (i = 0; i < na.length; i++) {
            na[i].style.visibility = sho;
        }

        setTimeout("bringBackBlinky()", spe);
    }
  
</script>
    <form id="form1" runat="server">
    <div>
        <div class="header">
            <div class="leftholder">
            </div>
            <div class="xmenu">
                <div class="xmenu_m">
                    <div class="xmenu_ml">
                    </div>
                    <div class="xmenu_mm">
                        <div class="menu">
                            <ul>
                                <li><a href="../lo.aspx">
                                    <img alt="" src="../../../images/logoff.png" width="16" height="16" />Log off</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="xmenu_mr">
                    </div>
                </div>
            </div>
            <div class="xlogoleftholder">
            </div>
            <div class="xlogo">
                <div class="xlogo_l">
                </div>
                <div class="xlogo_r">
                </div>
            </div>
        </div>
        <div class="container">
            <div class="sidebar">
        
               
            </div>
            <div class="content">
        
    <table align="center" width="100%" >
        <tr>
            <td colspan="3" align="left" class="tbbg">
                WELCOME TO THE PAYMENT VERIFICATION OFFICE</td>
        </tr>
       
        
                
        <tr>
            <td align="center" colspan="3">&nbsp;</td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                <a href="./verify_data.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a></td>
            <td style="width: 30%;" align="center">
                <a href="./v_contact.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a></td>
            <td style="width: 30%;" align="center">
                <a href="./verify_invalid_data.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a></td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                <a href="./verify_data.aspx">NEW APPLICATIONS</a>
                 &nbsp;<br /><%Response.Write("( "+lt_mi+" )");%></td>
            <td style="width: 30%;" align="center">
                 <a href="./v_contact.aspx">KIV</a>
                 &nbsp;<br /><%Response.Write("( " + lt_mi_contact + " )");%></td>
            <td style="width: 30%;" align="center">
                <a href="./verify_invalid_data.aspx">INVALID APPLICATIONS</a>
                 &nbsp;<br /><%Response.Write("( " + lt_mi_r + " )");%></td>
        </tr>
        
        <tr>
            <td style="width: 30%;" align="center">
                <a href="../../../cp.aspx?x=<%Response.Write(adminID);  %>">
                    <img alt="" src="../../../images/xsync.png" style="width: 100px; height: 100px" /></a></td>
            <td style="width: 30%;" align="center">
                <a href="./online_request_profile.aspx">
                    <img alt="" src="../../../images/view.png" style="width: 100px; height: 100px" /></a></td>
            <td style="width: 30%;" align="center">
                <a href="./ved.aspx"> 
                    <img alt="" src="../../../images/xexec.png" style="width: 100px; height: 100px" /></a></td>
        </tr>
        <tr>
            <td style="width: 30%;" align="center">
                <a href="../../../cp.aspx?x=<%Response.Write(adminID); %>">CHANGE PASSWORD</a></td>
            <td style="width: 30%;" align="center">
                 <a href="./online_request_profile.aspx">ONLINE REQUEST</a>
                  &nbsp;<br /><%Response.Write("( " + or_cnt + " )");%></td>
            <td style="width: 30%;" align="center">
                <a href="./ved.aspx">CHECK STATISTICS</a></td>
        </tr>
    </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
