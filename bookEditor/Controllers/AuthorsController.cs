using bookEditor.Models;
using bookEditor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace bookEditor.Controllers
{
    public class AuthorsController : ApiController
    {
        private IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            if (authorService == null)
            {
                throw new ArgumentNullException("AuthorService was not initialized");
            }

            _authorService = authorService;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _authorService.GetAuthors();
        }

        public HttpResponseMessage PostAuthor(Author author)
        {
           var newAuthor = _authorService.AddAuthor(author);

           return Request.CreateResponse(HttpStatusCode.OK, newAuthor);
        }

        public HttpResponseMessage DeleteAuthor(int id)
        {
            _authorService.DeleteAuthor(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
