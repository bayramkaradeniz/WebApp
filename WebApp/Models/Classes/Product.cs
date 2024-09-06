using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Classes
{
    public class Product
    {
        [Key]
        [Display(Name ="Ürün Id")]
        public int ProductId { get; set; }
        [Column(TypeName ="VarChar")]
        [StringLength(30)]
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }
        [StringLength(30)]
        [Display(Name = "Marka")]
        public string Brand { get; set; }
        [Display(Name = "Stok")]
        public int Stock { get; set; }
        [Display(Name = "Alış Fiyatı")]
        public decimal PurchasePrice { get; set; }
        [Display(Name = "Satış Fiyatı")]
        public decimal SalePrice { get; set; }
        [Display(Name = "Mevcut mu?")]
        public bool State { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        [Display(Name = "Model")]
        public string ProductModel { get; set; }
        [Display(Name = "Ürün Görseli")]
        public string  ProductImage { get; set; } = string.Empty;
        [Display(Name = "Bakım Periyotu")]
        public int MaintenanceIntervalInMonths { get; set; }
       
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]

        public virtual Category Category { get; set; }

        public ICollection<SaleTransaction> SaleTransactions { get; set; }
        public ICollection<Fault> Faults { get; set; }
    }
}
