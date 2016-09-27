<%@ page language="C#" autoeventwireup="true" CodeFile="ren_ack.cs" inherits="ren_ack" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ACKNOWLEDGEMENT SLIP</title>
   

<link href="css/print_style.css" rel="stylesheet" type="text/css" />

<script src="js/jquery.js" type="text/javascript"></script>

<script src="js/funk.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       
            <div id="searchform">
    <table align="center" width="1000px" class="form" >    
        <tr>
            <td colspan="2" align="center" >
             <img alt="Coat Of Arms" height="79" src="images/coat_of_arms.png" 
                        width="85" /><br />
                    FEDERAL REPUBLIC OF NIGERIA<br />                      
                    PATENTS AND DESIGNS DECREE 1970 (1970 NO 60)<br />
                    PATENT FORM NO 5<br />
                   <div style="font-size:20px;">
                   <strong> RENEWAL ACKNOWLEDGMENT FORM</strong>
                   </div> 
            </td>
        </tr>      
        
       
        <tr>
            <td width="100%" align="right" colspan="2" class="tbbg">
                --- PAYMENT INFORMATION ---</td>
        </tr>
        
        <tr>
            <td width="50%" align="right">
                &nbsp;FILING DATE :             </td>
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
                NATIONAL FILING DATE :
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
                LAST RENEWAL DATE :</td>
                <td>
               
                <asp:Label ID="p_last_rwl_date" runat="server" Text="None"></asp:Label>
                   </td>
        </tr>
      
    <tr>
            <td align="right">
                RENEWAL DUE DATE :</td>
                <td>
               
                <asp:Label ID="p_due_date" runat="server" Text="None"></asp:Label>
                   </td>
        </tr>
      
        <tr>
            <td class="tbbg" colspan="2" style="color: #fff; background-color: #006600; text-align: center; font-weight: bold;">
              
                &nbsp;</td>
        </tr>
        <tr>
            <td  align="center" colspan="2">
              
             <strong>YOUR APPLICATION HAS BEEN RECEIVED</strong><br />
             <strong>Registrar of Patents and Designs 
                <br />
               Patents Branch
               
                </strong></td>
        </tr>
        
         
    </table>
        </div>
        <table style="float:left;width:100%;">
        <tr>
        <td align="left" width="100%">       
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printHomePtCert('searchform');" class="button" /> 
                                <asp:Button ID="btnDashboard" runat="server" 
    Text="Back to Dashboard" class="button" onclick="btnDashboard_Click"/>
                
                
                
                </td>
        </tr>
        </table>
      
</div>
    </form>
</body>
</html>
