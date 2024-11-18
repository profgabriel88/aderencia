using ApiEscola.DTO;
using ApiEscola.Models;

namespace ApiEscola.Interfaces
{
    public interface IRelatorioService
    {
        Task<List<RelatorioGeralDto>> GeraRelatorioGeral(int? curso, string serie, string turma);
    }
}