# Scaffold UI Identity (Register Razor Page)
*   CLI tools
  ``` dotnet tool install -g dotnet-aspnet-codegenerator ```
*   Packaget Reference
```
    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
    dotnet add package Microsoft.AspNetCore.Identity.UI
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Tools
```
*   Scaffold Register Page
``` dotnet aspnet-codegenerator identity -dc MyApplication.Data.ApplicationDbContext --files "Account.Register;" ```

*   Add Razor to ServiceCollection & Middleware
  