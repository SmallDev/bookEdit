using bookEditor.Models;
using System.Data.Entity.Migrations;
using System.Linq;

namespace bookEditor.Data
{
    public class BookEditMigrateConfig: DbMigrationsConfiguration<BookEditContext>
    {
        public BookEditMigrateConfig()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BookEditContext context)
        {
            base.Seed(context);

            if (context.Books.Count() == 0)
            {
                var dummyBooks = new Book[]
                {
                    new Book
                    {
                        Title = "The Fellowship Of The Ring",
                        Publisher = "Tolkien Official Publishing",
                        ISBN = "978-0-00-720354-3",
                        PublishYear = 2005,
                        NumberOfPages = 432,
                        Authors = new Author []
                        {
                            new Author
                            {
                                FirstName = "John",
                                LastName = "Tolkien",
                                PatronymicName = "R.R."
                            }
                        },
                    },
                    new Book
                    {
                        Title = "The Martian",
                        Publisher = "Random House",
                        ISBN = "978-0-8041-3902-1",
                        PublishYear = 2014,
                        NumberOfPages = 384,
                        Authors = new Author []
                        {
                            new Author
                            {
                                FirstName = "Andy",
                                LastName = "Weir",
                                PatronymicName = "Weir"
                            }
                        }
                    },
                    new Book
                    {
                        Title = "A Storm of Swords",
                        Publisher = "Random House",
                        ISBN = "978-0-00-711955-4",
                        PublishYear = 2011,
                        NumberOfPages = 356,
                        Authors = new Author []
                        {
                            new Author
                            {
                                FirstName = "Geaorge",
                                LastName = "Martin",
                                PatronymicName = "R.R."
                            }
                        }
                    }
                };

                context.Books.AddRange(dummyBooks);
                context.SaveChanges();
            }
        }
    }
}