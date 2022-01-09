using Microsoft.EntityFrameworkCore.Migrations;

namespace RespositoryLayer.Migrations
{
    public partial class C8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverEmail",
                table: "CollaboratorTable");

            migrationBuilder.DropColumn(
                name: "SenderEmail",
                table: "CollaboratorTable");

            migrationBuilder.AddColumn<string>(
                name: "EmailId",
                table: "CollaboratorTable",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "CollaboratorTable",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "CollaboratorTable",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorTable_UserId",
                table: "CollaboratorTable",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorTable_Users_UserId",
                table: "CollaboratorTable",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorTable_Users_UserId",
                table: "CollaboratorTable");

            migrationBuilder.DropIndex(
                name: "IX_CollaboratorTable_UserId",
                table: "CollaboratorTable");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "CollaboratorTable");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CollaboratorTable");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CollaboratorTable");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverEmail",
                table: "CollaboratorTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderEmail",
                table: "CollaboratorTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
