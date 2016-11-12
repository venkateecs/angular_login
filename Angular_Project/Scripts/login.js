/// <reference path="angular.min.js" />
var app = angular.module('my_app', ['ngCookies','ngStorage']);
app.controller('my_ctrl', function ($scope, $http, $rootScope,$cookieStore,$localStorage) {
    $scope.ruser = { "user_name": "", "password": "" }
    $scope.guser = { "user_name": "", "password": "" }
    $scope.user = { "user_name": "", "password": "" }
    

    $http.get("/api/UserMaster").then(function (response) {
        $scope.guser = response.data;
      }
    )
    $scope.save = function () {
        var count = 0;
        angular.forEach($scope.guser, function (value, key) {

            if (value.user_name == $scope.ruser.user_name) {

                alert("Record Already exists");
                count = 1;
            }       
        })
        
        if (count == 0) {
            //$http.post("/api/UserMaster",{ "user_name": $scope.ruser.user_name.toUpperCase(), "password": $scope.ruser.password.toUpperCase()}).success(function (data) {
            $http.post("/api/UserMaster", $scope.ruser).success(function (data) {
                alert(data);
                //$scope.ruser = { "user_name": "", "password": "" };
                location.href = "LoginPage.html";
            })
        }
        
    }

    

    $scope.user_submit = function () {
        var count = 0;               
        angular.forEach($scope.guser, function (value, key, $cookieStore) {
            if (value.user_name == $scope.user.user_name && value.password == $scope.user.password) {
               count = 1;               
                //$window.alert($cookieStore.get('Name'));
                //$localStorage.message = "Hello World";
                //$scope.message = $localStorage.message;
                //alert($scope.message);
               // location.href = "HomePage.html";
                
            }            

        })

        if (count == 1) {
            $cookieStore.put("user_name", $scope.user.user_name);            
            //alert($localStorage.name_user);
            location.href = "HomePage.html";            
            $scope.cookie_username = $cookieStore.get("user_name");            
        }

        if (count == 0) {
            alert("Please Enter Correct UserName and Password");
        }
    }

    $scope.register = function () {
        location.href = "Register.html";
    }
})