using ApiEscola.DTO;
using ApiEscola.Models;

namespace ApiEscola.Interfaces
{
    public interface ICursoService
    {
        Task<List<CursoDto>> GetCursos();
        Task<CursoDto?> GetCurso(int id);
        Task<Curso?> InsertCurso(Curso curso);
        Task<int?> InsertAlunoCurso(int curso, int aluno);
        Task EditCurso(Curso curso);
        Task DeleteCurso(int id);

    }
}