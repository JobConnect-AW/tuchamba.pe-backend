using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuChambaPe.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProposal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "proposals");

            migrationBuilder.DropColumn(
                name: "estimated_time",
                table: "proposals");

            migrationBuilder.DropColumn(
                name: "status",
                table: "proposals");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "proposals",
                newName: "message");

            migrationBuilder.RenameColumn(
                name: "submitted_at",
                table: "proposals",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "customer_uid",
                table: "proposals",
                newName: "offer_uid");

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "proposals",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "proposals",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "proposals",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by",
                table: "proposals");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "proposals");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "proposals");

            migrationBuilder.RenameColumn(
                name: "offer_uid",
                table: "proposals",
                newName: "customer_uid");

            migrationBuilder.RenameColumn(
                name: "message",
                table: "proposals",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "proposals",
                newName: "submitted_at");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "proposals",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "estimated_time",
                table: "proposals",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "proposals",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
