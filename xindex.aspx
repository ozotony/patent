<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xindex.aspx.cs" Inherits="xindex" %>
<%@ Register assembly="Brettle.Web.NeatUpload" namespace="Brettle.Web.NeatUpload" tagprefix="Upload" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">

    <title>
PATENT APPLICATION NOTICE
</title>
  <link href="css/style.css" rel="stylesheet" type="text/css" />

<script src="js/jquery.js" type="text/javascript"></script>

<script src="js/funk.js" type="text/javascript"></script>
       
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
    <link href="css/print_style.css" rel="stylesheet" type="text/css" />

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
    
    <script language="javascript" type="text/javascript">
// <![CDATA[
       


        function Proceed_onclick() {
            window.location.href = "./application.aspx";
        }

// ]]>
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
  
<asp:Panel runat="server" ID="tt" > 
    <div>
      
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
                    &quot;PATENT APPLICATION SECTION&quot;</span></b></p>
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
                &nbsp; <asp:Button ID="Proceed" runat="server" name="Proceed2"   class="button" Text="Proceed" OnClick="Proceed_Click" />  </td>
        </tr>
         
    </table>
       

</div>

</asp:Panel>
<asp:Panel runat="server" Visible="false" ID="tt2"  > 
    
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
                    SelectCommand="SELECT * FROM [country] order by name">                  
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
                <asp:DropDownList ID="select_assignee_nationality" runat="server" OnDataBound="newsProviderID_DataBound" CssClass="textbox" DataSourceID="ds_Nationality" DataTextField="name" 
                    DataValueField="ID">
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
                <asp:DropDownList ID="select_assignor_nationality" OnDataBound="newsProviderID_DataBound2" runat="server" CssClass="textbox" DataSourceID="ds_Nationality" DataTextField="name" 
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
                    SelectCommand="SELECT * FROM [country] order by name"></asp:SqlDataSource>
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
                    onclick="ButtonAddPri_Click" CssClass="plus_button" Visible="true" />
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
                <%  if (pct_newfilename == "0")
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
                <%} %>
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
    
    </asp:Panel>
<asp:Panel ID="tt3" Visible="false" runat="server">
      <div>
       
            <div id="searchform">

    <table align="center" width="1000px" class="form" >    
        <tr>
            <td colspan="2" align="center" >
             <img alt="Coat Of Arms" height="79" src="images/coat_of_arms.png" 
                        width="85" /><br />
              FEDERAL REPUBLIC OF NIGERIA<br />
                    FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                    COMMERCIAL LAW DEPARTMENT<br />
                    TRADEMARKS, PATENTS AND DESIGNS REGISTRY<br />
                    PATENTS AND DESIGNS DECREE NO 60 OF 1970<br />
                   <div style="font-size:20px;"><strong>ACKNOWLEDGMENT FORM</strong></div> 
            </td>
        </tr>       
        
        <%if (info!=null)
          { %>
        <tr>
            <td width="100%" align="right" colspan="2" class="sub_header">
                </td>
        </tr>
        
        <tr>
            <td width="50%" align="right">
                &nbsp;FILING/APPLICATION DATE :             </td>
            <td>
               
                <asp:Label ID="Label1" runat="server" Text="Label"><% Response.Write(info.reg_date); %></asp:Label>&nbsp;</td>
        </tr>
        
        <tr>
            <td align="right">
                REGISTRATION NUMBER :
            </td>
                <td>
                  <asp:Label ID="Label2" runat="server" Text="Label"><%Response.Write( t.getRegNumber(num3)); %></asp:Label>
                    </td>
        </tr>
         <tr>
            <td align="right"> 
                                &nbsp;
                                ONLINE APPLICATION ID : </td>
            <td>
                 
               <%-- <asp:Label ID="Label6" runat="server" Text="Label"><% Response.Write("OAI/PT/" + t.ValidationIDByPwalletID(Session["new_ptID"].ToString())); %></asp:Label>--%>

                 <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>

            </td>
        </tr>
         <tr>
            <td colspan="2" class="tbbg">
                --- 
                PATENT INFORMATION --- </td>
        </tr>
        
        <tr>
            <td align="right">
                &nbsp;PATENT TYPE :</td>
                <td>
                 
                  <asp:Label ID="Label3" runat="server" Text="Label"><% Response.Write(info.xtype); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;TITLE OF INVENTION :
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Label"><% Response.Write(info.title_of_invention); %></asp:Label></td>
        </tr>
        <tr>
            <td align="right">
                TRANSACTION ID :
                </td>
            <td>
                <% Response.Write(Session["vid"].ToString()); %></td>
        </tr>
        
        <tr>
            <td align="right">
                TRANSACTION AMOUNT :
                </td>
            <td>
                <% Response.Write(Session["amt"].ToString()); %>  NGN
                </td>
        </tr>  
        <%}%>      
       <%if (list.Count > 0)
         {
            %>
        <tr>
            <td class="tbbg" colspan="2">
                --- APPLICANT INFORMATION ---</td>
        </tr>
         <%             for (int app = 0; app < list.Count; app++)
             {%>
        <tr>
            <td align="left" colspan="2" style="background-color:#999999;">
                <strong>APPLICANT <%=app + 1%>>></strong></td>
        </tr>
        
        <tr>
            <td align="right">
                NAME :</td>
                <td>
                    <% Response.Write(list[app].xname); %></td>
        </tr>
        
        <tr>
            <td align="right">
                ADDRESS :</td>
                <td>
                    <% Response.Write(list[app].address); %></td>
        </tr>
        
        <tr>
            <td align="right">
                PHONE NUMBER :
            </td>
                <td>
                    <% Response.Write(list[app].xmobile); %></td>
        </tr>
        
        <tr>
            <td align="right">
                E-MAILS :</td>
                <td>
                    <% Response.Write(list[app].xemail); %></td>
        </tr>
        <tr>
            <td align="right">
                NATIONALITY :</td>
                <td>
                   <% Response.Write(t.getCountryName(list[app].nationality)); %></td>
        </tr>
       
         <%
             }
         }%>
         <%if (list2.Count > 0)
           {
              %>  
        
       
        <tr>
            <td class="tbbg" colspan="2">
                --- TRUE INVENTOR INFORMATION ---</td>
        </tr>
        <%   for (int inv = 0; inv < list2.Count; inv++)
               {%>
        <tr>
            <td align="left" colspan="2" style="background-color:#999999;">
                <strong>INVENTOR <%=inv+1%>>></strong></td>
        </tr>
        
        <tr>
            <td align="right">
                NAME :</td>
                <td>
                    <% Response.Write(list2[inv].xname); %></td>
        </tr>
        
        <tr>
            <td align="right">
                ADDRESS :</td>
                <td>
                    <% Response.Write(list2[inv].address); %></td>
        </tr>
        
        <tr>
            <td align="right">
                PHONE NUMBER :
            </td>
                <td>
                    <% Response.Write(list2[inv].xmobile); %></td>
        </tr>
        
        <tr>
            <td align="right">
                E-MAILS :</td>
                <td>
                    <% Response.Write(list2[inv].xemail); %></td>
        </tr>
        <tr>
            <td align="right">
                NATIONALITY :</td>
                <td>
                   <% Response.Write(t.getCountryName(list2[inv].nationality)); %></td>
        </tr>
        <%
               }
           }%>
        <%if (_info != null)
          { %>
        <tr>
            <td class="tbbg" colspan="2">
                --- ASSIGNMENT INFORMATION ---</td>
        </tr>
          <tr>
            <td align="right">
                DATE OF ASSIGNMENT :</td>
                <td>
                    <% Response.Write(_info.date_of_assignment); %></td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="background-color:#999999;">
                <strong>ASSIGNEE >></strong></td>
        </tr>
       
        <tr>
            <td align="right">
                NAME :</td>
                <td>
                    <% Response.Write(_info.assignee_name); %></td>
        </tr>
        
        <tr>
            <td align="right">
                ADDRESS :</td>
                <td>
                    <% Response.Write(_info.assignee_address); %></td>
        </tr>
         <tr>
            <td align="right">
                NATIONALITY :</td>
                <td>
                   <% Response.Write(t.getCountryName(_info.assignee_nationality)); %></td>
        </tr>
       <tr>
            <td align="left" colspan="2" style="background-color:#999999;">
                <strong>ASSIGNOR >></strong></td>
        </tr>
        
        <tr>
            <td align="right">
                NAME :</td>
                <td>
                    <% Response.Write(_info.assignor_name); %></td>
        </tr>
        
       
       
        <tr>
            <td align="right">
                ADDRESS&nbsp; :</td>
                <td>
                     <% Response.Write(_info.assignor_address); %></td>
        </tr>
        <tr>
            <td align="right">
                NATIONALITY :</td>
                <td>
                   <% Response.Write(t.getCountryName(_info.assignor_nationality)); %></td>
        </tr>
        <%} %>
        <%if (list3.Count > 0)
          {%>
        <tr>
            <td colspan="2" class="tbbg">
                --- PRIORITY INFORMATION ---</td>
        </tr>
        <tr>
            <td colspan="2" style="border:0px outset silver; padding: 0px;">
                <table width="100%">
                <tr style="background-color:#999999;">
                <td style="width:10%;">
                    <strong>S/N</strong></td>
                <td style="width:30%;">
                    <strong>COUNTRY</strong></td>
                <td style="width:30%;">
                    <strong>APPLICATION NUMBER</strong></td>
                <td style="width:30%;">
                    <strong>DATE</strong></td>
                </tr>

                 <%
              for (int pri = 0; pri < list3.Count; pri++)
              {%>
                <tr >
                <td>
                <%=pri + 1%>
                </td>
                <td>
                    <% Response.Write(t.getCountryName(list3[pri].countryID)); %></td>
                <td>
                    <% Response.Write(list3[pri].app_no); %></td>
                <td>
                    <% Response.Write(list3[pri].xdate); %></td>
                </tr>
                 <%
              }
          %>
                </table></td>
        </tr>
        <%
          }%>
        <%if (representative !=null)
          { %>
        <tr>
            <td colspan="2" class="tbbg">
                --- ADDRESS OF SERVICE IN NIGERIA ---
            </td>
        </tr>
        <tr>
            <td align="right">
                                ATTORNEY CODE :
                </td>
            <td>
                 <asp:Label ID="Label9" runat="server" Text="Label"><% Response.Write(representative.agent_code); %></asp:Label>
                     </td>
        </tr>        
        
        
        <tr>
            <td align="right">
                                ATTORNEY NAME :</td>
            <td>
                <% Response.Write(representative.xname); %></td>
        </tr>
        
        
        <tr>
            <td align="right">
                NATIONALITY :</td>
            <td>
                <% Response.Write(t.getCountryName(representative.nationality)); %></td>
        </tr>
        
        
        <tr>
            <td align="right">
                COUNTRY :</td>
            <td>
               <% Response.Write(t.getCountryName(representative.country)); %></td>
        </tr>
        
        
        <tr>
            <td align="right">
                STATE :</td>
            <td>
               <% Response.Write(t.getStateName(representative.state)); %></td>
        </tr>
        
        
        <tr>
            <td align="right">
                &nbsp;ADDRESS :
                </td>
            <td>
                <asp:Label ID="Label8" runat="server" Text="Label"><% Response.Write(representative.address); %></asp:Label></td>
        </tr>
        
        
        <tr>
            <td align="right">
                PHONE NUMBER : </td>
            <td>
                <% Response.Write(representative.xmobile); %></td>
        </tr>
        
        
        <tr>
            <td align="right">
                E-MAIL : </td>
            <td>
                <% Response.Write(representative.xemail); %></td>
        </tr>
         <%} %>

        <tr>
            <td colspan="2" class="tbbg">
                --- DOCUMENTS ATTACHED ---
            </td>
        </tr>
        <%if (loa_newfilename == "0")
              { %>
        <tr>
            <td align="right">
               LETTER OF AUTHORIZATION OF AGENT(FORM 2) :
            </td>
            <td >
            <%if ((info.loa_doc == "") || (info.loa_doc == "0"))
              { %> NOT ATTACHED<%}
              else
              { %>ATTACHED<%} %></td>
        </tr>
          <%} %> 
        <%if (claim_newfilename == "0")
              { %>
        <tr>
            <td align="right">
                CLAIM(S) :</td>
            <td >
                <%if ((info.claim_doc == "") || (info.claim_doc == "0"))
                  { %> NOT ATTACHED  <%}
               
                  else
                  { %>ATTACHED<%} %></td>
        </tr>
        
        <%} %> 

         <%if (pct_newfilename == "0")
              { %>
        <tr>
            <td align="right">
                PCT DOCUMENT:</td>
            <td >
                  <%if ((info.pct_doc == "") || (info.pct_doc == "0"))
                    { %> NOT ATTACHED<%}
                    else
                    { %>ATTACHED<%} %></td>
        </tr>
         <%} %> 
          <%if (doa_newfilename == "0")
              { %>
        <tr>
            <td align="right">
                DEED OF ASSIGNMENT:</td>
            <td >
                  <%if ((info.doa_doc == "") || (info.doa_doc == "0"))
                    { %> NOT ATTACHED<%}
                   else
                    { %>ATTACHED<%} %></td>
        </tr>
           <%} %> 

         <%if (spec_newfilename == "0")
              { %>
        <tr>
            <td align="right">
                COMPLETE SPECIFICATION (FORM 3):</td>
            <td >
                <%if ((info.spec_doc == "") || (info.spec_doc == "0"))
                    { %> NOT ATTACHED<%}
                   else
                    { %>ATTACHED<%} %></td>
                  
        </tr>
        <%} %> 
        <tr>
            <td class="tbbg" colspan="2" style="color: #fff; background-color: #006600; text-align: center; font-weight: bold;">
              
                &nbsp;</td>
        </tr>
        <tr>
            <td  align="center" colspan="2">
              
             <strong>YOUR APPLICATION HAS BEEN RECEIVED AND IS RECEIVING DUE ATTENTION</strong><br />
             <strong>TRADEMARKS, PATENTS AND DESIGNS REGISTRY 
                <br />
                COMMERCIAL LAW DEPARTMENT
                <br />
                FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT
                </strong>
                </td>
        </tr>        
         
    </table>
        </div>
  <table style="float:left;width:100%;">
        <tr>
        <td align="left" width="100%">       
                <input type="button" name="Printform" id="Printform" value="Print" onclick="printPtCert(searchform);" class="button" />&nbsp;
                <asp:Button ID="btnDashboard" runat="server" Text="Back to Dashboard" 
                    class="button" onclick="btnDashboard_Click"/>
                
                </td>
        </tr>
        </table>
</div>

</asp:Panel>


    </form>
</body>
</html>

