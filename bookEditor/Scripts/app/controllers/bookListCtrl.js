angular.module('bookEditApp').controller('bookListCtrl', ['$scope', 'bookService', '$location', 'notificationService', function ($scope, bookService, $location, notificationService) {
    $scope.data = bookService;

    $scope.notification = {};
    notificationService.init($scope.notification);

    $scope.hideNotificationPanel = function () {
        notificationService.hideNotification($scope.notification);
    };

    $scope.deleteBook = function (bookId) {
        bookService.deleteBook(bookId).then(
            function() {
                notificationService.showSuccessMessage("Book was deleted.", $scope.notification);
            },
            function () {
                notificationService.showErrorMessage("Book was not deleted, due to server problems. Pleasy try later.", $scope.notification);
            });
    };

    $scope.editBook = function (bookId) {
        notificationService.hideNotification($scope.notification);
        $location.url('/editBook/' + bookId)
    };

    $scope.addBook = function () {
        notificationService.hideNotification($scope.notification);
        $location.url('/addBook')
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