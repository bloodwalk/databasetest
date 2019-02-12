using MyFirstASPNETCoreWebApp.Models;
using System.Collections.Generic;


namespace MyFirstASPNETCoreWebApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentMessage { get; set; }
    }
}
