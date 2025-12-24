using Lab_8.Models;

namespace Lab_8.Data
{
    public class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Brands.Any())
            {
                var toyota = new Brand { Name = "Toyota", Country = "Japan" };
                var hyundai = new Brand { Name = "Hyundai", Country = "Korea" };
                context.Brands.AddRange(toyota, hyundai);
                context.SaveChanges();
                context.Cars.AddRange(
                new Car { Name = "Vios", BrandId = toyota.Id },
                new Car { Name = "Camry", BrandId = toyota.Id },
                new Car { Name = "Accent", BrandId = hyundai.Id }
                );
                context.SaveChanges();
            }
        }

    }
}
