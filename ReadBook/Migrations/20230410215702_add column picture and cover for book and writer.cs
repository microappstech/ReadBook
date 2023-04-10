using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadBook.Migrations
{
    /// <inheritdoc />
    public partial class addcolumnpictureandcoverforbookandwriter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_categories_CategoryId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Writers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
