using DDDT.Application.Commands;
using DDDT.Application.DataTransfer;
using DDDT.EfDataAccess;
using DDDT.Implementation.Validators;

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

        }
    }
}
