using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuChambaPe.Migrations
{
    /// <inheritdoc />
    public partial class FixOffersv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "proposals_count",
                table: "offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "start_at",
                table: "offers",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "proposals_count",
                table: "offers");

            migrationBuilder.DropColumn(
                name: "start_at",
                table: "offers");
        }
    }
}
