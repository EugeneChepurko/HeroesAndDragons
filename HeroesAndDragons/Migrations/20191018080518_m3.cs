using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroesAndDragons.Migrations
{
    public partial class m3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dragon",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    HitPoint = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dragon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hits",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Power = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    DragonId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hits_Dragon_DragonId",
                        column: x => x.DragonId,
                        principalTable: "Dragon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hits_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hits_DragonId",
                table: "Hits",
                column: "DragonId");

            migrationBuilder.CreateIndex(
                name: "IX_Hits_UserId",
                table: "Hits",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hits");

            migrationBuilder.DropTable(
                name: "Dragon");
        }
    }
}
