using System.ComponentModel.DataAnnotations;
using iread_story.Web.Util;
using Microsoft.AspNetCore.Http;

namespace iread_story.Web.DTO.Story
{
    public class CreateStoryCoverDto
    {
        [Required]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] {
            ".jpeg",".png",".gif",".tiff",".psd",".pdf",".eps",".ai",".indd",".raw",
            ".JPEG",".PNG",".GIF",".TIFF",".PSD",".PDF",".EPS",".AI",".INDD",".RAW"},
            ErrorMessage = ErrorMessages.AUDIO_FILE_EXTENSION_NOT_ALLOWED)]
        public IFormFile StoryCover { get; set; }

        [Required(ErrorMessage = ErrorMessages.STORY_ID_REQUIRED)]
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.INVALID_STORY_ID_VALUE)]
        public int StoryId { get; set; }

        [Required(ErrorMessage = ErrorMessages.COLOR_REQUIRED)]
        public string Color { get; set; }

    }
}