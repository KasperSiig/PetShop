using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;

namespace PetShop.RestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET api/owners
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return Ok(_ownerService.GetOwners());
        }

        // GET api/owners/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            var owner = _ownerService.GetOwnerById(id);
            if (owner != null)
            {
                return Ok(owner);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/owners/search/name?search=henning
        [HttpGet("search/{filter}")]
        public ActionResult<IEnumerable<Owner>> Search(string filter, [FromQuery(Name = "search")] string search)
        {
            IEnumerable<Owner> owners;
            if (filter.Equals("name"))
            {
                owners = _ownerService.SearchByName(search);
            }
            else
            {
                return NotFound("Cannot search for provided filter");
            }

            if (owners.Any())
            {
                return Ok(owners);
            }

            return NoContent();
        }

        // POST api/owners
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            return Ok(_ownerService.CreateOwner(owner));
        }

        // PUT api/owners/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (!id.Equals(owner.Id))
            {
                return BadRequest("Parameter ID and Owner ID must be the same");
            }

            return _ownerService.UpdateOwner(owner) != null ? Ok() : ValidationProblem();
        }

        // DELETE api/owners/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            return _ownerService.DeleteOwner(id) != null ? Ok() : ValidationProblem();
        }
    }
}