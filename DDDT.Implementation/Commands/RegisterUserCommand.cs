using DDDT.Application.Commands;
using DDDT.Application.DataTransfer;
using DDDT.EfDataAccess;
using DDDT.Implementation.Validators;
using FluentValidation;

namespace DDDT.Implementation.Commands
{
    public class RegisterUserCommand : IRegisterUserCommand
    {
        private readonly DDDTContext _context;
        private readonly RegisterUserValidator _validator;

        public RegisterUserCommand(DDDTContext context)
        {
            _context = context;
        }

        public int Id => 7;

        public string Name => "Register user command";

        public void Execute(RegisterUserDto request)
        {
            _validator.ValidateAndThrow(request);

            _context.Users.Add(new Domain.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Password = request.Password,
                Email = request.Email
            });

            _context.SaveChanges();
        }
    }
}
