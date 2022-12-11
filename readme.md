Create solution

```cmd
dotnet new sln
```

Create project, and add to solution:

```cmd
dotnet new webapi -o wa-sample
dotnet sln add wa-sample/wa-sample.csproj
```

Run code:

```cmd
dotnet run --project wa-sample/wa-sample.csproj
```

Watch changes with

```cmd
dotnet watch run --project wa-sample/wa-sample.csproj
```

Add package Entity Framework In Memory:
```cmd
dotnet add wa-sample/wa-sample.csproj package Microsoft.EntityFrameworkCore.InMemory
```

Setup in program.cs

```c
//EF InMemory
builder.Services.AddDbContext<DataContext>(opt=>opt.UseInMemoryDatabase ("Database"));
builder.Services.AddScoped<DataContext, DataContext>();
```

Add version control, create .gitignore file, using comand *dotnet new gitignore*

```cmd
dotnet new gitignore
```


Link swagger: http://localhost:5108/swagger/index.html


In tets, test Name is required!!!

Publish using **dotnet publish**

```cmd
dotnet publish -c Release -o publish
```

* Dockerfile 

Add in .csproj xml autocopy

```xml
  <ItemGroup>
    <None Update="Dockerfile" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>
```

Use por 80, swagger url http://localhost/swagger/index.html

In mac, run docker with arg **--platform linux/amd64**

* Use MySql Database

Add package

```cmd
dotnet add wa-sample/wa-sample.csproj package MySql.EntityFrameworkCore
```
