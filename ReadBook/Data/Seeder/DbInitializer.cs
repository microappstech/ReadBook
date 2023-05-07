using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ReadBook.Enums;
using ReadBook.Models;

namespace ReadBook.Data.Seeder
{
    public static class DbInitializer
    {
        public static async Task SeedAsyncRoles(RoleManager<IdentityRole> roleManager) 
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.AccessAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Manager.ToString()));
        }
        public static async Task SeedAsyncUsers(UserManager<AppUser> userManager)
        {
            var UserOne = new AppUser { UserName = "UserOne", Email = "UserOne@gmail.com", EmailConfirmed = true };
            if (userManager.FindByEmailAsync(UserOne.Email) == null)
            {
                await userManager.CreateAsync(UserOne, UserOne.UserName + "!");
                await userManager.AddToRoleAsync(UserOne, Roles.Manager.ToString());
            }

            var UserTwo = new AppUser { UserName = "UserTwo", Email = "UserTwo@gmail.com", EmailConfirmed = true };
            if (userManager.FindByEmailAsync(UserTwo.Email) == null)
            {
                await userManager.CreateAsync(UserTwo, UserTwo.UserName + "!");
            }
            
            var UserThree = new AppUser { UserName = "UserTwo", Email = "UserTwo@gmail.com", EmailConfirmed = true };
            if (userManager.FindByEmailAsync(UserThree.Email) == null)
            {
                await userManager.CreateAsync(UserThree, UserThree.UserName + "!");
            }
            
            var UserFour = new AppUser { UserName = "UserTwo", Email = "UserTwo@gmail.com", EmailConfirmed = true };
            if (userManager.FindByEmailAsync(UserFour.Email) == null)
            {
                await userManager.CreateAsync(UserFour, UserFour.UserName + "!");
            }
        
        }
        
        public static async Task SeedClaimsForAdmin(RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(Roles.AccessAdmin.ToString());
        }
        public static async Task SeedClaims(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            
        }
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
                        BookId = _dbContext.Books.FirstOrDefault().Id,
                        WriterId = 2
                    },
                    new BookWriter()
                    {
                        BookId = _dbContext.Books.ToList()[0].Id,
                        WriterId = 1
                    },
                    new BookWriter()
                    {
                        BookId =  _dbContext.Books.ToList()[1].Id,
                        WriterId = 3
                    },
                    new BookWriter()
                    {
                        BookId = _dbContext.Books.ToList()[2].Id,
                        WriterId = 3
                    }
                });
                    _dbContext.SaveChanges();
                }

            }
        }
    }
}
