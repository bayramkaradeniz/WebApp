using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Classes
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string DepartmentName { get; set; }

        public ICollection<Staff> Staffs { get; set; }
    }
}
