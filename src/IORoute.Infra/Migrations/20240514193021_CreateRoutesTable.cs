using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IORoute.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CreateRoutesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Origin = table.Column<string>(type: "text", nullable: true),
                    Destination = table.Column<string>(type: "text", nullable: true),
                    Cost = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
