/// <reference path="../repository/scripts/jasmine.js" />
/// <reference path="../../bookeditor/scripts/angular/angular.js" />
/// <reference path="../../bookeditor/scripts/angular/angular-mocks.js" />
/// <reference path="../../bookeditor/scripts/app/app.js" />
/// <reference path="../../bookeditor/scripts/app/services/authorservice.js" />
/// <reference path="../../bookeditor/scripts/app/modules/angular-route.js" />
/// <reference path="../../bookeditor/scripts/app/modules/ng-file-upload-shim.js" />
/// <reference path="../../bookeditor/scripts/app/modules/ngdialog.js" />
/// <reference path="../../bookeditor/scripts/app/modules/ng-file-upload.js" />
/// <reference path="../../bookeditor/scripts/app/modules/angular-cookies.js" />
/// <reference path="../../bookeditor/scripts/jquery-1.10.2.js" />



describe("authorService Tests ->", function () {

    beforeEach(function () {
        module("bookEditApp");
    });

    beforeEach(inject(function ($injector) {
        $httpBackend = $injector.get("$httpBackend");
        $httpBackend.when("GET", "/api/authors")
        .respond([
            {   id: "1",
                firstName: "testFirstName1",
                lastName: "testLastName1",
                patronymicName : "testPatronymicName1"
            },
            {
                id: "2",
                firstName: "testFirstName2",
                lastName: "testLastName2",
                patronymicName: "testPatronymicName2"
            },
        ]);

        $httpBackend.when("DELETE", "/api/authors/2")
       .respond({});

        $httpBackend.when("POST", "/api/authors")
       .respond({
               id: "3",
               firstName: "newName3",
               lastName: "newName3",
               patronymicName: "newName3"
       });
    }));

    afterEach(function () {
        $httpBackend.verifyNoOutstandingExpectation();
        $httpBackend.verifyNoOutstandingRequest();
    });

    it("Can load authors", inject(function (authorService) {
        expect(authorService.authors).toEqual([])

        $httpBackend.expectGET("/api/authors");
        authorService.getAuthors();
        $httpBackend.flush();

        expect(authorService.authors.length).toEqual(2);

    }));

    it("Can delete author", inject(function (authorService) {
        expect(authorService.authors).toEqual([])

        $httpBackend.expectGET("/api/authors");
        authorService.getAuthors();
        $httpBackend.flush();

        $httpBackend.expectDELETE("/api/authors/2");
        authorService.deleteAuthor(2);
        $httpBackend.flush();

        expect(authorService.authors.length).toEqual(1);
        expect(authorService.authors[0].id).toEqual("1");
        expect(authorService.authors[0].firstName).toEqual("testFirstName1");

    }));

    it("Can add author", inject(function (authorService) {
        expect(authorService.authors).toEqual([])

        $httpBackend.expectGET("/api/authors");
        authorService.getAuthors();
        $httpBackend.flush();

        $httpBackend.expectPOST("/api/authors");
        authorService.addAuthor();
        $httpBackend.flush();

        expect(authorService.authors.length).toEqual(3);
        expect(authorService.authors[2].id).toEqual("3");
        expect(authorService.authors[2].firstName).toEqual("newName3");

    }));
});