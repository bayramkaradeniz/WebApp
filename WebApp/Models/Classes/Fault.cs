using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Classes
{
    public class Fault
    {
        [Key]
        public int FaultId { get; set; }
        public FaultStatuEnum Status { get; set; }

        public DateTime Timestamp { get; set; }

        public bool IsComplete { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public int StaffId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }
    }
    public enum FaultStatuEnum
    {
        Yeni,            // 0
        Tamirde,         // 1
        Onarıldı,        // 2
        ParçaBekleniyor, // 3
        Kapandı,         // 4
        İptalEdildi      // 5
    }


}
