using ApiEscola.Data;
using ApiEscola.Interfaces;
using ApiEscola.Models;
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

        public async Task<Aluno?> GetAluno(int id)
        {
            return await _apiContext.Alunos.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Aluno>> GetAlunos()
        {
            return await _apiContext.Alunos.ToListAsync();
        }

        public async Task<Aluno?> InsertAluno(Aluno aluno)
        {
            await _apiContext.Alunos.AddAsync(aluno);
            if (await _apiContext.SaveChangesAsync() > 0)
                return aluno;

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
    }
}