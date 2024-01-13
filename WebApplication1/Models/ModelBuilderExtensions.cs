using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                Name = "Manie",
                Department = Dept.HR,
                Email = "manie@na.com"
            },
            new Employee
            {
                Id = 2,
                Name = "Pan",
                Department = Dept.HR,
                Email = "pan@na.com"
            }
          );

        }
    }
}
