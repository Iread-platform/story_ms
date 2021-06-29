using iread_story.Web.DTO.Story;

namespace iread_story.Web.DTO.Page
{
    public class PageDto:PageWithoutStoryDto
    {
        
        public ViewStoryDto Story { get; set; }
    }
}