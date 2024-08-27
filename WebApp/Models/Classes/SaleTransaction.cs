using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Classes
{
    public class SaleTransaction
    {
        [Key]
        public int SaleTransactionId { get; set; }
        public DateTime Date { get; set; }
        public int StockAmount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public bool State { get; set; } = true;
        public DateTime? InstallationDate { get; set; }

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
}
