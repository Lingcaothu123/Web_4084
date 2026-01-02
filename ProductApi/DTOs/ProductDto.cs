namespace ProductApi.DTOs
{
    public class ProductDto
    {
		public string Name { get; set; }
		public decimal Price { get; set; }
        public IFormFile Image { get; set; }
    }
}
