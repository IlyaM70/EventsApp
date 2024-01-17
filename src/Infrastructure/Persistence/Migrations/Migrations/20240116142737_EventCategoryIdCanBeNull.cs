using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EventCategoryIdCanBeNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Categories_CategoryId",
                table: "Events");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Events",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 14, 27, 37, 174, DateTimeKind.Utc).AddTicks(2103),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 14, 9, 6, 42, 631, DateTimeKind.Utc).AddTicks(5112));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Events",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 16, 14, 27, 37, 174, DateTimeKind.Utc).AddTicks(1802),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 14, 9, 6, 42, 631, DateTimeKind.Utc).AddTicks(4811));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Events",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Categories_CategoryId",
                table: "Events",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Categories_CategoryId",
                table: "Events");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Events",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 14, 9, 6, 42, 631, DateTimeKind.Utc).AddTicks(5112),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 16, 14, 27, 37, 174, DateTimeKind.Utc).AddTicks(2103));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Events",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 14, 9, 6, 42, 631, DateTimeKind.Utc).AddTicks(4811),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 16, 14, 27, 37, 174, DateTimeKind.Utc).AddTicks(1802));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Categories_CategoryId",
                table: "Events",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
