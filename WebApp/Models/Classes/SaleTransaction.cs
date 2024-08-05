using System.ComponentModel.DataAnnotations;

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

        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int StaffId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
