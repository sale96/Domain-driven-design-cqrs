using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDT.Application.Commands;
using DDDT.Application.DataTransfer;
using DDDT.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDDT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/<TestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post(
            [FromBody] GroupDto dto,
            [FromServices] ICreateGroupCommand command)
        {
            command.Execute(dto);
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
            try
            {
                command.Execute(id);
                return NoContent();
            }
            catch(EntityNotFoundException ex)
            {
                return NotFound();
            }
        }
    }
}
