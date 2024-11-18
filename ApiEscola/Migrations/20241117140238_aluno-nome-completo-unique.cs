using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEscola.Migrations
{
    /// <inheritdoc />
    public partial class alunonomecompletounique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeCompleto",
                table: "Alunos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_NomeCompleto",
                table: "Alunos",
                column: "NomeCompleto",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Alunos_NomeCompleto",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "NomeCompleto",
                table: "Alunos");
        }
    }
}
