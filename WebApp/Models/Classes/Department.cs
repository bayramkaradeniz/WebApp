using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Classes
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}
