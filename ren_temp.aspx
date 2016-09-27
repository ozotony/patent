<%@ page language="C#" autoeventwireup="true"  CodeFile="ren_temp.cs" inherits="ren_temp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/funk.js" type="text/javascript"></script>

<script  type="text/javascript">
    function doPost(transID, amt, agt, xgt, applicantname, applicantemail, applicantpnumber, agentname, agentemail, agentpnumber, product_title, item_code) {
        postwith('./xindex_ren.aspx', { transID: transID, amt: amt, agt: agt, xgt: xgt, applicantname: applicantname, applicantemail: applicantemail, applicantpnumber: applicantpnumber, agentname: agentname, agentemail: agentemail, agentpnumber: agentpnumber, product_title: product_title, item_code: item_code });
    }   
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        Transaction ID:
        <br />
        <asp:TextBox ID="txt_transID" runat="server" Width="400px"></asp:TextBox>
        <br />
        <br />
        Product Title:
        <br />
        <asp:TextBox ID="txt_product_title" runat="server" Width="400px"></asp:TextBox>
        <br />
       <%if (xconfirm == "0")
           { %>
        <asp:Button ID="btnConfirm" runat="server" Text="Confirm Entry" 
            onclick="btnConfirm_Click" />
        <%}%>

          <%if (xconfirm != "0")
          { %>
    <input id="btnPost" type="button" value="Test Post"  onclick="doPost('<%=txt_transID.Text %>','10900','CLD/RA/0013','cbt','Einao Solutions','info@einaosolutions.com','08098887654','Maureen Esekhile','mesekhile@einaosolutions.com','07062349262','<%=txt_product_title.Text %>','P003');" /><br />
     <% } %>
    </div>
    </form>
</body>
</html>
