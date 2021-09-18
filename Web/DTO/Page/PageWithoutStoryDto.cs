using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using iread_story.Web.Dto.Interaction;
using iread_story.Web.Util;

namespace iread_story.Web.DTO.Page
{
    public class PageWithoutStoryDto
    {
        [Required(ErrorMessage = ErrorMessages.PAGE_ID_REQUIRED)]
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.INVALID_PAGE_ID_VALUE)]
        public int PageId { get; set; }

        public string Content { get; set; }
        public string Words { get; set; }
        public List<HighLightDto> HighLights { get; set; }
        public List<CommentDto> Comments { get; set; }

    }
}