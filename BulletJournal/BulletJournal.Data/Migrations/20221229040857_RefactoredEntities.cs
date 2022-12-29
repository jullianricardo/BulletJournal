using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulletJournal.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactoredEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FutureLogMonth_Collection_CollectionId",
                table: "FutureLogMonth");

            migrationBuilder.DropIndex(
                name: "IX_Log_CollectionId",
                table: "Log");

            migrationBuilder.RenameColumn(
                name: "CollectionId",
                table: "FutureLogMonth",
                newName: "LogId");

            migrationBuilder.RenameIndex(
                name: "IX_FutureLogMonth_CollectionId",
                table: "FutureLogMonth",
                newName: "IX_FutureLogMonth_LogId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_CollectionId",
                table: "Log",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_FutureLogMonth_Log_LogId",
                table: "FutureLogMonth",
                column: "LogId",
                principalTable: "Log",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FutureLogMonth_Log_LogId",
                table: "FutureLogMonth");

            migrationBuilder.DropIndex(
                name: "IX_Log_CollectionId",
                table: "Log");

            migrationBuilder.RenameColumn(
                name: "LogId",
                table: "FutureLogMonth",
                newName: "CollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_FutureLogMonth_LogId",
                table: "FutureLogMonth",
                newName: "IX_FutureLogMonth_CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_CollectionId",
                table: "Log",
                column: "CollectionId",
                unique: true,
                filter: "[CollectionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_FutureLogMonth_Collection_CollectionId",
                table: "FutureLogMonth",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "Id");
        }
    }
}
