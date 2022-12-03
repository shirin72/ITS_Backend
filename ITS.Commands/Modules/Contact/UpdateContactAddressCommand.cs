using System;
using ITS.Commands.Modules.Base;
using ITS.Commands.Modules.Contact.Validator;
using ITS.Infrastructure.Extensions;

namespace ITS.Commands.Modules.Contact
{
    public class UpdateContactAddressCommand : CommandBase
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public int AddressTypeCode { get; set; }
        public override void Validate()
        {
            new UpdateContactAddressCommandValidator().Validate(this).RaiseExceptionIfInvalid();
        }
    }
}