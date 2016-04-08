using App.DAL.Entities.Blog;
using App.DTO.Models.Blog;
using EmitMapper;
using EmitMapper.MappingConfiguration;

namespace App.DAL.Mappers
{
    public static class BlogMappers
    {
        public static readonly ObjectsMapper<BlogEntity, BlogModel> EntityRideToModelMapper = ObjectMapperManager.DefaultInstance.GetMapper<BlogEntity, BlogModel>(new DefaultMapConfig());
    }
}
