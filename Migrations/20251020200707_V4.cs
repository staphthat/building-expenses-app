using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class V4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BrojMeseca",
                table: "Racuni",
                newName: "Mesec");

            migrationBuilder.AddColumn<int>(
                name: "BrojStana",
                table: "Stanovi",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrojStana",
                table: "Stanovi");

            migrationBuilder.RenameColumn(
                name: "Mesec",
                table: "Racuni",
                newName: "BrojMeseca");
        }
    }
}
