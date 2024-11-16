using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ApiEscola.DTO
{
    public class AlunoDto
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; } = "";
        [Required]
        public string Sobrenome { get; set; } = "";
        [Required]
        public string Serie { get; set; } = "";
        [Required]
        public string Turma { get; set; } = "";
        public decimal Nota { get; set; }
    }
}