namespace WebApplication3.Models
{
    // Models/Brand.cs
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }


}
