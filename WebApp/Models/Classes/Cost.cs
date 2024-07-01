using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Classes
{
    public class Cost
    {
        [Key] 
        public int CostId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
