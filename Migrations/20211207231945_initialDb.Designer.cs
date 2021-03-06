// <auto-generated />
using API_Assignment_3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_Assignment_3.Migrations
{
    [DbContext(typeof(MediaDbContext))]
    [Migration("20211207231945_initialDb")]
    partial class initialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API_Assignment_3.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Character");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "Bilbo",
                            FullName = "Bilbo Baggins",
                            Gender = "Male",
                            ImageURL = "https://www.imdb.com/title/tt0903624/mediaviewer/rm2780802048?ref_=ttmi_mi_all_sf_3"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "Sam",
                            FullName = "Samwise Gamgee",
                            Gender = "Male",
                            ImageURL = "https://www.imdb.com/title/tt0120737/mediaviewer/rm2628354048?ref_=ttmi_mi_all_sf_7"
                        },
                        new
                        {
                            Id = 3,
                            Alias = "Frodo",
                            FullName = "Frodo Baggins",
                            Gender = "Male",
                            ImageURL = "https://www.imdb.com/title/tt0120737/mediaviewer/rm2645131264?ref_=ttmi_mi_all_sf_6"
                        },
                        new
                        {
                            Id = 4,
                            Alias = "Luke",
                            FullName = "Luke Skywalker",
                            Gender = "Male",
                            ImageURL = "https://www.imdb.com/title/tt0076759/mediaviewer/rm2759417344?ref_=ttmi_mi_all_sf_3"
                        },
                        new
                        {
                            Id = 5,
                            Alias = "Princess Leia",
                            FullName = "Princess Leia Organa",
                            Gender = "Female",
                            ImageURL = "https://www.imdb.com/title/tt0076759/mediaviewer/rm2927189504?ref_=ttmi_mi_all_sf_6"
                        });
                });

            modelBuilder.Entity("API_Assignment_3.Models.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Franchise");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A curious Hobbit, Bilbo Baggins, journeys to the Lonely Mountain with a vigorous group.",
                            Name = "The Hobbit"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A shy young hobbit named Frodo Baggins inherits a simple gold ring.",
                            Name = "The Lord of the Rings"
                        },
                        new
                        {
                            Id = 3,
                            Description = "American epic space opera multimedia franchise created by George Lucas.",
                            Name = "Star Wars"
                        });
                });

            modelBuilder.Entity("API_Assignment_3.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImageURL")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ReleaseYear")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TrailerURL")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "Peter Jackson",
                            FranchiseId = 1,
                            Genre = "Adventure, Fantasy",
                            ImageURL = "https://www.imdb.com/title/tt0903624/mediaviewer/rm3577719808/?ref_=tt_ov_i",
                            ReleaseYear = "2012",
                            Title = "The Hobbit : An Unexpected Journey",
                            TrailerURL = "https://www.imdb.com/video/vi650683417?playlistId=tt0903624&ref_=tt_ov_vi"
                        },
                        new
                        {
                            Id = 2,
                            Director = "Peter Jackson",
                            FranchiseId = 1,
                            Genre = "Adventure, Fantasy",
                            ImageURL = "https://www.imdb.com/title/tt1170358/mediaviewer/rm2431898112/?ref_=tt_ov_i",
                            ReleaseYear = "2013",
                            Title = "The Hobbit: The Desolation of Smaug",
                            TrailerURL = "https://www.imdb.com/video/vi2165155865?playlistId=tt1170358&ref_=tt_pr_ov_vi"
                        },
                        new
                        {
                            Id = 3,
                            Director = "Peter Jackson",
                            FranchiseId = 2,
                            Genre = "Adventure, Fantasy, Drama",
                            ImageURL = "https://www.imdb.com/title/tt0120737/mediaviewer/rm3592958976/?ref_=tt_ov_i",
                            ReleaseYear = "2001",
                            Title = "The Lord of the Rings : The Fellowship of the Ring",
                            TrailerURL = "https://www.imdb.com/video/vi2073101337?playlistId=tt0120737&ref_=tt_pr_ov_vi"
                        },
                        new
                        {
                            Id = 4,
                            Director = "Peter Jackson",
                            FranchiseId = 2,
                            Genre = "Adventure, Fantasy, Drama",
                            ImageURL = "https://www.imdb.com/title/tt0167261/mediaviewer/rm306845440/?ref_=tt_ov_i",
                            ReleaseYear = "2002",
                            Title = "Lord Of The Rings: The Two Towers",
                            TrailerURL = "https://www.imdb.com/video/vi2073101337?playlistId=tt0167261&ref_=tt_pr_ov_vi"
                        },
                        new
                        {
                            Id = 5,
                            Director = "George Lucas",
                            FranchiseId = 3,
                            Genre = "Action, Adventure, Fantasy",
                            ImageURL = "https://www.imdb.com/title/tt0076759/mediaviewer/rm3263717120/?ref_=tt_ov_i",
                            ReleaseYear = "1977",
                            Title = "Star Wars Episode IV: A New Hope",
                            TrailerURL = "https://www.imdb.com/video/vi1317709849?playlistId=tt0076759&ref_=tt_ov_vi"
                        },
                        new
                        {
                            Id = 6,
                            Director = "George Lucas",
                            FranchiseId = 3,
                            Genre = "Action, Adventure, Fantasy",
                            ImageURL = "https://www.imdb.com/title/tt0080684/mediaviewer/rm3114097664/?ref_=tt_ov_i",
                            ReleaseYear = "1980",
                            Title = "Star Wars Episode V: The Empire Strikes Back",
                            TrailerURL = "https://www.imdb.com/video/vi221753881?playlistId=tt0080684&ref_=tt_pr_ov_vi"
                        });
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.HasKey("MoviesId", "CharactersId");

                    b.HasIndex("CharactersId");

                    b.ToTable("CharacterMovie");

                    b.HasData(
                        new
                        {
                            MoviesId = 1,
                            CharactersId = 1
                        },
                        new
                        {
                            MoviesId = 2,
                            CharactersId = 1
                        },
                        new
                        {
                            MoviesId = 3,
                            CharactersId = 3
                        },
                        new
                        {
                            MoviesId = 3,
                            CharactersId = 2
                        },
                        new
                        {
                            MoviesId = 4,
                            CharactersId = 3
                        },
                        new
                        {
                            MoviesId = 5,
                            CharactersId = 4
                        },
                        new
                        {
                            MoviesId = 5,
                            CharactersId = 5
                        },
                        new
                        {
                            MoviesId = 6,
                            CharactersId = 4
                        });
                });

            modelBuilder.Entity("API_Assignment_3.Models.Movie", b =>
                {
                    b.HasOne("API_Assignment_3.Models.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("API_Assignment_3.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Assignment_3.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API_Assignment_3.Models.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
