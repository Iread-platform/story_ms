using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iread_story.Web.DTO.Tag;
using iread_story.Web.Util;

namespace iread_story.Web.DTO.Story
{
    public class CreateStoryTagsDto
    {
        [Required]
        [NotEmpty(ErrorMessage = "KeyWords must have at least one element.")]
        public List<CreateTagDto> KeyWords { get; set; }
        
        [Required(ErrorMessage = ErrorMessages.STORY_ID_REQUIRED)]
        [Range(1,int.MaxValue,ErrorMessage = ErrorMessages.INVALID_STORY_ID_VALUE)]
        public int StoryId { get; set; }
    }
}