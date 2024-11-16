using System.Text.Json.Serialization;

namespace ApiEscola.DTO
{
    public class CursoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public IEnumerable<AlunoDto>? Alunos { get; set; }
    }
}