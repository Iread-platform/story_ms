using System;
using System.ComponentModel.DataAnnotations;
using iread_story.Web.Util;

namespace iread_story.Web.DTO.Tag
{
    public class TagDto
    {
        [Required(ErrorMessage = ErrorMessages.TAG_TITLE_REQUIRED)] 
        public String Title { get; set; }
    }
}