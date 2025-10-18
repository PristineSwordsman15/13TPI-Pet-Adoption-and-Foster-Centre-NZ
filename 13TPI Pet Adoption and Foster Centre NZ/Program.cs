using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Areas.Identity.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// DB
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContextConnection")));

// Use ApplicationUser

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Context>();

// MVC
builder.Services.AddControllersWithViews();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var config = services.GetRequiredService<IConfiguration>();
    try
    {
        await _13TPI_Pet_Adoption_and_Foster_Centre_NZ.Data.RoleSeeder.SeedAsync(services, config);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error while seeding roles.");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();