(function () {
    'use strict';

    var myApp = angular.module('myApp');
    myApp.factory('loginService', ['$http', function($http, $localeStorage) {

        var pub = {
            addUser: function (user) {
                return $http({
                    url: 'http://localhost:32549/api/user',
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
                var request_body = "grant_type=password&username=" + user.name + "&password=" + user.password;
                return $http({
                    url: 'http://localhost:32549/token',
                    method: "POST",
                    data: request_body
                }).then(function (res) {
                    return res.data;
                }, function errorCallback(response) {
                    return response.data;
                });
            },
            registerUser: function (user) {
                return $http({
                    url: 'http://localhost:32549/api/account/register',
                    method: "POST",
                    data: user
                }).then(function (res){
                    return res.data;
                }, function errorCallback(response) {
                    return response.data;
                });
            }
        };
        return pub;
    }]);
})();
