using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RespositoryLayer.Migrations
{
    public partial class N1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotesTable",
                columns: table => new
                {
                    NotesId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    Remainder = table.Column<DateTime>(nullable: false),
                    Colour = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    IsArchive = table.Column<bool>(nullable: false),
                    IsPin = table.Column<bool>(nullable: false),
                    IsTrash = table.Column<bool>(nullable: false),
                    Createdat = table.Column<DateTime>(nullable: true),
                    Modifiedat = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotesTable", x => x.NotesId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotesTable");
        }
    }
}
