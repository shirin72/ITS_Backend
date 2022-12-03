using System;
using FluentValidation;
using ITS.Infrastructure.Extensions;


namespace ITS.Commands.Modules.Person
{
    public class CreatePersonCommandValidation : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidation()
        {
            //RuleFor(c => c.Birthdate).Must(c => c.Date > DateTime.Now).WithMessage("تاریخ وارد شده اشتباه است .");
            RuleFor(c => c.Name).NotNull().NotEmpty().WithMessage("لطفا نام را وارد کنید .");
            RuleFor(c => c.Family).NotNull().NotEmpty().WithMessage("لطفا نام خانوادگی را وارد کنید.");
        }
    }
}