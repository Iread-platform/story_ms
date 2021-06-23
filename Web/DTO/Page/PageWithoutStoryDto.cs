using System.ComponentModel.DataAnnotations;
using iread_story.Web.Util;

namespace iread_story.Web.DTO.Page
{
    public class PageWithoutStoryDto
    {
        [Required(ErrorMessage = ErrorMessages.PAGE_ID_REQUIRED)]
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.INVALID_Page_ID_VALUE)]
        public int PageId { get; set; }
        
        [Required(ErrorMessage = ErrorMessages.PAGE_CONTENT_REQUIRED)]
        public string Content { get; set; }
    }
}