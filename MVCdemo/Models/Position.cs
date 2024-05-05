using System.ComponentModel.DataAnnotations;

namespace MVCdemo.Models
{
    public class Position
    {
        [Key]
        public int PositionId { get; set; }

        [Required]
        [StringLength(100)]
        public string? PositionName { get; set; }
    }
}
