﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyFirstASPNETCoreWebApp.Data;
using MyFirstASPNETCoreWebApp.Services;

namespace MyFirstASPNETCoreWebApp
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup( IConfiguration configuration )
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            var test = _configuration.GetConnectionString("MyFirstConnection");
            
            services.AddDbContext<MyFirstDbContext>(
                options => options.UseSqlServer(_configuration.GetConnectionString("MyFirstConnection"))
            );

            services.AddScoped<IRestaurantData, SqlRestaurantData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(  IApplicationBuilder app, 
                                IHostingEnvironment env,
                                IGreeter greeter,
                                ILogger<Startup> logger )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseExceptionHandler();
            //}
            app.UseStaticFiles();
            app.UseMvc( ConfigureRoutes );           

            app.Run(async (context) =>
            {
                //throw new Exception("Error!");
                string greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync($"Not found" );
            });
        }

        private void ConfigureRoutes( IRouteBuilder routeBuilder )
        {
            // Home/Index/4
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
