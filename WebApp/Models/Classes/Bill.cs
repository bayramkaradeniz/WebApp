using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Classes
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }
        public string BillSequenceNo { get; set; }
        public string BillSerialNo { get; set; }
        public DateTime Date { get; set; }
        public DateTime Hour { get; set; }
        public string TaxOffice { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }

        public Category Category { get; set; }
    }
}
