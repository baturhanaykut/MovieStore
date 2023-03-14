﻿using Microsoft.EntityFrameworkCore;
using MovieStore.Models.DataAccess.Mappigs;
using MovieStore.Models.Entities;

namespace MovieStore.Models.DataAccess
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Starring> Starrings { get; set; }

        public DbSet<Language> Languages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new MovvieMapping())
                        .ApplyConfiguration(new CategoryMapping())
                        .ApplyConfiguration(new DirectorMapping())
                        .ApplyConfiguration(new LanguageMapping())
                        .ApplyConfiguration(new StarringMapping());

            base.OnModelCreating(modelBuilder);
        }

       

    }
}
