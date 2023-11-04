using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artimake_Web.Models
{
    public class Craftsman
    {
        [Key]
        public int CraftsmanId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string ContactInfo { get; set; }

        public string Description { get; set; }

        [ForeignKey("CraftsmanCategory")]
        public int? CategoryId { get; set; }

        public virtual CraftsmanCategory CraftsmanCategory { get; set; }

        // Если у вас есть связи с другими таблицами, добавьте их здесь
        // Например, если у мастеров есть продукты:
        public virtual ICollection<Product> Products { get; set; }
    }
}
