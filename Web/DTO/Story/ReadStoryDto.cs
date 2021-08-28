using System.Collections.Generic;
using iread_story.Web.DTO.Page;

namespace iread_story.Web.DTO.Story
{
    public class ReadStoryDto
    {

        public int StoryId { get; set; }
        public AttachmentDTO StoryCover { get; set; }
        public string Title { set; get; }
        public int PagesCount { get; set; }

    }
}