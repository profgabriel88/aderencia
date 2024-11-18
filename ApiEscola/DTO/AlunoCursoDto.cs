using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ApiEscola.DTO
{
    public class AlunoCursoDto
    {
        public int AlunosId { get; set; }
        public int CursosId { get; set; }
        public string Nome { get; set; }
        public decimal Nota { get; set; }
        public bool Novo { get; set; } = false;
    }
}