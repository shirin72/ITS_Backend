using System.ComponentModel;

namespace ITS.Infrastructure.Enums
{
    public enum ErrorServiceMessage
    {

            [Description("تاریخ تولد را صحیح وارد کنید")]
            ErrorInRegisterPerson,

            [Description("شخص مورد نظر یافت نشد")]
            PersonNotFound,

            [Description("داده ای وجود ندارد")]
            NotFound,

            [Description("دسته بندی یافت نشد")]
            CategoryNotFound,

            [Description("جزئیات دسته بندی یافت نشد")]
            CategoryDetailNotFound,

            [Description("مخاطب مورد نظر یافت نشد")]
            ContactNotFound,

            [Description("آدرس مخاطب مورد نظر یافت نشد")]
            ContactAddressNotFound,

            [Description("ایمیل مخاطب مورد نظر یافت نشد")]
            ContactMailNotFound,

            [Description("تلفن مخاطب مورد نظر یافت نشد")]
            ContactPhoneNotFound,

            [Description("برچسب مخاطب مورد نظر یافت نشد")]
            ContactTagNotFound,

            [Description("لینک سایت مخاطب مورد نظر یافت نشد")]
            ContactWebLinkNotFound,

            [Description("برچسب مورد نظر یافت نشد")]
            TagNotFound

    }
}