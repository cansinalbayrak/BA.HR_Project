using BA.HR_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Persistance.Configratitions
{
    public class DayOffConfiguration : IEntityTypeConfiguration<DayOff>
    {
        public void Configure(EntityTypeBuilder<DayOff> builder)
        {
            builder
                .HasOne(x => x.AppUser)
                .WithMany(x => x.DayOffs)
                .HasForeignKey(x => x.AppUserId);
            builder
                .Property(x => x.Description).HasMaxLength(150);
        }
    }
}
