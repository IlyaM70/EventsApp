using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EventsChangeMainEventIdNullability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Events_MainEventId",
                table: "Events");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Events",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 14, 9, 6, 42, 631, DateTimeKind.Utc).AddTicks(5112),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 13, 14, 43, 49, 800, DateTimeKind.Utc).AddTicks(8259));

            migrationBuilder.AlterColumn<int>(
                name: "MainEventId",
                table: "Events",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Events",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 14, 9, 6, 42, 631, DateTimeKind.Utc).AddTicks(4811),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 13, 14, 43, 49, 800, DateTimeKind.Utc).AddTicks(7969));

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Events_MainEventId",
                table: "Events",
                column: "MainEventId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Events_MainEventId",
                table: "Events");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Updated",
                table: "Events",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 13, 14, 43, 49, 800, DateTimeKind.Utc).AddTicks(8259),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 14, 9, 6, 42, 631, DateTimeKind.Utc).AddTicks(5112));

            migrationBuilder.AlterColumn<int>(
                name: "MainEventId",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Events",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 1, 13, 14, 43, 49, 800, DateTimeKind.Utc).AddTicks(7969),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 1, 14, 9, 6, 42, 631, DateTimeKind.Utc).AddTicks(4811));

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Events_MainEventId",
                table: "Events",
                column: "MainEventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
