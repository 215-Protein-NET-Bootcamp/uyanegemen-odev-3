using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OdevApi.Data.Model;
using OdevApi.Dto;
using OdevApi.Service.Abstract;
using Serilog;

namespace OdevApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController<PersonDto, Person>
    {
        private readonly IPersonService PersonService;
        public PersonController(IPersonService PersonService, IMapper mapper) : base(PersonService, mapper)
        {
            this.PersonService = PersonService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Log.Information($"{User.Identity?.Name}: get Person.");

            var result = await PersonService.GetAllAsync();

            if (!result.Success)
                return BadRequest(result);

            if (result.Response is null)
                return NoContent();

            return Ok(result);
        }


        [HttpGet("{id:int}")]
        public new async Task<IActionResult> GetByIdAsync(int id)
        {
            Log.Information($"{User.Identity?.Name}: get a Person with Id is {id}.");

            return await base.GetByIdAsync(id);
        }

        [HttpPost]
        public new async Task<IActionResult> CreateAsync([FromBody] PersonDto resource)
        {
            Log.Information($"{User.Identity?.Name}: create a Person.");

            resource.CreatedBy = User.Identity?.Name;

            var insertResult = await PersonService.InsertAsync(resource);

            if (!insertResult.Success)
                return BadRequest(insertResult);

            return StatusCode(201, insertResult);
        }

        [HttpPut("{id:int}")]
        public new async Task<IActionResult> UpdateAsync(int id, [FromBody] PersonDto resource)
        {
            Log.Information($"{User.Identity?.Name}: update a Person with Id is {id}.");

            return await base.UpdateAsync(id, resource);
        }


        [HttpDelete("{id:int}")]
        public new async Task<IActionResult> DeleteAsync(int id)
        {
            Log.Information($"{User.Identity?.Name}: delete a Person with Id is {id}.");

            return await base.DeleteAsync(id);
        }

    }
}
