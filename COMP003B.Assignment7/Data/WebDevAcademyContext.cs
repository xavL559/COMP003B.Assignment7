using COMP003B.Assignment7.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.LectureActivity7.Data
{
    public class WebDevAcademyContext : DbContext
    {
        public WebDevAcademyContext(DbContextOptions<WebDevAcademyContext> options)
            : base(options)
        {
        }

        public DbSet<ArtistViewModel> Artist { get; set; }
        public DbSet<AlbumViewModel> AlbumTitle { get; set; }
        public DbSet<ArtistViewModel> ArtistAlbum { get; set; }
    }
}
