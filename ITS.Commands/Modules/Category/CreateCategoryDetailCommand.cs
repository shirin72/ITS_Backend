using ITS.Commands.Modules.Base;
using ITS.Commands.Modules.Category.Validator;
using ITS.Infrastructure.Extensions;

namespace ITS.Commands.Modules.Category
{
    public class CreateCategoryDetailCommand : CommandBase
    {
        public int CategoryCode { get; set; }
        public int Code { get; set; }
        public string Key { get; set; }
        public string Title { get; set; }
        public string TitleFa { get; set; }
        public string Value { get; set; }
        public int SiteCustomerId { get; set; }

        public override void Validate()
        {
            new CreateCategoryDetailCommandValidator().Validate(this).RaiseExceptionIfInvalid();
        }
    }
}