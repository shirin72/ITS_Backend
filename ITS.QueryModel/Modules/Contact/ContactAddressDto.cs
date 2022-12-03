using System;

namespace ITS.QueryModel.Modules.Contact
{
    public class ContactAddressDto
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public int AddressTypeCode { get; set; }
    }
}