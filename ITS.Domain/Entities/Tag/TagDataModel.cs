using ITS.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITS.Domain.Entities.Tag
{
    [Table("Tag")]
    public class TagDataModel : BaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tag Title is required")]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
    }
}
