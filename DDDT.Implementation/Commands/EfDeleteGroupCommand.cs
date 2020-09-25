using DDDT.Application.Commands;
using DDDT.Application.Exceptions;
using DDDT.Domain;
using DDDT.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDT.Implementation.Commands
{
    public class EfDeleteGroupCommand : IDeleteGroupCommand
    {
        private readonly DDDTContext _context;

        public EfDeleteGroupCommand(DDDTContext context)
        {
            _context = context;
        }

        public int Id => 3;

        public string Name => "Deleting group command using ef.";

        public void Execute(int request)
        {
            var group = _context.Groups.Find(request);

            if (group == null)
            {
                throw new EntityNotFoundException(request, typeof(Group));
            }

            _context.Groups.Remove(group);

            _context.SaveChanges();
        }
    }
}
