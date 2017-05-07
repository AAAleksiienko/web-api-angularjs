var myApp = angular.module('myApp');
'use strict';
myApp.controller('authorizationController',['$rootScope', '$http', '$scope', '$location', '$document', 'loginService','$cookies','$cookieStore',
    function ($rootScope, $http, $scope, $location, $document, loginService, $cookies, $cookieStore) {

    var $ctrl = this;
    $ctrl.animationsEnabled = false;
    $ctrl.errorMsg = false;
    $rootScope.IsLogged = false;

     //   $cookies.remove("IsLogged");

    $scope.authorization = function (user, authorizationForm) {
        if(authorizationForm.$valid) {
            loginService.loginUser(user).then(function (data) {

                if (data.Id != undefined) {
                    $rootScope.IsLogged = true;
                    $cookies.put("IsLogged","true");
                    $location.path('/user_main_page');
                } else {
                    $ctrl.open();
                }
            })
        }
    };

    $scope.logout = function () {
        $cookies.put("IsLogged","false");
        $rootScope.IsLogged = false;

        $location.path('/main');
    };

    $ctrl.open = function (size, parentSelector) {
        var parentElem = parentSelector ?
            angular.element($document[0].querySelector('.modal-demo ' + parentSelector)) : undefined;
        $uibModal.open({
            animation: $ctrl.animationsEnabled,
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: 'js/views/errorModalWindow.html',
            controller: 'errorModal',
            controllerAs: '$ctrl',
            size: size,
            appendTo: parentElem,
            resolve: {
            }
        })};
}]);