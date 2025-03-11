using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Filters;
using WebAPIDemo.Filters.ActiionFilters;
using WebAPIDemo.Filters.ExceptionFilters;
using WebAPIDemo.Models;
using WebAPIDemo.Models.Repositories;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        

        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok(ShirtRepository.GetShirts());
        }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]                                   // [HttpGet("{id}/{color}")]
        public IActionResult GetShirtsById(int id)                   //GetShirtsById(int id,[FromHeader(Name ="Color")] string color)          [FromQuery][FromRoute][FromHeader(Name ="Color")]
        {
            if (id <= 0) return BadRequest();
            var shirt = ShirtRepository.GetShirtById(id);
            if (shirt == null) return NotFound();

            return Ok(shirt);
        }


        [HttpPost]
        [Shirt_ValidateCreateShirtFilter]
        public IActionResult CreateShirt([FromBody] Shirt shirt)        //[FromBody][FromForm]
        {

            ShirtRepository.AddShirt(shirt);
            return CreatedAtAction(nameof(GetShirtsById),
                new { id=shirt.ShirtId},
                shirt);
        }


        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
        [Shirt_HandleUpdateExceptionFilter]
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {

            ShirtRepository.UpdateShirt(shirt);

            return NoContent();
        }


        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult DeleteShirt(int id)
        {
            var shirt = ShirtRepository.GetShirtById(id);
            ShirtRepository.DeleteShirt(id);

            return Ok(shirt);
        }

    }
}
