using System;
using EFModeling.FluentAPI.Required;
using System.Linq;

namespace EFMigrations
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MyContext())
            {
                // Create
                Console.WriteLine("Inserting a new blog");
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();
            }
        }
    }
}
