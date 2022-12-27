using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulletJournal.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CalendarId",
                table: "Collection",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentDay",
                table: "Collection",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "Collection",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Collection",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Collection",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Bullet",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Bullet",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Bullet",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Bullet",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Bullet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Calendar",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FutureLogMonth",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    CollectionId = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    FutureLogId = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FutureLogMonth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FutureLogMonth_Collection_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collection",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FutureLogMonth_Collection_FutureLogId",
                        column: x => x.FutureLogId,
                        principalTable: "Collection",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Holiday",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Day",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    WeekDay = table.Column<int>(type: "int", nullable: false),
                    IsHoliday = table.Column<bool>(type: "bit", nullable: false),
                    HolidayId = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    EntriesId = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    CalendarEntityId = table.Column<string>(type: "nvarchar(128)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Day_Calendar_CalendarEntityId",
                        column: x => x.CalendarEntityId,
                        principalTable: "Calendar",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Day_Collection_EntriesId",
                        column: x => x.EntriesId,
                        principalTable: "Collection",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Day_Holiday_HolidayId",
                        column: x => x.HolidayId,
                        principalTable: "Holiday",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collection_CalendarId",
                table: "Collection",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Day_CalendarEntityId",
                table: "Day",
                column: "CalendarEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Day_EntriesId",
                table: "Day",
                column: "EntriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Day_HolidayId",
                table: "Day",
                column: "HolidayId");

            migrationBuilder.CreateIndex(
                name: "IX_FutureLogMonth_CollectionId",
                table: "FutureLogMonth",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_FutureLogMonth_FutureLogId",
                table: "FutureLogMonth",
                column: "FutureLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_Calendar_CalendarId",
                table: "Collection",
                column: "CalendarId",
                principalTable: "Calendar",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collection_Calendar_CalendarId",
                table: "Collection");

            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropTable(
                name: "FutureLogMonth");

            migrationBuilder.DropTable(
                name: "Calendar");

            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropIndex(
                name: "IX_Collection_CalendarId",
                table: "Collection");

            migrationBuilder.DropColumn(
                name: "CalendarId",
                table: "Collection");

            migrationBuilder.DropColumn(
                name: "CurrentDay",
                table: "Collection");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "Collection");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Collection");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Collection");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Bullet");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Bullet");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Bullet");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bullet");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Bullet");
        }
    }
}
