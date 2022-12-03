using System;
using ITS.Commands.Modules.Base;
using ITS.Commands.Modules.Contact.Validator;
using ITS.Infrastructure.Extensions;

namespace ITS.Commands.Modules.Contact
{
    public class CreateContactAddressCommand : CommandBase
    {
        public Guid ContactId { get; set; }
        public string Address { get; set; }
        public int AddressTypeCode { get; set; }
        public override void Validate()
        {
            new CreateContactAddressCommandValidator().Validate(this).RaiseExceptionIfInvalid();
        }
    }
}