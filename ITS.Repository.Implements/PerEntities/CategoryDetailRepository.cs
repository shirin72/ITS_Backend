using ITS.Domain.Entities.Category;
using ITS.Repository.Implements.Base;
using ITS.Repository.Implements.Context;
using ITS.Repository.Interface.PerEntities;

namespace ITS.Repository.Implements.PerEntities
{
    public class CategoryDetailRepository : RepositoryBase<CategoryDetailDataModel>, ICategoryDetailRepository
    {
        public CategoryDetailRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}