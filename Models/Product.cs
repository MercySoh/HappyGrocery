using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyGrocery.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Please enter product name.")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage ="Please enter valid price.")] 
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter quantity.")]
        public int Qty { get; set; }

        [Required(ErrorMessage ="Please enter category for product.")]
        public int CategoryId {  get; set; }
    }
}
