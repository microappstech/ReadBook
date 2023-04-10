# ERORS
The most erors i meet in this project
### ! Unable to create an object of type 'DBContext'. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
they was a problem in syntax of json Appsettings.json 

### The ConnectionString property has not been initialized.
there is a eror in syntax of connection string ConnectionString=>ConnectionsStrings 

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
            }