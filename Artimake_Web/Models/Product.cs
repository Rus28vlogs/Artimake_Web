using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artimake_Web.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [ForeignKey("Craftsman")]
        public int CraftsmanId { get; set; }

        [ForeignKey("ProductCategory")]
        public int? CategoryId { get; set; }

        public virtual Craftsman Craftsman { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
