# ERRORS
The most errors i meet in this project
### ! Unable to create an object of type 'DBContext'. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
they was a problem in syntax of json Appsettings.json 

### The ConnectionString property has not been initialized.
there is a error in syntax of connection string ConnectionString=>ConnectionsStrings 

### A connection was successfully established with the server, but then an error occurred during the login process. (provider: SSL Provider, error: 0 - The certificate chain was issued by an authority that is not trusted.)
We should add ` TrustServerCertificate = true ` the connections string for secure comminucations between server and App



<hr> 

# ** SEED DATAINITIALIZER **
> - Create class initdata using scope
``` using (var scop = applicationBuilder.ApplicationServices.CreateScope()) { ``` 

> - Call servce of DbContext 
` var _dbContext = scop.ServiceProvider.GetService<DBContext>(); `

> - Check if seed dosen't called before 
` _dbContext.Database.EnsureCreated(); `

> - Add You Object data 
```
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
```

<h3> Code Exemple <h3>

```
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
                    var books = new List<Book>()
                    {
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
              }
           }
```
## Identity 

    1- Install "Microsoft.AspNetCore.Identity" 
    2- Register Identity in your projects
    ```
        builder.Services.AddDbContext<AppliatioDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
        }, ServiceLifetime.Transient);
    -----------------------------------------------------------------------------------------------------------------------------
        builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ReadBookContext>();
        <hr/>
    -----------------------------------------------------------------------------------------------------------------------------
        app.UseAuthentication();
        app.UseAuthorization();
    ```|

    3- then add migration and update database