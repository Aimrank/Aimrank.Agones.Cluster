using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aimrank.Agones.Cluster.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cluster");

            migrationBuilder.CreateTable(
                name: "reservations",
                schema: "cluster",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    map = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    whitelist = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    expires_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    started = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reservations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "steam_tokens",
                schema: "cluster",
                columns: table => new
                {
                    token = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    server = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_steam_tokens", x => x.token);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservations",
                schema: "cluster");

            migrationBuilder.DropTable(
                name: "steam_tokens",
                schema: "cluster");
        }
    }
}
