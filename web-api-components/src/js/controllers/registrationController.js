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
        if(registerUserForm.$valid){
            loginService.addUser(user).then(function (data) {
                //Костыль =)
                console.log(data.Name);
                if(data.Name === undefined){

                    $ctrl.errorMsg = true;
                }else
                {
                    //success
                }
            });
        }
    }
}]);