using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore.Models.Entities;

namespace MovieStore.Models.DataAccess.Mappigs
{
    public class DirectorMapping : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.ToTable("Directors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn(1, 1)
                .HasColumnOrder(1);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(true)
                .HasColumnOrder(2);


            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(true)
                .HasColumnOrder(3);

            builder.Property(x => x.BirthDate)
               .IsRequired()
               .HasColumnType("date")         
               .HasColumnOrder(4);
        }
    }
}
