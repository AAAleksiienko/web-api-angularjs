var myApp = angular.module('myApp');
'use strict';
myApp.controller('registrationController',['$http', '$scope', '$location', '$document', 'loginService' , function ($http, $scope, $location, $document, loginService) {

    var $ctrl = this;
    $ctrl.animationsEnabled = false;

    $scope.user = {};

    $scope.saveUser = function () {

    };

    $scope.registration = function () {

    };

    $ctrl.open = function () {
        $location.path('/registration');
    };

    $scope.create = function(user,registerUserForm){
        console.log(registerUserForm);
        console.log(user);
        if(registerUserForm.$valid){
            loginService.registerUser(user).then(function (data) {
             /*
                not implemented yet
             if(data.email === undefined){

                    $ctrl.errorMsg = true;
                }else
                {
                    //success
                }*/
            });
        }
    }
}]);