angular.module('bookEditApp').directive('serverSideValidation', function ($http) {
    var toId;
    var _isbnValidationType = 0;

    var _validatuinResult = {
        Valid: 0,
        NotValid: 1,
        UsounsupportedValidationType: 2
    }

    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, elem, attr, ctrl) {
            var validationType;
            if (attr.serverSideValidation == "isbn") {
                validationType = _isbnValidationType;
            }
            else {
                return;
            };

            scope.$watch(attr.ngModel, function (value) {

                if (toId) clearTimeout(toId);
                toId = setTimeout(function () {

                    $http.post('/api/validation', { ValidationType: validationType, DataToValidate: value }).success(function (data) {
                        if (data == _validatuinResult.Valid) {
                            ctrl.$setValidity('serverSideValidation', true);
                        }
                        else if (data == _validatuinResult.NotValid) {
                            ctrl.$setValidity('serverSideValidation', false);
                        }
                    });
                }, 200);
            })
        }
    }
});