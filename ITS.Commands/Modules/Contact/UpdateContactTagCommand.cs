using System;
using ITS.Commands.Modules.Base;
using ITS.Commands.Modules.Contact.Validator;
using ITS.Infrastructure.Extensions;

namespace ITS.Commands.Modules.Contact
{
    public class UpdateContactTagCommand : CommandBase
    {
        public Guid Id { get; set; }
        public int TagId { get; set; }

        public override void Validate()
        {
            new UpdateContactTagCommandValidator().Validate(this).RaiseExceptionIfInvalid();
        }
    }
}