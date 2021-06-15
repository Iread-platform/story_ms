using System.ComponentModel.DataAnnotations;

namespace iread_story.Web.DTO.Tag
{
    public class TagWithIdDto:TagDto
    {
        [Required]
        public int Id { get; set; }
    }
}