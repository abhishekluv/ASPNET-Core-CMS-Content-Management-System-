using CoreCMS.Data;
using CoreCMS.Model;
using CoreCMS.Services.Concrete;
using CoreCMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var config = builder.Configuration;

//ef core
builder.Services.AddDbContext<CoreCMSContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("CoreCMS"), 
        cfg => cfg.MigrationsAssembly("CoreCMS.Web"));
});

builder.Services.AddIdentity<CustomUser, CustomRole>(cfg =>
{
    cfg.User.RequireUniqueEmail= true;
}).AddEntityFrameworkStores<CoreCMSContext>();

builder.Services.AddScoped<ISidebarService, SidebarService>();
builder.Services.AddScoped<IPageService, PageService>();

var app = builder.Build();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "page",
    pattern: "{slug}", defaults: new { Controller = "Home", Action = "Index"});

app.MapAreaControllerRoute(name: "MyAdminArea", areaName: "Admin", pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
