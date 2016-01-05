angular.module('bookEditApp', ['ngRoute', 'ngFileUpload']).config(['$routeProvider',
  function($routeProvider) {
      $routeProvider.
        when('/books', {
            templateUrl: 'templates/book-list.html',
            controller: 'bookListCtrl'
        }).
        when('/authors', {
            templateUrl: 'templates/authors-list.html',
            controller: 'authorListCtrl'
        }).
        when('/addBook', {
            templateUrl: 'templates/book.html',
            controller: 'addBookCtrl'
        }).
        when('/editBook/:id', {
            templateUrl: 'templates/book.html',
            controller: 'editBookCtrl'
        }).
        otherwise({
            redirectTo: '/books'
        });
  }]);
