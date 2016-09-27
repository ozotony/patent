<%@ page language="C#" autoeventwireup="true" CodeFile="application.cs" inherits="application" maintainscrollpositiononpostback="true" %>

<%@ Register assembly="Brettle.Web.NeatUpload" namespace="Brettle.Web.NeatUpload" tagprefix="Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PATENT APPLICATION</title>
<style type="text/css">
		.ProgressBar {
			margin: 0px;
			border: 0px;
			padding: 0px;
			width: 100%;
			height: 3em;
		}
		</style>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="css/jquery.ui.all.css" type="text/css"/>
<link rel="stylesheet" href="css/jquery.ui.theme.css" type="text/css"/>

<script src="js/funk.js" type="text/javascript"></script>
<script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
<script src="js/jquery.js" type="text/javascript"></script>
<script src="js/ui/jquery.cookie.js" type="text/javascript"></script>
<script src="js/ui/jquery.ui.core.js" type="text/javascript"></script>
<script src="js/ui/jquery.ui.widget.js" type="text/javascript"></script>

<script src="js/ui/jquery.ui.datepicker.js" type="text/javascript"></script>

<script language="javascript" type="text/javascript">

    $(function () {

        $(".txt_date_pri").datepicker({
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true,
            dateFormat: 'yy-mm-dd',
            yearRange: 'c-100:c+0'
        });
        
    });
</script>
</head>
<body>
    <form id="form1" runat="server">
    <table align="center" width="1200px">
            <tr >
                <td >
    <div id="searchform">                
        <table style="width:100%;font-family:Calibri;" id="applicantForm" align="center" class="form" >
            <tr align="center">
                <td colspan="2">
                    <img alt="Coat Of Arms" height="79" src="images/coat_of_arms.png" 
                        width="85" />
               </td>
            </tr>
            <tr align="center" style=" font-size:11pt;" >
                <td colspan="2">
                    FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY<br />
                    PATENTS AND DESIGNS ACT CAP 344 LFN 1990 
</td>
            </tr>
            
            <tr>
                <td colspan="2" style="font-size:18pt;line-height:115%;" align="center">
                        APPLICATION FOR GRANT OF PATENT
                </td>
            </tr>
            <tr>
                <td colspan="2">
                      <asp:SqlDataSource ID="ds_Nationality" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT * FROM [country]">                  
                    </asp:SqlDataSource></td>
            </tr>
            <tr>
                <td width="20%">
                    &nbsp;APPLICATION TYPE:</td>
                <td>        
                        <asp:Label ID="lbl_type" runat="server" Text="" Font-Bold="true"></asp:Label>
        </td>
            </tr>
            <tr>
                <td colspan="2" class="tbbg_left">
                    &nbsp;APPLICANT INFORMATION >></td>
            </tr>
            
            <tr>
                <td colspan="2">
                    <asp:gridview ID="gv_app" runat="server" ShowFooter="True" 
            AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" 
            ForeColor="#333333" GridLines="None" Width="100%">
           <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:BoundField DataField="RowNumber_app" HeaderText="S/N"  HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Left">     
            </asp:BoundField>       
          <asp:TemplateField HeaderText="Information" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
             NAME: <br />
                 <asp:TextBox ID="txt_name_app" runat="server" class="textbox" Width="400px"></asp:TextBox><br />
                 ADDRESS:<br />
                  <asp:TextBox ID="txt_address_app" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px" TextMode="MultiLine"></asp:TextBox> <br />              
            E-MAIL: <br />
                 <asp:TextBox ID="txt_email_app" runat="server" class="textbox" Width="400px"></asp:TextBox><br />
                  PHONE NO: <br />
                 <asp:TextBox ID="txt_mobile_app" runat="server" class="textbox" Width="400px"></asp:TextBox><br />
                 NATIONALITY:<br />
                 <asp:DropDownList ID="select_app_nationality" runat="server" CssClass="textbox" DataSourceID="ds_Nationality" DataTextField="name" 
                    DataValueField="ID" >
                </asp:DropDownList>
            </ItemTemplate>
             <FooterStyle HorizontalAlign="Right" />
            <FooterTemplate>
            Add Applicant
             <asp:Button ID="ButtonAddApp" runat="server" Text="" 
                    onclick="ButtonAddApp_Click" CssClass="plus_button" />
            </FooterTemplate>
        </asp:TemplateField>
        </Columns>
           <EditRowStyle BackColor="#7C6F57" />
           <FooterStyle Font-Bold="True" ForeColor="#006699" />
           <HeaderStyle BackColor="#999999" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
           <RowStyle BackColor="#E3EAEB" />
           <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
</asp:gridview></td>
            </tr>
           
            <tr>
                <td colspan="2" class="tbbg_left">
                    &nbsp;PATENT INFORMATON >></td>
            </tr>
            <tr>
                <td >
                    &nbsp;TITLE OF INVENTION:</td>
                <td>
                    <asp:TextBox ID="txt_title_of_invention" runat="server" class="textbox" Width="400px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>
                   &nbsp;BRIEF DESCRIPTION OF PATENT:<br />
                    &nbsp;(NOT MORE THAN 500 WORDS)
                    </td>
                <td>
                    <asp:TextBox ID="txt_pt_desc" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px" TextMode="MultiLine" MaxLength="500"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="sub_header" align="left">
                    &nbsp;TRUE INVENTOR INFORMATION >></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:gridview ID="gv_inv" runat="server" ShowFooter="True" 
            AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" 
            ForeColor="#333333" GridLines="None" Width="100%">
           <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:BoundField DataField="RowNumber_inv" HeaderText="S/N"  HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="Left"/>        
       
          <asp:TemplateField HeaderText="Information" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
            NAME: <br />
                 <asp:TextBox ID="txt_name_inv" runat="server" class="textbox" Width="400px"></asp:TextBox><br />
                  ADDRESS:<br />
                 <asp:TextBox ID="txt_address_inv" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px" TextMode="MultiLine"></asp:TextBox> <br />
                     E-MAIL: <br />
                 <asp:TextBox ID="txt_email_inv" runat="server" class="textbox" Width="400px"></asp:TextBox><br />
                 PHONE NO: <br />
                 <asp:TextBox ID="txt_mobile_inv" runat="server" class="textbox" Width="400px"></asp:TextBox><br />
                 NATIONALITY:<br />
                 <asp:DropDownList ID="select_inv_nationality" runat="server" CssClass="textbox" DataSourceID="ds_Nationality" DataTextField="name" 
                    DataValueField="ID" >
                    </asp:DropDownList>
            </ItemTemplate>
             <FooterStyle HorizontalAlign="Right" />
            <FooterTemplate>
            Add Inventor
             <asp:Button ID="ButtonAddInv" runat="server" Text="" 
                    onclick="ButtonAddInv_Click" CssClass="plus_button" />
            </FooterTemplate>
        </asp:TemplateField>
        </Columns>
           <EditRowStyle BackColor="#7C6F57" />
           <FooterStyle BackColor="" Font-Bold="True" ForeColor="#006699" />
           <HeaderStyle BackColor="#999999" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
           <RowStyle BackColor="#E3EAEB" />
           <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
</asp:gridview></td>
            </tr>
            <tr>
                <td colspan="2" class="tbbg_left">
                    &nbsp;ASSIGNMENT INFORMATION (if any) >></td>
            </tr>
             <tr>
                <td>
                    &nbsp;DATE OF ASSIGNMENT:</td>
                <td><asp:TextBox ID="txt_assignment_date" runat="server" Width="70px" CssClass="txt_date_pri" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="background-color:#999999;" align="left">
                    &nbsp;ASSIGNEE</td>
            </tr>
            <tr>
                <td>
                    &nbsp;NAME:</td>
                <td>
                    <asp:TextBox ID="txt_assignee_name" runat="server" class="textbox" 
                        Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;ADDRESS:</td>
                <td>
                <asp:TextBox ID="txt_assignee_address" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px" TextMode="MultiLine"></asp:TextBox>               
                </td>
            </tr>
            <tr>
            <td align="left">
                &nbsp;NATIONALITY :
            </td>
            <td align="left" >
                <asp:DropDownList ID="select_assignee_nationality" runat="server" CssClass="textbox" DataSourceID="ds_Nationality" DataTextField="name" 
                    DataValueField="ID" >
                </asp:DropDownList>
              
                     </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" style="background-color:#999999;" align="left">
                    &nbsp;ASSIGNOR</td>
            </tr>
            <tr>
                <td>
                    &nbsp;NAME:</td>
                <td>
                    <asp:TextBox ID="txt_assignor_name" runat="server" class="textbox" 
                        Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;ADDRESS:</td>
                <td>
                <asp:TextBox ID="txt_assignor_address" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px" TextMode="MultiLine"></asp:TextBox>               
                </td>
            </tr>
             <tr>
            <td align="left">
                &nbsp;NATIONALITY :
            </td>
            <td align="left" >
                <asp:DropDownList ID="select_assignor_nationality" runat="server" CssClass="textbox" DataSourceID="ds_Nationality" DataTextField="name" 
                    DataValueField="ID" >
                </asp:DropDownList>
                
                     </td>
            </tr>
            <tr>
                <td colspan="2" class="tbbg_left">
                    &nbsp;PRIORITY INFORMATION [applicable to foreign applications(convention-patent) ONLY] >></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:gridview ID="gv_pri" runat="server" ShowFooter="True" 
            AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True" 
            ForeColor="#333333" GridLines="None" Width="100%">
           <AlternatingRowStyle BackColor="White" />
           
        <Columns>
        <asp:BoundField DataField="RowNumber_pri" HeaderText="S/N"  HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Left"/>        
        <asp:TemplateField HeaderText="COUNTRY" HeaderStyle-Width="35%" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                 <asp:DropDownList ID="select_country_pri" runat="server" CssClass="textbox" DataSourceID="ds_Nationality" DataTextField="name"   DataValueField="ID"  >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_Nationality" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    SelectCommand="SELECT * FROM [country]"></asp:SqlDataSource>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="APPLICATION NUMBER" HeaderStyle-Width="35%" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:TextBox ID="txt_application_no_pri" runat="server" class="textbox" Width="200px"></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
          <asp:TemplateField HeaderText="DATE" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>           
                       <asp:TextBox ID="txt_date_pri" runat="server" Width="70px" CssClass="txt_date_pri" ></asp:TextBox>
            </ItemTemplate>
             <FooterStyle HorizontalAlign="Right" />
            <FooterTemplate>             
             <asp:Button ID="ButtonAddPri" runat="server" Text="" 
                    onclick="ButtonAddPri_Click" CssClass="plus_button" Visible="false" />
            </FooterTemplate>
        </asp:TemplateField>
        </Columns>
           <EditRowStyle BackColor="#7C6F57" />
           <FooterStyle BackColor="" Font-Bold="True" ForeColor="#006699" />
           <HeaderStyle BackColor="#999999" Font-Bold="True" ForeColor="White"/>
           <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
           <RowStyle BackColor="#E3EAEB" />
           <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
</asp:gridview></td>
            </tr>
            <tr>
                <td colspan="2" class="tbbg_left">
                   &nbsp;ADDRESS OF SERVICE IN NIGERIA >></td>
            </tr>
            <tr>
            <td>
                &nbsp;&nbsp;AGENT CODE:             </td>
            <td >
                <asp:TextBox ID="rep_code" runat="server" Width="400px" 
                    CssClass="textbox" ReadOnly="True"></asp:TextBox>
                                
                                   
                </td>
            </tr>
            <tr>
            <td align="left">
                &nbsp;&nbsp;NAME :
            </td>
            <td align="left" >
                <asp:TextBox ID="rep_xname" runat="server" Width="400px" CssClass="textbox" ReadOnly="True"></asp:TextBox>               
            </td>
            </tr>
            <tr>
            <td align="left">
                &nbsp;&nbsp;NATIONALITY :
            </td>
            <td align="left" >
                NIGERIA                 
                     </td>
            </tr>
            <tr>
            <td colspan="2" style="background-color:#999999;">
                &nbsp;ADDRESS INFORMATION >></td>
            </tr>
            <tr>
            <td >
                &nbsp;&nbsp;COUNTRY :
            </td>
            <td >
                NIGERIA             
           </td>
            </tr>
            <tr>
            <td >
                &nbsp;&nbsp;STATE:             </td>
                  
            <td >
               
                <asp:DropDownList ID="select_rep_state" runat="server" CssClass="textbox" 
                    DataSourceID="ds_RepState" DataTextField="name" DataValueField="ID" >
                </asp:DropDownList>
                <asp:SqlDataSource ID="ds_RepState" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:cldConnectionString %>" 
                    
                    SelectCommand="SELECT DISTINCT ID, name, countryID FROM state WHERE (countryID = 160)">
                    
                </asp:SqlDataSource>                 
                           
                            
            </td>
            </tr>
            <tr>
            <td >
                &nbsp;&nbsp;ADDRESS :
            </td>
            <td >
                <asp:TextBox ID="txt_rep_address" runat="server" Width="400px" CssClass="textbox" 
                    Height="80px" TextMode="MultiLine"></asp:TextBox>               
            </td>
            </tr>
            <tr>
            <td>
              &nbsp;&nbsp;TELEPHONE: &nbsp;</td>
            <td >
            <asp:TextBox ID="txt_rep_telephone" runat="server" Width="200px" CssClass="textbox" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td>
                &nbsp;&nbsp;E-MAIL:
                </td>
            <td >
            <asp:TextBox ID="txt_rep_email" runat="server" Width="200px" CssClass="textbox" ReadOnly="True" ></asp:TextBox>
                   </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
            
                    <table id="doc_tbl" align="center" style="width:100%;font-family:Calibri;">
                        <tr>
                            <td class="tbbg" colspan="3">PLEASE ENTER THE NUMBER OF PAGES OF EACH ITEM ACCOMPANYING THIS FORM AND ATTACH DOCUMENTS BELOW :</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="color:Red; font-size:16px;"><strong>(NOTE: DOCUMENTS ATTACHED SHOULD BE OF PDF FORMAT ONLY AND NOT MORE THAN 3MB EACH!!)</strong> </td>
                        </tr>
                        <tr style="background-color:#999999;">
                            <td align="left" class="tbbg_left2" style="width:25%;">&nbsp;ITEMS</td>
                            <td align="left" class="tbbg_left2" style="width:10%;">NUMBER</td>
                            <td align="left" class="tbbg_left2" style="width:65%;">ATTACH DOCUMENT</td>
                        </tr>
                <%if (loa_newfilename == "0")
                  { %>
                        <tr>
                            <td align="left">&nbsp;LETTER OF AUTHORIZATION OF AGENT(FORM 2) : </td>
                            <td align="left">
                                <asp:TextBox ID="txt_loa_no" runat="server" CssClass="textbox" Width="40px"></asp:TextBox>
                            </td>
                            <td align="left">
                                <Upload:InputFile ID="fu_loa_doc" runat="server" CssClass="textbox" />
                                <asp:RegularExpressionValidator ID="RegularExpressionLoa" runat="server" ControlToValidate="fu_loa_doc" Display="Static" EnableClientScript="True" ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF PDF/JPEG/PNG!!" ValidationExpression="(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png); *)*(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png))?$" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3"></td>
                        </tr>
                 <%} %>
                 <%if (claim_newfilename == "0")
                  { %>
                        <tr>
                            <td align="left">&nbsp;CLAIM(S) : </td>
                            <td align="left">
                                <asp:TextBox ID="txt_claim_no" runat="server" CssClass="textbox" Width="40px"></asp:TextBox>
                            </td>
                            <td align="left">
                                <Upload:InputFile ID="fu_claim_doc" runat="server" CssClass="textbox" />
                                <asp:RegularExpressionValidator ID="RegularExpressionClaim" runat="server" ControlToValidate="fu_claim_doc" Display="Static" EnableClientScript="True" ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF PDF/JPEG/PNG!!" ValidationExpression="(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png); *)*(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png))?$" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3"></td>
                        </tr>
                <%} %>
                <%if (pc == "P001")
                  {
                      if (pct_newfilename == "0")
                      { %>
                        <tr>
                            <td align="left">&nbsp;PCT DOCUMENT: </td>
                            <td align="left">
                                <asp:TextBox ID="txt_pct_no" runat="server" CssClass="textbox" Width="40px"></asp:TextBox>
                            </td>
                            <td align="left">
                                <Upload:InputFile ID="fu_pct_doc" runat="server" CssClass="textbox" />
                                <asp:RegularExpressionValidator ID="RegularExpressionPct" runat="server" ControlToValidate="fu_pct_doc" Display="Static" EnableClientScript="True" ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF PDF/JPEG/PNG" ValidationExpression="(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png); *)*(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png))?$" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3"></td>
                        </tr>
                <%} %>
                 <%if (doa_newfilename == "0")
                   { %>
                        <tr>
                            <td align="left">&nbsp;DEED OF ASSIGNMENT: </td>
                            <td align="left">
                                <asp:TextBox ID="txt_doa_no" runat="server" CssClass="textbox" Width="40px"></asp:TextBox>
                            </td>
                            <td align="left">
                                <Upload:InputFile ID="fu_doa_doc" runat="server" CssClass="textbox" />
                                <asp:RegularExpressionValidator ID="RegularExpressionDoa" runat="server" ControlToValidate="fu_doa_doc" Display="Static" EnableClientScript="True" ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF PDF/JPEG/PNG!!" ValidationExpression="(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png); *)*(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png))?$" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3"></td>
                        </tr>
                <%}
                  }%>
                <%if (spec_newfilename == "0")
                  { %>
                        <tr>
                            <td align="left">&nbsp;COMPLETE SPECIFICATION (FORM 3):</td>
                            <td align="left">&nbsp;</td>
                            <td align="left">
                                <Upload:InputFile ID="fu_spec_doc" runat="server" CssClass="textbox" />
                                <asp:RegularExpressionValidator ID="RegularExpressionSpec" runat="server" ControlToValidate="fu_spec_doc" Display="Static" EnableClientScript="True" ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF PDF!!" ValidationExpression="(([^.;]*[.])+(pdf|PDF); *)*(([^.;]*[.])+(pdf|PDF))?$" />
                            </td>
                        </tr>
                <%} %>
                        <tr>
                            <td align="center" colspan="3">
                                <Upload:ProgressBar ID="pb_all_doc" runat="server" inline="true" Text="" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">&nbsp;</td>
                            <td align="left">&nbsp;</td>
                            <td align="left">
                    <%if (ack_status == "0")
                      { %>
                               <asp:Button ID="SaveAll" runat="server" Text="Submit"  class="button" onclick="SaveAll_Click" />
                            <% }
                      else
                      { %>
                            <%} %>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>           
                     
            <tr style="background-color:#999999;">
                <td colspan="2" align="center">
            
                    &nbsp;</td>
            </tr>           
                  
            </table>
            
    
    </div>
    </td>
    </tr>
    </table>
    </form>
</body>
</html>
