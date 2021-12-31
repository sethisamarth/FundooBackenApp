using Microsoft.EntityFrameworkCore.Migrations;

namespace RespositoryLayer.Migrations
{
    public partial class N2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "NotesTable",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotesTable_UserId",
                table: "NotesTable",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotesTable_Users_UserId",
                table: "NotesTable",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotesTable_Users_UserId",
                table: "NotesTable");

            migrationBuilder.DropIndex(
                name: "IX_NotesTable_UserId",
                table: "NotesTable");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NotesTable");
        }
    }
}
