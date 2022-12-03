using System;

namespace ITS.QueryModel.Modules.Contact
{
    public class ContactPhoneDto
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public int? PhoneTypeCode { get; set; }
    }
}