<%@ page language="C#" autoeventwireup="true" CodeFile="n_renewal.cs" inherits="n_renewal" maintainscrollpositiononpostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RENEWAL APPLICATION</title>
<style type="text/css">
		.ProgressBar {
			margin: 0px;
			border: 0px;
			padding: 0px;
			width: 100%;
			height: 3em;
		}
		.style1
    {
        height: 25px;
    }
		</style>
<link href="css/style.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="css/jquery.ui.all.css" type="text/css"/>
<link rel="stylesheet" href="css/jquery.ui.theme.css" type="text/css"/>


<script src="js/jquery.js" type="text/javascript"></script>
<script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>

<script src="js/aj.js" type="text/javascript"></script>

<script src="js/ui/jquery.cookie.js" type="text/javascript"></script>
<script src="js/ui/jquery.ui.core.js" type="text/javascript"></script>
<script src="js/ui/jquery.ui.widget.js" type="text/javascript"></script>
<script src="js/ui/jquery.ui.datepicker.js" type="text/javascript"></script>
<script src="js/jquery.blockUI.js" type="text/javascript"></script>

<script  type="text/javascript">

    $(function () {

        $(".xdate").datepicker({
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
                    PATENTS AND DESIGNS DECREE 1970 (1970 NO 60)<br />
                    PATENT FORM NO 5<br />
                  
</td>
            </tr>
      </table>

      <table id="main" style="width:100%;font-family:Calibri;" id="applicantForm" align="center" >     
            <tr>
                <td colspan="2" style="font-size:18pt;line-height:115%;" align="center">
                        APPLICATION FOR ANNUAL RENEWAL OF A REGISTERED PATENT
                </td>
            </tr>
             <tr>
                <td colspan="2" class="tbbg_left">  
                     <input id="payment_date" type="hidden" runat="server"/>
                     <input id="hwalletID" type="hidden" runat="server"/>
                     <input id="transID" type="hidden" runat="server"/>
                     <input id="amt" type="hidden" runat="server"/>
                     <input id="serverpath" type="hidden" runat="server"/>
                     <input id="log_staffID" type="hidden" runat="server"/>

                    </td>
            </tr>
          
            <tr>
                <td style="width:30%;">
                    &nbsp;TITLE OF INVENTION:</td>
                <td style="width:70%;">
                    <input id="title" type="text" class="textbox" size="80" runat="server" readonly="true"/></td>
            </tr>
             <tr>
                <td >
                    &nbsp;ITEM CODE:</td>
                <td>
                    <input id="item_code" type="text" class="textbox" size="80" runat="server" readonly="true"/></td>
            </tr>
            
            <tr>
                <td>
                   &nbsp;PATENT TYPE: 
                    </td>
                <td>                    
                    <select id="type" name="type" class="textbox" runat="server">
                        <option value="Convention">Convention</option>
                        <option value="Non-Conventional">Non-Conventional</option>
                        <option value="PCT">PCT</option>
                    </select>
                    </td>
            </tr>
            
            <tr>
                <td>
                    &nbsp;PATENT APPLICATION NUMBER:</td>
                <td>
                    <input id="app_no" type="text" class="textbox" size="80" runat="server"/></td>
            </tr>
            
            <tr>
                <td>
                    &nbsp;NATIONAL FILING DATE:<br/>
                    <div style="color:#ff0000; background-color: #efefef; font-weight: bold;">
                    (For "PCT Annuities", Please enter the "International Filing Date")
                    </div>
                    </td>
                <td>
                    <input id="app_date" type="text" class="textbox xdate" size="10" runat="server" readonly="readonly"/> 
                    YYYY-MM-DD</td>
            </tr>
            
             <tr>
                <td colspan="2" style="background-color:#999999;">
                    &nbsp;APPLICANT INFORMATION </td>
            </tr>   
            
            <tr>
                <td>
                    NAME:</td>
                <td>
                    <input id="xname" type="text" class="textbox" size="80" runat="server" readonly="true"/></td>
            </tr>
            
            <tr>
                <td class="style1">
                    ADDRESS:</td>
                <td >
                  <textarea id="xaddy" cols="62" name="xaddy" rows="5" class="textbox" runat="server" ></textarea>
                                        </td>
            </tr>
            
            <tr>
                <td>
                    PHONE:</td>
                <td>
                    <input id="xmobile" type="text" class="textbox" size="80" runat="server" readonly="true"/></td>
            </tr>
            
            <tr>
                <td>
                    E-MAIL:</td>
                <td>
                    <input id="xemail" type="text" class="textbox" size="80" runat="server" readonly="true"/></td>
            </tr>
            
             <tr>
                <td colspan="2" style="background-color:#999999;">
                    &nbsp;AGENT INFORMATION</td>
            </tr>   
            
            <tr>
                <td>
                    NAME:</td>
                <td>
                    <input id="agt_name" type="text" class="textbox" size="80" runat="server" readonly="true"/></td>
            </tr>

             <tr>
                <td>
                    CODE:</td>
                <td>
                    <input id="agt_code" type="text" class="textbox" size="80" runat="server" readonly="true"/></td>
            </tr>

            <tr>
                <td class="style1">
                    ADDRESS:</td>
                <td >
                    <textarea id="agt_addy" cols="62" name="agt_addy" rows="5" class="textbox" runat="server" ></textarea></td>
            </tr>
            <tr>
                <td>
                    PHONE:</td>
                <td>
                    <input id="agt_mobile" type="text" class="textbox" size="80" runat="server" readonly="true"/></td>
            </tr>
            <tr>
                <td>
                    E-MAIL:</td>
                <td>
                    <input id="agt_email" type="text" class="textbox" size="80" runat="server" readonly="true"/></td>
            </tr>
            
            <tr>
                <td colspan="2" style="background-color:#999999;" >
                  </td>
            </tr> 
            
            <tr>
                <td>
                    LAST RENEWAL DATE:<br/> 
                 <div style="color:#ff0000; background-color: #efefef; font-weight: bold;">
                        (NOTE:For "PCT Annuities", If no annuities have been filed in Nigeria, Please enter the "Last Renewal Date" as the "International Filing Date")
                    </div>
                    </td>
                <td>
                    <input id="last_rwl_date" type="text" class="textbox xdate" size="10" runat="server" readonly="readonly"/>&nbsp; 
                    YYYY-MM-DD</td>
            </tr>
           
            <tr>
                <td colspan="2" style="background-color:#999999;" >
                   </td>
            </tr>
              <tr>
                <td colspan="2" style="text-align:center;">
                    <input id="btn_confirm" type="button" value="CONFIRM" class="button" onclick="doRenewalConfirm();return false;" /></td>
            </tr>   
            </table>


            <table id="confirm" style="width:100%;font-family:Calibri;display:none;" > 
              <tr  >
                <td colspan="2" style="background-color:#efefef;text-align:center;" >
                   <span style="font-size:18px; font-weight:bold;"> DETAILS FOR RENEWAL APPLICATION</span><br />                   
                    &nbsp;<br />
                    <br />
                    
                    <span style="font-size:16px; font-weight:bold;"> TITLE OF INVENTION:</span><br />
                     <div id="p_title"></div>
                    <br />

                    <span style="font-size:16px; font-weight:bold;"> ITEM CODE:</span><br />
                     <div id="p_item_code"></div>
                    <br />
                    
                     <span style="font-size:16px; font-weight:bold;">PATENT TYPE:</span> 
                     <div id="p_type"></div>
                    <br />
                     <span style="font-size:16px; font-weight:bold;">PATENT APPLICATION NUMBER:</span><br />
                     <div id="p_app_no"></div>
                    <br />
                    
                     <span style="font-size:16px; font-weight:bold;">FILING DATE:</span><br />
                     <div id="p_app_date"></div>
                    <br />
                    
                     <span style="font-size:16px; font-weight:bold;">APPLICANT NAME:</span><br />
                     <div id="p_xname"></div>
                    <br />
                   
                     <span style="font-size:16px; font-weight:bold;">APPLICANT ADDRESS:</span><br />
                     <div id="p_xaddy"></div>
                    <br />
                    
                     <span style="font-size:16px; font-weight:bold;">APPLICANT MOBILE:</span><br />
                     <div id="p_xmobile"></div>
                    <br />
                   
                     <span style="font-size:16px; font-weight:bold;">APPLICANT E-MAIL:</span><br />
                     <div id="p_xemail"></div>
                    <br />
                    
                     <span style="font-size:16px; font-weight:bold;">AGENT NAME:</span><br />
                     <div id="p_agt_name"></div>
                    <br />
                     <span style="font-size:16px; font-weight:bold;">AGENT CODE:</span><br />
                     <div id="p_agt_code"></div>
                    <br />

                    <span style="font-size:16px; font-weight:bold;"> AGENT ADDRESS:</span><br />
                     <div id="p_agt_addy"></div>
                    <br />
                   
                     <span style="font-size:16px; font-weight:bold;">AGENT MOBILE:</span><br />
                     <div id="p_agt_mobile"></div>
                    <br />
                      <span style="font-size:16px; font-weight:bold;">AGENT E-MAIL:</span><br />
                     <div id="p_agt_email"></div>
                    <br />
                   
                     <span style="font-size:16px; font-weight:bold;">LAST RENEWAL DATE:</span><br />
                     <div id="p_last_rwl_date"></div>
                    <br />
                    <input id="btn_submit" type="button" value="SUBMIT" class="button" onclick="addRenewal();return false;" /><input id="btn_edit" type="button" value="EDIT" class="button" onclick="doRenewalEdit();return false;" /><br />
                   </td>
            </tr>  
            </table>
            
    
                    </td>
    </tr>
    </table>
    </form>
</body>
</html>
