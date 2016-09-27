<%@ page language="C#" autoeventwireup="true"  CodeFile="rej_renewal.cs"  inherits="admin_pt_acceptance_unit_rej_renewal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
        postwith('./verify_data.aspx', { eu: eu });
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
            <a href="./profile.aspx">PROFILE</a> <a href="../../../cp.aspx?x=<% Response.Write(admin); %>">CHANGE PASSWORD</a> <a href="./aed.aspx">VIEW STATISTICS</a>
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

            <table  class="form" style="width:100%;">
          <tr>
            <td   class="tbbg"> WELCOME TO THE APPROVAL OFFICE</td>
          </tr>
          <tr >
            <td  align="center">
            &nbsp;<asp:Button ID="btnReloadPage" runat="server" class="button" 
                    onclick="btnReloadPage_Click" Text="RELOAD PAGE" />
              </td>
          </tr>
         
         <tr>
            <td  class="tbbg">&nbsp;PLEASE SEARCH FOR ENTRIES BELOW</td>
          </tr>
          
          <tr >
            <td  align="center" ><%Response.Write(criteria); %></td>
          </tr>
          
          <tr >
            <td  align="center" ><asp:DropDownList ID="selectSearchCriteria" runat="server" AutoPostBack="False">
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
            <td  align="center">            
                <asp:Button ID="btnSearch" runat="server" Text="SEARCH" class="button" 
                    onclick="btnSearch_Click"   />
                <br />
               Total Records :<strong> <%=x_cnt%></strong>
              </td>
            </tr>         
         <tr >
            <td  align="center"> 
            &nbsp;
              </td>
            </tr>                 
          </table>

          <table style="width:100%;">
          <tr class="stripedout">
            <td  align="center"> 
          <asp:GridView ID="gvX" runat="server" AllowPaging="True" AutoGenerateColumns="False" CaptionAlign="Left" CellPadding="4" EnableModelValidation="True" ForeColor="#000000" GridLines="None" HorizontalAlign="Left" onpageindexchanging="gvX_PageIndexChanging" onrowcommand="gvX_RowCommand" style="margin-top: 0px; width:100%;">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="S/N">
                            <ItemTemplate>
                                 <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="30px" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="reg_no" HeaderText="APPLICATION No." ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Left" Width="120px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                          <asp:BoundField DataField="app_no" HeaderText="REGISTRATION No." ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Left" Width="120px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="title" HeaderText="PRODUCT TITLE" ReadOnly="True">
                        <HeaderStyle HorizontalAlign="Left" Width="450px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="type" HeaderText="PT TYPE">
                        <HeaderStyle HorizontalAlign="Left" Width="80px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>                       
                        <asp:BoundField DataField="reg_date" HeaderText="REG DATE">
                        <HeaderStyle HorizontalAlign="Left" Width="100px" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>                      
                        <asp:TemplateField HeaderText="" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblLogStaff" runat="server" Text='<%#Eval("log_staff") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="10px" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="VIEW">
                            <ItemTemplate>
                                <asp:ImageButton ID="btnXEdit" runat="server" CommandArgument='<%#Eval("xid") %>' CommandName="TmViewClick" Height="16px" ImageUrl="../../../images/search.gif" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="20px" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
              </td>
            </tr>
            </table>
           </div>
         
                 

        </div>
</div>
    </form>
</body>
</html>
