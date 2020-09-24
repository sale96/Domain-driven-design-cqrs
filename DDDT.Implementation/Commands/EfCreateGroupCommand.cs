using DDDT.Application.Commands;
using DDDT.Application.DataTransfer;
using DDDT.Domain;
using DDDT.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDT.Implementation.Commands
{
    public class EfCreateGroupCommand : ICreateGroupCommand
    {
        private readonly DDDTContext _context;

        public EfCreateGroupCommand(DDDTContext context)
        {
            _context = context;
        }

        public int Id => 1;

        public string Name => "Create New Group Command using EF";

        public void Execute(GroupDto request)
        {
            var group = new Group
            {
                Name = request.Name
            };

            _context.Groups.Add(group);
            _context.SaveChanges();
        }
    }
}
