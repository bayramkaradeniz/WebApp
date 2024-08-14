
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Classes
{
    public class Detail 
    {
        [Key]
        public int DetailId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string DProductName { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(2000)]
        public string DProductDescription { get; set; }
    }
}
