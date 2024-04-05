using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Mission11_Stone.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BookstoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:AmazonConnection"]);
});

builder.Services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();

builder.Services.AddRazorPages();

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

app.MapControllerRoute("pagenumandtype", "{projectType}/{pageNum}", new { Controller = "Home", action = "Index", pageNum = 1});
app.MapControllerRoute("pagenumandtype", "{projectType}", new { Controller = "Home", action = "Index", pageNum = 1 });

app.MapControllerRoute(
    name: "pagination",
    pattern: "{pageNum}", new {Controller = "Home", action = "Index"}
);
app.MapControllerRoute("", "", new { Controller = "Home", action = "Index" });

app.MapRazorPages();

app.Run();
