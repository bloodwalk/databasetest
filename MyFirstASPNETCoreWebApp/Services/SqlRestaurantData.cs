using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFirstASPNETCoreWebApp.Data;
using MyFirstASPNETCoreWebApp.Models;

namespace MyFirstASPNETCoreWebApp.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private MyFirstDbContext _context;

        public SqlRestaurantData( MyFirstDbContext context )
        {
            _context = context;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            _context.Restaurants.Add(newRestaurant);
            _context.SaveChanges();
            return newRestaurant;
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault( r => r.Id == id );
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.OrderBy( r => r.Name );
        }
    }
}
