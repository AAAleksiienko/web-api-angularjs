var myApp = angular.module('myApp');
'use strict';
myApp.controller('productController',['$rootScope','$location','$scope','$http', '$document', 'productService','$cookies',
function ($rootScope,$location, $scope, $http ,$document, productService, $cookies) {

    var $ctrl = this;
    $ctrl.animationsEnabled = false;

    var modal = document.getElementById('edit-modal-window');
    var btn = document.getElementById("edit-button");
    var span = document.getElementsByClassName("close-edit-modal-window");

    $ctrl.openModal = function (product) {
        modal.style.display = "block";
        var $ctrl = this;
        var _product = angular.extend({}, product);
        var _oldProduct = product;
        _product.Id = product.Id;
        $ctrl.selected = {
            product: _product,
            oldProduct: _oldProduct
        };
    };

    $ctrl.ok = function (products) {
        productService.editProduct(products.product).then(function (res) {
            angular.extend(products.oldProduct, res)
        });
        modal.style.display = "none";
    };

    $ctrl.closeModal = function () {
        modal.style.display = "none";
    };

    window.onclick = function(event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    };

    //Костыль с авторизацией
    if(/*$rootScope.IsLogged == */false){
        //$cookies.get("IsLogged") == "false"
        $location.path('/main');
    }else{
     productService.getProducts().then(function(data) {
         $scope.products = data;
     });
    };


      $scope.delete = function (product) {
        productService.deleteProduct(product.Id).then(function(data){
            $scope.products.splice($scope.products.indexOf(product),1);
          }).then(function (data,status,header,config) {
        });
      };

      $scope.saveForm = function(product, AddProductForm){
          console.log(product);
          console.log(AddProductForm);
       if(AddProductForm.$valid){
           productService.addProduct(product).then(function (res) {
               $scope.products.push(product);
           })
       }
      };
}]);

