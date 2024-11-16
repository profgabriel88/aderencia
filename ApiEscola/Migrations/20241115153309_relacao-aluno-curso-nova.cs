using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEscola.Migrations
{
    /// <inheritdoc />
    public partial class relacaoalunocursonova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlunoCurso_Alunos_AlunosId",
                table: "AlunoCurso");

            migrationBuilder.DropForeignKey(
                name: "FK_AlunoCurso_Cursos_CursosId",
                table: "AlunoCurso");

            migrationBuilder.DropIndex(
                name: "IX_AlunoCurso_AlunosId",
                table: "AlunoCurso");

            migrationBuilder.DropIndex(
                name: "IX_AlunoCurso_CursosId",
                table: "AlunoCurso");

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Alunos",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_CursoId",
                table: "Alunos",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Cursos_CursoId",
                table: "Alunos",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Cursos_CursoId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_CursoId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Alunos");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoCurso_AlunosId",
                table: "AlunoCurso",
                column: "AlunosId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoCurso_CursosId",
                table: "AlunoCurso",
                column: "CursosId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoCurso_Alunos_AlunosId",
                table: "AlunoCurso",
                column: "AlunosId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlunoCurso_Cursos_CursosId",
                table: "AlunoCurso",
                column: "CursosId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
