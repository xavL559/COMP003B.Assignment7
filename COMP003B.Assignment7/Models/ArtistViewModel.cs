using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment7.Models
{
    public class ArtistViewModel
    {
        [Required]
        public string Artist { get; set; }
    }
}
