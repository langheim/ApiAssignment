using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Assignment_3.Migrations
{
    public partial class initialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ImageURL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Franchise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReleaseYear = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Director = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TrailerURL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FranchiseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Franchise_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterMovie",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "int", nullable: false),
                    CharactersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterMovie", x => new { x.MoviesId, x.CharactersId });
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Character_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterMovie_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Character",
                columns: new[] { "Id", "Alias", "FullName", "Gender", "ImageURL" },
                values: new object[,]
                {
                    { 1, "Bilbo", "Bilbo Baggins", "Male", "https://www.imdb.com/title/tt0903624/mediaviewer/rm2780802048?ref_=ttmi_mi_all_sf_3" },
                    { 2, "Sam", "Samwise Gamgee", "Male", "https://www.imdb.com/title/tt0120737/mediaviewer/rm2628354048?ref_=ttmi_mi_all_sf_7" },
                    { 3, "Frodo", "Frodo Baggins", "Male", "https://www.imdb.com/title/tt0120737/mediaviewer/rm2645131264?ref_=ttmi_mi_all_sf_6" },
                    { 4, "Luke", "Luke Skywalker", "Male", "https://www.imdb.com/title/tt0076759/mediaviewer/rm2759417344?ref_=ttmi_mi_all_sf_3" },
                    { 5, "Princess Leia", "Princess Leia Organa", "Female", "https://www.imdb.com/title/tt0076759/mediaviewer/rm2927189504?ref_=ttmi_mi_all_sf_6" }
                });

            migrationBuilder.InsertData(
                table: "Franchise",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A curious Hobbit, Bilbo Baggins, journeys to the Lonely Mountain with a vigorous group.", "The Hobbit" },
                    { 2, "A shy young hobbit named Frodo Baggins inherits a simple gold ring.", "The Lord of the Rings" },
                    { 3, "American epic space opera multimedia franchise created by George Lucas.", "Star Wars" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "ImageURL", "ReleaseYear", "Title", "TrailerURL" },
                values: new object[,]
                {
                    { 1, "Peter Jackson", 1, "Adventure, Fantasy", "https://www.imdb.com/title/tt0903624/mediaviewer/rm3577719808/?ref_=tt_ov_i", "2012", "The Hobbit : An Unexpected Journey", "https://www.imdb.com/video/vi650683417?playlistId=tt0903624&ref_=tt_ov_vi" },
                    { 2, "Peter Jackson", 1, "Adventure, Fantasy", "https://www.imdb.com/title/tt1170358/mediaviewer/rm2431898112/?ref_=tt_ov_i", "2013", "The Hobbit: The Desolation of Smaug", "https://www.imdb.com/video/vi2165155865?playlistId=tt1170358&ref_=tt_pr_ov_vi" },
                    { 3, "Peter Jackson", 2, "Adventure, Fantasy, Drama", "https://www.imdb.com/title/tt0120737/mediaviewer/rm3592958976/?ref_=tt_ov_i", "2001", "The Lord of the Rings : The Fellowship of the Ring", "https://www.imdb.com/video/vi2073101337?playlistId=tt0120737&ref_=tt_pr_ov_vi" },
                    { 4, "Peter Jackson", 2, "Adventure, Fantasy, Drama", "https://www.imdb.com/title/tt0167261/mediaviewer/rm306845440/?ref_=tt_ov_i", "2002", "Lord Of The Rings: The Two Towers", "https://www.imdb.com/video/vi2073101337?playlistId=tt0167261&ref_=tt_pr_ov_vi" },
                    { 5, "George Lucas", 3, "Action, Adventure, Fantasy", "https://www.imdb.com/title/tt0076759/mediaviewer/rm3263717120/?ref_=tt_ov_i", "1977", "Star Wars Episode IV: A New Hope", "https://www.imdb.com/video/vi1317709849?playlistId=tt0076759&ref_=tt_ov_vi" },
                    { 6, "George Lucas", 3, "Action, Adventure, Fantasy", "https://www.imdb.com/title/tt0080684/mediaviewer/rm3114097664/?ref_=tt_ov_i", "1980", "Star Wars Episode V: The Empire Strikes Back", "https://www.imdb.com/video/vi221753881?playlistId=tt0080684&ref_=tt_pr_ov_vi" }
                });

            migrationBuilder.InsertData(
                table: "CharacterMovie",
                columns: new[] { "CharactersId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 3, 3 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 5 },
                    { 5, 5 },
                    { 4, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterMovie_CharactersId",
                table: "CharacterMovie",
                column: "CharactersId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_FranchiseId",
                table: "Movie",
                column: "FranchiseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterMovie");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Franchise");
        }
    }
}
