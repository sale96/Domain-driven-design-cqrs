using DDDT.Application;
using DDDT.Application.DataTransfer;
using DDDT.Implementation.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDDT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly RegisterUserCommand _command;
        private readonly UseCaseExecutor _executor;

        public RegisterController(UseCaseExecutor executor, RegisterUserCommand command)
        {
            _executor = executor;
            _command = command;
        }

        // POST api/<RegisterController>
        [HttpPost]
        public void Post([FromBody] RegisterUserDto dto)
        {
            _executor.ExecuteCommand(_command, dto);
        }
    }
}
