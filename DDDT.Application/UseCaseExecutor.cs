﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDT.Application
{
    public class UseCaseExecutor
    {
        private readonly IApplicationActor _actor;

        public UseCaseExecutor(IApplicationActor actor)
        {
            _actor = actor;
        }

        public void ExecuteCommand<TRequest>(
            ICommand<TRequest> command,
            TRequest request)
        {
            Console.WriteLine($"{DateTime.Now}: {_actor.Identity} is trying to execute {command.Name} using data: {JsonConvert.SerializeObject(request)}");

            command.Execute(request);
        }
    }
}
