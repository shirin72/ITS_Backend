using ITS.Commands.Modules.Base;
using ITS.Commands.Modules.Tag.Validator;
using ITS.Infrastructure.Extensions;

namespace ITS.Commands.Modules.Tag
{
    public class UpdateTagCommand : CommandBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public override void Validate()
        {
            new UpdateTagCommandValidator().Validate(this).RaiseExceptionIfInvalid();

        }
    }
}