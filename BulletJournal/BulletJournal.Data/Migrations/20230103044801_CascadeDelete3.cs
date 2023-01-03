using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulletJournal.Data.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDelete3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collection_Journal_JournalId",
                table: "Collection");

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_Journal_JournalId",
                table: "Collection",
                column: "JournalId",
                principalTable: "Journal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collection_Journal_JournalId",
                table: "Collection");

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_Journal_JournalId",
                table: "Collection",
                column: "JournalId",
                principalTable: "Journal",
                principalColumn: "Id");
        }
    }
}
