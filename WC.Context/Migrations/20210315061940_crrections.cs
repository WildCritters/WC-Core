using Microsoft.EntityFrameworkCore.Migrations;

namespace WC.Context.Migrations
{
    public partial class crrections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "version",
                table: "NoteVersion",
                newName: "Version");

            migrationBuilder.RenameColumn(
                name: "version",
                table: "Notes",
                newName: "Version");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Version",
                table: "NoteVersion",
                newName: "version");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "Notes",
                newName: "version");
        }
    }
}
