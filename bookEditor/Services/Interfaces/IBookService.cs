using bookEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookEditor.Services.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();

        void UpdateBook(Book book);

        void AddBook(Book book);
    }
}
