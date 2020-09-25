using DDDT.Application.DataTransfer;
using DDDT.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDT.Implementation.Validators
{
    public class CreateGroupValidator : AbstractValidator<GroupDto>
    {
        public CreateGroupValidator(DDDTContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Must(name => !context.Groups.Any(g => g.Name == name))
                .WithMessage("Group name must be unique");
        }
    }
}
