<%@ page language="C#" autoeventwireup="true"  CodeFile="acceptance_r.cs"  inherits="admin_pt_acceptance_unit_acceptance_r" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PATENT APPROVING OFFICE</title>
<link rel="stylesheet" type="text/css" href="../../../css/style.css" />

<link rel="stylesheet" href="../../../css/jquery.ui.all.css" />

<script type="text/javascript" src="../../../js/jquery.js"></script>

<script type="text/javascript" src="../../../js/ui/jquery.cookie.js"></script>

<script type="text/javascript" src="../../../js/ui/jquery.ui.core.js"></script>

<script type="text/javascript" src="../../../js/ui/jquery.ui.widget.js"></script>

<script type="text/javascript" src="../../../js/ui/jquery.ui.datepicker.js"></script>

<script type="text/javascript" src="../../../js/ui/jquery.ui.position.js"></script>

<script type="text/javascript" src="../../../js/ui/jquery.ui.autocomplete.js"></script>
<script src="../../../js/funk.js" type="text/javascript"></script>

<script language="javascript" type="text/javascript">
    function doPostResults(eu) {
        postwith('./acceptance_r.aspx', { eu: eu });
    }

	</script>
<script type="text/javascript">
    $(function () {
        $("table tr:nth-child(even)").addClass("striped");
    });
</script>

<script type="text/javascript">
    $(function () {
        $("#datepickerFrom").datepicker();
    });
    $(function () {
        $("#datepickerTo").datepicker();
    });		
		
</script>

<script type="text/javascript">
    $(function () {
        var availableTags = [""];
        $("#kword").autocomplete({
            source: availableTags
        });
    });
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="container">
        <div class="sidebar">
            <a href="./profile.aspx">PROFILE</a>
             <a href="../../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a>
              <a href="./aed.aspx">VIEW STATISTICS</a>
        </div>
        <div class="content">
            <div class="header">
                <div class="xmenu">
                    <div class="menu">
                        <ul>
                            <li><a href="../lo.aspx">
                                <img alt="" src="../../../images/logoff.png" width="16" height="16" />Log off</a></li>
                        </ul>
                    </div>
                </div>
                <div class="xlogo">
                    <div class="xlogo_l">
                    </div>
                    <div class="xlogo_r">
                    </div>
                </div>
            </div>
            <div id="searchform">
            <table width="100%" class="form">
          <tr>
            <td colspan="8"  class="tbbg"> WELCOME TO THE PATENT APPROVING OFFICE</td>
          </tr>
          <tr class="stripedout">
            <td colspan="8" align="center">
            &nbsp;<asp:Button ID="btnReloadPage" runat="server" class="button" 
                    onclick="btnReloadPage_Click" Text="RELOAD PAGE" />
              </td>
          </tr>
         
         <tr>
            <td colspan="8" class="tbbg">&nbsp;PLEASE SEARCH FOR ENTRIES BELOW</td>
          </tr>
          
          <tr class="stripedout">
            <td colspan="8" align="center" ><%Response.Write(criteria); %></td>
          </tr>
          
          <tr >
            <td colspan="8" align="center" class="tbbg"><asp:DropDownList ID="selectSearchCriteria" runat="server" AutoPostBack="False">
                <asp:ListItem Text="TRADEMARK" Value="product_title"></asp:ListItem>
                <asp:ListItem Text="APP NUMBER" Value="app_number"></asp:ListItem>
                </asp:DropDownList>
&nbsp;&nbsp;

              key word:&nbsp;
              <input name="kword" type="text" id="kword"  size="50"   value="" runat="server"/>
              
              From :
              <input type="text" id="datepickerFrom" runat="server"/>
              &nbsp;
              To :
              <input type="text" id="datepickerTo" runat="server"/>
              &nbsp;</td>
          </tr>         
         
          <tr class="stripedout">
            <td colspan="8" align="center">            
                <asp:Button ID="btnSearch" runat="server" Text="SEARCH" class="button" 
                    onclick="btnSearch_Click"   />
                <br />
                <strong>Pages <% Response.Write(eu + 1);%> of <%if (pages.Count < 1) { Response.Write("1"); } else { Response.Write(pages.Count); }%> . Total records = <%=nume %> </strong>
              </td>
            </tr>          
         
          <tr >
            <td colspan="8" align="center"><strong><% foreach (string s in pages) { Response.Write(s + " "); }%></strong></td>
            </tr>
          <tr >
            <td  colspan="8" align="center">&nbsp;</td>
            </tr>
             <tr>
            <td width="5%" class="tdcolheader">S/N</td>
            <td width="20%" class="tdcolheader">REGISTRATION NUMBER</td>
            <td width="15%" class="tdcolheader">PRODUCT TITLE</td>
            <td width="20%" class="tdcolheader">PT TYPE</td>
            <td width="15%" class="tdcolheader">OAI No. </td>
            <td width="10%" class="tdcolheader">Enrolled On</td>
            <td width="10%" class="tdcolheader">Status</td>
            <td width="5%" class="tdcolheader">&nbsp;</td>
             </tr>
           <%if (lt_mi.Count > 0)
             {
                 int sn = Convert.ToInt32(dis.ToString());
                 for (int i = 0; i < lt_mi.Count; i++)
                 { %> 
        <tr>
            <td align="center">
                <%=sn %>
            </td>
            <td align="center">
                <%=lt_mi[i].reg_number.ToString() %>
            </td>
            <td  align="center">
                <%= lt_mi[i].title_of_invention.ToString() %>
            </td>
            <td align="center">
                <%= lt_mi[i].xtype.ToString() %>
            </td>
             <td align="center">
                 <% =z.getValidationIDFromPtInfo(lt_mi[i].xID)%>
            </td>
            <td align="center">
                <%= lt_mi[i].reg_date.ToString() %>
            </td>
            <td align="center">
                <% if (z.getPtOfficeByMID(lt_mi[i].log_staff) != "") { Response.Write(z.getPtOfficeByMID(lt_mi[i].log_staff)); } else { Response.Write("None"); }%></td>
           
            <td align="center">
               <a href="acceptance_r_details.aspx?x=<%= lt_mi[i].xID.ToString() %>">View</a>
            </td>
        </tr>
        <% sn++; } 
             }%>
          </table>
        </div>
    </div>
</div>
</div>
    </form>
</body>
</html>
