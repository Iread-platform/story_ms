using iread_story.DataAccess.Data.Entity;
using iread_story.Web.DTO.Page;
using iread_story.Web.DTO.Story;

namespace iread_story.Web.Profile
{
    public class AutoMapperProfile:AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Story, StoryDto>().ReverseMap();
            CreateMap<Story, ViewStoryDto>().ReverseMap();
            
            //pages
            CreateMap<Page, PageDto>().ReverseMap();
            CreateMap<Page, PageCreateDto>().ReverseMap();
            CreateMap<Page, PageUpdateDto>().ReverseMap();
            CreateMap<Page, PageWithoutStoryDto>().ReverseMap();
            
        }
    }
}