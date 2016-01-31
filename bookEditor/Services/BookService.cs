using bookEditor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bookEditor.Models;
using bookEditor.Data;
using bookEditor.Helpers;
using bookEditor.Models.ClientModels;

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

        public IEnumerable<ClientBook> GetBooks()
        {
            var books = _bookEditRepository.GetAllBooks().ToArray();
            return books.Select(_ => _.ToClientBook());
        }

        public void UpdateBook(Book book)
        {
            _bookEditRepository.UpdateBook(book);
        }

        public void AddBook(Book book)
        {
            _bookEditRepository.AddBook(book);
        }

        public void DeleteBook(int id)
        {
            _bookEditRepository.DeleteBook(id);
        }
    }
}