using ITS.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITS.Domain.Entities.SiteCustomer
{
    [Table("SiteCustomerContract")]
    public class SiteCustomerContractDataModel: BaseEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// شناسه شرکت طرف قرارداد
        /// </summary>
        public int SiteCustomerId { get; set; }
        /// <summary>
        /// تاریخ شروع قرارداد
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// تاریخ پایان قرارداد
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// تعداد کاربران مجاز
        /// </summary>
        public int NumberOfAllowedUsers { get; set; }
        /// <summary>
        /// امکان استفاده از ماژول CRM
        /// </summary>
        public bool CRM { get; set; }
        /// <summary>
        /// امکان استفاده از ماژول Sale
        /// </summary>
        public bool Sale { get; set; }
        /// <summary>
        /// امکان استفاده ازماژول Operation
        /// </summary>
        public bool Operation { get; set; }
        /// <summary>
        /// امکان استفاده ازماژول  Accounting
        /// </summary>
        public bool Accounting { get; set; }
        /// <summary>
        /// مبلغ پرداختی
        /// </summary>
        public int PayedPrice { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
    }
}
