using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Classes
{
    public class SaleTransaction
    {
        [Key]
        public int SaleTransactionId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public Boolean State { get; set; } = true;

        public string PaymentStatus { get; set; }= string.Empty;

        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int StaffId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }
    }
}
