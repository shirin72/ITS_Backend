using AutoMapper;
using ITS.Commands.Modules.Person;
using ITS.Domain.Entities.Person;
using ITS.QueryModel.Modules.Person;

namespace ITS.Service.Implements.Mapper
{
    public class PersonMapping : Profile
    {
        public PersonMapping()
        {
            CreateMap<CreatePersonCommand, PersonDataModel>().ReverseMap();
            //CreateMap<CreatePersonCommand, PersonDataModel>();
            //CreateMap<PersonDataModel, PersonDto>();
        }
    }
}