'use strict';

savita.controller('ServersController',
    function ($scope, $rootScope, $location, serverInfo) {

        $scope.servers = serverInfo.jsonp();

    }
);