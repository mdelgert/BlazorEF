# Dependencies

[AzureFunctions.Extensions.DependencyInjection](https://www.nuget.org/packages/AzureFunctions.Extensions.DependencyInjection)
```console
PM> Install-Package AzureFunctions.Extensions.DependencyInjection
```

[Microsoft.Azure.Functions.Extensions](https://www.nuget.org/packages/Microsoft.Azure.Functions.Extensions)

```console
PM> Install-Package Microsoft.Azure.Functions.Extensions
```

[Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore)
```console
PM> Install-Package Microsoft.EntityFrameworkCore
```

[Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer)
```console
PM> Install-Package Microsoft.EntityFrameworkCore.SqlServer
```

[Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools)
```console
PM> Install-Package Microsoft.EntityFrameworkCore.Tools
```

```console
PM> Update-Package Microsoft.EntityFrameworkCore.Tools
```

```console
PM> Get-Help about_EntityFrameworkCore
```

# Migrations PM
```console
PM> Add-Migration InitialCreate -Verbose
```

```console
PM> Remove-Migration
```

```console
PM> Update-Database
```

# Migrations Core CLI
```console
PS> cd .\BlazorEF.FunctionApp\
```

```console
PS> dotnet ef migrations add InitialCreate
```

```console
PS> dotnet ef migrations remove
```

```console
PS> dotnet ef database update
```

```console
PS> dotnet ef migrations add AddWeatherForecast
```

```console
PS> dotnet ef database update
```

```console
PS> dotnet ef migrations add UpdateNotes
```

```console
PS> dotnet ef database update
```

# Reference
[Applying Migrations](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=vs)
[Entity Framework Core tools reference - Package Manager Console in Visual Studio](https://learn.microsoft.com/en-us/ef/core/cli/powershell)
[Entity Framework Core tools reference](https://learn.microsoft.com/en-us/ef/core/cli/)
[Migrations Overview](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
