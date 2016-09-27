var app = angular.module('formApp', ['ngWig', 'ngModal']);


// configuring our routes 
// =============================================================================

var serviceBase = 'http://pt.cldng.com'
var serviceBaseIpo = 'http://ipo.cldng.com'

var serviceBaseCld = 'http://tm.cldng.com'
// our controller for the form
// =============================================================================
app.controller('formController', function ($scope, $rootScope, $http, $location) {

    $(document).ready(function () {

        //$scope.xname = $("input#xname2").val();
        //$scope.xname2 = $("input#xname3").val();

    });

    $scope.Payment_Reference = "";
    // we will store all of our form data in this object
    $scope.formData = {};
    $scope.model = {};
    $scope.content = "";
    var selectedVal = "";
    $(".table").hide();
    var selected = $("#rbValid input[type='radio']:checked");
    if (selected.length > 0) {
        //  alert(selected.val())
        if (selected.val() == "Ping") {


            $("#Verify").hide();
            $(".table").show();
            //  $("#rich").show();
            $("#new_comment").hide();
            $("#comment").hide();
            var vurl = serviceBaseIpo +"/A/SearchPatent.aspx#/form/search?MessageID=" + $("input#xname3").val();
            var vtarget = "blank";


            $scope.model.content = "<b> AGENT CODE  </b> :<span>" + $("input#xname").val() + "</span> <br/><b> PATENT  NAME  </b> :<span>" + $("input#xname2").val() + "</span> <br/> <b> REGISTRATION  NUMBER   </b> :<span>" + $("input#xname3").val() + "<br/> <b> PATENT UPLOAD URL  </b> :  <a target='" + vtarget + "'  href='" + vurl + "'  >click link to view Application  </a> <br/><b> ONLINE APPLICATION ID  </b> :<span>" + $("input#xname4").val() + "</span> "



            //  $scope.dialogShown = true;


        }

        else if (selected.val() == "Accepted") {

            $("#Verify").show();

            $(".table").hide();

            $("#new_comment").show();
            $("#comment").show();


        }

        else if (selected.val() == "Opposed") {

            $("#Verify").show();

            $(".table").hide();
            $("#new_comment").show();
            $("#comment").show();


        }

        else if (selected.val() == "Certified") {

            $("#Verify").show();

            $(".table").hide();
            $("#new_comment").show();
            $("#comment").show();


        }



        else {



        }
        // alert(selected.val())
        //  selectedVal = selected.val();
    }
    // $scope.dialogShown = true;
    $scope.add3 = function (vv) {
        var serviceBase = serviceBaseCld + '/Handlers/AddEmail.ashx';
        //  var serviceBase = 'http://localhost:49703/Handlers/AddEmail.ashx';
        var pp3 = "Patent Examiner  Information"
        var xname = $("input#xname").val();
        var xname2 = $("input#xname5").val();
        var Encrypt = {
            vid: vv,
            vid2: xname,
            vid3: pp3,
            vid4: xname2
        }

        $http({
            method: 'POST',
            url: serviceBase,
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: Encrypt,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
        })
            .success(function (response) {
                var dd = [];
                //  $rootScope.vcount = response

                swal({
                    title: "Agent Pinged Successfully",
                    text: "",
                    type: "success",
                    showCancelButton: false,
                    confirmButtonColor: "#DD6B55", confirmButtonText: "OK!",
                    cancelButtonText: "No, cancel please!",
                    closeOnConfirm: true,
                    closeOnCancel: true
                },
 function (isConfirm) {
     if (isConfirm) {

         window.location.assign("e_contact.aspx");


     }

 });


                //  IpoTradeMarks2(response.Email, response.Firstname, response.CompanyAddress, response.xid, response.PhoneNumber)
                //  ajaxindicatorstop();

            })
            .error(function (response) {
                //  ajaxindicatorstop();
            });



    }

    $scope.add4 = function (vv) {
        var serviceBase = serviceBase + '/Handlers/AddEmail.ashx';
        // var serviceBase = 'http://localhost:49703/Handlers/AddEmail.ashx';
        var pp3 = "Patent Search  Information"
        var xname = $("input#xname").val();
        var xname2 = $("input#xname5").val();
        var Encrypt = {
            vid: vv,
            vid2: xname,
            vid3: pp3,
            vid4: xname2
        }

        $http({
            method: 'POST',
            url: serviceBase,
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: Encrypt,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
        })
            .success(function (response) {
                var dd = [];
                //  $rootScope.vcount = response

                swal({
                    title: "Agent Pinged Successfully",
                    text: "",
                    type: "success",
                    showCancelButton: false,
                    confirmButtonColor: "#DD6B55", confirmButtonText: "OK!",
                    cancelButtonText: "No, cancel please!",
                    closeOnConfirm: true,
                    closeOnCancel: true
                },
 function (isConfirm) {
     if (isConfirm) {

         window.location.assign("s_contact.aspx");


     }

 });


                //  IpoTradeMarks2(response.Email, response.Firstname, response.CompanyAddress, response.xid, response.PhoneNumber)
                //  ajaxindicatorstop();

            })
            .error(function (response) {
                //  ajaxindicatorstop();
            });



    }
    $(document).ready(function () {
        var selectedVal = "";



    });




});

app.controller('form2Controller', function ($scope, $rootScope, $http, $location) {

    $(document).ready(function () {

        //$scope.xname = $("input#xname2").val();
        //$scope.xname2 = $("input#xname3").val();

    });

    $scope.Payment_Reference = "";
    // we will store all of our form data in this object
    $scope.formData = {};
    $scope.model = {};
    $scope.content = "";
    var selectedVal = "";
    $(".table").hide();
    var selected = $("#rbValid input[type='radio']:checked");
    if (selected.length > 0) {
        //  alert(selected.val())
        if (selected.val() == "Ping") {


            $("#Verify").hide();
            $(".table").show();
            //  $("#rich").show();
            $("#new_comment").hide();
            $("#comment").hide();
            var vurl = serviceBaseIpo + "/A/SearchPatent.aspx#/form/search?MessageID=" + $("input#xname3").val();
            var vtarget = "blank";


            $scope.model.content = "<b> AGENT CODE  </b> :<span>" + $("input#xname").val() + "</span> <br/><b> PATENT  NAME  </b> :<span>" + $("input#xname2").val() + "</span> <br/> <b> REGISTRATION  NUMBER   </b> :<span>" + $("input#xname3").val()  +" <br/><b> ONLINE APPLICATION ID  </b> :<span>" + $("input#xname4").val() + "</span> "



            //  $scope.dialogShown = true;


        }

        else if (selected.val() == "Approved") {

            $("#Verify").show();

            $(".table").hide();

            $("#new_comment").show();
            $("#comment").show();


        }

        else if (selected.val() == "Refused") {

            $("#Verify").show();

            $(".table").hide();
            $("#new_comment").show();
            $("#comment").show();


        }

      



        else {



        }
        // alert(selected.val())
        //  selectedVal = selected.val();
    }
    // $scope.dialogShown = true;
    $scope.add3 = function (vv) {
        var serviceBase = serviceBaseCld + '/Handlers/AddEmail.ashx';
        //  var serviceBase = 'http://localhost:49703/Handlers/AddEmail.ashx';
        var pp3 = "Patent Kiv  Information"
        var xname = $("input#xname").val();
        var xname2 = $("input#xname5").val();
        var Encrypt = {
            vid: vv,
            vid2: xname,
            vid3: pp3,
            vid4: xname2
        }

        $http({
            method: 'POST',
            url: serviceBase,
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: Encrypt,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
        })
            .success(function (response) {
                var dd = [];
                //  $rootScope.vcount = response

                swal({
                    title: "Agent Pinged Successfully",
                    text: "",
                    type: "success",
                    showCancelButton: false,
                    confirmButtonColor: "#DD6B55", confirmButtonText: "OK!",
                    cancelButtonText: "No, cancel please!",
                    closeOnConfirm: true,
                    closeOnCancel: true
                },
 function (isConfirm) {
     if (isConfirm) {

         window.location.assign("rej_renewal.aspx");


     }

 });


                //  IpoTradeMarks2(response.Email, response.Firstname, response.CompanyAddress, response.xid, response.PhoneNumber)
                //  ajaxindicatorstop();

            })
            .error(function (response) {
                //  ajaxindicatorstop();
            });



    }

    $scope.add4 = function (vv) {
        var serviceBase = serviceBaseCld + '/Handlers/AddEmail.ashx';
        // var serviceBase = 'http://localhost:49703/Handlers/AddEmail.ashx';
        var pp3 = "Patent Search  Information"
        var xname = $("input#xname").val();
        var xname2 = $("input#xname5").val();
        var Encrypt = {
            vid: vv,
            vid2: xname,
            vid3: pp3,
            vid4: xname2
        }

        $http({
            method: 'POST',
            url: serviceBase,
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: Encrypt,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
        })
            .success(function (response) {
                var dd = [];
                //  $rootScope.vcount = response

                swal({
                    title: "Agent Pinged Successfully",
                    text: "",
                    type: "success",
                    showCancelButton: false,
                    confirmButtonColor: "#DD6B55", confirmButtonText: "OK!",
                    cancelButtonText: "No, cancel please!",
                    closeOnConfirm: true,
                    closeOnCancel: true
                },
 function (isConfirm) {
     if (isConfirm) {

         window.location.assign("rej_renewal.aspx");


     }

 });


                //  IpoTradeMarks2(response.Email, response.Firstname, response.CompanyAddress, response.xid, response.PhoneNumber)
                //  ajaxindicatorstop();

            })
            .error(function (response) {
                //  ajaxindicatorstop();
            });



    }
    $(document).ready(function () {
        var selectedVal = "";



    });




});





