using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class Chambre_POST_Controller : ControllerBase
{
    private readonly Chambre_POST_Service _service;

    public Chambre_POST_Controller(Chambre_POST_Service service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateChambre([FromBody] Chambre chambre)
    {
        await _service.CreateChambreAsync(chambre);
        return Ok();
    }
}