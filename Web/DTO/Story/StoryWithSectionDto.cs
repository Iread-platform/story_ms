using System.Collections.Generic;
using iread_story.Web.Util;

namespace iread_story.Web.DTO.Story
{
    public class StoryWithSectionDto
    {
        public string SectionTitle { get; set; }
        public List<SearchedStoryByLevelDto> Stories { get; set; }
    }
}