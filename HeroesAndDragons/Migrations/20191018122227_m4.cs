using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroesAndDragons.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hits_AspNetUsers_UserId",
                table: "Hits");

            migrationBuilder.DropIndex(
                name: "IX_Hits_UserId",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "Weapon",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "HeroId",
                table: "Hits",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hero",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Weapon = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hero", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hits_HeroId",
                table: "Hits",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hits_Hero_HeroId",
                table: "Hits",
                column: "HeroId",
                principalTable: "Hero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hits_Hero_HeroId",
                table: "Hits");

            migrationBuilder.DropTable(
                name: "Hero");

            migrationBuilder.DropIndex(
                name: "IX_Hits_HeroId",
                table: "Hits");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Hits");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Hits",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weapon",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hits_UserId",
                table: "Hits",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hits_AspNetUsers_UserId",
                table: "Hits",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
