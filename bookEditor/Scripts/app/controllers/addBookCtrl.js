angular.module('bookEditApp').controller('addBookCtrl', ['$scope', 'bookService', '$location', function ($scope, bookService, $location) {
    $scope.pageName = "Add Book";
    $scope.book = {};

    $scope.cancel = function () {
        $location.url("/books")
    };

    $scope.save = function () {
        bookService.addBook($scope.book)
        .then(function (book) {
            // success
            $location.url("/books");
        },
        function () {
            //error;
        });
    };
}]);