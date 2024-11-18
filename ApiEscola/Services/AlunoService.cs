using ApiEscola.Data;
using ApiEscola.DTO;
using ApiEscola.Interfaces;
using ApiEscola.Models;
using EntityFramework.Exceptions.Common;
using Microsoft.EntityFrameworkCore;

namespace ApiEscola.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly ApiContext _apiContext;

        public AlunoService(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<Aluno?> GetAluno(int id) =>
            await _apiContext.Alunos.FirstOrDefaultAsync(a => a.Id == id);
        

        public async Task<List<Aluno>> GetAlunos() => 
            await _apiContext.Alunos
                .OrderBy(a => a.Serie)
                .ThenBy(a => a.Turma)
                .ToListAsync();

        public async Task<Aluno?> InsertAluno(Aluno aluno)
        {
            aluno.NomeCompleto = $"{aluno.Nome} {aluno.Sobrenome}";
            try
            {
                await _apiContext.Alunos.AddAsync(aluno);
                if (await _apiContext.SaveChangesAsync() > 0)
                    return aluno;
            }
            catch (UniqueConstraintException e)
            {
                throw e;
            }

            return null;
        }

        public async Task EditAluno(Aluno aluno)
        {
            _apiContext.Alunos.Update(aluno);
            await _apiContext.SaveChangesAsync();
        }

        public async Task DeleteAluno(int id)
        {
            var aluno = await GetAluno(id);
            if (aluno != null)
            {
                _apiContext.Alunos.Remove(aluno);
                await _apiContext.SaveChangesAsync();
            }
        }

        public List<AlunoCursoDto> GetCursos(int alunoId)
        {
            var alunoCursos = _apiContext.AlunoCurso.Where(a => a.AlunosId == alunoId).ToList();
            return _apiContext.Cursos.ToList()
                .Join(
                    alunoCursos, curso => curso.Id,
                    aC => aC.CursosId,
                    (curso, aC) => new AlunoCursoDto
                    {
                        AlunosId = aC.AlunosId,
                        CursosId = curso.Id,
                        Nome = curso.Nome,
                        Nota = aC.Nota
                    }
                ).Select(x => x).ToList();

        }

        public async Task InsereNotas(List<AlunoCursoDto> notas, int alunoId)
        {
            List<AlunoCurso> alunoCurso = new();
            List<AlunoCurso> cursosNovos = new();
            foreach(var nota in notas)
            {
                if (nota.Novo)
                {
                    cursosNovos.Add(new AlunoCurso
                    {
                        AlunosId = nota.AlunosId,
                        CursosId = nota.CursosId,
                        Nota = nota.Nota
                    });
                }
                else
                {
                    alunoCurso.Add(new AlunoCurso
                    {
                        AlunosId = nota.AlunosId,
                        CursosId = nota.CursosId,
                        Nota = nota.Nota
                    });
                }
            }
            _apiContext.AlunoCurso.AddRange(cursosNovos);
            _apiContext.AlunoCurso.UpdateRange(alunoCurso);
            await _apiContext.SaveChangesAsync();
        }
    }
}