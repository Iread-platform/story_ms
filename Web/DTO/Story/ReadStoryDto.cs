using System.Collections.Generic;
using iread_story.Web.DTO.Page;

namespace iread_story.Web.DTO.Story
{
    public class ReadStoryDto : GenericStoryDto
    {
        public string Title { set; get; }
        public int PagesCount { get; set; }

    }
}