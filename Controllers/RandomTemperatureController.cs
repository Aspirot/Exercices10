using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercices10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomTemperatureController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(DateTime date)
        {
            if(date >= new DateTime(date.Year, 9, 22) && date <= new DateTime(date.Year, 12, 21))
            {
                return Ok("C'est l'automne. Il fait " + new Random().Next(-10, 15));
            }
            if (date >= new DateTime(date.Year, 12, 22) || date <= new DateTime(date.Year, 3, 21))
            {
                return Ok("C'est l'hivers. Il fait " + new Random().Next(-20, 15));
            }
            if (date >= new DateTime(date.Year, 3, 22) && date <= new DateTime(date.Year, 6, 21))
            {
                return Ok("C'est le printemps. Il fait " + new Random().Next(5, 25));
            }
            if (date >= new DateTime(date.Year, 6, 22) && date <= new DateTime(date.Year, 9, 21))
            {
                return Ok("C'est l'été. Il fait " + new Random().Next(10, 35));
            }
            return BadRequest();
        }
    }
}
