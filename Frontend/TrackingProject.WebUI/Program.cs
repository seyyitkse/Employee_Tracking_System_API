using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using TrackingProject.WebUI.Areas.Admin.Models.ViewModels.AdminLoginTest;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

// Add services to the container.
//builder.Services.AddControllersWithViews();
//builder.Services.AddIdentity<AdminLoginTest, IdentityRole>()
//    .AddEntityFrameworkStores<AdminDbContext>()
//    .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AdminLayout}/{action=_AdminLayout}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Announcement}/{action=Index}/{id?}"
    );
});

app.Run();
