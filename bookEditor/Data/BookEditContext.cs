using bookEditor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace bookEditor.Data
{
    public class BookEditContext : DbContext
    {
        public BookEditContext():
            base("BookEditDb")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BookEditContext, BookEditMigrateConfig>()
                );
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookPicture> BookPictures { get; set; }

    }
}