using System;
using System.Collections.Generic;
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

        [Required]
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }
          
        [NotMapped]
        public string Description { get; set; }
        
        public int StoryLevel { get; set; }
        
        [Required]
        public string Writer { get; set; }
        
        // [NotMapped]
        // public ICollection<string> KeyWords { get; set; }
        
        public int Rating { get; set; }
    }
}
