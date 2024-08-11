using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApexaAssignment.Models
{
    public class Advisor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "SIN must be 9 characters in length.")]
        [Index(IsUnique = true)]
        public string SIN 
        {
            get
            {
                return $"{new string('*', 9)}";
            }
            set { }
        }
        public string? Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid Phone number")]
        public string? Phone { get; set; }
        [DisplayName("Health Status")]
        public HealthStatusType HealthStatus { get; set; }
    }
}
