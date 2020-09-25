using DDDT.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDT.API.Core
{
    public class FakeApiActor : IApplicationActor
    {
        public int Id => 1;

        public string Identity => "Test api user";

        public IEnumerable<int> AllowedUseCases => new List<int> { 1 };
    }
}
