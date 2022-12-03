using ITS.Domain.Entities.Category;
using ITS.Repository.Implements.Base;
using ITS.Repository.Implements.Context;
using ITS.Repository.Interface.PerEntities;

namespace ITS.Repository.Implements.PerEntities
{
    public class CategoryRepository : RepositoryBase<CategoryDataModel>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}