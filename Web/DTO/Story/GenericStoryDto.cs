using iread_story.Web.DTO.Category;
using iread_story.Web.DTO.Review;

namespace iread_story.Web.DTO.Story
{
    public class GenericStoryDto
    {

        public int StoryId { get; set; }
        public InnerCategoryDto Category { get; set; }
        public AttachmentDTO StoryCover { get; set; }
        public StoryReview Rating { get; set; }


    }
}