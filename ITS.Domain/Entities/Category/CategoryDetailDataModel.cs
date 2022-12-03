using ITS.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITS.Domain.Entities.Category
{
    [Table("CategoryDetail")]
    public class CategoryDetailDataModel: BaseEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// کد دسته بندی
        /// </summary>
        [Required(ErrorMessage = "Category is required")]
        public int CategoryCode { get; set; }
        /// <summary>
        /// کد یکتا در دسته بندی
        /// </summary>
        [Required(ErrorMessage = "Code is required")]
        public int Code { get; set; }

        /// <summary>
        /// کلید=> نام فنی یکتا در دسته بندی
        /// </summary>
        [Required(ErrorMessage = "Key is required")]
        public string Key { get; set; }
        /// <summary>
        /// نام 
        /// </summary>
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string TitleFa { get; set; }
        /// <summary>
        /// مقدار 
        /// </summary>
        [Required(ErrorMessage = "Value is required")]
        public string Value { get; set; }

        public int SiteCustomerId { get; set; }
    }
}
