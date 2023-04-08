using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore_Domain.Entities;

namespace MovieStore_Infrastructure.Mappings
{
    public class DirectorConfig : BaseEntityConfig<Director>
    {
        public override void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.ToTable("Directors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
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

            base.Configure(builder);
        }
    }
}
