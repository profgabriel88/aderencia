using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiEscola.Models
{
    [Index(nameof(NomeCompleto), IsUnique = true)]
    public class Aluno
    {
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; } = "";
        
        [Required]
        public string Sobrenome { get; set; } = "";
        public string NomeCompleto { get; set; } = "";

        [Required]
        public string Serie { get; set; } = "";
        
        [Required]
        public string Turma { get; set; } = "";
    }
}