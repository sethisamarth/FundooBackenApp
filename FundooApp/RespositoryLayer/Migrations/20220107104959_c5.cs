using Microsoft.EntityFrameworkCore.Migrations;

namespace RespositoryLayer.Migrations
{
    public partial class c5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CEmailId",
                table: "CollaboratorTable");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverEmail",
                table: "CollaboratorTable",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderEmail",
                table: "CollaboratorTable",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverEmail",
                table: "CollaboratorTable");

            migrationBuilder.DropColumn(
                name: "SenderEmail",
                table: "CollaboratorTable");

            migrationBuilder.AddColumn<string>(
                name: "CEmailId",
                table: "CollaboratorTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
