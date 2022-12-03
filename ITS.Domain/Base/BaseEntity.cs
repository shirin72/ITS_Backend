using System;
using System.Collections.Generic;
using System.Text;

namespace ITS.Domain.Base
{
    public class BaseEntity
    {
        /// <summary>
        /// وضعیت نمایش روی سایت
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// کاربر ایجاد کننده
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// تاریخ ایجاد
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// کاربر تغییر دهنده
        /// </summary>
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// تاریخ آخرین تغییر
        /// </summary>
        public DateTime? LastModified { get; set; }
        /// <summary>
        /// حذف شده
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
