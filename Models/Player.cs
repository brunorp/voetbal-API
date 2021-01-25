using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace voetbal_api.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; private set; }

        [Required(ErrorMessage="Field \"Name\" is required.", AllowEmptyStrings=false)]
        [MaxLength(50, ErrorMessage="Name max length is 50 characters")]
        public string Name { get; set; }
        
        [Required(ErrorMessage="Field \"Position\" is required.", AllowEmptyStrings=false)]
        [MaxLength(30, ErrorMessage="Position max length is 50 characters")]
        public string Position { get; set; }
        
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        
        public Team team { get; set; }
    }
}