angular.module('formdisplayer')
	.directive('formdisplayer',function(){
<<<<<<< HEAD
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

				$scope.showSuccess = false;
				$scope.successMessage = "";
				$scope.showError = false;
				$scope.errorMessage = "";

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
						if(data.result == "success") {
							$scope.showSuccess = true;
							$scope.successMessage = "Your form template was saved sucessfully!";
							$timeout(function(){
								$scope.showSuccess = false;
							},3000);
						} else {
							$scope.showError = true;
							$scope.errorMessage = "Your form template was saved sucessfully!";
							$timeout(function(){
								$scope.showError = false;
							}, 1000);
						}
					});
				};
			}]
		}
	})
	.directive('formeditor',function(){
=======
>>>>>>> origin/master
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
<<<<<<< HEAD
				var mode = "";
				console.log($scope.TemplateID);

				if($scope.FormID != "") {
=======

				if(typeof $scope.FormID != "undefined") {
>>>>>>> origin/master
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