using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuChambaPe.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOfferEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "category_id",
                table: "offers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "minimum_experience",
                table: "offers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "user_uid",
                table: "offers",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "work_schedule",
                table: "offers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "minimum_experience",
                table: "offers");

            migrationBuilder.DropColumn(
                name: "user_uid",
                table: "offers");

            migrationBuilder.DropColumn(
                name: "work_schedule",
                table: "offers");

            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "offers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
