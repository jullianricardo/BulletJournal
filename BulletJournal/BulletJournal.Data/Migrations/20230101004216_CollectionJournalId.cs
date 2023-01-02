using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulletJournal.Data.Migrations
{
    /// <inheritdoc />
    public partial class CollectionJournalId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JournalId",
                table: "Collection",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collection_JournalId_Order",
                table: "Collection",
                columns: new[] { "JournalId", "Order" },
                unique: true,
                filter: "[JournalId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_Journal_JournalId",
                table: "Collection",
                column: "JournalId",
                principalTable: "Journal",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collection_Journal_JournalId",
                table: "Collection");

            migrationBuilder.DropIndex(
                name: "IX_Collection_JournalId_Order",
                table: "Collection");

            migrationBuilder.DropColumn(
                name: "JournalId",
                table: "Collection");
        }
    }
}
