using AutoMapper;
using ITS.Commands.Modules.Category;
using ITS.Domain.Entities.Category;
using ITS.QueryModel.Modules.Category;

namespace ITS.Service.Implements.Mapper
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CreateCategoryCommand, CategoryDataModel>();
            CreateMap<CategoryDataModel, CategoryDto>();
        }
    }
}