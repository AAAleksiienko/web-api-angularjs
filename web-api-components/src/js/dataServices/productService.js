(function () {
    'use strict';

    var myApp = angular.module('myApp');
    myApp.factory('productService', ['$http', function($http) {

        var pub = {
            getProducts: function () {
                return $http.get('http://localhost:20613/api/product').then(function (res) {
                    return res.data; });
            },
            deleteProduct: function (id) {
                return $http.delete('http://localhost:20613/api/product/' + id);
            },
            addProduct: function (product) {
                return $http({
                    url: 'http://localhost:20613/api/product',
                    method: "POST",
                    data: product
                })
            },
            editProduct: function (product) {
                return $http({
                    url: 'http://localhost:20613/api/product/' + product.Id,
                    method: "PUT",
                    data: product
                }).then(function (res) {
                    return res.data;
                })
            }
        };
        return pub;
    }]);
})();

