angular.module('bookEditApp').controller('bookListCtrl', ['$scope', 'bookService', '$location', function ($scope, bookService, $location) {
    $scope.data = bookService;

    $scope.deleteBook = function (bookId) {
        bookService.deleteBook(bookId);
    };

    $scope.editBook = function (bookId) {
        $location.url('/editBook/' + bookId)
    };

    bookService.getBooks().then(
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