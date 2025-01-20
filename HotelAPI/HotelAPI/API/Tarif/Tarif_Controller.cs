using HotelAPI.API.Tarif.Tarif_POST;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.API.Tarif
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarifController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateTarif([FromBody] TarifPostData tarifData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = TarifPostService.TarifAdd(tarifData);

            return Ok(new { Message = result });
        }
    }
}