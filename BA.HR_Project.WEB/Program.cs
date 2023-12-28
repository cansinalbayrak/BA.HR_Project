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
using BA.HR_Project.Application.Email;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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

builder.Services.Configure<EmailOption>(builder.Configuration.GetSection("EmailOption"));
builder.Services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();
builder.Services.AddSingleton<IActionContextAccessor,ActionContextAccessor>();

var app = builder.Build(); 


using (var scope = app.Services.CreateScope())
{

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var RoleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();


    await RoleManager.CreateAsync(new() { Id=Guid.NewGuid().ToString() ,Name = "Admin" });
    await RoleManager.CreateAsync(new() { Id = Guid.NewGuid().ToString(),Name = "Employee" });


    var adminUser = await userManager.FindByEmailAsync("admin@bilgeadam.com");
    await userManager.AddToRoleAsync(adminUser, "Admin");
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseExceptionHandler(errorApp =>
{
	errorApp.Run(async context =>
	{
		context.Response.StatusCode = 500;
		context.Response.ContentType = "text/html";

		await context.Response.WriteAsync("<script>window.location='/Error/Warning';</script>");
	});
});

app.UseStatusCodePagesWithRedirects("/Error/Warning/{0}");

//app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.UseMvc();
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapDefaultControllerRoute();
});


app.Run();
