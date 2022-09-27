﻿# Dependencies

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
PM> cd .\BlazorEF.FunctionApp\
```

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
PM>
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
PS>
```

# Reference
[Entity Framework Core tools reference - Package Manager Console in Visual Studio](https://learn.microsoft.com/en-us/ef/core/cli/powershell)
[Entity Framework Core tools reference](https://learn.microsoft.com/en-us/ef/core/cli/)
[Migrations Overview](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
