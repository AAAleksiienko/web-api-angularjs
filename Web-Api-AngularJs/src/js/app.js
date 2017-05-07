var myApp = angular.module('myApp', ['ngRoute','ngCookies']);
myApp.config(function($routeProvider){
        $routeProvider.when('/user_main_page',
            {
                templateUrl:'js/views/userMainPage.html',
                controller:'productController'
            });
        $routeProvider.when('/main',
            {
                templateUrl:'js/views/MainPage.html',
                controller:'registrationController'
            });
        $routeProvider.when('/registration',
            {
            templateUrl:'js/views/registration.html',
            controller:'registrationController'
            });
    $routeProvider.otherwise({redirectTo: 'main'});
    });