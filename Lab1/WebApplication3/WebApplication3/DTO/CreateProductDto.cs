using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WebApplication3.DTOs
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
        public string Name { get; set; } = null!;

        [Range(0.01, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Chọn danh mục")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Hình ảnh là bắt buộc")]
        public IFormFile Image { get; set; } = null!;
    }
}
