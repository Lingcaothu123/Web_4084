using System.ComponentModel.DataAnnotations;

namespace book1.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public ICollection<Book> Books { get; set; }
    }


}
