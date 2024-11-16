using System.ComponentModel;

namespace ApiEscola.Models
{
    public class AlunoCurso
    {
        public int Id { get; set; }
        public int AlunosId { get; set; }
        public int CursosId { get; set; }
        public decimal Nota { get; set; }
    }
}