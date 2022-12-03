using System;

namespace ITS.QueryModel.Modules.Contact
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public int ContactTypeCode { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int? CompanyId { get; set; }
        public bool IsCompany { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}