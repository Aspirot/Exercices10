using Microsoft.AspNetCore.Mvc;

namespace Exercices10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SwitchTemperatureController : ControllerBase
    {
        [HttpGet("Switch")]
        public IActionResult SayHello(int temp, string tempType)
        {
            if(tempType == "F")
                return Ok((5 * (temp - 32)) / 9);
            else if(tempType == "C")
                return Ok((9 * temp + (32 * 5)) / 5);
            return BadRequest();
        }

        [HttpGet("Fahrenheit/Get")]
        public IActionResult GetFromFahrenheit(int fahrenheit)
        {
            return Ok((5 * (fahrenheit - 32)) / 9);
        }

        [HttpGet("Celsius/Get")]
        public IActionResult GetFromCelsius(int celsius)
        {
            return Ok((9 * celsius+ (32 * 5)) / 5);
        }
    }
}