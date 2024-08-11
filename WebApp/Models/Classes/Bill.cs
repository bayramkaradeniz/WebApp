using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Classes
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(15)]
        public string BillSequenceNo { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string BillSerialNo { get; set; }
        public DateTime Date { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Hour { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(15)]
        public string TaxOffice { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Sender { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string Receiver { get; set; }
        public decimal Total { get; set; }

        public ICollection<BillItem> BillItems { get; set; }
    }
}
