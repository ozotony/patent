<%@ page language="C#" autoeventwireup="true" CodeFile="multiple.cs" inherits="multiple" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       <asp:gridview ID="Gridview1" runat="server" ShowFooter="True" 
            AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" 
            ForeColor="#333333" GridLines="None">
           <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
        <asp:TemplateField HeaderText="Header 1">
            <ItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Header 2">
            <ItemTemplate>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Header 3">
            <ItemTemplate>
                 <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </ItemTemplate>
            <FooterStyle HorizontalAlign="Right" />
            <FooterTemplate>
             <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" 
                    onclick="ButtonAdd_Click" CssClass="button" />
            </FooterTemplate>
        </asp:TemplateField>
        </Columns>
           <EditRowStyle BackColor="#7C6F57" />
           <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
           <RowStyle BackColor="#E3EAEB" />
           <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
</asp:gridview>
    
        <br />
        ss1</div>
    </form>
</body>
</html>
