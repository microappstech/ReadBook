using ReadBook.Models;

namespace ReadBook.Data.Seeder
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var scop = applicationBuilder.ApplicationServices.CreateScope())
            {
                var _dbContext = scop.ServiceProvider.GetService<DBContext>();
                _dbContext.Database.EnsureCreated();
                if (!_dbContext.Categories.Any())
                {
                    var categories = new List<Category>()
                {
                    new Category { Name = "Fiction" },
                    new Category { Name = "Love" },
                    new Category { Name = "Anime" },
                    new Category { Name = "Programming" },
                    new Category { Name = "Islamic" },
                };
                    _dbContext.Categories.AddRange(categories);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Books.Any())
                {
                    var books = new List<Book>(){
                        new Book {
                            Name = "The Catcher in the Rye",
                            Price = 9.99,
                            DateCreation = DateTime.Now,
                            CategoryId = 1,
                            Category = _dbContext.Categories.FirstOrDefault(c => c.IdCategory == 1),

                        },
                        new Book {
                            Name = "To Kill a Mockingbird",
                            Price = 12.99,
                            DateCreation = DateTime.Now,
                            CategoryId = 1,
                            Category = _dbContext.Categories.FirstOrDefault(c => c.IdCategory == 2),
                        },
                        new Book {
                            Name = "The Elements of Style",
                            Price = 7.99,
                            DateCreation = DateTime.Now,
                            CategoryId = 3
                        },
                        new Book {
                            Name = "The Catcher in the Rye",
                            Price = 9.99,
                            DateCreation = DateTime.Now,
                            CategoryId = 4

                        }
                };
                    _dbContext.Books.AddRange(books);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Writers.Any())
                {
                    var writers = new List<Writer>()
                {
                    new Writer
                    {
                        Name = "Jane Austen",
                        Nationality = "English"
                    },
                    new Writer()
                    {
                        Name=  "Gabriel Garcia Marquez",
                        Nationality = "Colombian",
                    },
                    new Writer()
                    {
                        Name = "Haruki Murakami",
                        Nationality = "Japanese"
                    },
                    new Writer(){
                        Name = "J.K. Rowling",
                        Nationality = "British",
                    },
                    new Writer()
                    {
                        Name= "Chimamanda Ngozi Adichie",
                        Nationality ="Nigerian",
                    }

                };
                    _dbContext.Writers.AddRange(writers);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Writers_Books.Any())
                {
                    _dbContext.Writers_Books.AddRange(new List<BookWriter>()
                {
                    new BookWriter()
                    {
                        BookId = 1,
                        WriterId = 2
                    },
                    new BookWriter()
                    {
                        BookId = 2,
                        WriterId = 1
                    },
                    new BookWriter()
                    {
                        BookId = 2,
                        WriterId = 3
                    },
                    new BookWriter()
                    {
                        BookId = 1,
                        WriterId = 3
                    }
                });
                    _dbContext.SaveChanges();
                }

            }
        }
    }
}
