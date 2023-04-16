using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadBook.Migrations
{
    /// <inheritdoc />
    public partial class addreumeprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Resume",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resume",
                table: "Books");
        }
    }
}
