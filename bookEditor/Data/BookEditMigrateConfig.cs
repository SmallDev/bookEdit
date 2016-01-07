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
                        Title = "Story Book",
                        Publisher = "O'Relly",
                        ISBN = "2-266-11156",
                        PublishYear = 1984,
                        NumberOfPages = 1000,
                        Authors = new Author []
                        {
                            new Author
                            {
                                FirstName = "Tim",
                                LastName = "Smeet",
                                PatronymicName = "TJ"
                            },
                            new Author
                            {
                                FirstName = "Mike",
                                LastName = "Benington",
                                PatronymicName = "LP"
                            },
                        },
                    },
                    new Book
                    {
                        Title = "Lord Of The Time",
                        Publisher = "O'Relly",
                        ISBN = "2-266-17156",
                        PublishYear = 1993,
                        NumberOfPages = 100,
                        Authors = new Author []
                        {
                            new Author
                            {
                                FirstName = "Tom",
                                LastName = "Davidson",
                                PatronymicName = "Jonior"
                            },
                            new Author
                            {
                                FirstName = "Fred",
                                LastName = "Davidson",
                                PatronymicName = "TR"
                            },
                        }
                    }
                };

                context.Books.AddRange(dummyBooks);
                context.SaveChanges();
            }
        }
    }
}