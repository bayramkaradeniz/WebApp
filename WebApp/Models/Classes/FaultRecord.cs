using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Classes
{
    public class FaultRecord
    {
        [Key]
        public int SaleTransactionId { get; set; }
        public string? Issue { get; set; }
    }
}
