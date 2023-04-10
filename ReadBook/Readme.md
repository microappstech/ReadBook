# ERORS
The most erors i meet in this project
### ! Unable to create an object of type 'DBContext'. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
they was a problem in syntax of json Appsettings.json 

### The ConnectionString property has not been initialized.
there is a eror in syntax of connection string ConnectionString=>ConnectionsStrings 

### A connection was successfully established with the server, but then an error occurred during the login process. (provider: SSL Provider, error: 0 - The certificate chain was issued by an authority that is not trusted.)
We should add ` TrustServerCertificate = true ` the connections string for secure comminucations between server and App