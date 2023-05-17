using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment7.Models
{
    public class AlbumViewModel
    {
        [Required]
        public string AlbumTitle { get; set; }
    }
}
