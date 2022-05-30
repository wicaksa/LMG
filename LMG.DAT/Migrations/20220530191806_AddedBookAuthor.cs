using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMG.DAT.Migrations
{
    public partial class AddedBookAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DC_BookAuthor_Author_AuthorId",
                table: "DC_BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_DC_BookAuthor_Book_BookId",
                table: "DC_BookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DC_BookAuthor",
                table: "DC_BookAuthor");

            migrationBuilder.RenameTable(
                name: "DC_BookAuthor",
                newName: "BookAuthor");

            migrationBuilder.RenameIndex(
                name: "IX_DC_BookAuthor_BookId",
                table: "BookAuthor",
                newName: "IX_BookAuthor_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_DC_BookAuthor_AuthorId",
                table: "BookAuthor",
                newName: "IX_BookAuthor_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Author_AuthorId",
                table: "BookAuthor",
                column: "AuthorId",
                principalSchema: "Author",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthor_Book_BookId",
                table: "BookAuthor",
                column: "BookId",
                principalSchema: "Book",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Author_AuthorId",
                table: "BookAuthor");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthor_Book_BookId",
                table: "BookAuthor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthor",
                table: "BookAuthor");

            migrationBuilder.RenameTable(
                name: "BookAuthor",
                newName: "DC_BookAuthor");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthor_BookId",
                table: "DC_BookAuthor",
                newName: "IX_DC_BookAuthor_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthor_AuthorId",
                table: "DC_BookAuthor",
                newName: "IX_DC_BookAuthor_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DC_BookAuthor",
                table: "DC_BookAuthor",
                column: "Id");

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
    }
}
