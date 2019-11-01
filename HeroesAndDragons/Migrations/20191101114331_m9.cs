using Microsoft.EntityFrameworkCore.Migrations;

namespace HeroesAndDragons.Migrations
{
    public partial class m9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hits_Dragon_DragonId",
                table: "Hits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dragon",
                table: "Dragon");

            migrationBuilder.RenameTable(
                name: "Dragon",
                newName: "Dragons");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Heroes",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dragons",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dragons",
                table: "Dragons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hits_Dragons_DragonId",
                table: "Hits",
                column: "DragonId",
                principalTable: "Dragons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hits_Dragons_DragonId",
                table: "Hits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dragons",
                table: "Dragons");

            migrationBuilder.RenameTable(
                name: "Dragons",
                newName: "Dragon");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Heroes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Dragon",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dragon",
                table: "Dragon",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hits_Dragon_DragonId",
                table: "Hits",
                column: "DragonId",
                principalTable: "Dragon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
