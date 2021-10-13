using System.ComponentModel.DataAnnotations;

namespace iread_story.Web.DTO.Story
{
    public class CreateStoryTitleDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }
        public int LanguageId { get; set; }
    }
}