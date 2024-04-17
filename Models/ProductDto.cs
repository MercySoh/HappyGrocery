using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HappyGrocery.Models
{
    public class ProductDto
    {
        [Required]
        public string? ProductName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}
