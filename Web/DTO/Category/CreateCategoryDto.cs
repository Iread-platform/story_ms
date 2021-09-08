using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iread_story.Web.DTO.Tag;
using iread_story.Web.Util;

namespace iread_story.Web.DTO.Category
{
    public class CreateStoryCategoryDto
    {
        [Required]
        public Nullable<int> CategoryId { get; set; }

        [Required(ErrorMessage = ErrorMessages.STORY_ID_REQUIRED)]
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.INVALID_STORY_ID_VALUE)]
        public int StoryId { get; set; }
    }
}