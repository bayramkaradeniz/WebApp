using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Classes
{
    public class Customer
    {
        [Key] 
        public int CustomerId { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string CustomerName { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string CustomerSurname { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string CustomerEmail { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(15)]
        public string CustomerCity { get; set; }

        public ICollection<SaleTransaction> SaleTransactions { get; set; }
    }
}
