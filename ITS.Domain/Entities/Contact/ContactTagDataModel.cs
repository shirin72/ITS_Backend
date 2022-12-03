using ITS.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITS.Domain.Entities.Contact
{
    [Table("ContactTag")]
    public class ContactTagDataModel : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        public int TagId { get; set; }
        [ForeignKey("ContactId")]
        public ContactDataModel Contact { get; set; }

    }
}
