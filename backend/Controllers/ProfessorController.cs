using System;
using System.Threading.Tasks;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfessorController : ControllerBase
  {
    private readonly IRepository _repo;
    public ProfessorController(IRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
        var result = await _repo.GetAllProfessoresAsync(true);
        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest(new { error = ex.Message });
      }
    }

    [HttpGet("{professorId}")]
    public async Task<IActionResult> GetById(int professorId)
    {
      try
      {
        var result = await _repo.GetProfessorAsyncById(professorId, false);
        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest(new { error = ex.Message });
      }
    }

    [HttpGet("ByAluno/{alunoId}")]
    public async Task<IActionResult> GetProfessoresByAlunoId(int alunoId)
    {
      try
      {
        var result = await _repo.GetProfessoresAsyncByAlunoId(alunoId, false);
        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest(new { error = ex.Message });
      }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Aluno model)
    {
      try
      {
        _repo.Add(model);

        if (await _repo.SaveChangesAsync())
        {
          return Ok(model);
        }
      }
      catch (Exception ex)
      {
        return BadRequest(new { error = ex.Message });
      }

      return BadRequest(new { error = "Erro não esperado." });
    }

    [HttpPut("{professorId}")]
    public async Task<IActionResult> Update(int professorId, Aluno model)
    {
      try
      {
        var professor = await _repo.GetProfessorAsyncById(professorId, false);
        if (professor == null) return NotFound(new { mensagem = "Professor não encontrado!" });

        _repo.Update(model);

        if (await _repo.SaveChangesAsync())
        {
          return Ok(model);
        }
      }
      catch (Exception ex)
      {
        return BadRequest(new { error = ex.Message });
      }

      return BadRequest(new { error = "Erro não esperado." });
    }

    [HttpDelete("{professorId}")]
    public async Task<IActionResult> Delete(int professorId)
    {
      try
      {
        var professor = await _repo.GetProfessorAsyncById(professorId, false);
        if (professor == null) return NotFound(new { mensagem = "Professor não encontrado!" });

        _repo.Delete(professor);

        if (await _repo.SaveChangesAsync())
        {
          return Ok(new { mensagem = "Deletado" });
        }
      }
      catch (Exception ex)
      {
        return BadRequest(new { error = ex.Message });
      }

      return BadRequest(new { error = "Erro não esperado." });
    }

  }
}