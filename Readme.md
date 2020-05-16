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
## Tweede migration
Code voor posts toegevoegd aan MyContext.cs.
```
dotnet ef migrations add Posts
dotnet ef database update
```
## Seeden van data
Het seeden moet onderdeel zijn van een migration, komt dus bij het modelbuilder gebeuren in te staan.
Zie [Data Seeding](https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding)
Het forceren van seeden kan niet zo maar. Ik dacht de tabellen leeg te gooien en een nieuwe dotnet ef database update te doen maar die werd geweigerd. Ook bij een nieuwe migration met wat extra data werd de verwijderde data niet opnieuw toegevoegd!
Als je dus gebruikt maakt van migrations is het all the way, handmatige ingrepen verstoren het proces en worden genegeerd. Ik heb bijvoorbeeld de Post tabel gedelete maar die krijg ik niet zomaar terug met een migration of update.
Wat dan nog wel werkt is:
```
dotnet ef database drop
dotnet ef database update
```
# Conclusie
Migrations en seeding werkt prima maar je moet de hele database integraal op een manier benaderen. Mix and match tussen scaffolden van een bestaande db en migrations werkt niet; het is of migrations, of scaffolden.