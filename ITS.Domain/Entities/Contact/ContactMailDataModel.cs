using ITS.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITS.Domain.Entities.Contact
{
    [Table("ContactMail")]
    public class ContactMailDataModel: BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public string MailAddress { get; set; }
        public int? MailTypeCode { get; set; }
        [ForeignKey("ContactId")]
        public ContactDataModel Contact { get; set; }
    }
}
