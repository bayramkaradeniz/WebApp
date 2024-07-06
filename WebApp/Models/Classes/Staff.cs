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
        public string StaffName { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string StaffSurname { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(250)]
        public string StaffImage { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public ICollection<SaleTransaction> SaleTransactions { get; set; }
    }
}
