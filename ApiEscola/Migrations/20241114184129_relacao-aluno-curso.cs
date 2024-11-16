using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiEscola.Migrations
{
    /// <inheritdoc />
    public partial class relacaoalunocurso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunoCurso",
                table: "AlunoCurso");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AlunoCurso",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<decimal>(
                name: "Nota",
                table: "AlunoCurso",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunoCurso",
                table: "AlunoCurso",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoCurso_AlunosId",
                table: "AlunoCurso",
                column: "AlunosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AlunoCurso",
                table: "AlunoCurso");

            migrationBuilder.DropIndex(
                name: "IX_AlunoCurso_AlunosId",
                table: "AlunoCurso");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AlunoCurso");

            migrationBuilder.DropColumn(
                name: "Nota",
                table: "AlunoCurso");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlunoCurso",
                table: "AlunoCurso",
                columns: new[] { "AlunosId", "CursosId" });
        }
    }
}
