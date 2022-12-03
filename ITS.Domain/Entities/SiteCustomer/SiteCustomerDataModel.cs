using ITS.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITS.Domain.Entities.SiteCustomer
{
    [Table("SiteCustomer")]
    public class SiteCustomerDataModel:BaseEntity
    {
        public Guid Id { get; set; }
        /// <summary>
        /// نام شرکت
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// شماره ثبت
        /// </summary>
        public string RegisterNumber { get; set; }
        /// <summary>
        /// شناسه کشور
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// شناسه استان
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// وب سایت
        /// </summary>
        public string WebSite { get; set; }
        /// <summary>
        /// ایمیل
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// تلفن
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// تلفن همراه
        /// </summary>
        public string MobileNumber { get; set; }
        /// <summary>
        /// شناسه لوگو شرکت در پایگاه داده
        /// </summary>
        public Guid? LogoId { get; set; }

    }
}
