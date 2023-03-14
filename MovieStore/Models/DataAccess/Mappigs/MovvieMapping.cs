﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Models.Entities;

namespace MovieStore.Models.DataAccess.Mappigs
{
    public class MovvieMapping : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies");          // Table name will be Movies in the Database

            builder.HasKey(x => x.Id);          // Id is set as primary Key

            builder.Property(x => x.Id)
                .UseIdentityColumn(1, 1)        // Id starts at 1 and increase one by one
                .HasColumnOrder(1);             // Id is the first column int the database  

            builder.Property(x => x.Name)
                .IsRequired()                   // This makes it that is neccessary
                .HasMaxLength(50)               // The maximum characters can be 50 
                .IsUnicode(true)
                .HasColumnOrder(2);             // It asccepts Unicode characters such as chinese alphabet

            builder.Property(x => x.CategoryId)
                .IsRequired()
                .HasColumnOrder(3);

            builder.Property(x => x.DirectorId)
                .IsRequired()
                .HasColumnOrder(4);

            builder.Property(x => x.ReleaseDate)
                .IsRequired()                   
                .HasColumnType("date")          //Data Type is yyyy/mm/dd in te database
                .HasColumnOrder(5);

            builder.Property(x => x.RunningTimeMin)
                .HasColumnOrder(6)
                .HasColumnType("smallint");

            builder.Property(x=>x.LanguageId)
                .IsRequired()
                .HasColumnOrder(7);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(7,2)")
                .HasColumnOrder(8);

            builder.Property(x=>x.Stock)
                .IsRequired()
                .HasColumnOrder (9);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(false)         //Default value is false, If there is no input , the value of the property will be false
                .HasColumnOrder(10);


            // Foreing Key Between Movie and Category

            builder
                .HasOne<Category>(x => x.Category)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.CategoryId);

            // Foreing Key Between Movie and Director
            builder
                .HasOne<Director>(x => x.Director)
                .WithMany(x => x.DirectedMovies)
                .HasForeignKey(x => x.DirectorId);

            //Foreing Key Between Movie and Language
            builder
                .HasOne<Language>(x => x.Language)
                .WithMany(x => x.OriginalLanguageOfMovies)
                .HasForeignKey(x => x.LanguageId);

           
        }
    }
}
