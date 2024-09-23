using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookServicesApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAUserFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "zipCode",
                table: "Authors",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "Authors",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "Authors",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Authors",
                newName: "Province");

            migrationBuilder.CreateTable(
                name: "BookOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookOrder_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookOrder_BookId",
                table: "BookOrder",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookOrder");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Authors",
                newName: "zipCode");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Authors",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Authors",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "Authors",
                newName: "State");
        }
    }
}
