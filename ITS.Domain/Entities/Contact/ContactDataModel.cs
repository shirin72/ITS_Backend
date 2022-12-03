using ITS.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITS.Domain.Entities.Contact
{
    [Table("Contact")]
    public class ContactDataModel : BaseEntity
    {
        public Guid Id { get; set; }
        public int ContactTypeCode { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int? CompanyId { get; set; }
        public bool IsCompany { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public Guid SiteCutomerId { get; set; }

        public virtual List<ContactAddressDataModel> ContactAddresses{ get; set; }
        public virtual List<ContactMailDataModel> ContactMails { get; set; }
        public virtual List<ContactPhoneDataModel> ContactPhones { get; set; }
        public virtual List<ContactTagDataModel> ContactTags { get; set; }
        public virtual List<ContactWebLinkDataModel> ContactWebLinks { get; set; }
    }
}
