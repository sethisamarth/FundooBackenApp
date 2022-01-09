using Microsoft.EntityFrameworkCore.Migrations;

namespace RespositoryLayer.Migrations
{
    public partial class L1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabelsTable",
                columns: table => new
                {
                    LableId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotesId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: true),
                    Label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelsTable", x => x.LableId);
                    table.ForeignKey(
                        name: "FK_LabelsTable_NotesTable_NotesId",
                        column: x => x.NotesId,
                        principalTable: "NotesTable",
                        principalColumn: "NotesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabelsTable_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabelsTable_NotesId",
                table: "LabelsTable",
                column: "NotesId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelsTable_UserId",
                table: "LabelsTable",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelsTable");
        }
    }
}
