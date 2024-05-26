using System.ComponentModel.DataAnnotations;

namespace Fiorello_PB101.Models
{
    public class Expert : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required]
        [StringLength(50)]
        public string Position { get; set; }
        public string Image { get; set; }
    }
}
