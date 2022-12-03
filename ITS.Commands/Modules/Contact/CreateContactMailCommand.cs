using System;
using ITS.Commands.Modules.Base;
using ITS.Commands.Modules.Contact.Validator;
using ITS.Infrastructure.Extensions;

namespace ITS.Commands.Modules.Contact
{
    public class CreateContactMailCommand : CommandBase
    {
        public Guid ContactId { get; set; }
        public string MailAddress { get; set; }
        public int MailTypeCode { get; set; }
        public override void Validate()
        {
           new CreateContactMailCommandValidator().Validate(this).RaiseExceptionIfInvalid();
        }
    }
}