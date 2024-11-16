using System.Text.Json.Serialization;

namespace ApiEscola.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public IEnumerable<Aluno>? Alunos { get; set; }
    }
}