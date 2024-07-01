using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Classes
{
    public class BillItem
    {
        [Key] 
        public int BillItemId { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Sum { get; set; }
    }
}
