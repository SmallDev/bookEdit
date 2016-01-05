angular.module('bookEditApp').controller('authorListCtrl', ['$scope', 'authorService', 'notificationService', function ($scope, authorService, notificationService) {

    $scope.data = authorService;

    $scope.notification = {};
    notificationService.init($scope.notification);

    $scope.hideNotificationPanel = function () {
        notificationService.hideNotification($scope.notification);
    };

    $scope.addAuthor = function () {
        authorService.addAuthor().then(
            function () {
                
                notificationService.showSuccessMessage("Author was added sucessfully", $scope.notification);
            },
            function () {
                $scope.author = {};
                notificationService.showErrorMessage("Can't add author for some reason. Pleasy try later.", $scope.notification);
            })
    };

    $scope.deleteAuthor = function (id) {
        authorService.deleteAuthor(id).then(
            function () {
                notificationService.showSuccessMessage("Author was deleted successfully.", $scope.notification);
            },
            function () {
                notificationService.showErrorMessage("Can't delet author for some reason. Pleasy try later.", $scope.notification);
            })
    };

    authorService.getAuthors().then(
        function () {
            //success
        },
        function () {
            notificationService.setErrorInitMessage("Can't get authors list.");
            $location.url("/books");
        })
        .then(function () {
            //anyway
        });

}]);