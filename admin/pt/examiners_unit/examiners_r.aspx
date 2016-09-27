<%@ page language="C#" autoeventwireup="true"  CodeFile="examiners_r.cs"  inherits="admin_pt_examiners_unit_examiners_r " %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" data-ng-app="myModule">
<head runat="server">
    <title></title>
     <link href="../../../css/bootstrap.min.css" rel="stylesheet" />
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
        <script src="../../../js/angular.min.js"></script>

    <script src="../../../js/AngularLogin.js"></script>
    <script src="../../../js/smart-table.min.js"></script>
    <script src="../../../js/sweet-alert.min.js"></script>
    <script src="../../../js/loading-bar.js"></script>
    <link href="../../../css/loading-bar.css" rel="stylesheet" />
    <link href="../../../css/font-awesome.min.css" rel="stylesheet" />

<script language="javascript" type="text/javascript">
    function doPostResults(eu) {
        postwith('./examiners_r.aspx', { eu: eu });
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
     <style type="text/css">
        .sidebar a {
padding-left:5px;

}
    </style>
</head>
<body ng-controller="myController9">
    <form id="form1" runat="server">
   <div>
    <div class="container">
        <div class="sidebar">
            <a href="./profile.aspx">PROFILE</a>
 <a href="../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a> <a href="./eed.aspx">VIEW STATISTICS</a>
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
            <td colspan="8"  class="tbbg"> WELCOME TO THE PATENT EXAMINATION 1 OFFICE</td>
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
            <td colspan="8" align="center" class="tbbg"><%--<asp:DropDownList ID="selectSearchCriteria" runat="server" AutoPostBack="False">
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
              &nbsp;--%></td>
          </tr>         
         
       <%--   <tr class="stripedout">
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
               <a href="examination_r_details.aspx?x=<%= lt_mi[i].xID.ToString() %>">View</a>
            </td>
        </tr>
        <% sn++; } 
             }%>--%>
          </table>

                  <table st-table="displayedCollection" st-safe-src="ListAgent" class="table table-responsive  table-hover  table-bordered">
        <thead>
            <tr>
                 <th  class="tdcolheader">S/N</th>
                <th st-sort="reg_number" class="tdcolheader">REGISTRATION NUMBER</th>
                <th st-sort="title_of_invention" class="tdcolheader">PRODUCT TITLE</th>
                 <th st-sort="xtype" class="tdcolheader"> PT TYPE</th>
                 <th st-sort="Validation" class="tdcolheader"> OAI No.</th>
                 <th st-sort="reg_date" class="tdcolheader"> Enrolled On</th>

                 <th st-sort="Office" class="tdcolheader"> Status</th>

                 <th st-sort="reg_no" class="tdcolheader">View </th>
                <th st-sort="reg_no" class="tdcolheader">Open New Tab</th>
                 
                  

            </tr>
            <tr>
                <th colspan="9"><input st-search="" class="form-control" placeholder="global search ..." type="text" /></th>
            </tr>
        </thead>
        <tbody>
            <tr ng-repeat="row in displayedCollection">
               
                <td align="center">{{row.Sn}}</td>
                <td align="center">{{row.reg_number}}</td>
                <td align="center">{{row.title_of_invention}}</td>
                 <td align="center">{{row.xtype}}</td>
                <td align="center">{{row.Validation}}</td>
                 <td align="center">{{row.reg_date}}</td>
                 <td align="center">{{row.Office}}</td>
                <td align="center"><a href="examination_r_details.aspx?x={{row.xID}}"><i class="fa fa-link"></i></a></td>
                <td align="center"><a target="_blank"  href="examination_r_details.aspx?x={{row.xID}}"><i class="fa fa-external-link"></i></a></td>
               

               
                
                 

              

              
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="9" class="text-center">
                    <div st-pagination="" st-items-by-page="itemsByPage" st-displayed-pages="7"></div>
                </td>
            </tr>
        </tfoot>
    </table>
        </div>
    </div>
</div>
</div>
    </form>
</body>
</html>
