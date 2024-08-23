using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Classes
{
    public class TechnicalSupport
    {

        [Key]
        public int TechnicalSupportId { get; set; }

        public DateTime? TransactionDate { get; set; }
        public DateTime? CompletionDate { get; set; }

        public bool? IsComplete { get; set; } // Nullable bool
        [Column(TypeName = "VarChar")]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        public decimal? TransactionFee { get; set; } // Nullable decimal
        public int TechnicalCategoryId { get; set; }

        [ForeignKey("TechnicalCategoryId")]
        public virtual TechnicalCategory TechnicalCategory { get; set; }

        public int? ProductId { get; set; } // Nullable int
        public int? CustomerId { get; set; } // Nullable int
        public int? StaffId { get; set; } // Nullable int

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }



    }
}
