angular.module('bookEditApp').factory('bookService', ['$http', '$q', function ($http, $q) {
    var _books = [];

    var _getBooks = function () {
        var deferred = $q.defer();

        $http.get("/api/books")
        .then(function (result) {
            angular.copy(result.data, _books);
            deferred.resolve();
        },
        function () {
            deferred.reject();
        });

        return deferred.promise;
    };

    var _deleteBook = function (id) {
        var book = null;
        $.each(_books, function (i, item) {
            if (item.id == id) {
                book = item;
                return false;
            };
        })

        if (book) {
            _books.splice(_books.indexOf(book), 1);
        }
    };

    var _getBook = function (bookId) {
        var deferred = $q.defer();

        var book = _findBook(bookId)
        if (book) {
            deferred.resolve(book);
        }
        else {
            deferred.reject();
        }

        return deferred.promise;
    };

    var _updateBook = function (book) {
        var deferred = $q.defer();

        $http.put("/api/books", book)
        .then(function () {
            deferred.resolve();
        },
        function () {
            deferred.reject();
        });

        return deferred.promise;
    };

    var _addBook = function (book) {
        var deferred = $q.defer();

        $http.post("/api/books", book)
        .then(function () {
            deferred.resolve();
        },
        function () {
            deferred.reject();
        });

        return deferred.promise;
    };

    function _findBook(id) {
        var book = null;

        $.each(_books, function (i, item) {
            if (item.id == id) {
                book = item;
                return false;
            };
        })

        return book;
    };

    return {
        books: _books,
        getBooks: _getBooks,
        getBook: _getBook,
        deleteBook: _deleteBook,
        updateBook: _updateBook,
        addBook: _addBook
    };
}])