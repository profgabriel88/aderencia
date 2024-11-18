using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEscola.Migrations
{
    /// <inheritdoc />
    public partial class chavealunocurso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "AlunoCurso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AlunoCurso",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
