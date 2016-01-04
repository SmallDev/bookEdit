using bookEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookEditor.Services.Interfaces
{
    public interface IAuthorService
    {
        Author AddAuthor(Author newAuthor);

        void DeleteAuthor(int id);

        IEnumerable<Author> GetAuthors(); 
    }
}
