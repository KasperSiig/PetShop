using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;

namespace PetShop.RestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get([FromQuery] Filter filter)
        {
            try
            {
                return Ok(_petService.GetFilteredOrders(filter));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            
        }

        // GET api/pets/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            var pet = _petService.GetPetById(id);
            if (pet != null)
            {
                return Ok(pet);
            }
            else
            {
                return NoContent();
            }
        }
        
        // GET api/pets/search/type?search="cat"
        [HttpGet("search/{filter}")]
        public ActionResult<IEnumerable<Pet>> SearchByType([FromQuery(Name = "search")] string search, string filter)
        {
            IEnumerable<Pet> pets;
            if (filter.Equals("type"))
            {
                pets = _petService.SearchByType(search);
            }
            else
            {
                return NotFound("Cannot search for provided filter");
            }

            if (pets.Any())
            {
                return Ok(pets);
            }

            return NoContent();
        }

        // GET api/pets/cheapest-five
        [HttpGet("cheapest-five")]
        public ActionResult<IEnumerable<Pet>> GetFiveCheapest()
        {
            return Ok(_petService.GetFiveCheapest());
        }
        
        // GET api/pets/sort/price
        [HttpGet("sort/{filter}")]
        public ActionResult<IEnumerable<Pet>> SortPets(string filter)
        {
            if (filter.Equals("price"))
            {
                return Ok(_petService.SortPetsByPrice());
            }
            else
            {
                return NotFound("No sorting exists for this filter");
            }
        }

        // POST api/pets
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            return Ok(_petService.CreatePet(pet));
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (!id.Equals(pet.Id))
            {
                return BadRequest("Parameter ID and Pet ID must be the same");
            }
            return _petService.UpdatePet(pet) ? Ok() : ValidationProblem();
        }

        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            return _petService.DeletePet(id) ? Ok() : ValidationProblem();
        }
    }
}