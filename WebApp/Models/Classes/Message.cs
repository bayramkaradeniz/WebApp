using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Classes
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Receiver { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Sender { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Subject { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(500)]
        public string Content { get; set; } 

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }



    }
}
