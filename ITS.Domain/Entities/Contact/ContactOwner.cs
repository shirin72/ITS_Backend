using ITS.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.Domain.Entities.Contact
{
    [Table("ContactOwner")]
    public class ContactOwnerDataModel : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid ContactId { get; set; }
        [ForeignKey("ContactId")]
        public ContactDataModel Contact { get; set; }
        public string OwnerEmail { get; set; }
        public DateTime OwnershipStartDate { get; set; }
        public DateTime OwnershipEndDate { get; set; }
    }
}
