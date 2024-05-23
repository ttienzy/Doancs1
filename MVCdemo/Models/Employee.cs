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
        [Display(Name = "Tên nhân viên")]
        public string? EmployeeName { get; set; }

        [StringLength(50)]
        [Display(Name = "Dân tộc")]
        public string? EmployeeEthnic { get; set; }

        [Range(0, 1, ErrorMessage = "Male = 1 and Female = 0")]
        [Display(Name = "Giới tính")]
        public int EmployeeGender { get; set; }

        [Display(Name = "Quê quán")]

        [StringLength(50)]
        public string? nativeland { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        [Display(Name = "Số điện thoại")]
        public string EmployeePhone { get; set; }

        [EmailAddress]
        [Display(Name = "Địa chỉ Email")]
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
        [Display(Name = "Ảnh của bạn")]
        public IFormFile formFile { get; set; } = default!;

    }
}
