﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Patent_Recorder.aspx.cs" Inherits="Patent_Recorder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"  data-ng-app="myModule">
<head runat="server">
    <title>Patent Recordal</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/jquery-2.1.1.min.js"></script>
    <script src="js/angular.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/loading-bar.css" rel="stylesheet" />
    <link href="css/sweet-alert.css" rel="stylesheet" />
    <script src="js/loading-bar.js"></script>
    <script src="js/sweet-alert.min.js"></script>
    <link href="css/angular-datepicker.min.css" rel="stylesheet" />
    <script src="js/angular-datepicker.min.js"></script>
    <script src="js/smart-table.min.js"></script>
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <script src="Scripts/EditApplication.js"></script>



        <style type="text/css">
            .tbbg { padding:0; margin:0 auto; width:100%; height:20px;  background-color:#002030; text-align:center; color:#fff; font-weight:bold; border-color:#002030;}

.tbbg_left { padding:0; margin:0 auto; width:100%; height:20px;  background-color:#002030; text-align:left; color:#fff; font-weight:bold; border-color:#002030;}
        p.MsoNormal {
            margin-top: 0in;
            margin-right: 0in;
            margin-bottom: 10.0pt;
            margin-left: 0in;
            line-height: 115%;
            font-size: 11.0pt;
            font-family: "Calibri","sans-serif";
        }

        p.MsoListParagraphCxSpFirst {
            margin-top: 0in;
            margin-right: 0in;
            margin-bottom: 0in;
            margin-left: .5in;
            margin-bottom: .0001pt;
            line-height: 115%;
            font-size: 11.0pt;
            font-family: "Calibri","sans-serif";
        }

        p.MsoListParagraphCxSpMiddle {
            margin-top: 0in;
            margin-right: 0in;
            margin-bottom: 0in;
            margin-left: .5in;
            margin-bottom: .0001pt;
            line-height: 115%;
            font-size: 11.0pt;
            font-family: "Calibri","sans-serif";
        }

        p.MsoListParagraphCxSpLast {
            margin-top: 0in;
            margin-right: 0in;
            margin-bottom: 10.0pt;
            margin-left: .5in;
            line-height: 115%;
            font-size: 11.0pt;
            font-family: "Calibri","sans-serif";
        }

        a:link {
            color: blue;
            text-decoration: underline;
        }

        .style1 {
            color: black;
        }
    </style>

    <style>


  #sidebar-menu {

  top: 0px;

  width: 100%;

}

 

#sidebar-menu li { border-bottom: 1px solid rgba(238, 238, 238, 0.05); }

 

#sidebar-menu a {

  text-decoration: none;

  color: #595959;

}

 

#sidebar-menu a:hover {

  text-decoration: none;

  color: #595959;

}

    </style>

</head>
<body ng-controller="myController">
       
           <div>
                <table  align="center" width="100%" class="form table">
                        <tr>
                            <td align="center">

                                <img alt="Coat Of Arms" height="79" src="./images/coat_of_arms.png"
                                     width="85" /><br />
                                FEDERAL REPUBLIC OF NIGERIA<br />
                                FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT<br />
                                COMMERCIAL LAW DEPARTMENT<br />
                                TRADEMARKS, PATENTS AND DESIGNS REGISTRY<br />
                                PATENTS AND DESIGNS ACT CAP 344
                            </td>
                        </tr>


              







                       



                    </table>
               </div>

                  
       
        
   <div> 
            <table style="width:100%;font-family:Calibri;" id="applicantForm" align="center">


                          
                                <tr>
                                    <td colspan="2"></td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="tbbg_left">
                                        &nbsp;APPLICANT INFORMATION >>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2">
                                        <table  class="table table-responsive table-bordered">
                                           
                                                <tr>

                                                    <th  class="tbbg2">Applicant Name</th>
                                                    <th  class="tbbg2">Applicant Email</th>
                                                    <th  class="tbbg2">Applicant Mobile Number</th>
                                                    <th  class="tbbg2">Applicant Address</th>
                                                    <th  class="tbbg2">Country</th>




                                                </tr>

                                           
                                           
                                                <tr ng-repeat="row in ListAgent.Applicant">

                                                    <td><textarea rows="4" {{row.xname}} ng-model="row.xname" cols="30">  </textarea>  </td>

                                                    <td><input id="Text12" {{row.xemail}} ng-model="row.xemail" type="text" /> </td>
                                                    <td><input id="Text13" {{row.xmobile}} ng-model="row.xmobile" type="text" /> </td>
                                                    <td><textarea rows="4" {{row.address}} ng-model="row.address" cols="50">  </textarea> </td>

                                                    <td><select  ng-model="row.nationality" class="form-control" data-ng-options="c.code as c.name for c in countries" data-ng-change="GetStates(row)" >
                                                                                                                            <option value="">-- Select Country --</option>
                                                                                                                        </select> </td>

                                                </tr>
                                           
                                        </table>
                                    </td>
                                </tr>


                            </table>
       </div>

           
           
                       
            <div>
                
              
               <table style="width:100%;font-family:Calibri;"  align="center">




                                <tr>
                                    <td colspan="2"></td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="tbbg_left">
                                        &nbsp;TRUE INVENTOR INFORMATION >>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td colspan="2">
                                        <table  class="table table-responsive table-bordered">
                                            <thead>
                                                <tr>

                                                    <th  class="tbbg2">Name</th>
                                                    <th  class="tbbg2"> Email</th>
                                                    <th  class="tbbg2">Mobile Number</th>
                                                    <th  class="tbbg2"> Address</th>
                                                    <!--<th st-sort="reg_no" class="tbbg2"></th>-->




                                                </tr>

                                            </thead>
                                            <tbody>
                                                <tr ng-repeat="row in ListAgent.Inventor">

                                                    <td><textarea rows="4" {{row.xname}} ng-model="row.xname" cols="30">  </textarea>  </td>

                                                    <td><input id="Text2" {{row.xemail}} ng-model="row.xemail" type="text" /> </td>
                                                    <td><input id="Text3" {{row.xmobile}} ng-model="row.xmobile" type="text" /> </td>
                                                    <td><textarea rows="4" {{row.address}} ng-model="row.address" cols="50">  </textarea> </td>
                                                    <!--<td><button type="button" ng-click="add()" class="btn   btn-info "><i class="fa fa-search"></i>Save</button></td>-->


                                                </tr>
                                            </tbody>
                                           
                                        </table>
                                    </td>
                                </tr>

                                </table>

                <div>
                    <table style="width:100%;font-family:Calibri;" id="applicantForm3" align="center">

  <tr>
                                    <td colspan="2" class="tbbg_left">
                                        &nbsp;ASSIGNMENT  INFORMATION >>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2">
                                        <table  class="table table-responsive table-bordered">
                                            <thead>
                                                <tr>

                                                   
                                                   
                                                    <th  class="tbbg2">Assignee  Nationality</th>
                                                     <th  class="tbbg2">Assignor  Nationality</th>
                                                    <!--<th st-sort="reg_no" class="tbbg2"></th>-->




                                                </tr>

                                            </thead>
                                            <tbody>
                                                <tr ng-repeat="row in ListAgent.Assignment_info">

                                                   

                                                    <td><select  ng-model="row.assignee_nationality" class="form-control" data-ng-options="c.code as c.name for c in countries"  >
                                                                                                                            <option value="">-- Select Country --</option>
                                                                                                                        </select> </td>
                                                    <td><select  ng-model="row.assignor_nationality" class="form-control" data-ng-options="c.code as c.name for c in countries"  >
                                                                                                                            <option value="">-- Select Country --</option>
                                                                                                                        </select> </td>
                                                   
                                                    <!--<td><button type="button" ng-click="add()" class="btn   btn-info "><i class="fa fa-search"></i>Save</button></td>-->


                                                </tr>
                                            </tbody>
                                            
                                        </table>
                                    </td>

                                </tr>  
</table>
                </div>

               
               

            </div>
           
         

            <div> 

             <table style="width:100%;font-family:Calibri;" id="applicantForm8" >


                                <tr>
                                    <td colspan="2"></td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="tbbg_left">
                                        &nbsp;PATENT  INFORMATION >>
                                    </td>
                                </tr>

             

                                <tr>
                                    <td colspan="2">
                                        <table  class="table table-responsive table-bordered">
                                            
                                                <tr>

                                                    <td  class="tbbg2">TITLE OF INVENTION</td>

                                                   
                                               
                                                </tr>
                                            
                 
                                            
                                           
                                                <tr ng-repeat="row in ListAgent.PtInfo">
                                                    
                                                   
                                                    <td><textarea rows="4" {{row.title_of_invention}} ng-model="row.title_of_invention" cols="30">  </textarea>  </td>
                                                    
                                                    
                                                                                             
                                                    
                                                </tr>
                       
                                       
                                        </table>
                                    </td>
                                </tr>

                

                            </table>

         <div> 
            <table id="applicantForm28">

                    
                        

                 

                       

                                <tr>
                                    <td><button type="button" ng-click="add2()" class="btn   btn-info "><i class="fa fa-save"></i>Update</button></td>

                                  

                                </tr>


                        

                      
                </table>
              </div>

               </div>
           
          
          
        <form class="form-login" role="form" >
             <input id="xname" name="xname" type="hidden" runat="server" />
            <input id="vamount" name="vamount" type="hidden" runat="server" />
            <input id="vtranid" name="vtranid" type="hidden" runat="server" />

            </form>
   
    
        
</body>
</html>
