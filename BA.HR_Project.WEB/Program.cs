using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Persistance.Context;
using BA.HR_Project.WEB.CustomMiddleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using BA.HR_Project.Domain.Entities;
using BA.HR_Project.Persistance.Context;
using BA.HR_Project.Persistance.Extensions;
using BA.HR_Project.Infrastructure.Extension;
using BA.HR_Project.Application.Extentios;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<AppDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConn"));
//});
//builder.Services.AddIdentity<AppUser, AppRole>(options =>
//{

//}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


builder.Services.AddCoreDepecenies(Assembly.GetExecutingAssembly());
builder.Services.AddPersistanceDependencies(builder.Configuration.GetConnectionString("SqlConn"));
builder.Services.AddInfrastructureDependencies();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.UseMvc();

app.Run();
