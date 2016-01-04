angular.module('bookEditApp').controller('editBookCtrl', ['$scope', 'bookService', '$routeParams', '$location', function ($scope, bookService, $routeParams, $location) {
    $scope.pageName = "Edit Book";
    $scope.book = {};
    
    bookService.getBook($routeParams.id)
        .then(function (book) {
            $scope.book = book;
        },
        function () {
            //error;
        });

    $scope.deleteAuthor = function (id) {
        var author = null;
        $.each($scope.book.authors, function (i, item) {
            if (item.id == id) {
                author = item;
                return false;
            };
        })

        if (author) {
            $scope.book.authors.splice($scope.book.authors.indexOf(author), 1);
        }
    };

    $scope.cancel = function() {
        $location.url("/books")
    };

    $scope.save = function () {
        bookService.updateBook($scope.book)
    };
}]);