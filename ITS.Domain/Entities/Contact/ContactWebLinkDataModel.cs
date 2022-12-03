using ITS.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITS.Domain.Entities.Contact
{
    [Table("ContactWebLink")]
    public class ContactWebLinkDataModel : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public string Address { get; set; }
        public int AddressTypeCode { get; set; }
        [ForeignKey("ContactId")]
        public ContactDataModel Contact { get; set; }
    }
}
