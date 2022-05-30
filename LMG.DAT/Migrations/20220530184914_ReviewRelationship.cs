using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMG.DAT.Migrations
{
    public partial class ReviewRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Review_BookId",
                schema: "Review",
                table: "Review",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Book_BookId",
                schema: "Review",
                table: "Review",
                column: "BookId",
                principalSchema: "Book",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Book_BookId",
                schema: "Review",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_BookId",
                schema: "Review",
                table: "Review");
        }
    }
}
