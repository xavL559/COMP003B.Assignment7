using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment7.Models
{
    public class ArtistAlbumViewModel
    {
        [Required]
        [Key]
        public string ArtistId { get; set; }

        [Required]
        public string AlbumId { get; set; }
    }
}
