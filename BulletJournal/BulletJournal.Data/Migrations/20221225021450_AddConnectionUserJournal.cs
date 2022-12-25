using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulletJournal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddConnectionUserJournal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Page",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Journal",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Journal");
        }
    }
}
