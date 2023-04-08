using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore_Domain.Entities;

namespace MovieStore_Infrastructure.Mappings
{
    public class CategoryConfig : BaseEntityConfig<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");          

            builder.HasKey(x => x.Id);          

            builder.Property(x => x.Id) 
                .HasColumnOrder(1);               

            builder.Property(x => x.Name)
                .IsRequired()                   
                .HasMaxLength(30)               
                .IsUnicode(true)
                .HasColumnOrder(2);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(true)
                .HasColumnOrder(3);

            base.Configure(builder);
        }
    }
}
