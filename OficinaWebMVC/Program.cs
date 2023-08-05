
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OficinaWebMVC.Database.Contexto;
using OficinaWebMVC.Database.Entities;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.


builder.Services.AddDbContext<OficinaDBContexto>(options => {
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddControllersWithViews();




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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");





app.Run();

public partial class Program
{
    public static readonly string connectionString = "Server=127.0.0.1;Port=3306;Database=OficinaDB;Uid=root;Pwd=root;";
}
