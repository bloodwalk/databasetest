using Microsoft.EntityFrameworkCore;
using MyFirstASPNETCoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstASPNETCoreWebApp.Data
{
    public class MyFirstDbContext : DbContext
    {
        public MyFirstDbContext(DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
