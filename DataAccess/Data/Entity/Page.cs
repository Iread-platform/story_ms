using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using iread_story.Web.Util;

namespace iread_story.DataAccess.Data.Entity
{
    [Table("Pages")]
    public class Page
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int PageId { get; set; }

        [Required(ErrorMessage = ErrorMessages.STORY_ID_REQUIRED)]
        [Range(1, int.MaxValue, ErrorMessage = ErrorMessages.INVALID_STORY_ID_VALUE)]
        public int StoryId { get; set; }
        public Story Story { get; set; }
        
        public string Content { get; set; }
    }
}