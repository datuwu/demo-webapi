using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebAPI.Migrations
{
    public partial class RenameTblGood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoa_Category_CategoryId",
                table: "HangHoa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HangHoa",
                table: "HangHoa");

            migrationBuilder.RenameTable(
                name: "HangHoa",
                newName: "Good");

            migrationBuilder.RenameIndex(
                name: "IX_HangHoa_CategoryId",
                table: "Good",
                newName: "IX_Good_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Good",
                table: "Good",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Good_Category_CategoryId",
                table: "Good",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Good_Category_CategoryId",
                table: "Good");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Good",
                table: "Good");

            migrationBuilder.RenameTable(
                name: "Good",
                newName: "HangHoa");

            migrationBuilder.RenameIndex(
                name: "IX_Good_CategoryId",
                table: "HangHoa",
                newName: "IX_HangHoa_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HangHoa",
                table: "HangHoa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoa_Category_CategoryId",
                table: "HangHoa",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
