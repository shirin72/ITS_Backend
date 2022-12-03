using System;

namespace ITS.QueryModel.Modules.Person
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public DateTime Birthdate { get; set; }

    }
}