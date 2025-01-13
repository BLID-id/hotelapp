using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class Chambre_GET_Controller : ControllerBase
{
    private readonly Chambre_GET_Service _service;

    public Chambre_GET_Controller(Chambre_GET_Service service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllChambres()
    {
        var chambres = await _service.GetAllChambresAsync();
        return Ok(chambres);
    }
}