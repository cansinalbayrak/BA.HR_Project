using BA.HR_Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BA.HR_Project.Persistance.Configratitions
{
    public class ExpenseTypeConfiguration : IEntityTypeConfiguration<ExpenseType>
    {
      
       

        public void Configure(EntityTypeBuilder<ExpenseType> builder)
        {
         
            builder.HasData(new
            {
                Id = Guid.NewGuid().ToString(),
                ExpenseName = "Marketing and Advertising Expenditures",
                ExpenseMaxPrice = 10000m,
                ExpenseMinPrice = 1000m,

            });
            builder.HasData(new
            {
                Id = Guid.NewGuid().ToString(),
                ExpenseName = "Accomodation",
                ExpenseMaxPrice = 15000m,
                ExpenseMinPrice = 1000m,

            });
            builder.HasData(new
            {
                Id = Guid.NewGuid().ToString(),
                ExpenseName = "Travel",
                ExpenseMaxPrice = 5000m,
                ExpenseMinPrice = 1000m,

            });
            builder.HasData(new
            {
                Id = Guid.NewGuid().ToString(),
                ExpenseName = "Food and Drink",
                ExpenseMaxPrice = 4000m,
                ExpenseMinPrice = 400m,

            });
            builder.HasData(new
            {
                Id = Guid.NewGuid().ToString(),
                ExpenseName = "Education",
                ExpenseMaxPrice = 15000m,
                ExpenseMinPrice = 10000m,

            }); 
            builder.HasData(new
            {
                Id = Guid.NewGuid().ToString(),
                ExpenseName = "Research and Devolopment",
                ExpenseMaxPrice = 20000m,
                ExpenseMinPrice = 1000m,

            });
            builder.HasData(new
            {
                Id = Guid.NewGuid().ToString(),
                ExpenseName = "Others",
                ExpenseMaxPrice = 1000m,
                ExpenseMinPrice = 1m,

            });

        }
    }
}
