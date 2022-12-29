using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulletJournal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Log",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Collection",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Bullet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Collection");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Bullet");
        }
    }
}
