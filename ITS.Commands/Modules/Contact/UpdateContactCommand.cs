using System;
using ITS.Commands.Modules.Base;
using ITS.Commands.Modules.Contact.Validator;
using ITS.Infrastructure.Extensions;

namespace ITS.Commands.Modules.Contact
{
    public class UpdateContactCommand : CommandBase
    {
        public Guid Id { get; set; }
        public int ContactTypeCode { get; set; }
        public string Name { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int CompanyId { get; set; }
        public bool IsCompany { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public override void Validate()
        {
            new UpdateContactCommandValidator().Validate(this).RaiseExceptionIfInvalid();
        }
    }
}