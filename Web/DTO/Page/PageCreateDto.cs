using System.ComponentModel.DataAnnotations;
using iread_story.Web.Util;

namespace iread_story.Web.DTO.Page
{
    public class PageCreateDto
    {
        [Required(ErrorMessage = ErrorMessages.STORY_ID_REQUIRED)]
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.INVALID_STORY_ID_VALUE)]
        public int StoryId { get; set; }

        public string Content { get; set; }
    }
}