using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulletJournal.Data.Migrations
{
    /// <inheritdoc />
    public partial class IndexCascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Index_Journal_JournalId",
                table: "Index");

            migrationBuilder.AddForeignKey(
                name: "FK_Index_Journal_JournalId",
                table: "Index",
                column: "JournalId",
                principalTable: "Journal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Index_Journal_JournalId",
                table: "Index");

            migrationBuilder.AddForeignKey(
                name: "FK_Index_Journal_JournalId",
                table: "Index",
                column: "JournalId",
                principalTable: "Journal",
                principalColumn: "Id");
        }
    }
}
