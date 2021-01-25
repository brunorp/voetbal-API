using System.ComponentModel.DataAnnotations;

namespace voetbal_api.Models
{
    public class Team 
    {
        [Key]
        public int TeamId { get; private set; }

        [Required(ErrorMessage = "Field \"Name\" is required.", AllowEmptyStrings=false)]
        [MaxLength(50, ErrorMessage="Name max length is 50 characters")]
        public string Name { get; set; }
    }
}