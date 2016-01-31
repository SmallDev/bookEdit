using bookEditor.Models;
using bookEditor.Models.ClientModels;
using bookEditor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace bookEditor.Controllers
{
    public class BooksController : ApiController
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            if(bookService == null)
            {
                throw new ArgumentNullException("BookService was not initialized");
            }

            _bookService = bookService;
        }

        public IEnumerable<ClientBook> GetBooks()
        {
            return _bookService.GetBooks();
        }

        public HttpResponseMessage PutBook(Book book)
        {
            _bookService.UpdateBook(book);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage PostBook(Book book)
        {
            _bookService.AddBook(book);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage DeleteBook(int id)
        {
            _bookService.DeleteBook(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
