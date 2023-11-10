
# Library Project

This is a test project to simulate an online library


## Built with

- .NET
- Entity Framework Core
- PostgreSQL
- AutoMapper
- Swagger
- Authentication via bearer token;
## Getting started

- Git clone
- Configure connection stringi in 'appsettings.json' file in LibriaryProject.API
- If necessary, run uptate-database in the Package manager console
- Run LibriaryProject.API project 
- Using swagger, use the 'register' method in the account controller, then log in using the 'login' method to get your Bearer token
- Copy your token and paste it into the swagger authorization window along with the Bearer postscript (It should look like 'Bearer {your token}') and click authorize
- If you want to use methods that require the admin role, then use the admin account\
    Login: admin\
    Password: A123a_ 
- Enjoy
