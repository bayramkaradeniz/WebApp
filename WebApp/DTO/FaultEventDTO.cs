using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.DTO
{
    public class FaultEventDTO
    {
        public string? Status { get; set; }
        public int ProductId { get; set; }
        public int Duration { get; set; }
        public string? StartDate { get; set; }
        public int CustomerId { get; set; }
    }
}