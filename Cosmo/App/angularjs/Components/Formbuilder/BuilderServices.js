angular.module('formbuilder')
.service('templateAPI',['$resource',function($resource){
	this.save = function(form,callback) {
		Form = $resource("/API/Template/");
		// console.log(form);
		Form.save(form,function(data){
			callback(data);
		});
	}
	this.get = function(id, callback) {
		Form = $resource("/API/Template/:ID");
		Form.get({ID:id},function(data){
			callback(data);
		});
	};
}]);