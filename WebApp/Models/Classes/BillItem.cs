using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Classes
{
    public class BillItem
    {
        [Key] 
        public int BillItemId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(130)]
        public string Description { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Sum { get; set; }

        public Bill Bill { get; set; }
    }
}
