using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class V5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racuni_Stanovi_StanID",
                table: "Racuni");

            migrationBuilder.AlterColumn<int>(
                name: "StanID",
                table: "Racuni",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Racuni_Stanovi_StanID",
                table: "Racuni",
                column: "StanID",
                principalTable: "Stanovi",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racuni_Stanovi_StanID",
                table: "Racuni");

            migrationBuilder.AlterColumn<int>(
                name: "StanID",
                table: "Racuni",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Racuni_Stanovi_StanID",
                table: "Racuni",
                column: "StanID",
                principalTable: "Stanovi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
