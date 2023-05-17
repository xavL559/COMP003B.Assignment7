﻿// <auto-generated />
using COMP003B.LectureActivity7.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace COMP003B.Assignment7.Migrations
{
    [DbContext(typeof(WebDevAcademyContext))]
    [Migration("20230517015140_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("COMP003B.Assignment7.Models.AlbumViewModel", b =>
                {
                    b.Property<string>("AlbumTitle")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AlbumTitle");

                    b.ToTable("AlbumTitle");
                });

            modelBuilder.Entity("COMP003B.Assignment7.Models.ArtistViewModel", b =>
                {
                    b.Property<string>("Artist")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Artist");

                    b.ToTable("ArtistViewModel");
                });
#pragma warning restore 612, 618
        }
    }
}
