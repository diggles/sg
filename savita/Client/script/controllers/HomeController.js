'use strict';

savita.controller('HomeController',
    function ($scope, $rootScope, $location, serverInfo, groupInfo) {

        $scope.servers = serverInfo.jsonp();
        $scope.group = groupInfo.jsonp();

    }
);