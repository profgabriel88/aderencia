using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEscola.Migrations
{
    /// <inheritdoc />
    public partial class cursonomeunique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cursos_Nome",
                table: "Cursos",
                column: "Nome",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cursos_Nome",
                table: "Cursos");
        }
    }
}
