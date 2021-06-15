using iread_story.DataAccess.Data.Entity;
using iread_story.Web.DTO.Story;

namespace iread_story.Web.Profile
{
    public class AutoMapperProfile:AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Story, StoryDto>().ReverseMap();
        }
    }
}