using Microsoft.AspNetCore.Mvc;
using MyFirstASPNETCoreWebApp.Models;
using MyFirstASPNETCoreWebApp.Services;
using MyFirstASPNETCoreWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstASPNETCoreWebApp.Controllers
{
    public class HomeController : Controller
    {    
        public HomeController( IRestaurantData restaurantData, IGreeter greeter )
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {

            var model = new HomeIndexViewModel
            {
                Restaurants = _restaurantData.GetAll(),
                CurrentMessage = _greeter.GetMessageOfTheDay()
            };
                
            return View( model );            
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get( id );
            if( model == null )
            {
                return RedirectToAction( nameof(Index) );
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if( ModelState.IsValid )
            {
                var newRestaurant = new Restaurant();
                newRestaurant.Name = model.Name;
                newRestaurant.Cuisine = model.Cuisine;
                newRestaurant = _restaurantData.Add(newRestaurant);//.Add sets the newRestaurant.Id

                //return View("Details", newRestaurant);//without redirect
                return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
            }
            else
            {
                return View();
            }

        }

        private IGreeter _greeter;
        private IRestaurantData _restaurantData;
    }
}
