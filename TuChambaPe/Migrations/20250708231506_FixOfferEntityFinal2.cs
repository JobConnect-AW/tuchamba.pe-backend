using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuChambaPe.Migrations
{
    /// <inheritdoc />
    public partial class FixOfferEntityFinal2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "selected_proposal_uid",
                table: "offers",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "selected_proposal_uid",
                table: "offers");
        }
    }
}
