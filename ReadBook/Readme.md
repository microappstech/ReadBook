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

    ### ** create user in table aspnetusers **
    var user Activator.CreateInstance();
    var RealUser = UserManager.CreatUserAsync(user, password);


## Authorization with claims 
        ** Add required policy Claims ** 
    ```
        builder.services.AddAuthoritzation(opt=>opt.AddPolicy("AdminAccess",policy=>policy.RequireClaim("Admin","Admin"))
    ```
    -- Allow Access to users to accessing 
    ```
    ### in cs
        [Authorize("AdminAccess")]
        `before the action or controller
    ### in html
        @using Microsoft.AspNetCore.Authorization

        @inject IAuthorizationService Athourize
        @{
            AuthorizationResult authorizationResult = await Athourize.AuthorizeAsync(User, "AdminAccess");
        }

        --------------
        if (authorizationResult.Succeeded)
        {
            <li  class="bold" >
                <a class="waves-effect waves-cyan " asp-controller="Writer" asp-action="Create"><i class="material-icons">group_add</i><span class="menu-title" data-i18n="Mail"></span><span class="badge new badge pill pink accent-2 float-right mr-2">5</span></a>
            </li>                    
        }
    ```
    -- Add specific claim for user 
    ```
    if(user is admin)
        System.Security.Claims.Claim claimAdmin = new System.Security.Claims.Claim("AdminAccess", "AdminAccess");
        await _userManager.AddClaimAsync(user,claimAdmin);
    ```

    ## terms = >
        - POLICY : defines a set of rules or conditions that determine whether a user is authorized to perform a specific action or access a particular resource.
        - ROLE : represent a group or category of users who share common access privileges. A role is typically associated with certain permissions or responsibilities within the system


# CUSTOMIZE USEIDENTITY
### _customize tables of identity_
> - Ignoring columns in AspNetTables 
> - Rename AspNetTables 

    protected override void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);
        builder.Entity<IdentityUser>()
            .ToTable("Users")
            .Ignore(t=>t.EmailConfirmed) 
        builder.Entry<IdentityRole>().ToTable("Roles");
        builder.Entry<IdentityUserRole<string>>().ToTable("UserRole");
        ... 
        }
        
        
--------------------
> ``` - add Columns ```
    1 create model that extend from IdentityUser :
    2 Defines Attributes insead the classes
       
       
           public class AppUser: IdentityUser {
                public string?  Fullname { get; set; }
                public string? Phone { get; set; }
                public string? Nationality { get; set; }
                public byte[]? image { get; set; }
               } 
    
