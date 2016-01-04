angular.module('bookEditApp').controller('authorListCtrl', ['$scope', 'authorService', function ($scope, authorService) {

    $scope.data = authorService;

    $scope.addAuthor = function () {
        authorService.addAuthor().then(
            function () {
                
                //success
            },
            function () {
                $scope.author = {};
                //error
            })
    };

    $scope.deleteAuthor = function (id) {
        authorService.deleteAuthor(id).then(
            function () {
                //success
            },
            function () {
                //error
            })
    };

    authorService.getAuthors().then(
        function () {
            //success
        },
        function () {
            //error
        })
        .then(function () {
            //anyway
        });

}]);