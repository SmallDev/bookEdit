angular.module('bookEditApp').controller('bookListCtrl', ['$scope', 'bookService', '$location', 'notificationService', '$cookies', function ($scope, bookService, $location, notificationService, $cookies) {
    $scope.data = bookService;
    $scope.booksListLoaded = false;

    var orderByTitle = "title";
    var orderByPublishYear = "publishYear";

    function setCookie(name, value) {
        var expireDate = new Date();
        expireDate.setDate(expireDate.getDate() + 10);
        $cookies.put(name, value, { 'expires': expireDate });
    }

    $scope.notification = {};
    notificationService.init($scope.notification);

    $scope.hideNotificationPanel = function () {
        notificationService.hideNotification($scope.notification);
    };

    $scope.orderByTitle = function () {
        $scope.titleSortButton = "btn-primary";
        $scope.yearSortButton = "btn-default";
        setCookie('bookEditAppSort', orderByTitle);
        $scope.orderCategory = orderByTitle;
    };

    $scope.orderByPublishYear = function () {
        $scope.titleSortButton = "btn-default";
        $scope.yearSortButton = "btn-primary";
        setCookie('bookEditAppSort', orderByPublishYear);
        $scope.orderCategory = orderByPublishYear;
    };

    // init sort order
    var sortCookie = $cookies.get('bookEditAppSort'); 
    if (sortCookie) {
        switch (sortCookie) {
            case orderByTitle:
                $scope.orderByTitle();
                break;
            case orderByPublishYear:
                $scope.orderByPublishYear();
                break;

            default:
                $scope.orderByTitle();
        }
    } else {
        $scope.orderByTitle();
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

    $scope.collapseBook = function (book) {
        book.collapsed = true;
    };

    $scope.extendBook = function (book) {
        book.collapsed = false;
    };

    $scope.selectCategory = function (selectedCategory) {
        console.log("Hello from: " + selectedCategory);
    };

    bookService.getBooks().then(
        function () {
            $scope.booksListLoaded = true;
        },
        function () {
            notificationService.showErrorMessage("Can't get books list. Pleasy try later.", $scope.notification);
            $scope.booksListLoaded = true;
        })
        .then(function () {
            //anyway
        });
    
}]);