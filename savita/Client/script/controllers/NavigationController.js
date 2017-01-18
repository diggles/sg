'use strict';

savita.controller('NavigationController',
    function ($scope, $rootScope, $location) {
	
		$scope.isActive = function (page) {
			var currentRoute = $location.path();
			return page === currentRoute;
		};  
		
    }
);