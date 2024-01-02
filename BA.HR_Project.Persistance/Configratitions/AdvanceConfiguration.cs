using BA.HR_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BA.HR_Project.Persistance.Configratitions
{
    public class AdvanceConfiguration : IEntityTypeConfiguration<Advance>
    {
        public void Configure(EntityTypeBuilder<Advance> builder)
        {
            builder
                .HasOne(x => x.AppUser)
                .WithMany(x => x.Advances)
                .HasForeignKey(x => x.AppUserId);
            builder
                .Property(x => x.Description).HasMaxLength(150);
        }
    }
}
