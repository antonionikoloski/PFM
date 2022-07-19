using Microsoft.AspNetCore.Mvc;
using pfm.Commands;
using pfm.Services;

namespace pfm.Controllers;

[ApiController]
[Route("[controller]")]
public class PfmController : ControllerBase
{
  

    private readonly ILogger<PfmController> _logger;
    private readonly IPfmService _PfmService;

    public PfmController (ILogger<PfmController> logger,IPfmService pfm)
    {
        _logger = logger;
        _PfmService=pfm;
    }
      [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateTransactionCommand command)
        {
            var result = await _PfmService.CreateTransaction(command);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    
 
}
