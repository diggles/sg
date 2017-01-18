savita.factory('serverInfo', function ($resource, $q) {
	return $resource(apiserver + 'api/server', {}, {
		jsonp: { method: 'JSONP', params: {callback: 'JSON_CALLBACK'}, isArray: true } 
		
	});
});