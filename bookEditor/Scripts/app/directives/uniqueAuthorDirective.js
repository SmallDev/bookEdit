angular.module('bookEditApp').directive('uniqueAuthor',  function() {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function(scope, element, attrs, ctrl) {
            scope.$watch(attrs.ngModel, function (value) {
                var author = null;
                $.each(scope.data.authors, function (i, item) {
                    if (item.firstName == scope.data.author.firstName &&
                        item.lastName == scope.data.author.lastName &&
                        item.patronymicName == scope.data.author.patronymicName
                        )
                    {
                        author = item;
                        return false;
                    };
                })
                if (author) {
                    scope.authorForm.firstName.$setValidity('uniqueAuthor', false);
                    scope.authorForm.lastName.$setValidity('uniqueAuthor', false);
                    scope.authorForm.patronymicName.$setValidity('uniqueAuthor', false);
                } else {
                    scope.authorForm.firstName.$setValidity('uniqueAuthor', true);
                    scope.authorForm.lastName.$setValidity('uniqueAuthor', true);
                    scope.authorForm.patronymicName.$setValidity('uniqueAuthor', true);
                };
            });
        }
    };
});