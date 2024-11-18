using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ApiEscola.Models
{
    [Index(nameof(Nome), IsUnique = true)]
    public class Curso
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; } = "";
        public List<Aluno>? Alunos { get; set; }
    }
}