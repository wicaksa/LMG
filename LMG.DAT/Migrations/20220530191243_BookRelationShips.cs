using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMG.DAT.Migrations
{
    public partial class BookRelationShips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                schema: "Book",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DC_BookAuthor_AuthorId",
                table: "DC_BookAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_DC_BookAuthor_BookId",
                table: "DC_BookAuthor",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrow_BookId",
                schema: "Borrow",
                table: "Borrow",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_SerieId",
                schema: "Book",
                table: "Book",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Series_SerieId",
                schema: "Book",
                table: "Book",
                column: "SerieId",
                principalSchema: "Series",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrow_Book_BookId",
                schema: "Borrow",
                table: "Borrow",
                column: "BookId",
                principalSchema: "Book",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DC_BookAuthor_Author_AuthorId",
                table: "DC_BookAuthor",
                column: "AuthorId",
                principalSchema: "Author",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DC_BookAuthor_Book_BookId",
                table: "DC_BookAuthor",
                column: "BookId",
                principalSchema: "Book",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Series_SerieId",
                schema: "Book",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrow_Book_BookId",
                schema: "Borrow",
                table: "Borrow");

            migrationBuilder.DropForeignKey(
                name: "FK_DC_BookAuthor_Author_AuthorId",
                table: "DC_BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_DC_BookAuthor_Book_BookId",
                table: "DC_BookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_DC_BookAuthor_AuthorId",
                table: "DC_BookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_DC_BookAuthor_BookId",
                table: "DC_BookAuthor");

            migrationBuilder.DropIndex(
                name: "IX_Borrow_BookId",
                schema: "Borrow",
                table: "Borrow");

            migrationBuilder.DropIndex(
                name: "IX_Book_SerieId",
                schema: "Book",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "SerieId",
                schema: "Book",
                table: "Book");
        }
    }
}
