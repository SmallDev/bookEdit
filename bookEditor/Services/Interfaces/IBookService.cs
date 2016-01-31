using bookEditor.Models;
using bookEditor.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookEditor.Services.Interfaces
{
    public interface IBookService
    {
        IEnumerable<ClientBook> GetBooks();

        void UpdateBook(Book book);

        void AddBook(Book book);

        void DeleteBook(int id);
    }
}
