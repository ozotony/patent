﻿<%@ page language="C#" autoeventwireup="true"  CodeFile="registrar_c_details.cs"inherits="admin_pt_registrar_unit_registrar_c_details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../css/print_style.css" rel="stylesheet" type="text/css" />

<script src="../../../js/funk.js" type="text/javascript"></script>

<style type="text/css">
    .style1
    {
        width: 146px;
        height: 64px;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
   <div>
    <div class="container">
        <div class="sidebar">
                       <a href="./pt_profile.aspx">PROFILE</a> 
            <a href="../../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a> 
            <a href="./red.aspx">VIEW STATISTICS</a>
            <a href="../lo.aspx" >LOG OFF</a>
        </div>
        <div class="content">
           
            <div id="searchform">
            

    <table align="center"  style="width:100%;" class="form" >
            <tr id="xdets">
            <td>
            <table align="center" width="1000px"  class="form">
       <tr>
            <td colspan="2" align="center" >
             <img alt="Coat Of Arms" height="79" src="../../../images/coat_of_arms.png" 
                        width="85" /><br />
                FEDERAL REPUBLIC OF NIGERIA<br />
                Patents and Designs Act,<br />
                (CAP 344 LAWS OF THE FEDERATION OF NIGERIA 1990)<br />
                   <div style="font-size:22px;"><strong>CERTIFICATE OF REGISTRATION OF PATENT </strong></div> 
            </td>
        </tr>       
        
        <tr>
            <td width="100%" colspan="2" align="center" class="tbbg">
                &nbsp;</td>
        </tr>
        
     
        <tr>
            <td width="50%" align="right">
                &nbsp;<strong>Priority No:</strong>&nbsp;&nbsp;
                
            </td>
            <td>
                <strong>RP:</strong><% Response.Write(lt_mi[0].reg_number.ToUpper()); %>&nbsp;
            </td>
        </tr>

        <tr>
            <td align="right">
              <%if (lt_pri.Count > 0)
         { %>
                <% Response.Write(lt_pri[0].app_no); %>
                <%} %>&nbsp;&nbsp;
            </td>
            <td>
               <strong>Date of patent:</strong> <% Response.Write(lt_mi[0].reg_date); %>
            </td>
        </tr>
        <tr>
            <td align="right"> 
                                &nbsp;</td>
            <td>
              <strong>Date of sealing:</strong> <%=sealing_date %></td>
        </tr>
        <tr>
            <td class="tbbg" colspan="2" align="center">
                &nbsp;</td>
        </tr>

        <tr>
            <td align="left" colspan="2">
            <div style="padding-left:10px;padding-right:10px;padding-top:5px;padding-bottom:5px;">
                President of the Federal Republic of Nigeria and commander-in-Chief of the armed forces<br /> 
                <strong>DR. GOODLUCK EBELE JONATHAN</strong><br /> 
                WHEREAS a request for the grant of a patent has been made by:<br />      
                        <div style="background-color:#999999; font-weight:bold;">PRIMARY APPLICANT</div>
                         <% Response.Write(lt_app[0].xname); %><br />
                          <% if ((lt_app[0].xmobile != "") && (lt_app[0].xmobile != null)) { Response.Write(lt_app[0].address + ",<br />"); } else { Response.Write(lt_app[0].address + "<br />"); }%>
                          <% if ((lt_app[0].xemail != "") && (lt_app[0].xemail != null)) { Response.Write(lt_app[0].xmobile + ", ");} else { Response.Write(lt_app[0].xmobile + " "); }%>
                          <% if ((lt_app[0].nationality != "") && (lt_app[0].nationality != null)) { Response.Write(lt_app[0].xemail + ", "); } else { Response.Write(lt_app[0].xemail + " "); }%>
                           <% if ((lt_app[0].nationality != "") && (lt_app[0].nationality != null)) { Response.Write(t.getCountryName(lt_app[0].nationality) + ".<br />"); }%>
                       
                    <br />
                For the sole use and the advantage of an invention for:<br />
                <div style="text-align:center;font-weight:bold; font-size:20px;font-family: Arial Rounded MT Bold;">"<% Response.Write(lt_mi[0].title_of_invention.ToUpper()); %>"</div>
                <br />
                <div style="text-align:justify;">
                AND WHEREAS the federal Government being willing to encourage all invention which may be for the public good, is please to accede to the request:<br />
KNOW YE, THEREFORE, that I do by this instrument give and grant unto the person(s) above named and any successor(s), executor(s) and assign(s) (each and any of whom are hereinafter referred to as the patentee) 
by special license, full power, sole privilege and authority, that the patentee or any agent or licensee of the patentee may subject to the conditions and provisions prescribed by any statute or order for the time being force at all times hereafter during the term of years herein mentioned make, use, exercise ,and vend the said invention throughout the federal republic of Nigeria, and that the patentee shall have and enjoy the whole profit and advantage from time to time accruing by reason of the said invention during the term of twenty years  from the date first above written of this instrument: AND to the end that the patentee may have and enjoy the sole use and exercise and full benefit of the said invention, I do by this instrument strictly command all citizens of the Federal Republic of Nigeria that they do not at any time during the continuance of the said term either directly or indirectly make use of or put in practise the said invention, nor in anywise imitate the same, without the written consent, license or agreement of the patentee, on pain of incurring such penalties as may be justly inflicted on such offenders, and of being answerable to the patentee according to law of damages thereby occasioned:
PROVIDED ALWAYS that this patent shall be revocable on any of the grounds from time to time by the law prescribed as grounds for revoking patents by me and the same may be revoked and made void <br />
Accordingly:
                <br />
                PROVIDED ALSO that nothing herein contained shall prevent the granting of licences in such manner and for such considerations as they may by law granted.
                </div>
                <br />
                <br />
                <br />
                <div style="text-align:right;"><strong>MADE this date:</strong><%=registrar_date %></div>
                <br />
               
                <div style="text-align:right;">
                    <%--  <img alt="sign" class="style1" src="../signatures/Adeyemi.jpg"/> --%>
                     <img alt="Signature" class="style1" src="../signatures/aisha_acceptance_mini_png.png" />

                   <%-- <img alt="sign" class="style1" src="../signatures/sig.jpg"/>--%>

                </div><br />
                
                <div  ><strong>L.S.</strong>  <span style="padding-left:760px;"><strong> Acting Director / Registrar</strong> </span></div> 
                </div></td>
        </tr>       
    </table>
            </td>
            </tr>
			
			<tr>
            <td align="center" colspan="2">
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printAssessment('xdets');return false;" class="button" />
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
