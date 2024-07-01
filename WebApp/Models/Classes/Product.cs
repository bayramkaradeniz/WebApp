using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public short Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool State { get; set; }
        public string ProductImage { get; set; }


    }
}
