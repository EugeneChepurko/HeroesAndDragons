using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroesAndDragons.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hits_Hero_HeroId",
                table: "Hits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hero",
                table: "Hero");

            migrationBuilder.RenameTable(
                name: "Hero",
                newName: "Heroes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Heroes",
                table: "Heroes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hits_Heroes_HeroId",
                table: "Hits",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hits_Heroes_HeroId",
                table: "Hits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Heroes",
                table: "Heroes");

            migrationBuilder.RenameTable(
                name: "Heroes",
                newName: "Hero");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hero",
                table: "Hero",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hits_Hero_HeroId",
                table: "Hits",
                column: "HeroId",
                principalTable: "Hero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
