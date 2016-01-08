angular.module('bookEditApp').controller('addAuthorModalCtrl', ['$scope', 'authorService', 'addedAuthors', function ($scope, authorService, addedAuthors) {
    
    $scope.authors = [];
    $scope.showEmptyListMessage = false;

    authorService.getAuthors().then(
        function () {
            $scope.authors = _.filter(authorService.authors, function (obj) { return !_.findWhere(addedAuthors, obj); });
            if (!$scope.authors || $scope.authors.length == 0) {
                $scope.showEmptyListMessage = true;
            }
        },
        function () {
            scope.closeThisDialog();
        })
        .then(function () {
            //anyway
        });

    $scope.selectAuthor = function (authorToAdd) {
        $scope.closeThisDialog(authorToAdd);
    };
}]);