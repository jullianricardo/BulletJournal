using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulletJournal.Data.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDelete2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionPage_Collection_CollectionId",
                table: "CollectionPage");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionPage_Page_PageId",
                table: "CollectionPage");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionPage_Collection_CollectionId",
                table: "CollectionPage",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionPage_Page_PageId",
                table: "CollectionPage",
                column: "PageId",
                principalTable: "Page",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollectionPage_Collection_CollectionId",
                table: "CollectionPage");

            migrationBuilder.DropForeignKey(
                name: "FK_CollectionPage_Page_PageId",
                table: "CollectionPage");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionPage_Collection_CollectionId",
                table: "CollectionPage",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CollectionPage_Page_PageId",
                table: "CollectionPage",
                column: "PageId",
                principalTable: "Page",
                principalColumn: "Id");
        }
    }
}
