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

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public int StoryLevel { get; set; }

        public string Writer { get; set; }

        public int CoverId { get; set; }

        public int AudioId { get; set; }

        public Nullable<int> LanguageId { get; set; }
        public Language Language { get; set; }

        [Required]
        public string ManagerId { get; set; }

        public string Color { get; set; }

        public List<Page> Pages { get; set; }
    }
}