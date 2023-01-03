using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulletJournal.Data.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDelete1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bullet_Log_LogId",
                table: "Bullet");

            migrationBuilder.DropForeignKey(
                name: "FK_Log_Collection_CollectionId",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_Page_Journal_JournalId",
                table: "Page");

            migrationBuilder.AddForeignKey(
                name: "FK_Bullet_Log_LogId",
                table: "Bullet",
                column: "LogId",
                principalTable: "Log",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Collection_CollectionId",
                table: "Log",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Page_Journal_JournalId",
                table: "Page",
                column: "JournalId",
                principalTable: "Journal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bullet_Log_LogId",
                table: "Bullet");

            migrationBuilder.DropForeignKey(
                name: "FK_Log_Collection_CollectionId",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_Page_Journal_JournalId",
                table: "Page");

            migrationBuilder.AddForeignKey(
                name: "FK_Bullet_Log_LogId",
                table: "Bullet",
                column: "LogId",
                principalTable: "Log",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Collection_CollectionId",
                table: "Log",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Page_Journal_JournalId",
                table: "Page",
                column: "JournalId",
                principalTable: "Journal",
                principalColumn: "Id");
        }
    }
}
