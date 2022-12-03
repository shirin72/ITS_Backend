using ITS.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITS.Domain.Entities.Contact
{
    [Table("ContactPhone")]
    public class ContactPhoneDataModel : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public string Phone { get; set; }
        public int? PhoneTypeCode { get; set; }
        [ForeignKey("ContactId")]
        public ContactDataModel Contact { get; set; }
    }
}
