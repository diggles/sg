savita.factory('groupInfo', function ($resource, $q) {
	return $resource(apiserver + 'api/group', {}, {
		jsonp: { method: 'JSONP', params: {callback: 'JSON_CALLBACK'}, isArray: false } 
		
	});
});