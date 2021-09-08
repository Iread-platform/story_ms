using System.Collections.Generic;
using iread_story.Web.DTO.Category;
using iread_story.Web.DTO.Page;

namespace iread_story.Web.DTO.Story
{
    public class ListenStoryDto
    {
        public AttachmentDTO Audio { get; set; }
        public int PagesCount { get; set; }
        public List<PageWithoutStoryDto> Pages { get; set; }
        public InnerCategoryDto Category { get; set; }

    }
}