using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using combineDaySixteenN_TierAPIs.Models;
using combineDaySixteenN_TierAPIs.Services;
using Microsoft.AspNetCore.Mvc;

namespace combineDaySixteenN_TierAPIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class SuppliesController : ControllerBase
    {
        private readonly ISupplyService _supplies;

        public SuppliesController(ISupplyService supplies)
        {
            _supplies = supplies;
        }
        
        [HttpGet("GetAll")]
        public ActionResult<List<Supply>> GetAll()
        {
            return Ok(_supplies.GetAll()); //Returns Ok 200 + List of supplies
        }
        [HttpGet("GetById/{id}")]
        public ActionResult<Supply> GetById(int id)
        {
            Supply? supply = _supplies.GetById(id);

            //if no supply with id is available we return 404
            if(supply is null)
            {
                return NotFound($"No supply with id {id} was found");
            }
            return Ok(supply); 
        }
        [HttpPost("Create")]
        public ActionResult<Supply> Create([FromBody] Supply newSupply)
        {
            Supply? created = _supplies.Create(newSupply); 
            if(created is null)
            {
                return BadRequest("A supply needs a name, and its quantity must be greater than 0");
            }

            return CreatedAtAction(nameof(GetById), new {id = created.Id}, created); 
        }
        [HttpPut("{id}/Withdraw/{amount}")]
        public ActionResult<Supply> Withdraw(int id, int amount)
        {
            Supply? supply = _supplies.GetById(id);
            if(supply is null)
            {
                return NotFound($"No supply with id {id}");
            }

            bool ok = _supplies.Withdraw(supply, amount); 
            if(ok == false)
            {
                return BadRequest($"Can't withdraw {amount}. There are {supply.Quantity} on the shelf.");
            }
            return Ok(supply); 
        }

        [HttpDelete("Delete/{id}")]

        public IActionResult Delete(int id)
        {
            Supply? supply = _supplies.GetById(id); 
            if(supply is null)
            {
                 return NotFound($"No supply with id {id}");
            }
            _supplies.Delete(supply); 
            return NoContent(); 
        }

    }
}