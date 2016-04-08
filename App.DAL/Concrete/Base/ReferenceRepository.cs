using System.Linq;
using App.DAL.Abstract.Base;
using App.DAL.Entities.Base;
using App.DTO.Models.Base;

namespace App.DAL.Concrete.Base
{
    public class ReferenceRepository : BaseRepository, IReferenceRepository
    {
        #region Map

        public static ReferenceModel MapToModel(ReferenceEntity x)
        {
            var model = new ReferenceModel
            {
                Id = x.Id,
                IsActive = x.IsActive,
                CategoryId = x.CategoryId,
                Key = x.Key,
                Value = x.Value,
                ValueInt = x.ValueInt
            };

            return model;
        }

        public IQueryable<ReferenceModel> GetBy()
        {
            return Context.Reference.Select(x => new ReferenceModel
            {
                Id = x.Id,
                IsActive = x.IsActive,
                CategoryId = x.CategoryId,
                Key = x.Key,
                Value = x.Value,
                ValueInt = x.ValueInt
            });
        }

        #endregion

        #region Read

        public ReferenceModel GetById(int id)
        {
            return GetBy().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<ReferenceModel> GetByCategoryId(int categoryId)
        {
            return GetBy().Where(x => x.IsActive && x.CategoryId == categoryId);
        }

        #endregion
    }
}
