using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Classes
{
    public class PaymentCategory
    {

        [Key]
        public int PaymentCategoryId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string PaymentCategoryName { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}
