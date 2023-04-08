using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieStore_Domain.Entities;
using MovieStore_Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore_Infrastructure.Configuration
{
    public class AppUserConfig : BaseEntityConfig<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName)
                .IsRequired(true)
                .HasMaxLength(30);
            builder.Property(x => x.ImagePath)
                .IsRequired(false);

            
            base.Configure(builder);
        }
    }
}
