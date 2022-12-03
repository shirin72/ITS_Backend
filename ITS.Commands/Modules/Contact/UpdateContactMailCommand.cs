using System;
using ITS.Commands.Modules.Base;
using ITS.Commands.Modules.Contact.Validator;
using ITS.Infrastructure.Extensions;

namespace ITS.Commands.Modules.Contact
{
    public class UpdateContactMailCommand : CommandBase
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public string MailAddress { get; set; }
        public int MailTypeCode { get; set; }
        public override void Validate()
        {
            new UpdateContactMailCommandValidator().Validate(this).RaiseExceptionIfInvalid();
        }
    }
}