using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment7.Models
{
    public class ArtistViewModel
    {
        [Key]
        [Required]
        public string Artist { get; set; }
    }
}
