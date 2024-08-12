using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApexaAssignment.Models
{
    public class Advisor
    {
        private string _SIN;
        private string? _Phone;

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
            get { return $"{new string('*', 9)}"; }
            set { _SIN = value; }
        }
        [StringLength(255, ErrorMessage = "Address cannot be longer than 255 characters.")]
        public string? Address { get; set; }
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Phone Number must be 8 characters in length.")]
        public string? Phone
        {
            get
            {
                return $"{new string('*', 8)}";
            }
            set { _Phone = value; }
        }
        [DisplayName("Health Status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public HealthStatusType HealthStatus { get; set; }
    }
}
