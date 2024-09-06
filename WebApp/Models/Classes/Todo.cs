using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Classes
{
    public class Todo
    {
        [Key]
        public int ToDoID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(300)]
        public string TodoDescription { get; set; }
        public bool State { get; set; }
    }
}
