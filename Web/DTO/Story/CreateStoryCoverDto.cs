using System.ComponentModel.DataAnnotations;
using iread_story.Web.Util;
using Microsoft.AspNetCore.Http;

namespace iread_story.Web.DTO.Story
{
    public class CreateStoryCoverDto
    {
        [Required]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".png",".jpg"},ErrorMessage = ErrorMessages.AUDIO_FILE_EXTENSION_NOT_ALLOWED)]
        public IFormFile StoryCover { get; set; }
        
        [Required(ErrorMessage = ErrorMessages.STORY_ID_REQUIRED)]
        [Range(1,int.MaxValue,ErrorMessage = ErrorMessages.INVALID_STORY_ID_VALUE)]
        public int StoryId { get; set; }
    }
}