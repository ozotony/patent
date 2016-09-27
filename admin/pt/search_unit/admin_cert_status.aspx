<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_cert_status.aspx.cs" Inherits="admin_pt_search_unit_admin_cert_status" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
<link href="../../../css/style.css" rel="stylesheet" type="text/css" />
<script src="../../../js/jquery.js" type="text/javascript"></script>
<script src="../../../js/funk.js" type="text/javascript"></script>


    <style type="text/css">
        .style1
        {
            width: 197px;
            height: 75px;
        }
    p.MsoNormal
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:0in;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
    </style>


</head>
<body>
    <form id="form1" runat="server">
    <div>

    <div class="container">
    <div class="sidebar"></div>
       
        <div class="content">                
                     <div class="xmenu">
                     
                     </div>
                 
           
               <div id="searchform">
                <table align="center" width="100%" class="form" 
                     id="table1">
                    <tr align="center">
                <td colspan="2">
                    <img alt="Coat Of Arms" height="79" src="../../../images/coat_of_arms.png" 
                        width="85" />
               </td>
            </tr>
            <tr align="center" style=" font-size:10pt;" >
                <td colspan="2">
                   <strong> FEDERAL REPUBLIC OF NIGERIA<br />
                   PATENTS AND DESIGNS DECREE 1970 (1970 NO 60)<br />
                   PATENT FORM NO 5</strong>
</td>
            </tr>
                   
                    <tr>
                        <td width="100%" colspan="2" class="tbbg" >
                           
                        </td>
                    </tr>
                       <tr>
            <td width="100%"  colspan="2" >
                <p align="center" class="MsoNormal" style="text-align:center">
                    <b style="mso-bidi-font-weight:
normal"><span style="font-size:16.0pt;line-height:115%;font-family:&quot;Arial Unicode MS&quot;,&quot;sans-serif&quot;;
color:#E36C0A;mso-themecolor:accent6;mso-themeshade:191">CERTIFICATE OF RENEWAL  OF  PATENT<o:p></o:p></span></b>
                </p>
                           </td>
        </tr>
        
        <tr>
            <td width="50%" align="right">
                &nbsp;PAYMENT DATE :             </td>
            <td>
               
                <asp:Label ID="payment_date" runat="server" Text="None"></asp:Label>&nbsp;</td>
        </tr>
        
        <tr>
            <td align="right">
                TRANSACTION ID :
            </td>
                <td>
                  <asp:Label ID="transID" runat="server" Text="None"></asp:Label>
                    </td>
        </tr>
         <tr>
            <td colspan="2" class="tbbg">
                --- 
                PATENT APPLICATION INFORMATION --- </td>
        </tr>
        
        <tr>
            <td align="right">
                &nbsp;PATENT TYPE :</td>
                <td>
                 
                  <asp:Label ID="p_type" runat="server" Text="None"></asp:Label></td>
        </tr>
        
        <tr>
            <td align="right">
                ITEM CODE: </td>
                <td>
                  <asp:Label ID="p_item_code" runat="server" Text="None"></asp:Label>
                  </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;PATENT APPLICATION NUMBER :
            </td>
            <td>
                <asp:Label ID="p_app_no" runat="server" Text="None"></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                TITLE OF INVENTION :
                </td>
            <td>
               
                <asp:Label ID="p_title" runat="server" Text="None"></asp:Label>
                </td>
        </tr>
        
        <tr>
            <td align="right">
                FILING DATE :
                </td>
            <td>
               
                <asp:Label ID="p_app_date" runat="server" Text="None"></asp:Label>&nbsp;
                </td>
        </tr>  
      
        <tr>
            <td class="tbbg" colspan="2">
                --- APPLICANT INFORMATION ---</td>
        </tr>
      
        <tr>
            <td align="right">
                NAME :</td>
                <td>
               
                <asp:Label ID="p_xname" runat="server" Text="None"></asp:Label>
                   </td>
        </tr>
        
        <tr>
            <td align="right">
                ADDRESS :</td>
                <td>
               
                <asp:Label ID="p_xaddy" runat="server" Text="None"></asp:Label>
                    </td>
        </tr>
        
        <tr>
            <td align="right">
                PHONE NUMBER :
            </td>
                <td>
               
                <asp:Label ID="p_xmobile" runat="server" Text="None"></asp:Label>
                  </td>
        </tr>
        
        <tr>
            <td align="right">
                E-MAIL :</td>
                <td>
               
                <asp:Label ID="p_xemail" runat="server" Text="None"></asp:Label>
                   </td>
        </tr>
       

       <tr>
            <td class="tbbg" colspan="2">
                --- AGENT INFORMATION ---</td>
        </tr>
      
        <tr>
            <td align="right">
                NAME :</td>
                <td>
               
                <asp:Label ID="p_agt_name" runat="server" Text="None"></asp:Label>
                   </td>
        </tr>
        
        <tr>
            <td align="right">
                CODE: </td>
                <td>
                <asp:Label ID="p_agt_code" runat="server" Text="None"></asp:Label>
                </td>
        </tr>
        
        <tr>
            <td align="right">
                ADDRESS :</td>
                <td>
               
                <asp:Label ID="p_agt_addy" runat="server" Text="None"></asp:Label>
                    </td>
        </tr>
        
        <tr>
            <td align="right">
                PHONE NUMBER :
            </td>
                <td>
               
                <asp:Label ID="p_agt_mobile" runat="server" Text="None"></asp:Label>
                  </td>
        </tr>
        
        <tr>
            <td align="right">
                E-MAIL :</td>
                <td>
               
                <asp:Label ID="p_agt_email" runat="server" Text="None"></asp:Label>
                   </td>
        </tr>

        
        <tr>
            <td class="tbbg" colspan="2">
                --- RENEWAL INFORMATION ---</td>
        </tr>
      
    <tr>
            <td align="right">
                DUE DATE :</td>
                <td>
               
                <asp:Label ID="p_due_date" runat="server" Text="None"></asp:Label>
                   </td>
        </tr>
      
    <tr>
            <td align="right">
                NEXT RENEWAL DATE : </td>
                <td>
                <asp:Label ID="p_next_due_date" runat="server" Text="None"></asp:Label>
                    </td>
        </tr>
      
        <tr>
            <td class="tbbg" colspan="2" >
              
                &nbsp;</td>
        </tr>
                    <tr style="text-align:center;">
                        <td colspan="2">
                           <strong>
                               &nbsp;&nbsp; This is to certify that patent, as numbered above has been renewed for a further period of one year as from the due date,<br /> the payment of the requisite fee having been made. 
                            <br />
                          
                               
                                  <img alt="Signature" class="style1" src="../signatures/renewal.jpg" />
                         <%--   <img alt="Signature" class="style1" src="../signatures/aisha_acceptance_mini_png.png" />--%>
                               <%-- <img alt="Signature" class="style1" src="../signatures/sig.jpg" />--%>
                               <br />

                            CHINYERE AGBAI (DCR II )<br />
For: The Registrar of Patents and Designs<br />
</strong>

                        </td>
                    </tr>
                    <tr>
                        <td class="tbbg" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                   <%-- <tr>
                        <td align="center" colspan="2">
                           
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printAssessment('searchform');return false" class="button" />                        
                        </td>
                    </tr>--%>
                    <tr>
                        <td align="center" colspan="2" class="tbbg">
                           
                            &nbsp;</td>
                    </tr>
                </table>
               </div>

            <table>

                 <tr>
                        <td align="center" colspan="2">
                           
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printAssessment('searchform');return false" class="button" />                        
                        </td>
                    </tr>
            </table>
           
        </div>
     </div>   
    
    
</div>
    </form>
</body>
</html>

