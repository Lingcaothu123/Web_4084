using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data
{
	public static class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new AppDbContext(
				serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
			{
				// Kiểm tra nếu đã có dữ liệu thì không seed nữa
				if (context.Products.Any())
				{
					return;   // DB đã có dữ liệu
				}

				context.Products.AddRange(
					new Product
					{
						Name = "Laptop Dell XPS 13",
						Price = 25999000m
					},
					new Product
					{
						Name = "iPhone 15 Pro Max",
						Price = 29999000m
					},
					new Product
					{
						Name = "Samsung Galaxy S24",
						Price = 22999000m
					},
					new Product
					{
						Name = "iPad Air",
						Price = 15999000m
					},
					new Product
					{
						Name = "MacBook Pro M3",
						Price = 45999000m
					},
					new Product
					{
						Name = "Sony WH-1000XM5",
						Price = 8999000m
					},
					new Product
					{
						Name = "Logitech MX Master 3S",
						Price = 2499000m
					},
					new Product
					{
						Name = "LG UltraWide Monitor 34\"",
						Price = 12999000m
					}
				);

				context.SaveChanges();
			}
		}
	}
}
