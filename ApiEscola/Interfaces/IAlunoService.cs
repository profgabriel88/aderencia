using ApiEscola.DTO;
using ApiEscola.Models;

namespace ApiEscola.Interfaces
{
    public interface IAlunoService
    {
        Task<List<Aluno>> GetAlunos();
        Task<Aluno?> GetAluno(int id);
        List<AlunoCursoDto> GetCursos(int alunoId);
        Task<Aluno?> InsertAluno(Aluno aluno);
        Task EditAluno(Aluno aluno);
        Task DeleteAluno(int id);
        Task InsereNotas(List<AlunoCursoDto> notas, int alunoId);

    }
}