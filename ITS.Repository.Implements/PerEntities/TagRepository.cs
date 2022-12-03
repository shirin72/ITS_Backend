using ITS.Domain.Entities.Tag;
using ITS.Repository.Implements.Base;
using ITS.Repository.Implements.Context;
using ITS.Repository.Interface.PerEntities;

namespace ITS.Repository.Implements.PerEntities
{
    public class TagRepository : RepositoryBase<TagDataModel>, ITagRepository
    {
        public TagRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}