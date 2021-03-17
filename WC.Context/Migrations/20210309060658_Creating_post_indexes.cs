using Microsoft.EntityFrameworkCore.Migrations;

namespace WC.Context.Migrations
{
    public partial class Creating_post_indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Post",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Hash",
                table: "Post",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_DateOfCreation",
                table: "Post",
                column: "DateOfCreation");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Hash",
                table: "Post",
                column: "Hash",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_Height",
                table: "Post",
                column: "Height");

            migrationBuilder.CreateIndex(
                name: "IX_Post_LastCommented",
                table: "Post",
                column: "LastCommented");

            migrationBuilder.CreateIndex(
                name: "IX_Post_LastNote",
                table: "Post",
                column: "LastNote");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Size",
                table: "Post",
                column: "Size");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Status",
                table: "Post",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Width",
                table: "Post",
                column: "Width");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Post_DateOfCreation",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_Hash",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_Height",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_LastCommented",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_LastNote",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_Size",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_Status",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_Width",
                table: "Post");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Post",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Hash",
                table: "Post",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
