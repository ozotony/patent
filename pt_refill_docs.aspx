<%@ page language="C#" autoeventwireup="true" CodeFile="pt_refill_docs.cs" inherits="pt_refill_docs" maintainscrollpositiononpostback="true" %>

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
        <table style="width:100%;font-family:Calibri;" id="applicantForm" align="center" class="form">
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
                    PATENTS AND DESIGNS DECREE NO 60 OF 1970
</td>
            </tr>
           
           <tr>
           <td colspan="3">                       
            <table style="width:100%;font-family:Calibri;" id="doc_tbl" align="center">
            <tr>
                    <td class="tbbg" colspan="4">                       
                        PLEASE ENTER THE NUMBER OF PAGES OF EACH ITEM ACCOMPANYING THIS FORM AND ATTACH 
                        DOCUMENTS BELOW :</td>
                </tr>
              
                <tr>
                    <td align="center" colspan="4" style="color:Red; font-size:16px;">
                       <strong>
                        (NOTE: DOCUMENTS ATTACHED SHOULD BE OF 
                        JPEG/PDF/PNG TYPE FORMATS ONLY AND NOT MORE THAN 3MB EACH!!)</strong> </td>
                </tr>
                <tr style="background-color:#999999;">
                    <td align="left" class="tbbg_left2" style="width:25%;">
                        &nbsp;ITEMS</td>
                    <td align="left" class="tbbg_left2" style="width:10%;">
                        NUMBER</td>
                    <td align="left" class="tbbg_left2" style="width:45%;">
                        ATTACH DOCUMENT</td>
                    <td align="left" class="tbbg_left2" style="width:20%;">
                        DOCUMENT PREVIOUSLY ATTACHED</td>
                </tr>
                <%if (loa_newfilename == "0")
                  { %>
                <tr>
                    <td align="left">
                        &nbsp;LETTER OF AUTHORIZATION OF AGENT(FORM 2) :
                    </td>
                    <td align="left">
                       <asp:TextBox ID="txt_loa_no" runat="server" Width="40px" CssClass="textbox"></asp:TextBox>
                        </td>
                    <td align="left" >
                          <Upload:InputFile ID="fu_loa_doc" runat="server"  CssClass="textbox"/>
                         <asp:RegularExpressionValidator id="RegularExpressionLoa" 
				ControlToValidate="fu_loa_doc"
				ValidationExpression="(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png); *)*(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF PDF/JPEG/PNG!!"
				EnableClientScript="True"  runat="server"/>
                         </td>                       
                    <td align="left" >
                         <%if (loa_doc != "") { Response.Write("<a href='" + loa_doc + "' target='blank'>View</a>"); } else { Response.Write("No Document Attached"); } %> </td>                       
                </tr>               
                
                <tr>
                    <td colspan="4" align="center">
                     
                    </td>
                </tr>
                 <%} %>
                 <%if (claim_newfilename == "0")
                  { %>
                <tr>
                    <td align="left">
                        &nbsp;CLAIM(S) :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txt_claim_no" runat="server" Width="40px" 
                            CssClass="textbox"></asp:TextBox>
                        </td>
                    <td align="left">
                        <Upload:InputFile ID="fu_claim_doc" runat="server" CssClass="textbox" />
                         <asp:RegularExpressionValidator id="RegularExpressionClaim" 
				ControlToValidate="fu_claim_doc"
				ValidationExpression="(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png); *)*(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF PDF/JPEG/PNG!!"
				EnableClientScript="True"  runat="server"/>
                    </td>
                    <td align="left">
                        <%if (claim_doc != "") { Response.Write("<a href='" + claim_doc + "' target='blank'>View</a>"); } else { Response.Write("No Document Attached"); } %></td>
                </tr>
               
                <tr>
                    <td colspan="4"></td>
                </tr>
                <%} %>

                <% if((pc.ToLower() == "convention")||(pc.ToLower() == "conventional"))
                   {
                       if (pct_newfilename == "0")
                  { %>
                <tr>
                    <td align="left">
                        &nbsp;PCT DOCUMENT:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txt_pct_no" 
                            runat="server" Width="40px" 
                            CssClass="textbox"></asp:TextBox>
                        </td>
                    <td align="left">
                        <Upload:InputFile ID="fu_pct_doc" runat="server" CssClass="textbox" />
                         <asp:RegularExpressionValidator id="RegularExpressionPct" 
				ControlToValidate="fu_pct_doc"
				ValidationExpression="(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png); *)*(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF PDF/JPEG/PNG"
				EnableClientScript="True"  runat="server"/>
                    </td>
                    <td align="left">
                         <%if (pct_doc != "") { Response.Write("<a href='" + pct_doc + "' target='blank'>View</a>"); } else { Response.Write("No Document Attached"); } %> </td>
                </tr>
                
                 <tr>
                    <td colspan="4"></td>
                </tr>
                <%} %>
                 <%if (doa_newfilename == "0")
                  { %>
                <tr>
                    <td align="left">
                        &nbsp;DEED OF ASSIGNMENT:
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txt_doa_no" runat="server" Width="40px" 
                            CssClass="textbox"></asp:TextBox>
                        </td>
                    <td align="left">
                        <Upload:InputFile ID="fu_doa_doc" runat="server" CssClass="textbox" />
                         <asp:RegularExpressionValidator id="RegularExpressionDoa" 
				ControlToValidate="fu_doa_doc"
				ValidationExpression="(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png); *)*(([^.;]*[.])+(pdf|PDF|JPEG|JPG|jpg|jpeg|PNG|png))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF PDF/JPEG/PNG!!"
				EnableClientScript="True"  runat="server"/>
                    </td>
                    <td align="left">
                       <%if (doa_doc != "") { Response.Write("<a href='" + doa_doc + "' target='blank'>View</a>"); } else { Response.Write("No Document Attached"); } %></td>
                </tr>
               

                 <tr>
                    <td colspan="4"></td>
                </tr>
                <%}
                  }%>
                <%if (spec_newfilename == "0")
                  { %>
                <tr>
                    <td align="left">
                        &nbsp;COMPLETE SPECIFICATION (FORM 3):</td>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left">
                        <Upload:InputFile ID="fu_spec_doc" runat="server" CssClass="textbox" />
                         <asp:RegularExpressionValidator id="RegularExpressionSpec" 
				ControlToValidate="fu_spec_doc"
				ValidationExpression="(([^.;]*[.])+(pdf|PDF); *)*(([^.;]*[.])+(pdf|PDF))?$"
				Display="Static"
				ErrorMessage="DOCUMENTS ATTACHED SHOULD BE OF PDF!!"
				EnableClientScript="True"  runat="server"/>
                    </td>
                    <td align="left">
                         <%if (spec_doc != "") { Response.Write("<a href='" + spec_doc + "' target='blank'>View</a>"); } else { Response.Write("No Document Attached"); } %> </td>
                </tr>
                <%} %>
                <tr>
                    <td colspan="4" align="center">
                          <Upload:ProgressBar id="pb_all_doc" runat="server" inline="true" Text="" /></td>
                </tr>


                <tr>
                    <td align="center" colspan="4">
                    <%if (ack_status == "0")
                      { %>
                          <asp:Button ID="btn_all_doc" runat="server" Text="Upload Documents"  
                            CssClass="button"/> 
                            <% } %> 
                                  
                        <input id="btnPrintAck" type="button" value="Print Acknowledgement Slip" class="button" onclick="doView('./tm_acknowledgement.aspx?0001234445XXX43943OPFDSMZXUHSJFDSKFGKSDKGFSDKFSKFDKFD=<%=vid %>')" />
                    <asp:Button ID="btnDashBoard" runat="server" Text="Back to Dashboard"  
                            CssClass="button" onclick="btnDashBoard_Click"/>
                         </td>
                </tr>
                </table>
           
            </td>
            </tr>
            </table>
            
    
    </div>
    </td>
    </tr>
    </table>
    </form>
</body>
</html>
