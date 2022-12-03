using ITS.Commands.Modules.Base;
using ITS.Commands.Modules.Category.Validator;
using ITS.Infrastructure.Extensions;

namespace ITS.Commands.Modules.Category
{
    public class UpdateCategoryCommand : CommandBase
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }
        public string TitleFa { get; set; }
        public bool IsSystematic { get; set; }
        public override void Validate()
        {
            new UpdateCategoryCommandValidator().Validate(this).RaiseExceptionIfInvalid();
        }
    }
}