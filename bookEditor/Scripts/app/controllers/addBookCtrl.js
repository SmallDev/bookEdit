angular.module('bookEditApp').controller('addBookCtrl', ['$scope', 'bookService', '$location', 'Upload', 'notificationService', function ($scope, bookService, $location, Upload, notificationService) {
    $scope.pageName = "Add Book";
    $scope.book = {};
    $scope.bookHasImage = false;

    $scope.notification = {};
    notificationService.init($scope.notification);

    $scope.hideNotificationPanel = function () {
        notificationService.hideNotification($scope.notification);
    };

    $scope.cancel = function () {
        notificationService.hideNotification($scope.notification);
        $location.url("/books")
    };

    $scope.save = function () {
        bookService.addBook($scope.book)
        .then(function (book) {
            notificationService.setSuccessInitMessage("Book was addded successfully.");
            $location.url("/books");
        },
        function () {
            notificationService.setErrorInitMessage("Book was not addded, because of some server errors.");
        });
    };

    $scope.uploadFiles = function (file, errFiles) {

        var errFile = errFiles && errFiles[0];
        if (errFile) {
            if (errFile.$error == "maxSize") {
                notificationService.showErrorMessage("Image upload error! File size should be equal or smaller then " + errFile.$errorParam, $scope.notification);
            } else if (errFile.$error == "pattern") {
                notificationService.showErrorMessage("Image upload error! File could have only .jpeg or .jpg extensions.", $scope.notification);
            }
        }

        if (file) {
            file.upload = Upload.upload({
                url: '/api/images',
                data: { file: file }
            });

            file.upload.then(function (response) {
                $scope.book.picture = { img: response.data.img };
                $scope.bookHasImage = true;
                notificationService.showSuccessMessage("New image uploaded successfully.", $scope.notification);
            }, function () {
                notificationService.showErrorMessage("Image was not uploaded due to some server problems. Please try again later.", $scope.notification);
            });
        }
    };

}]);