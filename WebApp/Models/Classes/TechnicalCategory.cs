using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Classes
{
    public class TechnicalCategory
    {
        [Key]
        public int TechnicalCategoryId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string TechnicalCategoryName { get; set; }

        public ICollection<TechnicalSupport> TechnicalSupports { get; set; }
    }
}
