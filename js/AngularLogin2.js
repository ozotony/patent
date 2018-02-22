var app = angular.module('myModule', ['smart-table', 'angular-loading-bar']);
var serviceBaseIpo = 'http://ipo.cldng.com/';

var serviceBasePatent = 'http://pt.cldng.com/';
app.filter('offset', function () {
    return function (input, start) {
        start = parseInt(start, 10);
        return input.slice(start);
    };
});


app.controller('myController', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.BranchCollect = [];
    $scope.itemsPerPage = 10;
    $scope.currentPage = 0;
    $scope.items = [];
    $scope.isDisabled = false;
    var url3 = 'http://localhost:55482/Handlers/GetRegistration2.ashx';

    // var url3 = ' http://localhost:21936/home/GetAgent';



    $scope.changeValue2 = function () {
        event2s = []
        var vcount = 0;
        angular.forEach($scope.displayedCollection, function (item) {
            var User_Status = new Object();
            if (item.description == true) {
                User_Status.online_id = item.validationID;
                User_Status.Status = "Search"

                event2s.push(User_Status)
                vcount = vcount + 1;
                //alert(item.oai_no)
            }


        });

        if (vcount == 0) {

            swal("", "No Record Selected", "error")
            return;
        }

        swal({
            title: "",
            text: "Are you sure you want to update the status of   " + vcount + " Records",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55", confirmButtonText: "UPDATE",
            cancelButtonText: "No!",
            closeOnConfirm: true,
            closeOnCancel: true
        },
function (isConfirm) {
    if (isConfirm) {

        var formData = new FormData();


        formData.append("vid", JSON.stringify(event2s));
        // formData.append("vid", event2s);




        var jsonData = angular.toJson(event2s);
        var objectToSerialize = { 'object': jsonData };




        $http.post(serviceBasePatent + 'Handlers/PostTransaction2.ashx', formData, {

            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
        .success(function (response) {

            //  ajaxindicatorstop();

            var kk = response

            swal("", "Record Updated Successfully", "success")
            window.location.assign("n_renewal.aspx");

        })
        .error(function (aa) {
            var data = aa
            // ajaxindicatorstop();
            swal("error")
        });


    } else {
        swal("Cancelled", "Action Canceled :)", "error");
    }
});



        // alert(events[0].User_Status.online_id )

    }

    var Encrypt = {
        vid: "1",
        vid2: "Fresh"
    }


    $http({
        method: 'POST',
        // url: 'http://88.150.164.30/CLD/Handlers/GetData2.ashx'
        url: serviceBasePatent + 'Handlers/GetData2.ashx',
        transformRequest: function (obj) {
            var str = [];
            for (var p in obj)
                str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
            return str.join("&");
        },
        data: Encrypt,
        headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });







    //When you have entire dataset



}]);


app.controller('myController2', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.BranchCollect = [];
    $scope.itemsPerPage = 10;
    $scope.currentPage = 0;
    $scope.items = [];
    $scope.isDisabled = false;
    var url3 = 'http://localhost:55482/Handlers/GetRegistration2.ashx';

    // var url3 = ' http://localhost:21936/home/GetAgent';

    var Encrypt = {
        vid: "1",
        vid2: "Invalid"
    }


    $http({
        method: 'POST',
        // url: 'http://88.150.164.30/CLD/Handlers/GetData2.ashx'
        url: serviceBasePatent + 'Handlers/GetData2.ashx',
        transformRequest: function (obj) {
            var str = [];
            for (var p in obj)
                str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
            return str.join("&");
        },
        data: Encrypt,
        headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });







    //When you have entire dataset



}]);

app.controller('myController3', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.BranchCollect = [];
    $scope.itemsPerPage = 10;
    $scope.currentPage = 0;
    $scope.items = [];
    $scope.isDisabled = false;
    var url3 = 'http://localhost:55482/Handlers/GetRegistration2.ashx';

    // var url3 = ' http://localhost:21936/home/GetAgent';

    var Encrypt = {
        vid: "2",
        vid2: "Valid"
    }


    $http({
        method: 'POST',
        // url: 'http://88.150.164.30/CLD/Handlers/GetData2.ashx'
        url: serviceBasePatent + 'Handlers/GetData2.ashx',
        transformRequest: function (obj) {
            var str = [];
            for (var p in obj)
                str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
            return str.join("&");
        },
        data: Encrypt,
        headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });







    //When you have entire dataset



}]);




app.controller('myController5', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.BranchCollect = [];
    $scope.itemsPerPage = 10;
    $scope.currentPage = 0;
    $scope.items = [];
    $scope.isDisabled = false;
    var url3 = 'http://localhost:55482/Handlers/GetRegistration2.ashx';

    // var url3 = ' http://localhost:21936/home/GetAgent';

    var Encrypt = {
        vid: "2",
        vid2: "Refused"
    }


    $http({
        method: 'POST',
        // url: 'http://88.150.164.30/CLD/Handlers/GetData2.ashx'
        url: serviceBasePatent + 'Handlers/GetData2.ashx',
        transformRequest: function (obj) {
            var str = [];
            for (var p in obj)
                str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
            return str.join("&");
        },
        data: Encrypt,
        headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
    }).success(function (data, status, headers, config) {
        var dd = data;

        $scope.itemsByPage = 50;
        $scope.ListAgent = data;
        $scope.displayedCollection = [].concat($scope.ListAgent);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });







    //When you have entire dataset



}]);








