using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Classes
{
    public class SaleTransaction
    {
        [Key]
        public int SaleId { get; set; }

        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
