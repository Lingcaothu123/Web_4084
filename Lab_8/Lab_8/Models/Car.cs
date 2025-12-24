namespace Lab_8.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
    }
}
