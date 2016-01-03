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

        public IEnumerable<Book> GetBooks()
        {
            return _bookService.GetBooks().ToArray();
        }
    }
}
