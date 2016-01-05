using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bookEditor.Models;

namespace bookEditor.Data
{
    public class BookEditRepository : IBookEditRepository
    {
        private BookEditContext _ctx;

        public BookEditRepository(BookEditContext ctx)
        {
            if (ctx == null)
            {
                throw new ArgumentNullException(" BookEditContext was not initialized");
            }

            _ctx = ctx;
        }

        public Author AddAuthor(Author newAuthor)
        {
            _ctx.Authors.Add(newAuthor);
            _ctx.SaveChanges();

            return newAuthor;
        }

        public void AddBook(Book newBook)
        {
            _ctx.Books.Add(newBook);
            _ctx.SaveChanges();
        }

        public BookPicture AddBookPicture(BookPicture bookPicture)
        {
            _ctx.BookPictures.Add(bookPicture);
            _ctx.SaveChanges();
            return bookPicture;
        }

        public void DeleteAuthor(int authorId)
        {
            var author = new Author() { Id = authorId };
            _ctx.Authors.Attach(author);
            _ctx.Authors.Remove(author);
            _ctx.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            var book = new Book() { Id = bookId };
            _ctx.Books.Attach(book);
            _ctx.Books.Remove(book);
            _ctx.SaveChanges();
        }

        public IQueryable<Author> GetAllAuthors()
        {
            return _ctx.Authors;
        }

        public IQueryable<Book> GetAllBooks()
        {
            return _ctx.Books.Include("Authors").Include("Picture");
        }

        public void UpdateBook(Book book)
        {
            var result = _ctx.Books.Include("Authors").Include("Picture").SingleOrDefault(b => b.Id == book.Id);
            if (result != null)
            {
                result.ISBN = book.ISBN;
                result.NumberOfPages = book.NumberOfPages;
                result.Picture = book.Picture;
                result.Publisher = book.Publisher;
                result.PublishYear = book.PublishYear;
                result.Title = book.Title;

                var authors = result.Authors.ToList();
                foreach (var a in authors)
                {
                    result.Authors.Remove(a);
                }


                var authorIdsToAdd = book.Authors.Select(at => at.Id).ToArray();
                var authorsToAdd = _ctx.Authors.Where(_ => authorIdsToAdd.Contains(_.Id)).ToArray();

                foreach (var a in authorsToAdd)
                {
                    result.Authors.Add(a);
                }
                _ctx.SaveChanges();
            }
        }
    }
}