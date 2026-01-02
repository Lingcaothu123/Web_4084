using WebApplication3.Models;

namespace WebApplication3.Data
{
    public static class CategoryDto
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Brands.Any())
                return; // đã có dữ liệu

            var brands = new List<Brand>
            {
                new Brand { Name = "Toyota" },
                new Brand { Name = "Honda" },
                new Brand { Name = "BMW" }
            };

            context.Brands.AddRange(brands);
            context.SaveChanges();

            var cars = new List<Car>
            {
                new Car { Name = "Camry", Price = 1200, BrandId = 1 },
                new Car { Name = "Civic", Price = 1000, BrandId = 2 },
                new Car { Name = "BMW X5", Price = 2500, BrandId = 3 },
                 new Car { Name = "BMW X6", Price = 290900, BrandId = 3 }
            };

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }
    }
}
