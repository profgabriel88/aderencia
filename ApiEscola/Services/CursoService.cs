using ApiEscola.Data;
using ApiEscola.DTO;
using ApiEscola.Interfaces;
using ApiEscola.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiEscola.Services
{
    public class CursoService : ICursoService
    {
        private readonly ApiContext _apiContext;

        public CursoService(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<CursoDto?> GetCurso(int id)
        {
            var curso = await _apiContext.Cursos.FirstOrDefaultAsync(a => a.Id == id);
            if (curso != null)
            {
                CursoDto cursoDto = new CursoDto 
                {
                    Id = curso.Id,
                    Nome = curso.Nome,
                    Alunos = new List<AlunoDto>()
                };
                var alunosMatriculados = GetAlunosPorCurso(id);
                cursoDto.Alunos = alunosMatriculados;
                return cursoDto;
            }
            return null;
        }

        private IEnumerable<AlunoDto>? GetAlunosPorCurso(int id)
        {
            var alunoCursos = _apiContext.AlunoCurso.Where(x => x.CursosId == id).ToList();
            return _apiContext.Alunos.ToList()
                    .Join(
                        alunoCursos, aluno => aluno.Id, 
                        aC => aC.AlunosId,
                        (aluno, ac) => new AlunoDto
                        {
                            Nome = aluno.Nome, 
                            Sobrenome = aluno.Sobrenome, 
                            Serie = aluno.Serie,
                            Turma = aluno.Turma,
                            Nota = ac.Nota
                        }
                    )
                    .Select(x => x).ToList();
        }

        public async Task<List<CursoDto>> GetCursos()
        {
            var cursos = await _apiContext.Cursos.ToListAsync();
            var cursosDto = new List<CursoDto>();
            foreach(var curso in cursos)
            {
                CursoDto cursoDto = new CursoDto 
                {
                    Id = curso.Id,
                    Nome = curso.Nome,
                    Alunos = GetAlunosPorCurso(curso.Id)
                };
                cursosDto.Add(cursoDto);
            }

            return cursosDto;
        }

        public async Task<Curso?> InsertCurso(Curso curso)
        {
            await _apiContext.Cursos.AddAsync(curso);
            if (await _apiContext.SaveChangesAsync() > 0)
                return curso;

            return null;
        }

        public async Task<int?> InsertAlunoCurso(int curso, int aluno)
        {
            var alunoCurso = new AlunoCurso { CursosId = curso, AlunosId = aluno };
            await _apiContext.AlunoCurso.AddAsync(alunoCurso);
            if (await _apiContext.SaveChangesAsync() > 0)
                return 1;

            return null;
        }

        public async Task EditCurso(Curso curso)
        {
            _apiContext.Cursos.Update(curso);
            await _apiContext.SaveChangesAsync();
        }

        public async Task DeleteCurso(int id)
        {
            var curso = await GetCurso(id);
            if (curso != null)
            {
                // _apiContext.Cursos.Remove(curso);
                await _apiContext.SaveChangesAsync();
            }
        }
    }
}