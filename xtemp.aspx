<%@ page language="C#" autoeventwireup="true" CodeFile="xtemp.cs" inherits="xtemp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/funk.js" type="text/javascript"></script>

<script language="javascript" type="text/javascript">
    function doPost(transID, amt, agent, xgt, cname, agentemail, agentpnumber, product_title,pc) {
        postwith('./xxindex.aspx', { transID: transID, amt: amt, agent: agent, xgt: xgt, cname: cname, agentemail: agentemail, agentpnumber: agentpnumber, product_title: product_title, pc: pc});
    }   
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        Transaction ID:
        <br />
        <asp:TextBox ID="txt_transID" runat="server"></asp:TextBox>
        <br />
        <br />
        Product Title:
        <br />
        <asp:TextBox ID="txt_product_title" runat="server"></asp:TextBox>
        <br />
        <br />
        Patent form type:
        <br />
        <asp:DropDownList ID="selectPtType" runat="server" AutoPostBack="True">
        <asp:ListItem Text="Convention" Value="P001"></asp:ListItem>
        <asp:ListItem Text="Non-Conventional" Value="P002"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        Value:<%=xvalue %>
        <br />
         <%if (xconfirm == "0")
           { %>
        <asp:Button ID="btnConfirm" runat="server" Text="Confirm Entry" 
            onclick="btnConfirm_Click" />
        <%}%>
        
         <%if (xconfirm != "0")
          { %>
        <br />
    <input id="btnPost" type="button" value="Test Post"  onclick="doPost('<%=txt_transID.Text %>','<%=xvalue %>','CLD/RA/0013','cbt','NOVASYS %26 LIMITED','meenese@yahoo.com','07062349262','<%=txt_product_title.Text %>','<%=selectPtType.SelectedValue %>');" /><br />
     <% } %>
    </div>
    </form>
</body>
</html>
