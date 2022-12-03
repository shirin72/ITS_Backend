using System;
using ITS.Commands.Modules.Base;
using ITS.Commands.Modules.Contact.Validator;
using ITS.Infrastructure.Extensions;

namespace ITS.Commands.Modules.Contact
{
    public class UpdateContactPhoneCommand : CommandBase
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public int PhoneTypeCode { get; set; }
        public override void Validate()
        {
            new UpdateContactPhoneCommandValidator().Validate(this).RaiseExceptionIfInvalid();  
        }
    }
}