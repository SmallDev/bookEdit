using bookEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookEditor.Data
{
    public interface IBookEditRepository
    {
        //Books
        IQueryable<Book> GetAllBooks();

        void AddBook(Book newBook);

        void DeleteBook(int bookId);


        //Authors
        IQueryable<Author> GetAllAuthors();

        void AddAuthor(Author newAuthor);

        void DeleteAuthor(int authorId);

        //Pictures
        BookPicture AddBookPicture(BookPicture bookPicture);
    }
}
