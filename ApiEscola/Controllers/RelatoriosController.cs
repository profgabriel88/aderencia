using ApiEscola.Interfaces;
using ApiEscola.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiEscola.Controllers;

[ApiController]
[Route("Api/v1/[controller]")]
public class RelatoriosController : ControllerBase
{
    private readonly IRelatorioService _relatorioService;

    public RelatoriosController(IRelatorioService relatorioService)
    {
        _relatorioService = relatorioService;
    }

    [HttpGet]
    public async Task<IActionResult> Cursos([FromQuery] int? curso, [FromQuery] string? serie, [FromQuery] string? turma)
    {
        var rel = await _relatorioService.GeraRelatorioGeral(curso, serie, turma);
        if (rel != null)
            return Ok(new {lista = rel, erro = ""});

        return BadRequest(new {lista = rel, erro = "Nenhum resultado encontrado para a busca"});
    }
}
