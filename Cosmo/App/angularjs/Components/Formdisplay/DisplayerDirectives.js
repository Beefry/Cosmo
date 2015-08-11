angular.module('formdisplayer')
	.directive('formdisplayer',function(){
		return {
			templateUrl:'/Templates/DisplayerEdit.htm',
			restrict:'E',
			scope: {
				FormID: "@fid",
				TemplateID: "@tid"
			},
			controllerAs: 'Displayer',
			controller: ['$scope','formAPI',function($scope,formAPI){
				var displayer = this;

				if(typeof $scope.FormID != "undefined") {
					formAPI.get($scope.FormID,function(data) {
						$scope.model = data;
					});
				} else if(typeof $scope.TemplateID != "undefined") {
					formAPI.newForm($scope.TemplateID,function(data) {
						$scope.model = data;
						console.log($scope.model);
					});
				}

				$scope.saveForm = function() {
					formAPI.save($scope.model,function(data){
						console.log(data);
					});
				};
			}]
		}
	});