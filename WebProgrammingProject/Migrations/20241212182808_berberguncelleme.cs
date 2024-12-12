using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgrammingProject.Migrations
{
    /// <inheritdoc />
    public partial class berberguncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "end_t",
                table: "AvailableTime_t");

            migrationBuilder.DropColumn(
                name: "start_t",
                table: "AvailableTime_t");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Shop_t",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int[]>(
                name: "AllDays",
                table: "Barber_t",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "EndTime",
                table: "Barber_t",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<int[]>(
                name: "SelectedDays",
                table: "Barber_t",
                type: "integer[]",
                nullable: false,
                defaultValue: new int[0]);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "StartTime",
                table: "Barber_t",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "shift_end",
                table: "AvailableTime_t",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "shift_start",
                table: "AvailableTime_t",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Shop_t");

            migrationBuilder.DropColumn(
                name: "AllDays",
                table: "Barber_t");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Barber_t");

            migrationBuilder.DropColumn(
                name: "SelectedDays",
                table: "Barber_t");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Barber_t");

            migrationBuilder.DropColumn(
                name: "shift_end",
                table: "AvailableTime_t");

            migrationBuilder.DropColumn(
                name: "shift_start",
                table: "AvailableTime_t");

            migrationBuilder.AddColumn<DateTime>(
                name: "end_t",
                table: "AvailableTime_t",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "start_t",
                table: "AvailableTime_t",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
