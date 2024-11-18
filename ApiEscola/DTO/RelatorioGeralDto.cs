using ApiEscola.Models;

namespace ApiEscola.DTO
{
    public class RelatorioGeralDto
    {
        public string Serie { get; set; }
        public string Turma { get; set; }
        public string Curso { get; set; }
        public List<AlunoCursoDto> Alunos { get; set; }
    }
}