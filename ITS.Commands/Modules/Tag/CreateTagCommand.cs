using ITS.Commands.Modules.Base;
using ITS.Commands.Modules.Tag.Validator;
using ITS.Infrastructure.Extensions;

namespace ITS.Commands.Modules.Tag
{
    public class CreateTagCommand : CommandBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public override void Validate()
        {
            new CreateTagCommandValidator().Validate(this).RaiseExceptionIfInvalid();
        }
    }
}