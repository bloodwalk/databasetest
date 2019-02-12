using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MyFirstASPNETCoreWebApp.Data;

namespace MyFirstASPNETCoreWebApp
{
    public class MyFirstContextFactory : IDesignTimeDbContextFactory<MyFirstDbContext>
    {
        public MyFirstDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyFirstDbContext>();
            optionsBuilder.UseSqlite("Data Source=blog.db");

            return new MyFirstDbContext(optionsBuilder.Options);
        }

    }
}