using System;

namespace ITS.Commands.Modules.Person
{
    public class UpdatePersonCommand
    {
        public Guid Id { get; set; }    
        public string Name { get; set; }
        public string Family { get; set; }
        public DateTime Birthdate { get; set; }
    }
}