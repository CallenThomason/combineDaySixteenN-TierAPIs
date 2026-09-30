using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using combineDaySixteenN_TierAPIs.Dtos;
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
        public ActionResult<List<SupplyReadDTO>> GetAll()
        {
            return Ok(_supplies.GetAll()); //Returns Ok 200 + List of supplies
        }
        [HttpGet("GetById/{id}")]
        public ActionResult<SupplyReadDTO> GetById(int id)
        {
            //We are returning our DTO NOT our model because we do not want our location leaking
            SupplyReadDTO? supply = _supplies.GetById(id);

            //if no supply with id is available we return 404
            if(supply is null)
            {
                return NotFound($"No supply with id {id} was found");
            }
            return Ok(supply); 
        }
       
       //[APIController] checks the DTO attributes [Required] and [Range] BEFORE the methods run
       //any non name or any bad quantity the user gets an automatic 400
        [HttpPost("Create")]
        public ActionResult<SupplyReadDTO> Create([FromBody] SupplyCreateDTO newSupply)
        {
            SupplyReadDTO? created = _supplies.Create(newSupply); 
            if(created is null)
            {
                //This is stating there is a conflict with the information that sent and the DB
                return Conflict($"There is already a supply called {newSupply.Name}"); //409
            }

            return CreatedAtAction(nameof(GetById), new {id = created.Id}, created); 
        }
        [HttpPut("{id}/Withdraw/{amount}")]
        public ActionResult<SupplyReadDTO> Withdraw(int id, int amount)
        {
            SupplyReadDTO? supply = _supplies.GetById(id);
            if(supply is null)
            {
                return NotFound($"No supply with id {id}");
            }

            bool ok = _supplies.Withdraw(id, amount); 
            if(ok == false)
            {
                return BadRequest($"Can't withdraw {amount}. There are {supply.Quantity} on the shelf.");
            }
            return Ok(true); 
        }

        [HttpDelete("Delete/{id}")]

        public IActionResult Delete(int id)
        {
            //SupplyReadDTO? supply = _supplies.GetById(id); 
            if(_supplies.GetById(id) is null)
            {
                 return NotFound($"No supply with id {id}");
            }
            _supplies.Delete(id); 
            return NoContent(); 
        }

    }
}