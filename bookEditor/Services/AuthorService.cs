using bookEditor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bookEditor.Models;
using bookEditor.Data;

namespace bookEditor.Services
{
    public class AuthorService : IAuthorService
    {
        IBookEditRepository _bookEditRepository;

        public AuthorService(IBookEditRepository bookEditRepository)
        {
            if (bookEditRepository == null)
            {
                throw new ArgumentNullException("BookEditRepository was not initialized succesfully");
            }
            _bookEditRepository = bookEditRepository;
        }

        public Author AddAuthor(Author newAuthor)
        {
            return _bookEditRepository.AddAuthor(newAuthor);
        }

        public void DeleteAuthor(int id)
        {
            _bookEditRepository.DeleteAuthor(id);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _bookEditRepository.GetAllAuthors();
        }
    }
}