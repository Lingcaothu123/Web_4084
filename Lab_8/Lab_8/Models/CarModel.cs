namespace Lab_8.Models
{
    
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
        //public CarModel() { }
        //public CarModel(string name, int brandId)
        //{
        //    Name = name;
        //    BrandId = brandId;
        //    Brand = ;
        //}
        //public override string ToString()
        //{
        //    return $"CarModel(Id={Id}, Name={Name}, BrandId={BrandId})";
        //}
       
    }
}
