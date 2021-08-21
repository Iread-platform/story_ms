using iread_story.DataAccess.Data.Entity;
using iread_story.Web.DTO.Page;
using iread_story.Web.DTO.Story;

namespace iread_story.Web.Profile
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            //Story Mapper
            CreateMap<Story, StoryDto>().ReverseMap();
            CreateMap<Story, ViewStoryDto>().ReverseMap();
            CreateMap<Story, CreateStoryTitleDto>().ReverseMap();
            CreateMap<Story, CreateStoryCoverDto>().ReverseMap();
            CreateMap<Story, CreateStoryAudioDto>().ReverseMap();
            CreateMap<Story, CreateStoryTagsDto>().ReverseMap();
            CreateMap<Story, UpdateStoryDto>().ReverseMap();

            //Page Mapper
            CreateMap<Page, PageDto>().ReverseMap();
            CreateMap<Page, PageCreateDto>().ReverseMap();
            CreateMap<Page, PageUpdateDto>().ReverseMap();
            CreateMap<Page, PageWithoutStoryDto>().ReverseMap();

        }
    }
}