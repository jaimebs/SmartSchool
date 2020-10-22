using System;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AlunoController : ControllerBase
  {
    [HttpGet]
    public IActionResult get()
    {
      try
      {
        throw new Exception("Deu erro");
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

  }
}