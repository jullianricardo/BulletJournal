using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulletJournal.Data.Migrations
{
    /// <inheritdoc />
    public partial class OrderRestrictions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Page_JournalId",
                table: "Page");

            migrationBuilder.DropIndex(
                name: "IX_Log_CollectionId",
                table: "Log");

            migrationBuilder.DropIndex(
                name: "IX_Collection_PageId",
                table: "Collection");

            migrationBuilder.DropIndex(
                name: "IX_Bullet_LogId",
                table: "Bullet");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Page",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "Log",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "Collection",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "Bullet",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Page_JournalId_Number",
                table: "Page",
                columns: new[] { "JournalId", "Number" },
                unique: true,
                filter: "[JournalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Log_CollectionId_Order",
                table: "Log",
                columns: new[] { "CollectionId", "Order" },
                unique: true,
                filter: "[CollectionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Collection_PageId_Order",
                table: "Collection",
                columns: new[] { "PageId", "Order" },
                unique: true,
                filter: "[PageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bullet_LogId_Order",
                table: "Bullet",
                columns: new[] { "LogId", "Order" },
                unique: true,
                filter: "[LogId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Page_JournalId_Number",
                table: "Page");

            migrationBuilder.DropIndex(
                name: "IX_Log_CollectionId_Order",
                table: "Log");

            migrationBuilder.DropIndex(
                name: "IX_Collection_PageId_Order",
                table: "Collection");

            migrationBuilder.DropIndex(
                name: "IX_Bullet_LogId_Order",
                table: "Bullet");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Page",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "Log",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "Collection",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "Bullet",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Page_JournalId",
                table: "Page",
                column: "JournalId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_CollectionId",
                table: "Log",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Collection_PageId",
                table: "Collection",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Bullet_LogId",
                table: "Bullet",
                column: "LogId");
        }
    }
}
