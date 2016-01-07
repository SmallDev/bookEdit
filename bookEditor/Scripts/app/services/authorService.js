angular.module('bookEditApp').factory('authorService', ['$http', '$q', function ($http, $q) {
    var _authors = [];
    var _author = {};

    var _getAuthors = function () {
        var deferred = $q.defer();

        $http.get("/api/authors")
            .then(function (result) {
                angular.copy(result.data, _authors);
                deferred.resolve();
            }, function () {
                deferred.reject();
            })

        return deferred.promise;
    };
    
    var _addAuthor = function () {
        var deferred = $q.defer();

        $http.post("/api/authors", _author)
            .then(function (result) {
                if (!result.data.patronymicName) {
                    result.data.patronymicName = "";
                }
                _authors.push(result.data);
                clearAuthorInfo();

                deferred.resolve();
            }, function () {
                deferred.reject();
            })

        return deferred.promise;
    };

    var _deleteAuthor = function (id) {
        var deferred = $q.defer();

        var author = null;
        $.each(_authors, function (i, item) {
            if (item.id == id) {
                author = item;
                return false;
            };
        })

        if (author) {
            $http.delete("/api/authors/" + author.id)
                .then(function () {
                    _authors.splice(_authors.indexOf(author), 1);
                    deferred.resolve();
                }, function () {
                    deferred.reject();
                })
        }
        else {
            deferred.reject();
        }

        return deferred.promise;
    };

    function clearAuthorInfo() {
        _author.firstName = '';
        _author.lastName = '';
        _author.patronymicName = '';
    }

    return {
        author: _author,
        authors: _authors,
        getAuthors: _getAuthors,
        addAuthor: _addAuthor,
        deleteAuthor: _deleteAuthor
    };
}])