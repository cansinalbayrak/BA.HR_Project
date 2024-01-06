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
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasOne(x => x.AppUser).WithMany(x => x.Expenses)
                .HasForeignKey(x => x.AppUserId);

            builder.HasOne(x => x.ExpenseType).WithMany(x => x.Expenses)
             .HasForeignKey(x => x.ExpenseTypeId);
        }
    }
}
