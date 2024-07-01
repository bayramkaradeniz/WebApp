using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Classes
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public string StaffName { get; set; }

        public string StaffSurname { get; set; }
        public string StaffImage { get; set; }

    }
}
