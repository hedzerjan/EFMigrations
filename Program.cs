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
                // Console.WriteLine("Inserting a new blog");
                // db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                // db.SaveChanges();

                // Read
                // Console.WriteLine("Querying for a blog");
                // var blog = db.Blogs
                //     .OrderBy(b => b.BlogId)
                //     .First();

                // /// Update
                // Console.WriteLine("Updating the blog and adding a post");
                // blog.Url = "https://devblogs.microsoft.com/dotnet";
                // blog.Posts.Add(
                //     new Post
                //     {
                //         Title = "Hello World",
                //         Content = "I wrote an app using EF Core!"
                //     });
                // db.SaveChanges();

                // Delete
                var blog = db.Blogs
                    .Where(p => p.BlogId == 2);
                Console.WriteLine($"Gevonden blog: {blog}");

                if (blog.Count() == 1)
                {
                    Console.WriteLine("Delete the blog");
                    db.Remove(blog.First());
                    db.SaveChanges();
                }
            }
        }
    }
}
