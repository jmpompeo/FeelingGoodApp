using FeelingGoodApp.Data;
using FeelingGoodApp.Services;
using FeelingGoodApp.Services.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace FeelingGoodApp
{
    public class Startup
    {
        private string _googleApiKey = null;
        private string _nutritionApiKey = null;
        private string _nutritionAppId = null;
        private string _nutritionApiKey2 = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _googleApiKey = Configuration["GoogleApiKey"];
            _nutritionApiKey = Configuration["NutritionAPIKey"];
            _nutritionApiKey2 = Configuration["NutritionAPIKey2"];
            _nutritionAppId = Configuration["NutritionAppId"]; 

            services.AddDbContext<FeelingGoodContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false);

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<FeelingGoodContext>();

            services.AddHttpClient<INutritionService, NutritionService>(client =>
            {

                client.BaseAddress = new Uri("https://nutritionix-api.p.rapidapi.com/");
                client.DefaultRequestHeaders.Add("x-rapidapi-key", _nutritionApiKey2);
            });

            services.AddHttpClient<IExerciseService, ExerciseService>(client =>
            {
                client.BaseAddress = new Uri("https://trackapi.nutritionix.com/");
                client.DefaultRequestHeaders.Add("x-app-id", _nutritionAppId);
                client.DefaultRequestHeaders.Add("x-app-key", _nutritionApiKey);
            });

            //services.AddHttpClient<INutritionService, NutritionService>(client =>
            //{
            //    client.BaseAddress = new Uri("https://trackapi.nutritionix.com/");
            //    client.DefaultRequestHeaders.Add("98c2fa3e", _nutritionApiKey2);
            //    client.DefaultRequestHeaders.Add("x-app-id", _nutritionApiKey2);
            //});

            services.AddHttpClient<ILocationService, LocationService>();



            services.AddHttpClient<ILocationService, LocationService>(client =>
            {
                client.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/");

            });

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
