using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMG.DAT.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Author");

            migrationBuilder.EnsureSchema(
                name: "Book");

            migrationBuilder.EnsureSchema(
                name: "Borrow");

            migrationBuilder.EnsureSchema(
                name: "Member");

            migrationBuilder.EnsureSchema(
                name: "Reservation");

            migrationBuilder.EnsureSchema(
                name: "Review");

            migrationBuilder.EnsureSchema(
                name: "Series");

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Dob = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Dod = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                schema: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Birthdate = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                schema: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    SeriesName = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    TotalBooks = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Copies = table.Column<int>(type: "int", nullable: false),
                    SerieId = table.Column<int>(type: "int", nullable: true),
                    Edition = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    PublicationYear = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Series_SerieId",
                        column: x => x.SerieId,
                        principalSchema: "Series",
                        principalTable: "Series",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "Author",
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthor_Book_BookId",
                        column: x => x.BookId,
                        principalSchema: "Book",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Borrow",
                schema: "Borrow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Borrow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Borrow_Book_BookId",
                        column: x => x.BookId,
                        principalSchema: "Book",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Borrow_Member_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "Member",
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                schema: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationStatus = table.Column<bool>(type: "bit", nullable: false),
                    ReservationResult = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Book_BookId",
                        column: x => x.BookId,
                        principalSchema: "Book",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Member_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "Member",
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                schema: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Review = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_Book_BookId",
                        column: x => x.BookId,
                        principalSchema: "Book",
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Member_MemberId",
                        column: x => x.MemberId,
                        principalSchema: "Member",
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Author",
                table: "Author",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "Dob", "Dod", "FirstName", "LastName", "ModifiedAt", "ModifiedBy" },
                values: new object[,]
                {
                    { 1, null, "Me", "Joanne Rowling, also known by her pen name J. K. Rowling, is a British author and philanthropist. She wrote a seven-volume children's fantasy series, Harry Potter, published from 1997 to 2007.", "07/31/1965", null, "J.K.", "Rowling", null, "Me" },
                    { 2, null, "Me", "Jerome David Salinger was an American author best known for his 1951 novel The Catcher in the Rye. Before its publication, Salinger published several short stories in Story magazine and served in World War II.", "01/01/1919", "01/27/2010", "J.D.", "Sallinger", null, "Me" },
                    { 3, null, "Me", "Chinua Achebe was a Nigerian novelist, poet, and critic who is regarded as the dominant figure of modern African literature. His first novel and magnum opus, Things Fall Apart, occupies a pivotal place in African literature and remains the most widely studied, translated and read African novel.", "11/16/1930", "03/21/2013", "Chinua", "Achebe", null, "Me" },
                    { 4, null, "Me", "Alice Louise Waters is an American chef, restaurateur, and author. In 1971 she opened Chez Panisse, a Berkeley, California restaurant famous for its role in creating the farm-to-table movement and for pioneering California cuisine.", "04/28/1944", null, "Alice", "Waters", null, "Me" }
                });

            migrationBuilder.InsertData(
                schema: "Book",
                table: "Book",
                columns: new[] { "Id", "Copies", "CreatedAt", "CreatedBy", "Edition", "Genre", "ModifiedAt", "ModifiedBy", "PublicationYear", "SerieId", "Summary", "Title" },
                values: new object[,]
                {
                    { 3, 5, null, "Me", 1, "Fiction", null, "Me", 1951, null, "The novel details two days in the life of 16-year-old Holden Caulfield after he has been expelled from prep school. Confused and disillusioned, Holden searches for truth and rails against the phoniness of the adult world.", "The Catcher in the Rye" },
                    { 4, 5, null, "Me", 1, "Fiction", null, "Me", 1958, null, "Things Fall Apart is the debut novel by Nigerian author Chinua Achebe, first published in 1958. It depicts pre-colonial life in the southeastern part of Nigeria and the invasion by Europeans during the late 19th century. ", "Things Fall Apart" },
                    { 5, 2, null, "Me", 1, "Non-Fiction", null, "Me", 2021, null, "Since opening Chez Panisse in 1971, Alice Waters has been a kind of living legend in the movement for local food, sustainable agriculture, and seasonal cooking. In her latest work, she recounts scenes from that career that fans of hers will enjoy while championing a slow food approach to farming and eating, with an emphasis on regenerative agriculture, biodiversity, and health.", "We Are What We Eat: A Slow Food Manifesto" }
                });

            migrationBuilder.InsertData(
                schema: "Member",
                table: "Member",
                columns: new[] { "Id", "Birthdate", "CreatedAt", "CreatedBy", "FirstName", "Gender", "LastName", "ModifiedAt", "ModifiedBy", "Phone" },
                values: new object[,]
                {
                    { 1, "11/15/1967", null, null, "Earl", "Male", "Stevens", null, null, 8312124438L },
                    { 2, "04/28/1966", null, null, "Todd", "Male", "Shaw", null, null, 8315142982L },
                    { 3, "07/11/1974", null, null, "Kimberly", "Female", "Jones", null, null, 8316554577L },
                    { 4, "07/07/1993", null, null, "Khalif", "Male", "Malek", null, null, 8054243108L },
                    { 5, "11/21/1995", null, null, "Amala", "Female", "Dlamini", null, null, 8052629749L }
                });

            migrationBuilder.InsertData(
                schema: "Series",
                table: "Series",
                columns: new[] { "Id", "AuthorId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "SeriesName", "TotalBooks" },
                values: new object[] { 1, 1, null, null, null, null, "Harry Potter", 7 });

            migrationBuilder.InsertData(
                schema: "Book",
                table: "Book",
                columns: new[] { "Id", "Copies", "CreatedAt", "CreatedBy", "Edition", "Genre", "ModifiedAt", "ModifiedBy", "PublicationYear", "SerieId", "Summary", "Title" },
                values: new object[,]
                {
                    { 1, 3, null, "Me", 1, "Fantasy", null, "Me", 1997, 1, "A boy learns on his eleventh birthday that he is the orphaned son of two powerful wizards and possesses unique magical powers of his own. He is summoned from his life as an unwanted child to become a student at Hogwarts, an English boarding school for wizards. There, he meets several friends who become his closest allies and help him discover the truth about his parents' mysterious deaths.", "Harry Potter & The Socerer's Stone" },
                    { 2, 3, null, "Me", 1, "Fantasy", null, "Me", 1998, 1, "The second instalment of boy wizard Harry Potter's adventures at Hogwarts School of Witchcraft and Wizardry, based on the novel by JK Rowling. A mysterious elf tells Harry to expect trouble during his second year at Hogwarts, but nothing can prepare him for trees that fight back, flying cars, spiders that talk and deadly warnings written in blood on the walls of the school.", "Harry Potter and the Chamber of Secrets" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthor",
                columns: new[] { "Id", "AuthorId", "BookId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy" },
                values: new object[,]
                {
                    { 3, 2, 3, null, null, null, null },
                    { 4, 3, 4, null, null, null, null },
                    { 5, 4, 5, null, null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "Borrow",
                table: "Borrow",
                columns: new[] { "Id", "BookId", "BorrowDate", "CreatedAt", "CreatedBy", "DueDate", "MemberId", "ModifiedAt", "ModifiedBy", "ReturnDate", "Status" },
                values: new object[,]
                {
                    { 4, 3, new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Returned" },
                    { 5, 4, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good" },
                    { 6, 5, new DateTime(2021, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, null, new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Overdue" }
                });

            migrationBuilder.InsertData(
                schema: "Reservation",
                table: "Reservation",
                columns: new[] { "Id", "BookId", "CreatedAt", "CreatedBy", "MemberId", "ModifiedAt", "ModifiedBy", "ReservationDate", "ReservationExpirationDate", "ReservationResult", "ReservationStatus" },
                values: new object[,]
                {
                    { 3, 4, null, null, 2, null, null, new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Borrow", false },
                    { 4, 3, null, null, 3, null, null, new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true }
                });

            migrationBuilder.InsertData(
                schema: "Review",
                table: "Review",
                columns: new[] { "Id", "BookId", "CreatedAt", "CreatedBy", "MemberId", "ModifiedAt", "ModifiedBy", "Review" },
                values: new object[] { 4, 4, null, null, 4, null, null, "Snooze fest." });

            migrationBuilder.InsertData(
                table: "BookAuthor",
                columns: new[] { "Id", "AuthorId", "BookId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy" },
                values: new object[,]
                {
                    { 1, 1, 1, null, null, null, null },
                    { 2, 1, 2, null, null, null, null }
                });

            migrationBuilder.InsertData(
                schema: "Borrow",
                table: "Borrow",
                columns: new[] { "Id", "BookId", "BorrowDate", "CreatedAt", "CreatedBy", "DueDate", "MemberId", "ModifiedAt", "ModifiedBy", "ReturnDate", "Status" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good" },
                    { 2, 1, new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, null, new DateTime(2022, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good" },
                    { 3, 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Good" }
                });

            migrationBuilder.InsertData(
                schema: "Reservation",
                table: "Reservation",
                columns: new[] { "Id", "BookId", "CreatedAt", "CreatedBy", "MemberId", "ModifiedAt", "ModifiedBy", "ReservationDate", "ReservationExpirationDate", "ReservationResult", "ReservationStatus" },
                values: new object[,]
                {
                    { 1, 2, null, null, 1, null, null, new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true },
                    { 2, 2, null, null, 3, null, null, new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancel", false },
                    { 5, 2, null, null, 5, null, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true }
                });

            migrationBuilder.InsertData(
                schema: "Review",
                table: "Review",
                columns: new[] { "Id", "BookId", "CreatedAt", "CreatedBy", "MemberId", "ModifiedAt", "ModifiedBy", "Review" },
                values: new object[,]
                {
                    { 1, 1, null, null, 1, null, null, "This book was great." },
                    { 2, 1, null, null, 2, null, null, "This book was bad." },
                    { 3, 2, null, null, 3, null, null, "Amazing book!" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_SerieId",
                schema: "Book",
                table: "Book",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_AuthorId",
                table: "BookAuthor",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_BookId",
                table: "BookAuthor",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrow_BookId",
                schema: "Borrow",
                table: "Borrow",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrow_MemberId",
                schema: "Borrow",
                table: "Borrow",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_BookId",
                schema: "Reservation",
                table: "Reservation",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_MemberId",
                schema: "Reservation",
                table: "Reservation",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_BookId",
                schema: "Review",
                table: "Review",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_MemberId",
                schema: "Review",
                table: "Review",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropTable(
                name: "Borrow",
                schema: "Borrow");

            migrationBuilder.DropTable(
                name: "Reservation",
                schema: "Reservation");

            migrationBuilder.DropTable(
                name: "Review",
                schema: "Review");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "Author");

            migrationBuilder.DropTable(
                name: "Book",
                schema: "Book");

            migrationBuilder.DropTable(
                name: "Member",
                schema: "Member");

            migrationBuilder.DropTable(
                name: "Series",
                schema: "Series");
        }
    }
}
