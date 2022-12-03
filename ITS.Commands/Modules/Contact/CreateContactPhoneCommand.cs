using System;
using ITS.Commands.Modules.Base;
using ITS.Commands.Modules.Contact.Validator;
using ITS.Infrastructure.Extensions;

namespace ITS.Commands.Modules.Contact
{
    public class CreateContactPhoneCommand : CommandBase
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public string Phone { get; set; }
        public int PhoneTypeCode { get; set; }
        public override void Validate()
        {
            new CreateContactPhoneCommandValidator().Validate(this).RaiseExceptionIfInvalid();
        }
    }
}