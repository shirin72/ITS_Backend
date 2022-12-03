using FluentValidation;

namespace ITS.Commands.Modules.Contact.Validator
{
    public class CreateContactCommandValidator  : AbstractValidator<CreateContactCommand> 
    {
        public CreateContactCommandValidator()
        {
            
        }
    }
}