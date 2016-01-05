angular.module('bookEditApp').controller('addBookCtrl', ['$scope', 'bookService', '$location', 'Upload', function ($scope, bookService, $location, Upload) {
    $scope.pageName = "Add Book";
    $scope.book = {};
    $scope.bookHasImage = false;
    $scope.statusMessage = "";

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

    $scope.uploadFiles = function (file, errFiles) {

        $scope.f = file;
        $scope.errFile = errFiles && errFiles[0];
        if (file) {
            file.upload = Upload.upload({
                url: '/api/images',
                data: { file: file }
            });

            file.upload.then(function (response) {
                $scope.book.picture = { img: response.data.img };
                $scope.bookHasImage = true;
                $scope.statusMessage = "New image uploaded successfully."
            }, function () {
                $scope.statusMessage = "Image was not uploaded due to some server problems. Please try again later."
            });
        }
    };

    $scope.$watch('errFile', function (newVal, oldVal) {
        if (newVal && newVal.hasOwnProperty('$error')) {
            if (newVal.$error == "maxSize") {
                $scope.statusMessage = "Image upload error! File size should be equal or smaller then " + newVal.$errorParam;
            } else if (newVal.$error == "pattern") {
                $scope.statusMessage = "Image upload error! File could have only .jpeg or .jpg extensions.";
            }
        }
    }, true);

}]);