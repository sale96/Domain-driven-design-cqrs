using DDDT.Application;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDT.Implementation.Logging
{
    public class ConsoleUseCaseLogger : IUseCaseLogger
    {
        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            Console.WriteLine($"{DateTime.Now}: {actor.Identity} is trying to execute {useCase.Name} using data: {JsonConvert.SerializeObject(useCaseData)}");
        }
    }
}
