using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulletJournal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bullet_Collection_CollectionId",
                table: "Bullet");

            migrationBuilder.RenameColumn(
                name: "CollectionId",
                table: "Bullet",
                newName: "LogId");

            migrationBuilder.RenameIndex(
                name: "IX_Bullet_CollectionId",
                table: "Bullet",
                newName: "IX_Bullet_LogId");

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollectionId = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_Collection_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collection",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_CollectionId",
                table: "Log",
                column: "CollectionId",
                unique: true,
                filter: "[CollectionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Bullet_Log_LogId",
                table: "Bullet",
                column: "LogId",
                principalTable: "Log",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bullet_Log_LogId",
                table: "Bullet");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.RenameColumn(
                name: "LogId",
                table: "Bullet",
                newName: "CollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Bullet_LogId",
                table: "Bullet",
                newName: "IX_Bullet_CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bullet_Collection_CollectionId",
                table: "Bullet",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "Id");
        }
    }
}
