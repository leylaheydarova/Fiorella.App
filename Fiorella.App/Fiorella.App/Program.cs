//using AspNetCore;
using Fiorella.App.Context;
using Fiorella.App.Dtos.Category;
using Fiorella.App.Profiles;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(fv=>fv.RegisterValidatorsFromAssemblyContaining<CategoryPostDto>());
builder.Services.AddAutoMapper(typeof(CategoryMap));
builder.Services.AddDbContext<FiorellaDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
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

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "default",
        areaName: "admin",
        pattern: "admin/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

//app.MapControllerRoute(
    //name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
