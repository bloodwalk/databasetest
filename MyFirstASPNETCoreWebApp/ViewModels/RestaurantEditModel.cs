using MyFirstASPNETCoreWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MyFirstASPNETCoreWebApp.ViewModels
{
    public class RestaurantEditModel
    {
        [Required, MaxLength(80)]
        public string Name { get; set; }

        [Range(1, 3)]
        public CuisineType Cuisine { get; set; }
    }
}
