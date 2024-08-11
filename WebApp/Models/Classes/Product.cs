using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Column(TypeName ="VarChar")]
        [StringLength(30)]
        public string ProductName { get; set; }
        [StringLength(30)]
        public string Brand { get; set; }
        public int Stock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool State { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        public string ProductModel { get; set; }

        public int MaintenanceIntervalInMonths { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]

        public virtual Category Category { get; set; }

        public ICollection<SaleTransaction> SaleTransactions { get; set; }

    }
}
