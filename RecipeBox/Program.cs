using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RecipeBox.Models;
using Microsoft.AspNetCore.Identity;
// using System.Data.SqlClient;
using System.Configuration;

namespace RecipeBox
{
  class Program
  {
    static void Main(string[] args)
    {

      WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


      builder.Services.AddControllersWithViews();

      builder.Services.AddDbContext<RecipeBoxContext>(
                        dbContextOptions => dbContextOptions
                          .UseMySql(
                            builder.Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                          )
                        )
                      );
    

      builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<RecipeBoxContext>()
                .AddDefaultTokenProviders();
 

                

      builder.Services.Configure<IdentityOptions>(options =>
      {
      // Default Password settings.
      options.Password.RequireDigit = false;
      options.Password.RequireLowercase = false;
      options.Password.RequireNonAlphanumeric = false;
      options.Password.RequireUppercase = false;
      options.Password.RequiredLength = 0;
      options.Password.RequiredUniqueChars = 0;
      // options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
      // options.Lockout.MaxFailedAccessAttempts = 5;
      // options.Lockout.AllowForNewUsers = true;
      });  
      // this api key is non-functional
      // var RecipesApiKey = builder.Configuration["Recipes:ServiceApiKey"]

      WebApplication app = builder.Build();

      // app.UseDeveloperExceptionPage();
      app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication(); 
      app.UseAuthorization();

      app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}"
        );

      app.Run();
    }
  }
}