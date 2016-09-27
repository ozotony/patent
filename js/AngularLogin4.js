var app = angular.module('myModule', ['smart-table', 'angular-loading-bar', 'ngCsv']);
var serviceBaseIpo = 'http://ipo.cldng.com/';

var serviceBasePatent = 'http://pt.cldng.com/';
app.filter('offset', function () {
    return function (input, start) {
        start = parseInt(start, 10);
        return input.slice(start);
    };
});


var serviceBase = serviceBasePatent + '';

app.controller('myController3', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.Export = function () {
        alasql('SELECT * INTO XLSX("patent.xlsx",{headers:true}) FROM ?', [$scope.ListAgent]);
    };

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
        url: serviceBase + 'Handlers/GetData2.ashx',
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

app.controller('myController4', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {
    $scope.Export = function () {
        alasql('SELECT * INTO XLSX("patent.xlsx",{headers:true}) FROM ?', [$scope.ListAgent2]);
    };
    $scope.BranchCollect = [];
    $scope.itemsPerPage = 10;
    $scope.currentPage = 0;
    $scope.items = [];
    $scope.isDisabled = false;
    var url3 = 'http://localhost:55482/Handlers/GetRegistration2.ashx';

    // var url3 = ' http://localhost:21936/home/GetAgent';

    var Encrypt = {
        vid: "3",
        vid2: "Approved"
    }


    $http({
        method: 'POST',
        // url: 'http://88.150.164.30/CLD/Handlers/GetData2.ashx'
        url: serviceBase + 'Handlers/GetData2.ashx',
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


    $http({
        method: 'POST',
        // url: 'http://88.150.164.30/CLD/Handlers/GetData2b.ashx'
        url: serviceBase + 'Handlers/GetData2b.ashx',
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
        $scope.ListAgent2 = data;
        $scope.displayedCollection2 = [].concat($scope.ListAgent2);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });







    //When you have entire dataset



}]);


app.controller('myController5', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {
    $scope.Export = function () {
        alasql('SELECT * INTO XLSX("patent.xlsx",{headers:true}) FROM ?', [$scope.ListAgent2]);
    };
    $scope.BranchCollect = [];
    $scope.itemsPerPage = 10;
    $scope.currentPage = 0;
    $scope.items = [];
    $scope.isDisabled = false;
    var url3 = 'http://localhost:55482/Handlers/GetRegistration2.ashx';

    // var url3 = ' http://localhost:21936/home/GetAgent';

    var Encrypt = {
        vid: "3",
        vid2: "Approved"
    }


    $http({
        method: 'POST',
        // url: 'http://88.150.164.30/CLD/Handlers/GetData2.ashx'
        url: serviceBase + 'Handlers/GetData2.ashx',
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


    $http({
        method: 'POST',
        // url: 'http://88.150.164.30/CLD/Handlers/GetData2b.ashx'
        url: serviceBase + 'Handlers/GetData2b.ashx',
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
        $scope.ListAgent2 = data;
        $scope.displayedCollection2 = [].concat($scope.ListAgent2);
    }).error(function (data, status, headers, config) {
        alert("error " + data)
        $scope.message = 'Unexpected Error';
    });







    //When you have entire dataset



}]);








