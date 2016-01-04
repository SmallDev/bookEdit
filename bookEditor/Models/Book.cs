using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookEditor.Models
{
    public class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Publisher { get; set; }

        public string ISBN { get; set; }

        public int NumberOfPages { get; set; }
        
        public string PublishYear { get; set; }
        
        public virtual BookPicture Picture { get; set; }
        
        public virtual ICollection<Author> Authors { get; set; }
    }
}