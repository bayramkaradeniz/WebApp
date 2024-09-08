using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Classes
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrackingId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string TrackingCode { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        public string TrackingDescription { get; set; }
        public string Date { get; set; }

    }
}

