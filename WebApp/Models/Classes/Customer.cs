using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Classes
{
    public class Customer
    {
        [Key] 
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } 
        public string CustomerSurname { get; set; } 
        public string CustomerEmail { get; set; }
        public string CustomerCity { get; set; }

    }
}
