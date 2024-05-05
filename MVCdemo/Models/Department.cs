using System.ComponentModel.DataAnnotations;

namespace MVCdemo.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        [StringLength(100)]
        public string? DepartmentName { get; set; }

        [Required]
        [StringLength(100)]
        public string? DepartmentAddress { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public long DepartmentPhone { get; set; }

        [EmailAddress]
        [Display(Name = "EMAIL")]
        public string Email { set; get; }
    }
}
