using System;
using iread_story.Web.DTO.Category;
using iread_story.Web.DTO.Review;

namespace iread_story.Web.DTO.Story
{
    public class GenericStoryDto
    {

        public int StoryId { get; set; }
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }
        public string ManagerId { get; set; }
        public InnerCategoryDto Category { get; set; }
        public AttachmentDTO StoryCover { get; set; }
        public StoryAverageRate Rating { get; set; }


    }
}