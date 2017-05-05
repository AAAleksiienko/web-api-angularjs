(function () {
    'use strict';

    var myApp = angular.module('myApp');
    myApp.factory('loginService', ['$http', function($http) {

        var pub = {
            addUser: function (user) {
                return $http({
                    url: 'http://localhost:20613/api/user',
                    method: "POST",
                    data: user
                }).then(function (res) {
                    return res.data;
                }, function errorCallback(res) {
                    console.log(res);
                    return res.data;
                })
            },
            loginUser: function (user) {
                return $http({
                    url: 'http://localhost:20613/api/user/login',
                    method: "POST",
                    data: user
                }).then(function (res) {
                    return res.data;
                }, function errorCallback(response) {
                    return response.data;
                });
            }
        };
        return pub;
    }]);
})();

