using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITS.Commands.Modules.Tag;
using ITS.Domain.Entities.Tag;
using ITS.Infrastructure.Enums;
using ITS.Infrastructure.Exceptions;
using ITS.Infrastructure.Helpers;
using ITS.QueryModel.Modules.Tag;
using ITS.Repository.Interface.Base;
using ITS.Service.Interface.Helper;
using ITS.Service.Interface.Modules.Tag;

namespace ITS.Service.Implements.Modules.Tag
{
    public class TagService : ITagService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public TagService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        /// <summary>
        /// سرویس ثبت برچسب
        /// </summary>
        /// <returns></returns>
        public async Task<RetrieveObject> CreateTag(CreateTagCommand command)
        {
            var tag = new TagDataModel()
            {
                Title = command.Title,
                Description = command.Description,
                IsPublic = command.IsPublic
            };
            _repositoryWrapper.Tag.Create(tag);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return new RetrieveObject()
            {
                Id = tag.Id,
                Message = OperationHelper.BooleanToOperationResult(result).GetDescription()
            };
        }

        /// <summary>
        /// سرویس ویرایش برچسب
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<string> UpdateTag(UpdateTagCommand command)
        {
            var tag = _repositoryWrapper.Tag.FindByCondition(i => i.Id == command.Id && i.IsDeleted != true).FirstOrDefault();
            if (tag == null) throw new ServiceException(ErrorServiceMessage.TagNotFound.GetDescription());
            tag.Description = command.Description;
            tag.IsPublic = command.IsPublic;
            tag.Title = command.Title;
            _repositoryWrapper.Tag.Update(tag);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(result).GetDescription();
        }

        /// <summary>
        /// سرویس حذف برچسب
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        public async Task<string> DeleteTag(int id)
        {
            var tag = _repositoryWrapper.Tag.FindByCondition(i => i.Id == id && i.IsDeleted != true).FirstOrDefault();
            if (tag == null) throw new ServiceException(ErrorServiceMessage.TagNotFound.GetDescription());
            tag.IsDeleted = true;
            _repositoryWrapper.Tag.Delete(tag);
            var result = await _repositoryWrapper.SaveChangesAsync() > 0;
            return OperationHelper.BooleanToOperationResult(result).GetDescription();
        }

        /// <summary>
        /// سرویس دریافت برچسب با شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TagDto> GetTagById(int id)
        {
            var tag = _repositoryWrapper.Tag.FindByCondition(i => i.Id == id && i.IsDeleted != true).FirstOrDefault();
            if (tag == null) throw new ServiceException(ErrorServiceMessage.TagNotFound.GetDescription());
            var dto = new TagDto()
            {
                Id = tag.Id,
                Description = tag.Description,
                IsPublic = tag.IsPublic,
                Title = tag.Title
            };
            return await Task.FromResult(dto);
        }

        /// <summary>
        /// سرویس دریافت برچسب ها
        /// </summary>  
        /// <returns></returns>
        public async Task<IEnumerable<TagDto>> GetAllTag()
        {
            var tag = _repositoryWrapper.Tag.FindByCondition(i => i.IsDeleted != true);
            var dto = tag.Select(i => new TagDto()
            {
                Id = i.Id,
                Description = i.Description,
                IsPublic = i.IsPublic,
                Title = i.Title
            }).ToList();
            return await Task.FromResult(dto);
        }
    }
}