using ApiEscola.DTO;
using ApiEscola.Interfaces;
using ApiEscola.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApiEscola.Controllers;

[ApiController]
[Route("Api/v1/[controller]")]
public class AlunosController : ControllerBase
{
    private readonly IAlunoService _alunoService;

    public AlunosController(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    [HttpGet]
    public async Task<IActionResult> Alunos()
    {
        var alunos = await _alunoService.GetAlunos();
        if (alunos.Count() > 0)
            return Ok(new {lista = alunos, erro = ""});
        
        return NotFound(new {lista = alunos, erro = "Nenhum aluno cadastrado."});
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Aluno(int id)
    {
        var aluno = await _alunoService.GetAluno(id);
        if (aluno != null)
            return Ok(new {aluno, erro = ""});

        return NotFound(new {aluno, erro = "Aluno não encontrado."});
    }

    [HttpPost]
    public async Task<IActionResult> Aluno([FromBody]Aluno aluno)
    {
        Aluno? alunoCriado = await _alunoService.InsertAluno(aluno);
        if (alunoCriado != null)
            return CreatedAtAction(nameof(Aluno), alunoCriado);

        return BadRequest(new {aluno, erro = "Erro ao cadastrar aluno"});

    }

    [HttpGet("Cursos/{id}")]
    public IActionResult Cursos(int id)
    {
        var cursos = _alunoService.GetCursos(id);
        return Ok(new {lista = cursos, erro = ""});
    }

    [HttpPost("Notas/{id}")]
    public async Task<IActionResult> Notas([FromBody]List<AlunoCursoDto> notas, int id)
    {
        await _alunoService.InsereNotas(notas, id);
        return Ok(new {erro = ""});
    }
}
