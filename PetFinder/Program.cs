using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetFinder.Data;
using PetFinder.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPetFinderDbContext(builder.Configuration);
builder.Services.AddPetFinderIdentity(builder.Configuration);

builder.Services.AddControllersWithViews();
builder.Services.AddPetFinderServices();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
