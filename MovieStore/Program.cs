using MovieStore.Models.DataAccess;
using Microsoft.EntityFrameworkCore;
using MovieStore.Repository.Abstract;
using MovieStore.Repository.Concerete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));  // Connection string will be taken fraom appsettings.json file

builder.Services.AddScoped<IMovieDbContext, MovieDbContext>(); // The program create MovieDbContext Object when encounter IMovieDbContext Interface

builder.Services.AddTransient<IMovieRepository, MovieRepository>();

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
    pattern: "{controller=Movie}/{action=Index}/{id?}");

app.Run();
