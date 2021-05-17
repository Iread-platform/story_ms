using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iread_story.DataAccess.Data.Entity
{
    [Table("Stories")]
    public class Story
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int StoryId { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }
        
    }
}
