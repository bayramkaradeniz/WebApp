using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Classes
{
    public enum InstallmentPaymentType
    {
        Cash = 1,
        CreditCard = 2
    }

    public class Installment
    {
        [Key]
        public int InstallmentId { get; set; }

        public decimal InstallmentAmount { get; set; }
        public DateTime InstallmentDate { get; set; }
        public DateTime? PaymentDate { get; set; }

        // Indicates if the installment has been paid
        public bool InstallmentIsPaid { get; set; }

        public int PaymentId { get; set; }

        [ForeignKey("PaymentId")]
        public virtual Payment Payment { get; set; }

        // Payment type for the installment
        public InstallmentPaymentType InstallmentPaymentType { get; set; }
    }


}
