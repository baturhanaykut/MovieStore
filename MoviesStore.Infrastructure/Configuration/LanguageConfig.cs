using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore_Domain.Entities;

namespace MovieStore_Infrastructure.Mappings
{
    public class LanguageConfig : BaseEntityConfig<Language>
    {
        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnOrder(1);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(true)
                .HasColumnOrder(2);

            base.Configure(builder);
        }
    }
}
