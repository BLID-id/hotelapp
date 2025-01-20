using Microsoft.AspNetCore.Mvc;
using HotelAPI.API.TypesChambres.TypesChambres_POST;

namespace HotelAPI.API.TypesChambres
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypesChambresController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateTypeChambre([FromBody] TypesChambresPostData chambreData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = TypesChambresPostService.ChambresTypesAdd(chambreData);

            return Ok(new { Message = result });
        }
    }
}

