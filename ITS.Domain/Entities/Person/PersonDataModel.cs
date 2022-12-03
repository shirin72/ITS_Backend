using ITS.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITS.Domain.Entities.Person
{
    [Table("Person")]   
    public class PersonDataModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Family is required")]
        [StringLength(60, ErrorMessage = "Family can't be longer than 60 characters")]
        public string Family { get; set; }

        [Required(ErrorMessage = "Birthdate of birth is required")]
        public DateTime Birthdate { get; set; }
    }
}