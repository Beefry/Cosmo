angular.module('formbuilder')
	.directive('formbuilder',function(){
		return {
			templateUrl:'/Templates/Builder.htm',
			restrict:'E',
			scope: {
				FormBuilderID: "@id"
			},
			controllerAs: 'Builder',
			controller: ['$scope','$window','$timeout','templateAPI',function($scope,$window,$timeout,templateAPI){
				var builder = this;
				
				$scope.showSuccess = false;
				$scope.successMessage = "";
				$scope.showError = false;
				$scope.errorMessage = "";
				$scope.model = new Template();
				$scope.newFieldType = "";

				$scope.testInfo = function() {
					$scope.showSuccess = true;
					$scope.successMessage = "Your form template was saved sucessfully!";
					$timeout(function(){
						$scope.showSuccess = false;
					},3000);
				};

				$scope.addField = function(section) {
					try {
						var newField = new Field(section);
						section.Fields.push(newField);
					} catch (error) {
						//handle error message
						throw error;
						delete newField;
					}
					section.newFieldType = "";
				};

				$scope.removeField = function(section,field) {
					//Do confirmation here.
					section.Fields = section.Fields.filter(function(element) {
						return element !== field;
					});
				};

				$scope.addNewOption = function(field) {
					//for debug only consolidate later
					var newOption = new Option(field);
					field.Options.push(newOption);
				};

				$scope.removeOption = function(field,option) {
					field.Options = field.Options.filter(function(elem){
						return elem !== option;
					});
				};

				$scope.addSection = function() {
					$scope.model.Sections.push(new Section($scope.model));
				}

				$scope.removeSection = function(section) {
					$scope.model.Sections = $scope.model.Sections.filter(function(currSection) {
						return currSection != section;
					})
				}

				$scope.saveForm = function() {
					for(var i = 0; i < $scope.model.Sections.length-1; i++) {
						delete $scope.model.Sections[i].newFieldType;
					}
					$scope.model.Sections.map(function(section,sectionIndex) {
						section.SortOrder = sectionIndex;
						section.Fields.map(function(field,fieldIndex) {
							field.SortOrder = fieldIndex;
						})
					});
					templateAPI.save($scope.model,function(data) {
						console.log(data);
						if(data.result == "success") {
							$scope.showSuccess = true;
							$scope.successMessage = "Your form template was saved sucessfully!";
							$timeout(function(){
								$scope.showSuccess = false;
							},3000);
						} else if (data.result == "error") {
							$scope.showError = true;
							$scope.errorMessage = "Your form template was saved sucessfully!";
							$timeout(function(){
								$scope.showError = false;
							}, 1000);
						} else {
							console.log("Else");
						}
					});
				};

				$scope.hasOptions = function (type) {
					switch(type) {
						case 'textbox':
						case 'textarea':
						case 'text':
							return false;
						case 'select':
						case 'checkbox':
						case 'radio':
							return true;
						case '':
							return false;
							break;
						default:
							return false;
					}
				};

				// if(typeof $scope.FormBuilderID != "undefined") {
				// }
				if($scope.FormBuilderID != "null") {
					templateAPI.get($scope.FormBuilderID,function(data) {
						$scope.model = data;
					});
				}
			}]
		};
	});