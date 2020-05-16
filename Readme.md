# Onderzoek EF Migrations
Simpel beginnen, doel is om uit te vinden hoe migrations werken en hoe seeden werkt.
## Basis opzet
```
dotnet new console
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
```
Voeg context met model toe:
```c#
using Microsoft.EntityFrameworkCore;

namespace EFModeling.FluentAPI.Required
{
    class MyContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(b => b.Url)
                .IsRequired();
        }
        #endregion
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
    }
}
```
## Eerste migration
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```
Valt te bekijken met sqlite extension voor vs code.
