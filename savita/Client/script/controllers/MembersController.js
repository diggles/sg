'use strict';

savita.controller('MembersController',
    function ($scope, $rootScope, $location, groupInfo) {

        $scope.group = groupInfo.jsonp();

    }
);