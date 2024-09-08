using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Classes
{

    public class CargoDetail
    {
        [Key]
        public int CargoDetailId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        public string Description { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string TrackingCode { get; set; }
        public string Staff { get; set; }
        public string Owner { get; set; }
        public DateTime Date { get; set; }

    }
}
