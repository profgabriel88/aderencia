using ApiEscola.Models;

namespace ApiEscola.Interfaces
{
    public interface IAlunoService
    {
        Task<List<Aluno>> GetAlunos();
        Task<Aluno?> GetAluno(int id);
        Task<Aluno?> InsertAluno(Aluno aluno);
        Task EditAluno(Aluno aluno);
        Task DeleteAluno(int id);

    }
}