using System;
using ITS.Commands.Modules.Base;
using ITS.Infrastructure.Extensions;

namespace ITS.Commands.Modules.Person
{
    public class CreatePersonCommand : CommandBase
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public DateTime Birthdate { get; set; }
        public override void Validate()
        {
            new CreatePersonCommandValidation().Validate(this).RaiseExceptionIfInvalid();
        }
    }
}