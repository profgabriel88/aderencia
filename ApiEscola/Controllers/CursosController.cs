using ApiEscola.Interfaces;
using ApiEscola.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiEscola.Controllers;

[ApiController]
[Route("Api/v1/[controller]")]
public class CursosController : ControllerBase
{
    private readonly ICursoService _cursoService;

    public CursosController(ICursoService cursoService)
    {
        _cursoService = cursoService;
    }

    [HttpGet]
    public async Task<IActionResult> Cursos()
    {
        var cursos = await _cursoService.GetCursos();
        if (cursos.Count() > 0)
            return Ok(new {lista = cursos, erro = ""});
        
        return NotFound(new {lista = cursos, erro = "Nenhum curso cadastrado."});
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Curso(int id)
    {
        var curso = await _cursoService.GetCurso(id);
        if (curso != null)
            return Ok(new {curso, erro = ""});

        return NotFound(new {curso, erro = "Curso não encontrado."});
    }

    [HttpPost]
    public async Task<IActionResult> Curso([FromBody]Curso curso)
    {
        if (!ModelState.IsValid)
            return BadRequest(new {curso, erro = "Todos os campos são obrigatórios."});

        Curso? cursoCriado = await _cursoService.InsertCurso(curso);
        if (cursoCriado != null)
            return CreatedAtAction(nameof(Curso), cursoCriado);

        return BadRequest(new {curso, erro = "Erro ao cadastrar curso."});

    }

    [HttpPost("Matricula")]
    public async Task<IActionResult> AlunoCurso([FromQuery]int curso, int aluno)
    {
        var sucesso = await _cursoService.InsertAlunoCurso(curso, aluno);
        if (sucesso == 1)
            return CreatedAtAction(nameof(AlunoCurso), new { msg = "Inserido com sucesso." });
        
        return BadRequest(new { erro = "Erro ao cadastrar." });
    }
}
