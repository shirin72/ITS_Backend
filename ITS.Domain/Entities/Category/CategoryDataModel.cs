using ITS.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ITS.Domain.Entities.Category
{
    [Table("Category")]
    public class CategoryDataModel: BaseEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// کد یکتا
        /// </summary>
        [Required(ErrorMessage = "Code is required")]
        public int Code { get; set; }
        /// <summary>
        /// کلید نام فنی یکتا
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// نام
        /// </summary>
        public string Title { get; set; }
        public string TitleFa { get; set; }
        public bool IsSystematic { get; set; }
    }
}
