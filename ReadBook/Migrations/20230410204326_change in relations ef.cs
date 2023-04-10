using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadBook.Migrations
{
    /// <inheritdoc />
    public partial class changeinrelationsef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_categories_CategoryIdCategory",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Writers_Books_BooksId",
                table: "Writers");

            migrationBuilder.DropIndex(
                name: "IX_Writers_BooksId",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "BooksId",
                table: "Writers");

            migrationBuilder.RenameColumn(
                name: "CategoryIdCategory",
                table: "Books",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_CategoryIdCategory",
                table: "Books",
                newName: "IX_Books_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_categories_CategoryId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Books",
                newName: "CategoryIdCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                newName: "IX_Books_CategoryIdCategory");

            migrationBuilder.AddColumn<int>(
                name: "BooksId",
                table: "Writers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Writers_BooksId",
                table: "Writers",
                column: "BooksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_categories_CategoryIdCategory",
                table: "Books",
                column: "CategoryIdCategory",
                principalTable: "categories",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Writers_Books_BooksId",
                table: "Writers",
                column: "BooksId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
