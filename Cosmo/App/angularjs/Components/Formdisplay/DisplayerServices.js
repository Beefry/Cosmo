angular.module('formdisplayer')
.service('formAPI',['$resource',function($resource){
	this.save = function(form,callback) {
		Form = $resource('/API/Form/');
		// console.log(form);
		Form.save(form,function(data){
			callback(data);
		});
	}
	this.get = function(id, callback) {
		Form = $resource("/API/Form/:ID");
		Form.get({ID:id},function(data){
			callback(data);
		});
	};
	this.newForm = function(templateID, callback) {
		Form = $resource("/API/Form/?templateID=:templateID");
		Form.get({templateID:templateID},function(data) {
			callback(data);
		});
	};
}]);