<%@ page language="C#" autoeventwireup="true"  CodeFile="registrar_c_details2.cs" inherits="admin_pt_registrar_unit_registrar_c_details2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../../css/style.css" rel="stylesheet" type="text/css" />

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
            <table align="center" width="1000px"  class="form">
       <tr>
            <td colspan="2" align="center" >
             <img alt="Coat Of Arms" height="79" src="../../../images/coat_of_arms.png" 
                        width="85" /><br />
              FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY<br />
                    PATENTS AND DESIGNS DECREE NO 60 OF 1970<br />
                   <div style="font-size:22px;"><strong>CERTIFICATE OF REGISTRATION OF PATENT </strong></div> 
            </td>
        </tr>       
        
        <tr>
            <td width="100%" colspan="2" align="center" class="tbbg">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td width="100%" colspan="2" align="center">
                <strong>
                PATENTS ACT<br />
                (CAP 436 LAWS OF THE FEDERATION OF NIGERIA 1990, SECTION 22(3)REGULATION 65)<br />
                THE PATENT SHOWN BELOW HAS BEEN REGISTERED IN PART A (OR B) OF THE REGISTRAR</strong>
            </td>
        </tr>
        <tr>
            <td width="22%" colspan="2" class="tbbg">
                <strong>---PATENT INFORMATION---</strong></td>
        </tr>
        <tr>
            <td width="50%" align="right">
                &nbsp;FILING/APPLICATION DATE :&nbsp;&nbsp;
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Label"><% Response.Write(lt_mi[0].reg_date); %></asp:Label>&nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                REGISTRATION NUMBER :&nbsp;&nbsp;
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Label"><% Response.Write(lt_mi[0].reg_number.ToUpper()); %></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right"> 
                                &nbsp;
                                ONLINE APPLICATION ID : </td>
            <td>
                 
                <asp:Label ID="Label44" runat="server" Text="Label"><% Response.Write("OAI/PT/"+t.ValidationIDByPwalletID(lt_mi[0].log_staff) ); %></asp:Label></td>
        </tr>
        <tr>
            <td class="tbbg" colspan="2" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;PATENT TYPE :</td>
                <td>
                 
                  <asp:Label ID="Label3" runat="server" Text="Label"><% Response.Write(lt_mi[0].xtype.ToUpper()); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;TITLE OF INVENTION :
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Label"><% Response.Write(lt_mi[0].title_of_invention.ToUpper()); %></asp:Label></td>
        </tr>
        
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
                E-MAIL :</td>
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
         <tr>
            <td class="tbbg" colspan="2"></td>
        </tr>
        <tr>
            <td align="left">
                <strong>
                &nbsp;THE TRADEMARK REGISTRY,<br />
                &nbsp;INDUSTRIAL PROPERTY OFFICE NIGERIA,<br />
                &nbsp;FEDERAL MINISTRY OF TRADE AND INVESTMENT,<br />
                &nbsp;FEDERAL CAPITAL TERRITORY,<br />
                &nbsp;ABUJA,NIGERIA
                </strong>
                </td>
            
            <td align="right">
                <img alt="sign" class="style1" src="../signatures/registrar_mini_png.png" /><br />
                <strong>Signed :REGISTRAR OF PATENTS&nbsp;&nbsp; </strong>
            </td>
        </tr>
        
        <tr>
            <td class="tbbg" colspan="2">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td  align="center" colspan="2">
            REGISTRATION IS 7 YEARS FROM THE DATE OF FILING AND MAY THEN BE RENEWED ALD ALSO AT THE EXPIRATION 
                <br />
                OF EACH PERIOD OF 14 YEARS THEREAFTER.<br />
                THIS CERTIFICATE IS NOT FOR USE IN THE LEGAL PRECEEDINGS OR FOR OBTAINING REGISTRATION ABROAD.<br />
                UPON ANY CHANGE OF OWNERSHIP OF THIS TRADEMARK, OR CHANGE IN ADDRESS, AN APPLICATION SHOULD BE AT ONCE MADE<br />
                TO THE <strong>REGISTRAR</strong> TO  REGISTER THE CHANGE
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printAll();return false" class="button" />
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
