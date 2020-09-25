using DDDT.Application.Commands;
using DDDT.Application.DataTransfer;
using DDDT.Domain;
using DDDT.EfDataAccess;
using DDDT.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDT.Implementation.Commands
{
    public class EfCreateGroupCommand : ICreateGroupCommand
    {
        private readonly DDDTContext _context;
        private readonly CreateGroupValidator _validator;

        public EfCreateGroupCommand(
            DDDTContext context,
            CreateGroupValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 1;

        public string Name => "Create New Group Command using EF";

        public void Execute(GroupDto request)
        {
            _validator.ValidateAndThrow(request);

            var group = new Group
            {
                Name = request.Name
            };

            _context.Groups.Add(group);
            _context.SaveChanges();
        }
    }
}
