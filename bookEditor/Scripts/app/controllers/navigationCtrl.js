angular.module('bookEditApp').controller('navigationCtrl', ['$scope', '$location', 'notificationService', function ($scope, $location, notificationService) {
    $scope.notification = {};
    notificationService.init($scope.notification);

    $scope.navigateToBooks = function () {
        notificationService.hideNotification($scope.notification);
        $location.url("/books");
    };

    $scope.navigateToAuthors = function () {
        notificationService.hideNotification($scope.notification);
        $location.url("/authors");
    };
}]);