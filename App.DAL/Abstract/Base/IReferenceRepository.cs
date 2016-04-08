using System.Linq;
using App.DTO.Models.Base;

namespace App.DAL.Abstract.Base
{
    public interface IReferenceRepository
    {
        IQueryable<ReferenceModel> GetBy();

        ReferenceModel GetById(int id);
        IQueryable<ReferenceModel> GetByCategoryId(int categoryId);
    }
}
