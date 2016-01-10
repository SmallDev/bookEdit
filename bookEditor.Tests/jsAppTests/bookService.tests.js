/// <reference path="../repository/scripts/jasmine.js" />
/// <reference path="../../bookeditor/scripts/angular/angular.js" />
/// <reference path="../../bookeditor/scripts/angular/angular-mocks.js" />
/// <reference path="../../bookeditor/scripts/app/app.js" />
/// <reference path="../../bookeditor/scripts/app/services/bookservice.js" />
/// <reference path="../../bookeditor/scripts/app/modules/angular-route.js" />
/// <reference path="../../bookeditor/scripts/app/modules/ng-file-upload-shim.js" />
/// <reference path="../../bookeditor/scripts/app/modules/ngdialog.js" />
/// <reference path="../../bookeditor/scripts/app/modules/ng-file-upload.js" />
/// <reference path="../../bookeditor/scripts/app/modules/angular-cookies.js" />
/// <reference path="../../bookeditor/scripts/jquery-1.10.2.js" />

describe("bookService Test ->", function () {

    beforeEach(function () {
        module("bookEditApp");
    });

    beforeEach(inject(function ($injector) {
        $httpBackend = $injector.get("$httpBackend");
        $httpBackend.when("GET", "/api/books")
        .respond([
            {
                id: "1",
                title: "tetsTitle1",
                publisher: "testPublisher1",
                isbn: "978-0-00-720354-3",
                numberOfPages: "100",
                publishYear: "1984"
            },
            {
                id: "2",
                title: "tetsTitle2",
                publisher: "testPublisher2",
                isbn: "978-0-00-720354-3",
                numberOfPages: "200",
                publishYear: "2004"
            }
        ]);

        $httpBackend.when("DELETE", "/api/books/1")
        .respond({});


    }));

    afterEach(function () {
        $httpBackend.verifyNoOutstandingExpectation();
        $httpBackend.verifyNoOutstandingRequest();
    });

    it("Can load books", inject(function (bookService) {
        expect(bookService.books).toEqual([])

        $httpBackend.expectGET("/api/books");
        bookService.getBooks();
        $httpBackend.flush();

        expect(bookService.books.length).toEqual(2);

    }));

    it("Can get book by id", inject(function (bookService) {
        expect(bookService.books).toEqual([])

        $httpBackend.expectGET("/api/books");
        bookService.getBooks();
        $httpBackend.flush();

        expect(bookService.books.length).toEqual(2);

        bookService.getBook(2).then(function (result) {
            expect(result.id).toEqual('2');
            expect(result.title).toEqual("tetsTitle2");
        })
    }));

    it("Can delete book by id", inject(function (bookService) {
        expect(bookService.books).toEqual([])

        $httpBackend.expectGET("/api/books");
        bookService.getBooks();
        $httpBackend.flush();

        expect(bookService.books.length).toEqual(2);

        $httpBackend.expectDELETE("/api/books/1");
        bookService.deleteBook(1);
        $httpBackend.flush();

        expect(bookService.books.length).toEqual(1);
        expect(bookService.books[0].id).toEqual("2");
        expect(bookService.books[0].title).toEqual("tetsTitle2");
    }));
});