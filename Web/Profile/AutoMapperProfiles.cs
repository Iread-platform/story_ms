using iread_story.DataAccess.Data.Entity;
using iread_story.Web.DTO.Page;
using iread_story.Web.DTO.Story;
using iread_story.Web.DTO.Language;

using System.Globalization;

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
            CreateMap<Story, SearchedStoryDto>().ReverseMap();
            CreateMap<Story, SearchedStoryByLevelDto>().ReverseMap();
            CreateMap<Story, ReadStoryDto>()
            .ForMember(dest =>
            dest.PagesCount,
            opt => opt.MapFrom(src => src.Pages == null ? 0 : src.Pages.Count));


            //Page Mapper
            CreateMap<Page, PageDto>().ReverseMap();
            CreateMap<Page, PageCreateDto>().ReverseMap();
            CreateMap<Page, PageUpdateDto>().ReverseMap();
            CreateMap<Page, PageWithoutStoryDto>().ReverseMap();

            //Language Mapper
            CreateMap<Language, LanguageAddDto>().ReverseMap();
            CreateMap<Language, LanguageGetDto>().ReverseMap();
            CreateMap<CultureInfo, LanguageGetDto>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NativeName)).ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.TwoLetterISOLanguageName)).ReverseMap();
            CreateMap<CultureInfo, Language>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NativeName)).ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.TwoLetterISOLanguageName)).ReverseMap();
        }
    }
}