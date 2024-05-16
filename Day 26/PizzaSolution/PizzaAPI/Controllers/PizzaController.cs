using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Interfaces;
using PizzaAPI.Models;

namespace PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaServices _pizzaService;
        public PizzaController(IPizzaServices pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet("Pizza")]
        [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetAllPizza()
        {
            try
            {
                var result = await _pizzaService.GetAllPizzas();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }
        [HttpPut("UpdatePizzaAvailablity")]
        [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pizza>> UpdatePizza(int pizzaid, bool status)
        {
            try
            {
                var result = await _pizzaService.UpdatePizzaAvailablity(pizzaid, status);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }
        [HttpGet("GetPizzaByName")]
        [ProducesResponseType(typeof(Pizza), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pizza>> GetPizzaByName(string pizzaname)
        {
            try
            {
                var result = await _pizzaService.GetPizzaByName(pizzaname);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(501, ex.Message));
            }
        }
    }
}
