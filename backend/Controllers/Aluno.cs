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
      return Ok();
    }

  }
}