using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCdemo.Models
{
    public class Salary
    {
        [Key]
        public int LevelSalary { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal BasicSalary { get; set; }

        public int CoefficientsSalary { get; set; }

        [Column(TypeName = "money")]
        public decimal AllowanceSalary {  get; set; }
    }
}
