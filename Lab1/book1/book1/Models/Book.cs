using System.ComponentModel.DataAnnotations;

namespace book.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Range(0, 1000000)]
        public decimal Price { get; set; }

        public string Description { get; set; }
        public string Image { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

}
