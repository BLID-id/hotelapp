using Microsoft.AspNetCore.Mvc;
using HotelAPI.API.Chambre.Chambre_POST;

namespace HotelAPI.API.Chambre
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChambreController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateChambre([FromBody] ChambrePostData chambreData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                string result = ChambrePostService.ChambreAdd(chambreData);

                if (result.Contains("succès"))
                {
                    return Ok(new { Message = result });
                }
                else
                {
                    return BadRequest(new { Error = result });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "Erreur interne du serveur", Details = ex.Message });
            }
        }
    }
}


