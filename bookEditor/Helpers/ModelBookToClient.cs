using bookEditor.Models;
using bookEditor.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookEditor.Helpers
{
    public static class ModelBookToClient
    {
        public static ClientBook ToClientBook(this Book book)
        {
            return new ClientBook() { 
                 Id = book.Id,
                 Title = book.Title,
                 Publisher = book.Publisher,
                 ISBN = book.ISBN,
                 NumberOfPages = book.NumberOfPages,
                 PublishYear = book.PublishYear,
                 Picture = book.Picture,
                 Authors = book.Authors 

            };
        } 
    }
}