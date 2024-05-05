using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCdemo.Models
{
    public class EmploymentContract
    {
        [Key]
        public int EmploymentContractId { get; set; }

        [StringLength(50)]
        public string? CategoryEmploymentContact { get; set;}

        [DataType(DataType.Date)]
        public DateTime DayStart { get; set; }

        [DataType(DataType.Date)]
        public DateTime DayEnd { get; set; }
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
