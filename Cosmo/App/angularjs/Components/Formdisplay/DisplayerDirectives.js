angular.module('formdisplayer')
	.directive('formdisplayer',function(){
		return {
			templateUrl:'/Templates/Displayer.htm',
			restrict:'E',
			scope: {
				FormID: "@fid",
				TemplateID: "@tid"
			},
			controllerAs: 'Displayer',
			controller: ['$scope','formAPI',function($scope,formAPI){
				var displayer = this;
				var mode = "";

				console.log(typeof $scope.TemplateID);
				console.log(typeof $scope.FormID);

				if(typeof $scope.FormID != "undefined") {
					formAPI.get($scope.FormID,function(data) {
						$scope.model = data;
						mode = "view";
					});
				} else if(typeof $scope.TemplateID != "undefined") {
					formAPI.newForm($scope.TemplateID,function(data) {
						console.log(data);
						$scope.model = data;
						mode = "new";
					});
				}

				$scope.saveForm = function() {
					formAPI.save($scope.model,function(data){
						console.log(data);
					});
				};
			}]
		}
	})
	.directive('formeditor',function(){
		return {
			templateUrl:'/Templates/Displayer.htm',
			restrict:'E',
			scope: {
				FormID: "@fid",
				TemplateID: "@tid"
			},
			controllerAs: 'Displayer',
			controller: ['$scope','formAPI',function($scope,formAPI){
				var displayer = this;
				var mode = "";
				console.log($scope.TemplateID);

				if($scope.FormID != "") {
					formAPI.get($scope.FormID,function(data) {
						$scope.model = data;
						mode = "edit";
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