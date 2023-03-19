using MovieStore.Models.DataAccess;
using Microsoft.EntityFrameworkCore;
using MovieStore.Repository.Abstract;
using MovieStore.Repository.Concerete;
using System.Reflection;
using Microsoft.Extensions.FileProviders;
using MovieStore.Models.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));  // Connection string will be taken fraom appsettings.json file

builder.Services.AddScoped<IMovieDbContext, MovieDbContext>(); // The program create MovieDbContext Object when encounter IMovieDbContext Interface

builder.Services.AddTransient<IMovieRepository, MovieRepository>()
                .AddTransient<IDirectorRepository, DirectorRepository>()
                .AddTransient<IStarringRepository, StarringRepository>()
                .AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<ILanguageRepository, LanguageRepository>();

builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));



builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
SeedData.Seed(app);  //Bogus Kullanmak için
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Index}/{id?}");

app.Run();
