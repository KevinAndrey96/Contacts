using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    documentType = table.Column<string>(nullable: true),
                    documentNumber = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_email_phone_documentNumber",
                table: "Users",
                columns: new[] { "email", "phone", "documentNumber" },
                unique: true,
                filter: "[email] IS NOT NULL AND [phone] IS NOT NULL AND [documentNumber] IS NOT NULL");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
