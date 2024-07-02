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

        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public Staff Staff { get; set; }
    }
}
