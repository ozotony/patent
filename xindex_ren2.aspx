<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xindex_ren2.aspx.cs" Inherits="xindex_ren2" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

    <title>
PATENT APPLICATION NOTICE
</title>
  <link href="css/style.css" rel="stylesheet" type="text/css" />

<script src="js/jquery.js" type="text/javascript"></script>

<script src="js/aj.js" type="text/javascript"></script>

    <link rel="stylesheet" href="css/jquery.ui.all.css" type="text/css"/>
<link rel="stylesheet" href="css/jquery.ui.theme.css" type="text/css"/>

<script src="js/aj.js" type="text/javascript"></script>

<script src="js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="js/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>

<script src="js/ui/jquery.cookie.js" type="text/javascript"></script>
<script src="js/ui/jquery.ui.core.js" type="text/javascript"></script>
<script src="js/ui/jquery.ui.widget.js" type="text/javascript"></script>
<script src="js/ui/jquery.ui.datepicker.js" type="text/javascript"></script>
<script src="js/jquery.blockUI.js" type="text/javascript"></script>
<link href="css/print_style.css" rel="stylesheet" type="text/css" />



<script src="js/funk.js" type="text/javascript"></script>

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

    
    <script  type="text/javascript">

        function doProceed() {
            postwith('./n_renewal.aspx', { transID: '<%=transID %>', amt: '<%=amt %>', agt: '<%=agt %>', xgt: '<%=xgt %>', applicantname: '<%=applicantname %>', applicantemail: '<%=applicantemail  %>', applicantpnumber: '<%=applicantpnumber %>', agentname: '<%=agentname %>', agentemail: '<%=agentemail  %>', agentpnumber: '<%=agentpnumber %>', payment_date: '<%=payment_date  %>', product_title: '<%=product_title %>', item_code: '<%=item_code %>', serverpath: '<%=serverpath %>' });
        }
    </script>

    <style type="text/css">

 p.MsoNormal
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:0in;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
p.MsoListParagraphCxSpFirst
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:0in;
	margin-left:.5in;
	margin-bottom:.0001pt;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
p.MsoListParagraphCxSpMiddle
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:0in;
	margin-left:.5in;
	margin-bottom:.0001pt;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
p.MsoListParagraphCxSpLast
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:.5in;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
    </style>

</head>
<body>
    <form id="form1" runat="server">
  

<div>
      <asp:Panel runat="server" ID="tt"> 
           <table align="center" width="1200px" class="form">
        <tr>
            <td align="center" >
             <img alt="Coat Of Arms" height="79" src="images/coat_of_arms.png" 
                        width="85" /><br />
              FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY<br />
                    PATENTS AND DESIGNS ACT CAP 344 LFN 1990                 
            </td>
        </tr>
       
        
        <tr>
            <td width="22%" align="center" bgcolor="#006699">
                &nbsp;</td>
        </tr>
        
        
        <tr>
            <td width="22%" align="center">
                <strong>&nbsp;APPLICATION PROCESS NOTICE</strong> </td>
        </tr>
        
        
        <tr>
            <td width="50%" align="left">
               
                <br />
                <p align="center" class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;
text-align:center;line-height:normal">
                    <b style="mso-bidi-font-weight:normal">
                    <span lang="EN-GB" style="font-size:16.0pt;mso-bidi-font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB">WELCOME TO THE 
                    &quot;PATENT RENEWAL APPLICATION SECTION&quot;</span></b></p>
                <p align="center" class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;
text-align:center;line-height:normal">
                    <b style="mso-bidi-font-weight:
normal"><span lang="EN-GB" style="font-size:60.0pt;mso-bidi-font-size:12.0pt;
font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
mso-fareast-language:EN-GB">PAS</span></b><b style="mso-bidi-font-weight:normal"><span lang="EN-GB" style="font-size:16.0pt;mso-bidi-font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB"><o:p></o:p></span></b></p>
                <p align="center" class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;
text-align:center;line-height:normal">
                    <span lang="EN-GB" style="font-size:20.0pt;
mso-bidi-font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:
&quot;Times New Roman&quot;;color:red;mso-fareast-language:EN-GB">Please note and follow the 
                    guidelines to complete a successful application<o:p></o:p></span></p>
                <p align="center" class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;
text-align:center;line-height:normal">
                    <span lang="EN-GB" style="font-size:12.0pt;
font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
mso-fareast-language:EN-GB"><o:p>&nbsp;</o:p></span></p>
                <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;text-align:
justify;line-height:normal">
                    <b style="mso-bidi-font-weight:normal">
                    <span lang="EN-GB" style="font-size:14.0pt;mso-bidi-font-size:12.0pt;font-family:&quot;Andalus&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB">TECHNICAL 
                    INFORMATION:</span></b><span lang="EN-GB" style="font-size:14.0pt;mso-bidi-font-size:
12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
mso-fareast-language:EN-GB"><o:p></o:p></span></p>
                <p class="MsoListParagraphCxSpFirst" style="margin-bottom:0in;margin-bottom:.0001pt;
mso-add-space:auto;text-indent:-.25in;line-height:normal;mso-list:l1 level1 lfo1">
                    <![if !supportLists]>
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB">
                    <span style="mso-list:Ignore">1.<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;
                    </span></span></span><![endif]>
                    <span lang="EN-GB" style="font-size:12.0pt;
font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
mso-fareast-language:EN-GB">Once an application has been started; please do &quot;NOT&quot; click on the 
                    &quot;BACK&quot; button of the browser&nbsp;<o:p></o:p></span></p>
                <p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0in;margin-bottom:
.0001pt;mso-add-space:auto;text-indent:-.25in;line-height:normal;mso-list:l1 level1 lfo1">
                    <![if !supportLists]>
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB">
                    <span style="mso-list:Ignore">2.<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;
                    </span></span></span><![endif]>
                    <span lang="EN-GB" style="font-size:12.0pt;
font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
mso-fareast-language:EN-GB">Do &quot;NOT&quot; start &quot;MULTIPLE&quot; applications by creating &quot;MULTIPLE TABS&quot; 
                    within the same browser&nbsp;<o:p></o:p></span></p>
                <p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0in;margin-bottom:
.0001pt;mso-add-space:auto;text-indent:-.25in;line-height:normal;mso-list:l1 level1 lfo1">
                    <![if !supportLists]>
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB">
                    <span style="mso-list:Ignore">3.<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;
                    </span></span></span><![endif]>
                    <span lang="EN-GB" style="font-size:12.0pt;
font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
mso-fareast-language:EN-GB">If multiple applications are absolutely necessary, do so by starting 
                    each in a different browser&nbsp;<o:p></o:p></span></p>
                <p class="MsoListParagraphCxSpLast" style="margin-bottom:0in;margin-bottom:.0001pt;
mso-add-space:auto;text-indent:-.25in;line-height:normal;mso-list:l1 level1 lfo1">
                    <![if !supportLists]>
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB">
                    <span style="mso-list:Ignore">4.<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;
                    </span></span></span><![endif]>
                    <span lang="EN-GB" style="font-size:12.0pt;
font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
mso-fareast-language:EN-GB">During each step (or form), please click on the &quot;Save&quot; or &quot;Save and 
                    Continue&quot; button<span style="mso-spacerun:yes">&nbsp;&nbsp; </span>
                    <b style="mso-bidi-font-weight:normal"><u>ONLY ONCE</u></b> to proceed<o:p></o:p></span></p>
                <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;line-height:
normal">
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB"><o:p>&nbsp;</o:p></span></p>
                <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;line-height:
normal">
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;color:red;mso-fareast-language:EN-GB">This 
                    service is best used with Internet Explorer 6, Firefox 2 or Safari 2 or later 
                    version on a screen at least 1024 by 768 pixels in size. Our website requires 
                    the use of cookies and JavaScript and supports the ISO 8859-1 character set<o:p></o:p></span></p>
                <p class="MsoNormalCxSpMiddle" style="margin-bottom:0in;margin-bottom:.0001pt;
mso-add-space:auto;text-align:justify;text-indent:-.25in;line-height:normal">
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB">&nbsp;<o:p></o:p></span></p>
                <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;line-height:
normal">
                    <b>
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB">BEFORE STARTING THE 
                    APPLICATION PROCESS, IT IS IMPORTANT TO BEAR, CLEARLY, IN MIND:&nbsp;&nbsp;<o:p></o:p></span></b></p>
                <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;line-height:
normal">
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB"><o:p>&nbsp;</o:p></span></p>
                <p class="MsoListParagraphCxSpFirst" style="margin-bottom:0in;margin-bottom:.0001pt;
mso-add-space:auto;text-indent:-.25in;line-height:normal;mso-list:l0 level1 lfo2">
                    <![if !supportLists]>
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB">
                    <span style="mso-list:Ignore">1.<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;
                    </span></span></span><![endif]>
                    <span lang="EN-GB" style="font-size:12.0pt;
font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
mso-fareast-language:EN-GB">The acceptable formats for uploading Patent representations are <b>
                    <span style="color:#990000">&quot;pdf&quot;</span></b> formats only,<o:p></o:p></span></p>
                <p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0in;margin-bottom:
.0001pt;mso-add-space:auto;text-indent:-.25in;line-height:normal;mso-list:l0 level1 lfo2">
                    <![if !supportLists]>
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB">
                    <span style="mso-list:Ignore">2.<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;
                    </span></span></span><![endif]>
                    <span lang="EN-GB" style="font-size:12.0pt;
font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
mso-fareast-language:EN-GB">Ensure that the name and<span style="mso-spacerun:yes">&nbsp; </span>
                    address of<span style="mso-spacerun:yes">&nbsp; </span>the Inventor /Applicant 
                    are correctly and properly filled,&nbsp;<o:p></o:p></span></p>
                <p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0in;margin-bottom:
.0001pt;mso-add-space:auto;text-indent:-.25in;line-height:normal;mso-list:l0 level1 lfo2">
                    <![if !supportLists]>
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB">
                    <span style="mso-list:Ignore">3.<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;
                    </span></span></span><![endif]>
                    <span lang="EN-GB" style="font-size:12.0pt;
font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
mso-fareast-language:EN-GB">All information entered and <b style="mso-bidi-font-weight:
normal">SUBMITTED</b> cannot be retrieved, amended or corrected without the payment of an amendment 
                    fee. Please ensure that the information filled is correct,<o:p></o:p></span></p>
                <p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0in;margin-bottom:
.0001pt;mso-add-space:auto;text-indent:-.25in;line-height:normal;mso-list:l0 level1 lfo2">
                    <![if !supportLists]>
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB">
                    <span style="mso-list:Ignore">4.<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;
                    </span></span></span><![endif]>
                    <span lang="EN-GB" style="font-size:12.0pt;
font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
mso-fareast-language:EN-GB">All correspondence with regards to applications filed will be sent to 
                    the agents email as specified during accreditation,<o:p></o:p></span></p>
                <p class="MsoListParagraphCxSpMiddle" style="margin-bottom:0in;margin-bottom:
.0001pt;mso-add-space:auto;text-indent:-.25in;line-height:normal;mso-list:l0 level1 lfo2">
                    <![if !supportLists]>
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB">
                    <span style="mso-list:Ignore">5.<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;
                    </span></span></span><![endif]>
                    <span lang="EN-GB" style="font-size:12.0pt;
font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
mso-fareast-language:EN-GB">You will be issued an on-screen acknowledgment copy immediately after 
                    submission. If you do not receive your acknowledgment immediately, kindly use 
                    the “check status” link to re-print your acknowledgment slip,&nbsp;and<o:p></o:p></span></p>
                <p class="MsoListParagraphCxSpLast" style="margin-bottom:0in;margin-bottom:.0001pt;
mso-add-space:auto;text-indent:-.25in;line-height:normal;mso-list:l0 level1 lfo2">
                    <![if !supportLists]>
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB">
                    <span style="mso-list:Ignore">6.<span 
                        style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;
                    </span></span></span><![endif]>
                    <span lang="EN-GB" style="font-size:12.0pt;
font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;mso-fareast-font-family:&quot;Times New Roman&quot;;
mso-fareast-language:EN-GB">This form has a session of 2 hours; ensure you complete FILING in the 
                    form within the specified period to avoid being timed out.&nbsp;<o:p></o:p></span></p>
                <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;line-height:
normal">
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB"><o:p>&nbsp;</o:p></span></p>
                <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;line-height:
normal">
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB">For technical 
                    information on HOW TO FILE APPLICATIONS using PAS, kindly send an email to 
                    customersupport@iponoigeria.com and all requests will be treated within 48 
                    hours, <span style="mso-spacerun:yes">&nbsp;</span>Mondays- Fridays.&nbsp;<o:p></o:p></span></p>
                <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;line-height:
normal;text-align:center">
                    <span lang="EN-GB" style="font-size:12.0pt;font-family:&quot;Times New Roman&quot;,&quot;serif&quot;;
mso-fareast-font-family:&quot;Times New Roman&quot;;mso-fareast-language:EN-GB">
                    <span style="mso-spacerun:yes; ">
                    </span><b>THANK YOU FOR YOUR UNDERSTANDING</b></span></p>
            </td>
        </tr>
        
        <tr>
            <td class="tbbg">               
                &nbsp;</td>
        </tr>
        
       
        <tr>
            <td  align="center">
                &nbsp;

                <asp:Button ID="Button1" runat="server"  value="Proceed" class="button" Text="Proceed" OnClick="Button1_Click" />

            </td>
        </tr>
         
    </table>

          </asp:Panel>

     <asp:Panel runat="server" Visible="false" ID="tt2"> 
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

      <table id="main" style="width:100%;font-family:Calibri;"  align="center" >     
            <tr>
                <td colspan="2" style="font-size:18pt;line-height:115%;" align="center">
                        APPLICATION FOR ANNUAL RENEWAL OF A REGISTERED PATENT
                </td>
            </tr>
             <tr>
                <td colspan="2" class="tbbg_left">  
                     <input id="payment_date2" type="hidden" runat="server"/>
                     <input id="hwalletID2" type="hidden" runat="server"/>
                     <input id="transID2" type="hidden" runat="server"/>
                     <input id="amt2" type="hidden" runat="server"/>
                     <input id="serverpath2" type="hidden" runat="server"/>
                     <input id="log_staffID2" type="hidden" runat="server"/>

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
                    <input id="item_code2" type="text" class="textbox" size="80" runat="server" readonly="true"/></td>
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
                    <input id="btn_confirm" type="button" value="CONFIRM" class="button" onclick="doRenewalConfirm(); return false;" /></td>
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
                    <input id="btn_submit" type="button" value="SUBMIT" class="button" onclick="addRenewal(); return false;" /><input id="btn_edit" type="button" value="EDIT" class="button" onclick="    doRenewalEdit(); return false;" /><br />
                   </td>
            </tr>  
            </table>
            
    
                    </td>
    </tr>
    </table>

         </asp:Panel>

    <asp:Panel ID="tt3" style="display:none;" runat="server">


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
               
                <asp:Label ID="payment_date3" runat="server" Text="None"></asp:Label>&nbsp;</td>
        </tr>
        
        <tr>
            <td align="right">
                TRANSACTION ID :
            </td>
                <td>
                  <asp:Label ID="transID3" runat="server" Text="None"></asp:Label>
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
                 
                  <asp:Label ID="Label1" runat="server" Text="None"></asp:Label></td>
        </tr>
        
        <tr>
            <td align="right">
                ITEM CODE: </td>
                <td>
                  <asp:Label ID="Label2" runat="server" Text="None"></asp:Label>
                  </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;PATENT APPLICATION NUMBER :
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="None"></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                TITLE OF INVENTION :
                </td>
            <td>
               
                <asp:Label ID="Label4" runat="server" Text="None"></asp:Label>
                </td>
        </tr>
        
        <tr>
            <td align="right">
                NATIONAL FILING DATE :
                </td>
            <td>
               
                <asp:Label ID="Label5" runat="server" Text="None"></asp:Label>&nbsp;
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
               
                <asp:Label ID="Label6" runat="server" Text="None"></asp:Label>
                   </td>
        </tr>
        
        <tr>
            <td align="right">
                ADDRESS :</td>
                <td>
               
                <asp:Label ID="Label7" runat="server" Text="None"></asp:Label>
                    </td>
        </tr>
        
        <tr>
            <td align="right">
                PHONE NUMBER :
            </td>
                <td>
               
                <asp:Label ID="Label8" runat="server" Text="None"></asp:Label>
                  </td>
        </tr>
        
        <tr>
            <td align="right">
                E-MAIL :</td>
                <td>
               
                <asp:Label ID="Label9" runat="server" Text="None"></asp:Label>
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
               
                <asp:Label ID="Label10" runat="server" Text="None"></asp:Label>
                   </td>
        </tr>
        
        <tr>
            <td align="right">
                CODE: </td>
                <td>
                <asp:Label ID="Label11" runat="server" Text="None"></asp:Label>
                </td>
        </tr>
        
        <tr>
            <td align="right">
                ADDRESS :</td>
                <td>
               
                <asp:Label ID="Label12" runat="server" Text="None"></asp:Label>
                    </td>
        </tr>
        
        <tr>
            <td align="right">
                PHONE NUMBER :
            </td>
                <td>
               
                <asp:Label ID="Label13" runat="server" Text="None"></asp:Label>
                  </td>
        </tr>
        
        <tr>
            <td align="right">
                E-MAIL :</td>
                <td>
               
                <asp:Label ID="Label14" runat="server" Text="None"></asp:Label>
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
               
                <asp:Label ID="Label15" runat="server" Text="None"></asp:Label>
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

          <table style="float:left;width:100%;">
        <tr>
        <td align="left" width="100%">       
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printHomePtCert('searchform');" class="button" /> 
                                <asp:Button ID="btnDashboard" runat="server" 
    Text="Back to Dashboard" class="button" onclick="btnDashboard_Click"/>
                
                
                
                </td>
        </tr>
        </table>
    </asp:Panel>

  

</div>

    </form>
</body>
</html>