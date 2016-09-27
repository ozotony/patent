var app = angular.module('myModule', ['smart-table', 'angular-loading-bar', 'ngModal']);
var serviceBaseIpo = 'http://88.150.164.30/EinaoTestEnvironment.IPO/';

var serviceBasePatent = 'http://88.150.164.30/EinaoTestEnvironment.Patent/';
app.filter('offset', function () {
    return function (input, start) {
        start = parseInt(start, 10);
        return input.slice(start);
    };
});





app.controller('myController8', ['$scope', '$http', '$rootScope','$interval', function ($scope, $http, $rootScope, $interval) {



    var serviceBase6 = serviceBasePatent + 'Handlers/GetEmailCount4.ashx';
    var Encrypt6 = {
        vid: "3",
        vid2: "E_Contact"

    }


    $http({
        method: 'POST',
        url: serviceBase6,
        transformRequest: function (obj) {
            var str = [];
            for (var p in obj)
                str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
            return str.join("&");
        },
        data: Encrypt6,
        headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
    })
        .success(function (response) {
            // var a = parseInt(response);
            $rootScope.result = response;


        })
        .error(function (response) {
            var dd = response;
            //  ajaxindicatorstop();
        });

    $scope.add2 = function (dd) {

        for (var key in $rootScope.result) {

            if ($rootScope.result[key] == dd.Validation) {

                return true;
            }


        }





    }
    $scope.BranchCollect = [];
    $scope.itemsPerPage = 10;
    $scope.currentPage = 0;
    $scope.items = [];
    $scope.isDisabled = false;
    var Encrypt2 = {
        vid: "3",
        vid2: "E_Contact"
    }

    var serviceBase3 = serviceBasePatent + 'Handlers/GetEmailCount2.ashx';
    $(document).ready(function () {

       
        $http({
            method: 'POST',
            url: serviceBase3,
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: Encrypt2,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
        })
            .success(function (response) {
                if (response != "null") {
                    $scope.news = [
      { "firstName": response, "link": "../x_unit/profile4.aspx" }
                    ]

                }
           

            })
            .error(function (response) {
                //  ajaxindicatorstop();
            });


        //   alert(xname)

    });

    $scope.conf = {
        news_length: false,
        news_pos: 400, // the starting position from the right in the news container
        news_margin: 20,
        news_move_flag: true
    };

    $scope.get_news_right = function (idx) {
        if ($scope.conf.news_pos == '0') {
            $scope.conf.news_pos = 400;
        }


        var $right = $scope.conf.news_pos;
        for (var ri = 0; ri < idx; ri++) {
            if (document.getElementById('news_' + ri)) {
                $right += $scope.conf.news_margin + angular.element(document.getElementById('news_' + ri))[0].offsetWidth;
            }
        }
        return $right + 'px';
    };

    $scope.news_move = function () {
        if ($scope.conf.news_move_flag) {
            $scope.conf.news_pos--;
            if (angular.element(document.getElementById('news_0'))[0].offsetLeft > angular.element(document.getElementById('news_strip'))[0].offsetWidth + $scope.conf.news_margin) {
                var first_new = $scope.news[0];
                $scope.news.push(first_new);
                $scope.news.shift();
                $scope.conf.news_pos += angular.element(document.getElementById('news_0'))[0].offsetWidth + $scope.conf.news_margin;
            }
        }
    };

    $interval($scope.news_move, 50);

    var Encrypt4 = {
        vid: "3",
        vid2: "E_Contact"
    }

    var serviceBase = serviceBasePatent + 'Handlers/GetEmailCount.ashx';
    $(document).ready(function () {


        $http({
            method: 'POST',
            url: serviceBase,
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: Encrypt4,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
        })
            .success(function (response) {
                var dd = [];
                var a = parseInt(response);
                if (a > 0) {
                    $rootScope.xvv = true;

                }
                $rootScope.vcount = response



            })
            .error(function (response) {
                //  ajaxindicatorstop();
            });


        //   alert(xname)

    });

    $scope.EditRow = function (dd) {
        $scope.VEmail = "";
        var url3 = 'http://localhost:55482/Handlers/GetRegistration2.ashx';

        // var url3 = ' http://localhost:21936/home/GetAgent';

        var Encrypt = {
            vid: dd.log_staff
        }


        $http({
            method: 'POST',
          //  url: 'http://localhost:55482/Handlers/GetComment.ashx',
            url: serviceBasePatent + 'Handlers/GetComment.ashx',
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: Encrypt,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8;' }
        }).success(function (data, status, headers, config) {
            $scope.dialogShown = true;
            var dd = data;

            $scope.itemsByPage = 50;
            $scope.ListAgent2 = data;
            $scope.displayedCollection2 = [].concat($scope.ListAgent2);
        }).error(function (data, status, headers, config) {
            alert("error " + data)
            $scope.message = 'Unexpected Error';
        });





    }


    var url3 = 'http://localhost:55482/Handlers/GetRegistration2.ashx';

    // var url3 = ' http://localhost:21936/home/GetAgent';

    var Encrypt = {
        vid: "3",
        vid2: "E_Contact"
    }


    $http({
        method: 'POST',
       // url: 'http://localhost:55482/Handlers/GetData.ashx',
        url: serviceBasePatent + 'Handlers/GetData.ashx',
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







