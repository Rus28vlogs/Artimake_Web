using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artimake_Web.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Craftsman")]
        public int CraftsmanId { get; set; }

        [Required]
        public string MessageText { get; set; }

        public DateTime MessageDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Craftsman Craftsman { get; set; }
    }
}
