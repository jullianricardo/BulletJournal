using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulletJournal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedJournalIsDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "Journal",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Journal",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "Journal");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Journal");
        }
    }
}
