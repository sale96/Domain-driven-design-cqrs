using DDDT.Application;
using System.Collections.Generic;

namespace DDDT.API.Core
{
    public class AnonymusActor : IApplicationActor
    {
        public int Id => 0;

        public string Identity => "Anonymus actor";

        public IEnumerable<int> AllowedUseCases => new List<int> { 4 };
    }
}
