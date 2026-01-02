namespace WebApplication3.Models
{
    // Models/Brand.cs
    // Models/Car.cs
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
    }


}
