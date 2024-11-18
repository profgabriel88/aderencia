using ApiEscola.Data;
using ApiEscola.DTO;
using ApiEscola.Interfaces;
using ApiEscola.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiEscola.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly ApiContext _apiContext;

        public RelatorioService(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public async Task<List<RelatorioGeralDto>> GeraRelatorioGeral(int? curso, string serie, string turma)
        {
            var query = await
                (from a in _apiContext.Alunos
                join ac in _apiContext.AlunoCurso on a.Id equals ac.AlunosId
                join c in _apiContext.Cursos on ac.CursosId equals c.Id
                select new 
                {
                    Serie = a.Serie,
                    Turma = a.Turma,
                    Curso = c.Nome,
                    CursoId = ac.CursosId,
                    Aluno = a.NomeCompleto,
                    Nota = ac.Nota
                })
                .Where(
                    c => 
                    curso != null ? c.CursoId == curso : c.CursoId != 0
                )
                .Where(
                    c =>
                    serie != null ? c.Serie == serie : c.Serie != null
                )
                .Where(
                    c =>
                    turma != null ? c.Turma == turma : c.Turma != null
                )
                .OrderBy(a => a.Serie)
                .ThenBy(a => a.Turma)   
                .ToListAsync();

            if (query.Count() == 0)
                return null;

            var rel = new List<RelatorioGeralDto>();
            foreach (var q in query)
            {   
                if (!rel.Exists(r => r.Serie == q.Serie && r.Turma == q.Turma && r.Curso == q.Curso))
                // if (!serieAtual.Equals(q.Serie))
                {
                    var relatorio = new RelatorioGeralDto
                    {
                        Serie = q.Serie,
                        Turma = q.Turma,
                        Curso = q.Curso,
                        Alunos = new List<AlunoCursoDto>()
                    };
                    relatorio.Alunos.Add(new AlunoCursoDto { Nome = q.Aluno, Nota = q.Nota });
                    rel.Add(relatorio);
                }   
                else 
                {
                    var r = rel.FirstOrDefault(r => r.Serie == q.Serie && r.Turma == q.Turma && r.Curso == q.Curso);
                    r?.Alunos.Add(new AlunoCursoDto { Nome = q.Aluno, Nota = q.Nota });
                }

            }

            return rel;
        }
    }
}