using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebAPI.Migrations
{
    public partial class AddTblCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "HangHoa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HangHoa_CategoryId",
                table: "HangHoa",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_HangHoa_Category_CategoryId",
                table: "HangHoa",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HangHoa_Category_CategoryId",
                table: "HangHoa");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_HangHoa_CategoryId",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "HangHoa");
        }
    }
}
