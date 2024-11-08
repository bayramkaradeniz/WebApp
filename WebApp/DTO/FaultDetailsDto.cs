using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models.Classes;

namespace WebApp.DTO
{
    public class FaultDetailsDto
    {
        public int FaultId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime Timestamp { get; set; }
        public bool IsComplete { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public string? ProductName { get; set; }
    }
}