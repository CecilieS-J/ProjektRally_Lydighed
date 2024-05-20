using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjektRally_Lydighed.Data;
using ProjektRally_Lydighed.Interfaces;
using ProjektRally_Lydighed.Models;
using ProjektRally_Lydighed.Repositories;
using Microsoft.AspNetCore.Identity;
using ProjektRally_Lydighed.Areas.Identity.Data;



        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<ProjektRally_LydighedContext1>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ProjektRally_LydighedContext") ?? throw new InvalidOperationException("Connection string 'ProjektRally_LydighedContext' not found.")));




        builder.Services.AddDefaultIdentity<ProjektRally_Lydighed1>(options => options.SignIn.RequireConfirmedAccount = true)
      .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ProjektRally_LydighedContext1>();




        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<ITrackRepository, TrackRepository>();
        builder.Services.AddScoped<ISignRepository, SignRepository>();





        var app = builder.Build();


// Seed roles and assign admin role to an existing user
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ProjektRally_Lydighed1>>();

    // Assign admin role to an existing user
    string userEmail = "sillejohnsen@gmail.com"; // Replace with the email of the existing user
    var user = await userManager.FindByEmailAsync(userEmail);
    if (user != null)
    {
        var roles = await userManager.GetRolesAsync(user);
        if (!roles.Contains("Administrator"))
        {
            await userManager.AddToRoleAsync(user, "Administrator");
        }
    }
}



/*using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}*/



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

/*app.MapControllerRoute(
    name: "admin",
    pattern: "{controller=Admin}/{action=AssignAdminRole}/{email?}");

*/

app.MapRazorPages();



app.Run();

       
       
    



