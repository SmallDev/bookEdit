using bookEditor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bookEditor.Models;
using bookEditor.Data;

namespace bookEditor.Services
{
    public class BookService : IBookService
    {
        IBookEditRepository _bookEditRepository;

        public BookService(IBookEditRepository bookEditRepository)
        {
            if(bookEditRepository == null)
            {
                throw new ArgumentNullException("BookEditRepository was not initialized succesfully");
            }
            _bookEditRepository = bookEditRepository;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _bookEditRepository.GetAllBooks();
        }

        public void UpdateBook(Book book)
        {
            _bookEditRepository.UpdateBook(book);
        }

        public void AddBook(Book book)
        {
            _bookEditRepository.AddBook(book);
        }
    }
}