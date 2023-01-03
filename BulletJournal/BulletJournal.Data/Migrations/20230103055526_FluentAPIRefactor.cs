using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulletJournal.Data.Migrations
{
    /// <inheritdoc />
    public partial class FluentAPIRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Index_IndexId",
                table: "Topic");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Index_IndexId",
                table: "Topic",
                column: "IndexId",
                principalTable: "Index",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Index_IndexId",
                table: "Topic");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Index_IndexId",
                table: "Topic",
                column: "IndexId",
                principalTable: "Index",
                principalColumn: "Id");
        }
    }
}
