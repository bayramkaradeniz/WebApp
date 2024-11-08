using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        // Döngüyü önlemek için SaleTransactions burada yer
    }
}