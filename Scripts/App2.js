﻿var app=angular.module('formApp', [])

var serviceBaseIpo = 'http://88.150.164.30/EinaoTestEnvironment.IPO/';

var serviceBasePatent = 'http://88.150.164.30/EinaoTestEnvironment.Patent/';

// configuring our routes 
// =============================================================================


// our controller for the form
// =============================================================================
app.controller('formController', function ($scope,  $rootScope, $http) {

    var serviceBase = serviceBasePatent + 'Handlers/GetEmailCount.ashx';
    $(document).ready(function () {

     //   var xname = $("input#xname").val();

     ////   setInterval(blinktext, 500);
     //   var txt = "";
     //   var count = 0;
      

     //   //  $scope.formData.vname = xname;


     //   var Encrypt = {
     //       vid: xname
     //   }

        $http({
            method: 'POST',
            url: serviceBase,
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            //data: Encrypt,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
        })
            .success(function (response) {
                var dd = [];
                var a = parseInt(response);
                if (a > 0) {
                    $rootScope.xvv = true;

                }
                $rootScope.vcount = response
             



                //  IpoTradeMarks2(response.Email, response.Firstname, response.CompanyAddress, response.xid, response.PhoneNumber)
                //  ajaxindicatorstop();

            })
            .error(function (response) {
                //  ajaxindicatorstop();
            });


        //   alert(xname)

    });

    // alert($location.search().name)

 

    //  $scope.formData.vname = $location.search().name;



   





});



function blinktext() {
    var count = 0;
    var cntrl = document.getElementById("txtblinkingtext");
    if (count == 0)
        txt = cntrl.value;
    if (count % 2 == 0)
        cntrl.value = "";
    else
        cntrl.value = txt;
    count++;

}