using System.ComponentModel.DataAnnotations;
using iread_story.Web.Util;
using Microsoft.AspNetCore.Http;

namespace iread_story.Web.DTO.Story
{
    public class CreateStoryAudioDto
    {
        [Required]
        [DataType(DataType.Upload)]
        [AllowedExtensions(new string[] { ".mp4",".aac",".wma",".wav",".m4a",".flac",".mp3",
            ".MP4",".AAC",".WMA",".WAV",".M4A",".FLAC",".MP3"}, ErrorMessage = ErrorMessages.AUDIO_FILE_EXTENSION_NOT_ALLOWED)]
        public IFormFile StoryAudio { get; set; }

        [Required(ErrorMessage = ErrorMessages.STORY_ID_REQUIRED)]
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.INVALID_STORY_ID_VALUE)]
        public int StoryId { get; set; }
    }
}