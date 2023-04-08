using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieStore_Domain.Entities;
using MovieStore_Infrastructure.Configuration;
using MovieStore_Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Infrastructure.ApllicationDbContext
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        DbSet<Movie> Movies { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<Director> Directors { get; set; }

        DbSet<Starring> Starrings { get; set; }

        DbSet<Language> Languages { get; set; }

        DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new MovieConfig())
                        .ApplyConfiguration(new CategoryConfig())
                        .ApplyConfiguration(new DirectorConfig())
                        .ApplyConfiguration(new LanguageConfig())
                        .ApplyConfiguration(new StarringConfig())
                        .ApplyConfiguration(new AppUserConfig());
                        

            base.OnModelCreating(builder);
        }
    }
}
