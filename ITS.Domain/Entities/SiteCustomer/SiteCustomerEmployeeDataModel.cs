using ITS.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITS.Domain.Entities.SiteCustomer
{
    [Table("SiteCustomerEmployee")]
    public class SiteCustomerEmployeeDataModel : BaseEntity
    {
        public int Id { get; set; }
        public Guid SiteCustomerId { get; set; }
        [ForeignKey("SiteCustomerId")]
        public SiteCustomerDataModel SiteCustomer { get; set; }
        public string JoinCode { get; set; }
        public bool IsJoined { get; set; }
        public bool IsLeft { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LeftDate { get; set; }
    }
}
