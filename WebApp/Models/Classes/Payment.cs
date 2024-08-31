using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Classes
{
    public enum PaymentTypeForDownPayment
    {
        Cash = 1,
        CreditCard = 2
    }
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public decimal? TotalPrice { get; set; }

        public decimal? PaidPrice { get; set; }
        public decimal? DownPayment { get; set; }
        public int? InstallmentCount { get; set; }
        public DateTime? FirstInstallmentDate { get; set; }
        public int? InstallmentPeriodMonths { get; set; }


        // Indicates if the payment has been fully completed
        public bool IsPaid { get; set; } = true;
        public PaymentTypeForDownPayment? PaymentTypeForDownPayment { get; set; }
        public int PaymentCategoryId { get; set; }

        [ForeignKey("PaymentCategoryId")]
        public virtual PaymentCategory PaymentCategory { get; set; }

        // Navigation property for SaleTransaction
        public virtual SaleTransaction SaleTransaction { get; set; }

        // Nullable List of Installments
        public virtual List<Installment> Installments { get; set; } = null;
    }
}
