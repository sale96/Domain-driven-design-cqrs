using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDT.Application;
using DDDT.Application.Commands;
using DDDT.Application.DataTransfer;
using DDDT.Application.Exceptions;
using DDDT.Application.Queries;
using DDDT.Application.Searches;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDDT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;

        public GroupsController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<TestController>
        [HttpGet]
        public IActionResult Get(
            [FromQuery] GroupSearch search,
            [FromServices] IGetGroupsQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        public IActionResult Post(
            [FromBody] GroupDto dto,
            [FromServices] ICreateGroupCommand command)
        {
            _executor.ExecuteCommand(command, dto);
            return NoContent();
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteGroupCommand command)
        {
            _executor.ExecuteCommand(command, id);
            return NoContent();
        }
    }
}
