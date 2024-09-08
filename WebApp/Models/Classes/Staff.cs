using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Classes
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string StaffFullName { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string StaffMail { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string StaffPassword { get; set; }
        public string StaffImage { get; set; }

        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public  Department Department { get; set; }

        public ICollection<SaleTransaction> SaleTransactions { get; set; }
        public ICollection<Fault> Faults { get; set; }
    }
}
