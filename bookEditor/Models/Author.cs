using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookEditor.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PatronymicName { get; set; }

        public virtual Book Book { get; set; }
    }
}