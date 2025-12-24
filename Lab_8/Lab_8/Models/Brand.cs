namespace Lab_8.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Country { get; set; }
        public ICollection<Car> CarModels { get; set; } = new
       List<Car>();
    }
}
