using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.DTOs;
using ProductApi.Models;
using System.Linq;

namespace ProductApi.Controllers
{
    [ApiController]
	[Route("api/products")]
	public class ProductsController : ControllerBase
	{
		private readonly AppDbContext _context;

		public ProductsController(AppDbContext context)
		{
			_context = context;
		} 


		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				var products = await _context.Products.ToListAsync();
				return Ok(new
				{
					message = "OK",
					products = products,
					statusCode=200
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "Lỗi khi lấy danh sách sản phẩm",
					error = ex.Message
				});
			}
		} 

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			try
			{
				var product = await _context.Products.FindAsync(id);

				if (product == null)
					return NotFound(new { message = "Không tìm thấy sản phẩm" });

				return Ok(product); 
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "Lỗi khi lấy sản phẩm",
					error = ex.Message
				});
			}
		}
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductDto dto)
        {
            try
            {
                

              
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                var extension = Path.GetExtension(dto.Image.FileName).ToLower();

                if (!allowedExtensions.Contains(extension))
                {
                    return BadRequest(new
                    {
                        errorCode = "INVALID_FILE_TYPE",
                        message = "Chỉ chấp nhận ảnh JPG hoặc PNG"
                    });
                }

              
                var fileName = $"{Guid.NewGuid()}{extension}";
                var uploadFolder = Path.Combine("wwwroot", "uploads");

                if (!Directory.Exists(uploadFolder))
                    Directory.CreateDirectory(uploadFolder);

                var filePath = Path.Combine(uploadFolder, fileName);

              
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await dto.Image.CopyToAsync(stream);
                }
                var product = new Product
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    ImageUrl = $"/uploads/{fileName}"
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, new
                {
                    errorCode = "SYSTEM_ERROR",
                    message = "Lỗi hệ thống khi tạo sản phẩm",
                    detail = ex.Message
                });
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(ProductDto dto)
        //{
        //	try
        //	{
        //		if (!ModelState.IsValid)
        //			return BadRequest(ModelState); // 400

        //		var product = new Product
        //		{
        //			Name = dto.Name,
        //			Price = dto.Price
        //		};

        //		_context.Products.Add(product);
        //		await _context.SaveChangesAsync();

        //		return CreatedAtAction(nameof(GetById),
        //			new { id = product.Id }, product); // 201
        //	}
        //	catch (Exception ex)
        //	{
        //		return StatusCode(500, new
        //		{
        //			message = "Lỗi khi tạo sản phẩm",
        //			error = ex.Message
        //		});
        //	}
        //}

        [HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, ProductDto dto)
		{
			try
			{
				var product = await _context.Products.FindAsync(id);
				if (product == null)
					return NotFound(new { message = "Không tìm thấy sản phẩm" }); // 404
				product.Name = dto.Name;
				product.Price = dto.Price;
				await _context.SaveChangesAsync();
				return NoContent(); // 204
			} 
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "Lỗi hệ thống",
					error = ex.Message
				});
			}
		}
		 
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var product = await _context.Products.FindAsync(id);
				if (product == null)
				{
					return NotFound(new
					{
						statusCode = 404, 
						message = "PRODUCT NOT FOUND"
                    });
				}	
				_context.Products.Remove(product);
				await _context.SaveChangesAsync();
				return NoContent(); // 204
			}
			catch (Exception ex)
			{
				return StatusCode(500, new
				{
					message = "Error",
					error = ex.Message
				});
			}
		}
	}
}
