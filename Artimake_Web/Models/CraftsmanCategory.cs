using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artimake_Web.Models
{
    public class CraftsmanCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Craftsman> Craftsmen { get; set; }
    }
}
