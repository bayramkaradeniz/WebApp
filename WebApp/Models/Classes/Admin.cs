using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Classes
{
    public class Admin
    {
        [Key] 
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Auth { get; set; }

    }
}
