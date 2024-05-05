using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCdemo.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string? EmployeeName { get; set; }

        [StringLength(50)]
        public string? EmployeeEthnic { get; set; }

        [Range(0,1,ErrorMessage = "Male = 1 and Female = 0")]
        public int EmployeeGender { get; set; }

        [Display(Name = "Nativeland")]
        [StringLength(50)]
        public string? nativeland { get; set;}

        [DataType(DataType.PhoneNumber)]
        [Required]
        public string EmployeePhone { get; set; }
        
        [EmailAddress]
        [Display(Name = "EMAIL")]
        public string Email { set; get; }

        [Display(Name = "Position")]
        public int PositionID { get; set; }

        [Display(Name = "Salary")]
        public int LevelSalary { get; set; }

        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        [ForeignKey("PositionID")]
        public Position position { get; set; }
        [ForeignKey("LevelSalary")]
        public Salary salary { get; set; }
        [ForeignKey("DepartmentID")]
        public Department department { get; set; }

        [StringLength(50)]
        public string? UrlImage { get; set; }

        [NotMapped]
        [Display(Name = "UpLoad Image")]
        public IFormFile formFile { get; set; } = default!;

    }
}
