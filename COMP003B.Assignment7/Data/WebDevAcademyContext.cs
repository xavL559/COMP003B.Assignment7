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
        public DbSet<AlbumViewModel> Album { get; set; }
        public DbSet<ArtistAlbumViewModel> ArtistAlbum { get; set; }
        public DbSet<COMP003B.Assignment7.Models.ArtistAlbumViewModel>? ArtistAlbumViewModel { get; set; }
    }
}
