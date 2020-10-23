using System;
using System.Threading.Tasks;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AlunoController : ControllerBase
  {
    private readonly IRepository _repo;
    public AlunoController(IRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
        var result = await _repo.GetAllAlunosAsync(true);
        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest($"Error: {ex.Message}");
      }
    }

    [HttpGet("{alunoId}")]
    public async Task<IActionResult> Get(int alunoId)
    {
      try
      {
        var result = await _repo.GetAlunoAsyncById(alunoId, false);
        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest($"Error: {ex.Message}");
      }
    }

    [HttpGet("ByDisciplina/{disciplinaId}")]
    public async Task<IActionResult> GetByDisciplinaId(int disciplinaId)
    {
      try
      {
        var result = await _repo.GetAlunosAsyncByDisciplinaId(disciplinaId, false);
        return Ok(result);
      }
      catch (Exception ex)
      {
        return BadRequest($"Error: {ex.Message}");
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
        return BadRequest($"Error: {ex.Message}");
      }

      return BadRequest("Erro não esperado.");
    }

    [HttpPut("{alunoId}")]
    public async Task<IActionResult> Update(int alunoId, Aluno model)
    {
      try
      {
        var aluno = await _repo.GetAlunoAsyncById(alunoId, false);
        if (aluno == null) return NotFound("Aluno não encontrado!");

        _repo.Update(model);

        if (await _repo.SaveChangesAsync())
        {
          return Ok(model);
        }
      }
      catch (Exception ex)
      {
        return BadRequest($"Error: {ex.Message}");
      }

      return BadRequest("Erro não esperado.");
    }

    [HttpDelete("{alunoId}")]
    public async Task<IActionResult> Delete(int alunoId)
    {
      try
      {
        var aluno = await _repo.GetAlunoAsyncById(alunoId, false);
        if (aluno == null) return NotFound("Aluno não encontrado!");

        _repo.Delete(aluno);

        if (await _repo.SaveChangesAsync())
        {
          return Ok("Deletado");
        }
      }
      catch (Exception ex)
      {
        return BadRequest($"Error: {ex.Message}");
      }

      return BadRequest("Erro não esperado.");
    }

  }
}