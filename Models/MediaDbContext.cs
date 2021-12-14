using API_Assignment_3.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace API_Assignment_3.Models
{
    public class MediaDbContext : DbContext
    {
        // Overide defult constructor
        public MediaDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        // Create Tables
        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        // Fill tables with ModelBuilder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add new franchise
            modelBuilder.Entity<Franchise>().HasData(new Franchise
            {
                Id = 1,
                Name = "The Hobbit",
                Description = "A curious Hobbit, Bilbo Baggins, journeys to the Lonely Mountain with a vigorous group."
            });
            modelBuilder.Entity<Franchise>().HasData(new Franchise
            {
                Id = 2,
                Name = "The Lord of the Rings",
                Description = "A shy young hobbit named Frodo Baggins inherits a simple gold ring."
            });
            modelBuilder.Entity<Franchise>().HasData(new Franchise
            {
                Id = 3,
                Name = "Star Wars",
                Description = "American epic space opera multimedia franchise created by George Lucas."
            });
            // Add some movies

            modelBuilder.Entity<Movie>()
                .Property(b => b.FranchiseId)
                .HasDefaultValue(1);

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 1,
                Title = "The Hobbit : An Unexpected Journey",
                Genre = "Adventure, Fantasy",
                Director = "Peter Jackson",
                ImageURL = "https://www.imdb.com/title/tt0903624/mediaviewer/rm3577719808/?ref_=tt_ov_i",
                TrailerURL = "https://www.imdb.com/video/vi650683417?playlistId=tt0903624&ref_=tt_ov_vi",
                FranchiseId = 1,
                ReleaseYear = "2012",
            });
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 2,
                Title = "The Hobbit: The Desolation of Smaug",
                Genre = "Adventure, Fantasy",
                Director = "Peter Jackson",
                ImageURL = "https://www.imdb.com/title/tt1170358/mediaviewer/rm2431898112/?ref_=tt_ov_i",
                TrailerURL = "https://www.imdb.com/video/vi2165155865?playlistId=tt1170358&ref_=tt_pr_ov_vi",
                FranchiseId = 1,
                ReleaseYear = "2013",
            });
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 3,
                Title = "The Lord of the Rings : The Fellowship of the Ring",
                Genre = "Adventure, Fantasy, Drama",
                Director = "Peter Jackson",
                ImageURL = "https://www.imdb.com/title/tt0120737/mediaviewer/rm3592958976/?ref_=tt_ov_i",
                TrailerURL = "https://www.imdb.com/video/vi2073101337?playlistId=tt0120737&ref_=tt_pr_ov_vi",
                FranchiseId = 2,
                ReleaseYear = "2001",
            });
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 4,
                Title = "Lord Of The Rings: The Two Towers",
                Genre = "Adventure, Fantasy, Drama",
                Director = "Peter Jackson",
                ImageURL = "https://www.imdb.com/title/tt0167261/mediaviewer/rm306845440/?ref_=tt_ov_i",
                TrailerURL = "https://www.imdb.com/video/vi2073101337?playlistId=tt0167261&ref_=tt_pr_ov_vi",
                FranchiseId = 2,
                ReleaseYear = "2002",
            });
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 5,
                Title = "Star Wars Episode IV: A New Hope",
                Genre = "Action, Adventure, Fantasy",
                Director = "George Lucas",
                ImageURL = "https://www.imdb.com/title/tt0076759/mediaviewer/rm3263717120/?ref_=tt_ov_i",
                TrailerURL = "https://www.imdb.com/video/vi1317709849?playlistId=tt0076759&ref_=tt_ov_vi",
                FranchiseId = 3,
                ReleaseYear = "1977",
            });
            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                Id = 6,
                Title = "Star Wars Episode V: The Empire Strikes Back",
                Genre = "Action, Adventure, Fantasy",
                Director = "George Lucas",
                ImageURL = "https://www.imdb.com/title/tt0080684/mediaviewer/rm3114097664/?ref_=tt_ov_i",
                TrailerURL = "https://www.imdb.com/video/vi221753881?playlistId=tt0080684&ref_=tt_pr_ov_vi",
                FranchiseId = 3,
                ReleaseYear = "1980",
            });
            // Add some characters

            modelBuilder.Entity<Character>()
                .Property(b => b.Alias)
                .HasDefaultValue(null);
            modelBuilder.Entity<Character>()
                .Property(b => b.Gender)
                .HasDefaultValue(null);
            modelBuilder.Entity<Character>()
                .Property(b => b.ImageURL)
                .HasDefaultValue(null);


            modelBuilder.Entity<Character>().HasData(new Character
            {
                Id = 1,
                FullName = "Bilbo Baggins",
                Alias = "Bilbo",
                Gender = "Male",
                ImageURL = "https://www.imdb.com/title/tt0903624/mediaviewer/rm2780802048?ref_=ttmi_mi_all_sf_3"
            });
            modelBuilder.Entity<Character>().HasData(new Character
            {
                Id = 2,
                FullName = "Samwise Gamgee",
                Alias = "Sam",
                Gender = "Male",
                ImageURL = "https://www.imdb.com/title/tt0120737/mediaviewer/rm2628354048?ref_=ttmi_mi_all_sf_7"
            });
            modelBuilder.Entity<Character>().HasData(new Character
            {
                Id = 3,
                FullName = "Frodo Baggins",
                Alias = "Frodo",
                Gender = "Male",
                ImageURL = "https://www.imdb.com/title/tt0120737/mediaviewer/rm2645131264?ref_=ttmi_mi_all_sf_6"
            });
            modelBuilder.Entity<Character>().HasData(new Character
            {
                Id = 4,
                FullName = "Luke Skywalker",
                Alias = "Luke",
                Gender = "Male",
                ImageURL = "https://www.imdb.com/title/tt0076759/mediaviewer/rm2759417344?ref_=ttmi_mi_all_sf_3"
            });
            modelBuilder.Entity<Character>().HasData(new Character
            {
                Id = 5,
                FullName = "Princess Leia Organa",
                Alias = "Princess Leia",
                Gender = "Female",
                ImageURL = "https://www.imdb.com/title/tt0076759/mediaviewer/rm2927189504?ref_=ttmi_mi_all_sf_6"
            });
            // Create relationship to movies and Character 
            modelBuilder
                .Entity<Character>()
                .HasMany(m => m.Movies)
                .WithMany(c => c.Characters)
                .UsingEntity<Dictionary<string, object>>("CharacterMovie", r => r.HasOne<Movie>()
                .WithMany().HasForeignKey("MoviesId"), i => i.HasOne<Character>()
                .WithMany().HasForeignKey("CharactersId"), ur =>
                {
                    ur.HasKey("MoviesId", "CharactersId");
                    ur.HasData(
                        new { MoviesId = 1, CharactersId = 1 },
                        new { MoviesId = 2, CharactersId = 1 },
                        new { MoviesId = 3, CharactersId = 3 },
                        new { MoviesId = 3, CharactersId = 2 },
                        new { MoviesId = 4, CharactersId = 3 },
                        new { MoviesId = 5, CharactersId = 4 },
                        new { MoviesId = 5, CharactersId = 5 },
                        new { MoviesId = 6, CharactersId = 4 });
                });
        }
    }
}
