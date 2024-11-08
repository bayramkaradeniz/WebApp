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
        public string? Description { get; set; }

        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public int? StaffId { get; set; }
        public int? SaleTransactionId { get; set; } // SaleTransactionId alanı eklendi

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; } = new Product();

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        [ForeignKey("StaffId")]
        public virtual Staff? Staff { get; set; }

        [ForeignKey("SaleTransactionId")]
        public virtual SaleTransaction? SaleTransaction { get; set; } // SaleTransaction ilişkisi eklendi

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int DefaultDurationInMinutes => Status.GetDefaultDurationInMinutes();
    }

    public enum FaultStatuEnum
    {
        Kurulum = 0,  // "Kurulum"
        Bakim = 1,    // "Bakim"
        Onarim = 2,   // "Onarim"
        Ariza = 3     // "Ariza"
    }

    public static class FaultStatuEnumExtensions
    {
        public static int GetDefaultDurationInMinutes(this FaultStatuEnum status)
        {
            return status switch
            {
                FaultStatuEnum.Kurulum => 120, // 2 saat
                FaultStatuEnum.Bakim => 60,    // 1 saat
                FaultStatuEnum.Onarim => 180,  // 3 saat
                FaultStatuEnum.Ariza => 240,   // 4 saat
                _ => 0
            };
        }
    }
}
